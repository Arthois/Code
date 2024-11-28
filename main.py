# Before running any code please ensure all dependencies are installed
# if not run commands in terminal:
# pip install tensorflow
# pip install opencv-python
# pip install numpy

import os
import uuid
import time
import cv2
import tensorflow as tf
import keras
import albumentations as alb
import json
import numpy as np
from matplotlib import pyplot as plt
from tensorflow.keras.models import Model
from tensorflow.keras.layers import Input, Conv2D, Dense, GlobalMaxPooling2D
from tensorflow.keras.applications import VGG16
from tensorflow.keras.models import load_model


# Class that will be used later in the code
class Get_Face(Model):
    def __init__(self, eyetracker, **kwargs):  # Initialisation
        super().__init__(**kwargs)
        self.model = eyetracker

    def compile(self, opt, classloss, localizationloss, **kwargs):  # Code to compile the class
        super().compile(**kwargs)
        self.closs = classloss
        self.lloss = localizationloss
        self.opt = opt

    def train_step(self, batch, **kwargs):  # Defining the training steps like gradient loss and localisation loss
        X, y = batch

        with tf.GradientTape() as tape:
            classes, coords = self.model(X, training=True)

            batch_classloss = self.closs(y[0], classes)
            batch_localizationloss = self.lloss(tf.cast(y[1], tf.float32), coords)

            total_loss = batch_localizationloss + 0.5 * batch_classloss

            grad = tape.gradient(total_loss, self.model.trainable_variables)

        self.opt.apply_gradients(zip(grad, self.model.trainable_variables))

        return {"total_loss": total_loss, "class_loss": batch_classloss, "regress_loss": batch_localizationloss}

    def test_step(self, batch, **kwargs):  # Same as train test just in this case for testing
        X, y = batch

        classes, coords = self.model(X, training=False)

        batch_classloss = self.closs(y[0], classes)
        batch_localizationloss = self.lloss(tf.cast(y[1], tf.float32), coords)
        total_loss = batch_localizationloss + 0.5 * batch_classloss

        return {"total_loss": total_loss, "class_loss": batch_classloss, "regress_loss": batch_localizationloss}

    def call(self, X, **kwargs):
        return self.model(X, **kwargs)


def localization_loss(y_true, yhat):  # Defining localisation loss
    delta_coord = tf.reduce_sum(tf.square(y_true[:, :2] - yhat[:, :2]))

    h_true = y_true[:, 3] - y_true[:, 1]
    w_true = y_true[:, 2] - y_true[:, 0]

    h_pred = yhat[:, 3] - yhat[:, 1]
    w_pred = yhat[:, 2] - yhat[:, 0]

    delta_size = tf.reduce_sum(tf.square(w_true - w_pred) + tf.square(h_true - h_pred))

    return delta_coord + delta_size


def load_image(x):  # Loads up images
    byte_img = tf.io.read_file(x)
    img = tf.io.decode_jpeg(byte_img)
    return img


def build_model(num_anchors=9, num_classes=1):  # Set num_anchors to the desired number of anchor boxes
    input_layer = Input(shape=(120, 120, 3))

    vgg = VGG16(include_top=False)(input_layer)

    # Classification Model
    f1 = GlobalMaxPooling2D()(vgg)
    class1 = Dense(2048, activation='relu')(f1)
    class2 = Dense(num_anchors * num_classes, activation='sigmoid')(class1)

    # Bounding box model
    f2 = GlobalMaxPooling2D()(vgg)
    regress1 = Dense(2048, activation='relu')(f2)
    regress2 = Dense(4 * num_anchors, activation='sigmoid')(regress1)

    facetracker = Model(inputs=input_layer, outputs=[class2, regress2])
    return facetracker


def non_max_suppression(boxes, scores, iou_threshold=0.5):  # Defining non max suppression
    # Ensure boxes is 2-D
    boxes = tf.reshape(boxes, (-1, 4))

    selected_indices = tf.image.non_max_suppression(boxes, scores, max_output_size=len(boxes),
                                                    iou_threshold=iou_threshold)
    return selected_indices


def load_labels(label_path):  # Loads up the labels created using label me
    with open(label_path.numpy(), 'r', encoding="utf-8") as f:
        label = json.load(f)

    return [label['class']], label['bbox']


