package Android.Assessment2;

import android.content.pm.PackageManager;
import android.os.Bundle;
import android.telephony.SmsManager;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.app.ActivityCompat;
import androidx.core.content.ContextCompat;

import java.util.List;

public class Item_Delegation extends AppCompatActivity {

    // Initialises Class variables
    private Spinner spinner;
    private databaseHandler database;
    private Button sendSMS;
    private EditText phoneNo;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_item_delegation);
        // Initialises UI elements
        spinner = findViewById(R.id.spinner);
        database = new databaseHandler(this);
        sendSMS = findViewById(R.id.sendSMS);
        phoneNo = findViewById(R.id.phoneNo);

        // Fetches items from the database
        List<Item> itemList = database.getAllItems();

        // Creates an ArrayAdapter using the string array and a default spinner layout
        ArrayAdapter<Item> adapter = new ArrayAdapter<>(this, android.R.layout.simple_spinner_item, itemList);

        // Specifies the layout to use when the list of choices appears
        adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);

        // Apply the adapter to the spinner
        spinner.setAdapter(adapter);

        spinner.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {

            }

            @Override
            public void onNothingSelected(AdapterView<?> parent) {

            }
        });
        sendSMS.setOnClickListener(new View.OnClickListener() {
            @Override//On click sends the message
            public void onClick(View v) {
                sendMessage();
            }
        });
    }
    // Send message method
    private void sendMessage() {
        String sendSmsPermission = "android.permission.SEND_SMS";

        // If permissions to the phone given
        if (ContextCompat.checkSelfPermission(this, sendSmsPermission) == PackageManager.PERMISSION_GRANTED) {
            Item itemSelected = (Item) spinner.getSelectedItem();
            String smsMessage = "Item: " + itemSelected.getItemName() +
                    "\nPrice: " + itemSelected.getPrice() +
                    "\nDescription: " + itemSelected.getDesc() +
                    "\nStatus: " + (itemSelected.getStatus() ? "Purchased" : "Not Purchased");

            // Sets the phone number to the one from the EditText
            String destinationPhoneNumber = phoneNo.getText().toString();;

            SmsManager smsManager = SmsManager.getDefault();

            // Check if the message needs to be divided if its too long
            List<String> dividedMessages = smsManager.divideMessage(smsMessage);

            for (String message : dividedMessages) {
                // Send each part of the message if its too long
                smsManager.sendTextMessage(destinationPhoneNumber, null, message, null, null);
            }

            Toast.makeText(this, "SMS sent successfully", Toast.LENGTH_SHORT).show();
        } else { // If permissions are denied requests permissions
            ActivityCompat.requestPermissions(this, new String[]{sendSmsPermission}, 1);
        }
    }

    public void onRequestPermissionsResult(int requestCode, @NonNull String[] permissions, @NonNull int[] grantResults) {
        super.onRequestPermissionsResult(requestCode, permissions, grantResults);

        if (requestCode == 1) {
            if (grantResults.length > 0 && grantResults[0] == PackageManager.PERMISSION_GRANTED) {
                // Permission granted, send SMS
                sendMessage();
            } else {
                // Permission denied
                Toast.makeText(this, "SMS permission denied", Toast.LENGTH_SHORT).show();
            }
        }
    }
}
