package Android.Assessment2;

import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;

public class Sign_Up extends AppCompatActivity implements View.OnClickListener{
    // Initialises Variables
    String user;
    String passwd;

    private SharedPreferences mPreferences;
    private String sharedPrefFile = "Users";

    @Override// Initialises UI elements
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_sign_up);
        Button button3 = (Button) findViewById(R.id.button3);
        button3.setOnClickListener(this);
        EditText user_name = (EditText) findViewById(R.id.editTextUser);
        EditText passwd = (EditText) findViewById(R.id.editTextTextPassword);
        mPreferences = getSharedPreferences(sharedPrefFile, MODE_PRIVATE);
    }

    @Override
    public void onClick(View v) {
        int id = v.getId();
        if (id == R.id.button3) {
            user = ((EditText) findViewById(R.id.editTextUser)).getText().toString();
            passwd = ((EditText) findViewById(R.id.editTextTextPassword)).getText().toString();

            // Checks if the password has at least 6 characters
            if (passwd.length() >= 6) {
                // Stores user data in SharedPreferences
                SharedPreferences.Editor preferencesEditor = mPreferences.edit();
                preferencesEditor.putString("username", user);
                preferencesEditor.putString("password", passwd);
                preferencesEditor.apply();

                // Shows a Toast message indicating user creation
                Toast.makeText(this, "User " + user + " has been created!", Toast.LENGTH_SHORT).show();

                // Returns to the main activity
                Intent intent = new Intent(this, Log_in.class);
                finish();
                startActivity(intent);
            } else {
                // Displays an error message for insufficient password length
                Toast.makeText(this, "Password must be at least 6 characters long", Toast.LENGTH_SHORT).show();
            }
        }
    }
}