def train_model():
    train_images = tf.data.Dataset.list_files('aug_data\\train\\images\\*.jpg', shuffle=False)
    train_images = train_images.map(load_image)
    train_images = train_images.map(lambda x: tf.image.resize(x, (120, 120)))
    train_images = train_images.map(lambda x: x / 255)

    test_images = tf.data.Dataset.list_files('aug_data\\test\\images\\*.jpg', shuffle=False)
    test_images = test_images.map(load_image)
    test_images = test_images.map(lambda x: tf.image.resize(x, (120, 120)))
    test_images = test_images.map(lambda x: x / 255)

    val_images = tf.data.Dataset.list_files('aug_data\\val\\images\\*.jpg', shuffle=False)
    val_images = val_images.map(load_image)
    val_images = val_images.map(lambda x: tf.image.resize(x, (120, 120)))
    val_images = val_images.map(lambda x: x / 255)

    train_labels = tf.data.Dataset.list_files('aug_data\\train\\labels\\*.json', shuffle=False)
    train_labels = train_labels.map(lambda x: tf.py_function(load_labels, [x], [tf.uint8, tf.float16]))

    test_labels = tf.data.Dataset.list_files('aug_data\\test\\labels\\*.json', shuffle=False)
    test_labels = test_labels.map(lambda x: tf.py_function(load_labels, [x], [tf.uint8, tf.float16]))

    val_labels = tf.data.Dataset.list_files('aug_data\\val\\labels\\*.json', shuffle=False)
    val_labels = val_labels.map(lambda x: tf.py_function(load_labels, [x], [tf.uint8, tf.float16]))

    train = tf.data.Dataset.zip((train_images, train_labels))
    train = train.shuffle(5000)
    train = train.batch(8)
    train = train.prefetch(4)

    test = tf.data.Dataset.zip((test_images, test_labels))
    test = test.shuffle(1300)
    test = test.batch(8)
    test = test.prefetch(4)

    val = tf.data.Dataset.zip((val_images, val_labels))
    val = val.shuffle(1000)
    val = val.batch(8)
    val = val.prefetch(4)

    fig, ax = plt.subplots(ncols=4, figsize=(20, 20))

    data_samples = train.as_numpy_iterator()
    res = data_samples.next()

    for idx in range(4):
        sample_image = (res[0][idx] * 255).astype(np.uint8)
        sample_coords = res[1][1][idx]

        sample_image_bgr = cv2.cvtColor(sample_image, cv2.COLOR_RGB2BGR)

        # Assuming sample_coords has shape (4,)
        coords_int = np.round(np.multiply(sample_coords, [120, 120, 120, 120])).astype(int)

        cv2.rectangle(sample_image_bgr,
                      tuple(coords_int[:2]),
                      tuple(coords_int[2:]),
                      (255, 0, 0), 2)

        sample_image_rgb = cv2.cvtColor(sample_image_bgr, cv2.COLOR_BGR2RGB)

        ax[idx].imshow(sample_image_rgb)

    plt.show()

    vgg = VGG16(include_top=False)
    vgg.summary()

    facetracker = build_model(num_anchors=9, num_classes=1)
    facetracker.summary()

    batches_per_epoch = len(train)
    lr_decay = (1. / 0.75 - 1) / batches_per_epoch

    opt = tf.keras.optimizers.Adam(learning_rate=0.0001)

    classloss = tf.keras.losses.BinaryCrossentropy()
    regressloss = localization_loss

    model = Get_Face(facetracker)
    model.compile(opt, classloss, regressloss)
    logdir = 'logs'
    tensorboard_callback = tf.keras.callbacks.TensorBoard(log_dir=logdir)

    hist = model.fit(train, epochs=10, validation_data=val, callbacks=[tensorboard_callback])

    fig, ax = plt.subplots(ncols=3, figsize=(20, 5))

    ax[0].plot(hist.history['total_loss'], color='teal', label='loss')
    ax[0].plot(hist.history['val_total_loss'], color='orange', label='val loss')
    ax[0].title.set_text('Loss')
    ax[0].legend()

    ax[1].plot(hist.history['class_loss'], color='teal', label='class loss')
    ax[1].plot(hist.history['val_class_loss'], color='orange', label='val class loss')
    ax[1].title.set_text('Classification Loss')
    ax[1].legend()

    ax[2].plot(hist.history['regress_loss'], color='teal', label='regress loss')
    ax[2].plot(hist.history['val_regress_loss'], color='orange', label='val regress loss')
    ax[2].title.set_text('Regression Loss')
    ax[2].legend()

    plt.show()

    test_data = test.as_numpy_iterator()
    test_sample = test_data.next()
    yhat = facetracker.predict(test_sample[0])

    # Apply NMS to get selected indices
    class_probabilities = yhat[0][0]
    box_predictions = yhat[1][0]
    selected_indices = non_max_suppression(box_predictions, class_probabilities)

    fig, ax = plt.subplots(ncols=4, figsize=(20, 20))

    for idx in range(4):
        sample_image = (res[0][idx] * 255).astype(np.uint8)
        sample_coords = res[1][1][idx]

        if selected_indices.numpy().tolist().count(idx) > 0:
            cv2.rectangle(sample_image,
                          tuple(np.multiply(sample_coords[:2], [120, 120]).astype(int)),
                          tuple(np.multiply(sample_coords[2:], [120, 120]).astype(int)),
                          (255, 0, 0), 2)

        ax[idx].imshow(sample_image)

    plt.show()

    facetracker.save('facetracker.h5')

    # Load the saved model
    facetracker = tf.keras.models.load_model(model_path)

    # Preprocess the input image
    resized = tf.image.resize(image, (120, 120))
    input_image = np.expand_dims(resized / 255, 0)

    # Make predictions using the loaded model
    predictions = facetracker.predict(input_image)

    # Extract class probabilities and box predictions
    class_probabilities = predictions[0][0]
    box_predictions = predictions[1][0]

    # Apply non-maximum suppression to get selected indices
    selected_indices = non_max_suppression(box_predictions, class_probabilities)

    # Get selected boxes
    selected_boxes = box_predictions[selected_indices]

    return selected_boxes


