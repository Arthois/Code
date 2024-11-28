package Android.Assessment2;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;

import androidx.appcompat.app.AppCompatActivity;

public class Home_Screen extends AppCompatActivity implements  View.OnClickListener{

    //private SharedPreferences mPreferences;
    //private String sharedPrefFile = "Users";

    // Initialises the UI elements
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        //mPreferences = getSharedPreferences(sharedPrefFile, MODE_PRIVATE);
        //SharedPreferences.Editor preferencesEditor = mPreferences.edit();
        Button button1 = (Button) findViewById(R.id.Log_In);
        button1.setOnClickListener(this);
        Button button2 = (Button) findViewById(R.id.Sign_Up);
        button2.setOnClickListener(this);
    }

    // Logic of what to do once a button is pressed
    @Override
    public void onClick(View v) {
        int id = v.getId();
        if (id == R.id.Log_In) {// Launches Log In page
            Intent myIntent = new Intent(Home_Screen.this, Log_in.class);
            Home_Screen.this.startActivity(myIntent);
        } else if (id == R.id.Sign_Up) {// Launches Sign Up page
            Intent myIntent = new Intent(Home_Screen.this, Sign_Up.class);
            Home_Screen.this.startActivity(myIntent);
        }
    }
}