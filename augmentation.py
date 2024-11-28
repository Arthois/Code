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
from tensorflow.python.keras.models import Model
from tensorflow.python.keras.layers import Input, Conv2D, Dense, GlobalMaxPooling2D
from keras.applications import VGG16

# Constants

IMAGES_PATH = os.path.join('data', 'images')
num_images = 30


# Disables shuffle
# images = tf.data.Dataset.list_files('data/images/*.jpg', shuffle=False)

# Loads up the image
def load_image(x):
    byte_img = tf.io.read_file(x)
    img = tf.io.decode_jpeg(byte_img)
    return img


# This function helps with capturing training data
def capture():
    cap = cv2.VideoCapture(0)
    for imgnum in range(num_images):
        print("Collecting Image {}".format(imgnum))
        ret, frame = cap.read()
        imgname = os.path.join(IMAGES_PATH, f"{str(uuid.uuid1())}.jpg")
        cv2.imwrite(imgname, frame)
        cv2.imshow("frame", frame)
        time.sleep(0.5)

        if cv2.waitKey(1) & 0xFF == ord("q"):
            break
    cap.release()
    cv2.destroyAllWindows()


# Sorts out the lables
def sort_labels():
    for folder in ['train', 'test', 'val']:
        for file in os.listdir(os.path.join('data', folder, 'images')):

            filename = file.split('.')[0] + '.json'
            existing_filepath = os.path.join('data', 'labels', filename)
            if os.path.exists(existing_filepath):
                new_filepath = os.path.join('data', folder, 'labels', filename)
                os.replace(existing_filepath, new_filepath)


def augment_images(img, coords):
    augmentor = alb.Compose([alb.RandomCrop(width=450, height=450),
                             alb.HorizontalFlip(p=0.5),
                             alb.RandomBrightnessContrast(p=0.2),
                             alb.RandomGamma(p=0.2),
                             alb.RGBShift(p=0.2),
                             alb.VerticalFlip(p=0.5)],
                            bbox_params=alb.BboxParams(format='albumentations',
                                                       label_fields=['class_labels']))
    augmented = augmentor(image=img, bboxes=[coords], class_labels=['face'])
    cv2.rectangle(augmented['image'],
                  tuple(np.multiply(augmented['bboxes'][0][:2], [450, 450]).astype(int)),
                  tuple(np.multiply(augmented['bboxes'][0][2:], [450, 450]).astype(int)),
                  (255, 0, 0), 2)
    plt.imshow(augmented['image'])


def test_image():
    img = cv2.imread(os.path.join('data', 'train', 'images', '9d6f326d-cf1c-11ee-a936-00d861e39ce5.jpg'))
    with open(os.path.join('data', 'train', 'labels', '9d6f326d-cf1c-11ee-a936-00d861e39ce5.json'), 'r') as f:
        label = json.load(f)
        print(label)


def get_coords(label):
    coords = [0, 0, 0, 0]
    coords[0] = label['shapes'][0]['points'][0][0]
    coords[1] = label['shapes'][0]['points'][0][1]
    coords[2] = label['shapes'][0]['points'][1][0]
    coords[3] = label['shapes'][0]['points'][1][1]
    coords = list(np.divide(coords, [640, 480, 640, 480]))
    return coords


def get_label(img_path):
    label_path = os.path.join('data', 'train', 'labels', os.path.splitext(os.path.basename(img_path))[0] + '.json')
    with open(label_path, 'r') as f:
        label = json.load(f)
    return label