def load_model_and_predict(model_path, image):
    # Load the saved model
    facetracker = tf.keras.models.load_model(model_path)

    # Preprocess the input image
    resized = tf.image.resize(image, (120, 120))
    input_image = np.expand_dims(resized / 255, 0)

    # Make predictions using the loaded model
    predictions = facetracker.predict(input_image)

    # Extract class probabilities and box predictions
    class_probabilities = predictions[0][0]
    box_predictions = predictions[1][0]

    # Apply non-maximum suppression to get selected indices
    selected_indices = non_max_suppression(box_predictions, class_probabilities)

    # Get selected boxes
    selected_boxes = box_predictions[selected_indices]

    return selected_boxes


def run_inference(frame, facetracker):
    rgb = cv2.cvtColor(frame, cv2.COLOR_BGR2RGB)
    resized = tf.image.resize(rgb, (120, 120))
    yhat = facetracker.predict(np.expand_dims(resized / 255, 0))
    return yhat


def main():
    # # Path to the saved model
    # model_path = 'facetracker.h5'
    #
    # # Load the saved model
    # facetracker = tf.keras.models.load_model(model_path)
    #
    # # Open video capture (you can adjust the index based on your camera setup)
    # cap = cv2.VideoCapture(0)
    # while cap.isOpened():
    #     _, frame = cap.read()
    #     frame = frame[50:500, 50:500, :]
    #
    #     # Use the loaded facetracker model
    #     yhat = run_inference(frame, facetracker)
    #     class_probabilities = yhat[0][0]
    #     box_predictions = yhat[1][0]
    #
    #     # Apply NMS to get selected indices
    #     selected_indices = non_max_suppression(box_predictions, class_probabilities)
    #     selected_boxes = box_predictions[selected_indices]
    #
    #     # Draw rectangles for each detected face
    #     for coords in selected_boxes:
    #         coords = coords.numpy() if isinstance(coords, tf.Tensor) else coords
    #         coords = np.squeeze(coords)
    #
    #         if isinstance(coords, np.ndarray) and len(coords.shape) > 0:
    #             coords = coords * [450, 450]
    #             coords = coords.astype(int)
    #
    #             cv2.rectangle(frame,
    #                           (coords[0], coords[1]),
    #                           (coords[2], coords[3]),
    #                           (255, 0, 0), 2)
    #
    #     cv2.imshow('FaceTracker', frame)
    #
    #     if cv2.waitKey(1) & 0xFF == ord("q"):
    #         break
    #
    # cap.release()
    # cv2.destroyAllWindows()

    facetracker = load_model('facetracker.h5')

    cap = cv2.VideoCapture(0)
    while cap.isOpened():
        _, frame = cap.read()
        frame = frame[50:500, 50:500, :]

        rgb = cv2.cvtColor(frame, cv2.COLOR_BGR2RGB)
        resized = tf.image.resize(rgb, (120, 120))

        yhat = facetracker.predict(np.expand_dims(resized / 255, 0))
        sample_coords = yhat[1][0]

        if yhat[0] > 0.5:
            # Controls the main rectangle
            cv2.rectangle(frame,
                          tuple(np.multiply(sample_coords[:2], [450, 450]).astype(int)),
                          tuple(np.multiply(sample_coords[2:], [450, 450]).astype(int)),
                          (255, 0, 0), 2)
            # Controls the label rectangle
            cv2.rectangle(frame,
                          tuple(np.add(np.multiply(sample_coords[:2], [450, 450]).astype(int),
                                       [0, -30])),
                          tuple(np.add(np.multiply(sample_coords[:2], [450, 450]).astype(int),
                                       [80, 0])),
                          (255, 0, 0), -1)

            # Controls the text rendered
            cv2.putText(frame, 'face', tuple(np.add(np.multiply(sample_coords[:2], [450, 450]).astype(int),
                                                    [0, -5])),
                        cv2.FONT_HERSHEY_SIMPLEX, 1, (255, 255, 255), 2, cv2.LINE_AA)

        cv2.imshow('FaceTracker', frame)

        if cv2.waitKey(1) & 0xFF == ord("q"):
            break
    cap.release()
    cv2.destroyAllWindows()


if __name__ == "__main__":
    main()
