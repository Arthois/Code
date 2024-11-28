package Android.Assessment2;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Switch;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;

public class Edit_Item extends AppCompatActivity implements View.OnClickListener {

    // Initialises variables
    private EditText nameEdit;
    private EditText priceEdit;
    private EditText descEdit;
    private databaseHandler database;
    private Switch isPurchased;
    private Button saveButton;
    private Button backButton;
    private Item item;

    // Initialises the UI elements
    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_edit_item);
        nameEdit = (EditText) findViewById(R.id.editName);
        priceEdit = (EditText) findViewById(R.id.editPrice);
        descEdit = (EditText) findViewById(R.id.editDesc);
        isPurchased = (Switch) findViewById(R.id.isPurchased);
        saveButton = (Button)findViewById(R.id.saveChanges);
        saveButton.setOnClickListener(this);
        backButton = (Button)findViewById(R.id.back_button);
        backButton.setOnClickListener(this);
        database = new databaseHandler(this);
        int itemId = getIntent().getIntExtra("ITEM_ID", -1);
        item = database.getItem(itemId);

        if (item == null) {
            // Handle the case where the item is not found
            Toast.makeText(this, "Item not found", Toast.LENGTH_SHORT).show();
            finish(); // Finish the activity
            return;
        }
        item = database.getItem(itemId);
        nameEdit.setText(item.getItemName());
        priceEdit.setText(item.getPrice());
        descEdit.setText(item.getDesc());
        isPurchased.setChecked(item.isPurchased());
        isPurchased.jumpDrawablesToCurrentState();
        saveButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                saveChanges();
            }
        });
    }

    // Method to save made changes to the database
    private void saveChanges() {
        if (item != null && database != null) {
            String editedName = nameEdit.getText().toString();
            String editedPrice = priceEdit.getText().toString();
            String editedDesc = descEdit.getText().toString();
            boolean editedPurchased = isPurchased.isChecked();
            item.setItemName(editedName);
            item.setPrice(editedPrice);
            item.setDesc(editedDesc);
            item.setStatus(editedPurchased);
            database.updateItem(item);
            setResult(Activity.RESULT_OK);
            finish();
        }
    }

    @Override
    public void onClick(View v) {
        int id = v.getId();

        if(id == R.id.back_button){
            Intent intent = new Intent(this, Manage_Items.class);
            finish();
            startActivity(intent);
        }
    }
}