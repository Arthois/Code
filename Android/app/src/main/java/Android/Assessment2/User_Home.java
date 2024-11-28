package Android.Assessment2;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;

import androidx.appcompat.app.AppCompatActivity;
//import android.widget.TextView;

public class User_Home extends AppCompatActivity implements View.OnClickListener{
    // Initialises UI elements
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_user_home);

        Button manageItems = (Button) findViewById(R.id.manageItems);
        Button createItem = (Button) findViewById(R.id.createItem);
        Button itemDelegation = (Button) findViewById(R.id.itemDelegation);
        Button logOut = (Button) findViewById(R.id.logOut);
        manageItems.setOnClickListener(this);
        createItem.setOnClickListener(this);
        itemDelegation.setOnClickListener(this);
        logOut.setOnClickListener(this);
    }

    @Override // Click logic for buttons
    public void onClick(View v) {
        int id = v.getId();

        if(id == R.id.manageItems){// Opens manage items activity
            Intent signUpIntent = new Intent(this, Manage_Items.class);
            startActivity(signUpIntent);
        }
        else if (id == R.id.createItem) {// Opens create item activity
            Intent signUpIntent = new Intent(this, Create_Item.class);
            startActivity(signUpIntent);        }
        else if (id == R.id.itemDelegation) {// Opens Item delegation activity
            Intent signUpIntent = new Intent(this, Item_Delegation.class);
            startActivity(signUpIntent);        }
        else if (id == R.id.logOut) {// Logs out and opens home screen
            Intent signUpIntent = new Intent(this, Home_Screen.class);
            finish();
            startActivity(signUpIntent);
        }
    }
}