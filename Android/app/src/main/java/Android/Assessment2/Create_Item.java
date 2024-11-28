package Android.Assessment2;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;

public class Create_Item extends AppCompatActivity implements View.OnClickListener {

    private databaseHandler dbHandler;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_create_item);
        dbHandler = new databaseHandler(this); // Initialises the database handler
        Button addItem = findViewById(R.id.addItem);// Initialises the button
        Button back_Button = findViewById(R.id.back_Button);
        addItem.setOnClickListener(this);
        back_Button.setOnClickListener(this);
    }

    @Override
    public void onClick(View v) {
        if (v.getId() == R.id.addItem) {
            EditText enterItemName = findViewById(R.id.enterItem);
            EditText enterItemPrice = findViewById(R.id.itemPrice);
            EditText enterItemDesc = findViewById(R.id.itemDesc);
            String itemName = enterItemName.getText().toString();
            String itemPrice = enterItemPrice.getText().toString();
            String itemDesc = enterItemDesc.getText().toString();

            if (!itemName.isEmpty() && !itemPrice.isEmpty() && !itemDesc.isEmpty()) {
                Item newItem = new Item(itemName, itemPrice, itemDesc, false);
                dbHandler.addItem(newItem);// Adds the new item to the database
                Toast.makeText(this, "Item added successfully", Toast.LENGTH_SHORT).show();
                enterItemName.setText("");// Clears the EditText after adding the item
                enterItemDesc.setText("");
                enterItemPrice.setText("");
            } else {
                Toast.makeText(this, "Please Fill Out All The Fields", Toast.LENGTH_SHORT).show();
            }
        }
        else if (v.getId() == R.id.back_Button) {
            Intent intent = new Intent(this, User_Home.class);
            finish();
            startActivity(intent);
        }
    }
}