def augment_data():
    augmentor = alb.Compose([alb.RandomCrop(width=450, height=450),
                             alb.HorizontalFlip(p=0.5),
                             alb.RandomBrightnessContrast(p=0.2),
                             alb.RandomGamma(p=0.2),
                             alb.RGBShift(p=0.2),
                             alb.VerticalFlip(p=0.5)],
                            bbox_params=alb.BboxParams(format='albumentations',
                                                       label_fields=['class_labels']))
    for partition in ['train', 'test', 'val']:
        for image in os.listdir(os.path.join('data', partition, 'images')):
            img = cv2.imread(os.path.join('data', partition, 'images', image))

            coords = [0, 0, 0.00001, 0.00001]
            label_path = os.path.join('data', partition, 'labels', f'{image.split(".")[0]}.json')
            if os.path.exists(label_path):
                with open(label_path, 'r') as f:
                    label = json.load(f)

                coords[0] = label['shapes'][0]['points'][0][0]
                coords[1] = label['shapes'][0]['points'][0][1]
                coords[2] = label['shapes'][0]['points'][1][0]
                coords[3] = label['shapes'][0]['points'][1][1]
                coords = list(np.divide(coords, [640, 480, 640, 480]))

            try:
                for x in range(60):
                    augmented = augmentor(image=img, bboxes=[coords], class_labels=['face'])
                    cv2.imwrite(os.path.join('aug_data', partition, 'images', f'{image.split(".")[0]}.{x}.jpg'),
                                augmented['image'])

                    annotation = {}
                    annotation['image'] = image

                    if os.path.exists(label_path):
                        if len(augmented['bboxes']) == 0:
                            annotation['bbox'] = [0, 0, 0, 0]
                            annotation['class'] = 0
                        else:
                            annotation['bbox'] = augmented['bboxes'][0]
                            annotation['class'] = 1
                    else:
                        annotation['bbox'] = [0, 0, 0, 0]
                        annotation['class'] = 0

                    with open(os.path.join('aug_data', partition, 'labels', f'{image.split(".")[0]}.{x}.json'),
                              'w') as f:
                        json.dump(annotation, f)

            except Exception as e:
                print(e)


def load_labels(label_path):
    with open(label_path.numpy(), 'r', encoding="utf-8") as f:
        label = json.load(f)

    return [label['class']], label['bbox']


def images_labels_load():
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

    data_samples = train.as_numpy_iterator()
    res = data_samples.next()
    fig, ax = plt.subplots(ncols=4, figsize=(20, 20))
    for idx in range(4):
        sample_image = (res[0][idx] * 255).astype(np.uint8)
        sample_coords = res[1][1][idx]

        sample_image_bgr = cv2.cvtColor(sample_image, cv2.COLOR_RGB2BGR)

        coords_int = np.round(np.multiply(sample_coords.reshape(-1, 2), [120, 120])).astype(int)

        cv2.rectangle(sample_image_bgr,
                      tuple(coords_int[0]),
                      tuple(coords_int[1]),
                      (255, 0, 0), 2)

        sample_image_rgb = cv2.cvtColor(sample_image_bgr, cv2.COLOR_BGR2RGB)

        ax[idx].imshow(sample_image_rgb)
    plt.show()


def build_model():
    input_layer = Input(shape=(120, 120, 3))

    vgg = VGG16(include_top=False)(input_layer)

    # Classification Model
    f1 = GlobalMaxPooling2D()(vgg)
    class1 = Dense(2048, activation='relu')(f1)
    class2 = Dense(1, activation='sigmoid')(class1)

    # Bounding box model
    f2 = GlobalMaxPooling2D()(vgg)
    regress1 = Dense(2048, activation='relu')(f2)
    regress2 = Dense(4, activation='sigmoid')(regress1)

    facetracker = Model(inputs=input_layer, outputs=[class2, regress2])
    return facetracker

def main():
    # Capture images
    capture()

    # Test Images
    test_image()

    # Load and display captured images
    images = tf.data.Dataset.list_files('data\\train\\images\\*.jpg', shuffle=False)
    images = images.map(load_image)

    images_labels_load()

    for img in images.take(5):  # Display the first 5 images
       img_path = img.numpy().decode()
       with open(os.path.join('data', 'train', 'labels', f'{os.path.splitext(os.path.basename(img))[0]}'), 'r') as f:
           label = json.load(f)
       augment_images(img, get_coords(label))
       plt.imshow(img.numpy())
       plt.show()

    image_generator = images.batch(4).as_numpy_iterator()
    plot_images = image_generator.next()

    fig, ax = plt.subplots(ncols=4, figsize=(20,20))
    for idx, image in enumerate(plot_images):
       ax[idx].imshow(image)
    plt.show()

    vgg = VGG16(include_top=False)
    vgg.summary()

    facetracker = build_model()
    facetracker.summary()
    # X, y = train.as_numpy_iterator().next()


if __name__ == "__main__":
    main()
