package Android.Assessment2;

import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;
// Log In class
public class Log_in extends AppCompatActivity {
    // Initialises the variables
    private SharedPreferences mPreferences;
    private String sharedPrefFile = "Users";

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_log_in);
        // Creates Shared Preferences File
        mPreferences = getSharedPreferences(sharedPrefFile, MODE_PRIVATE);
        // Initialises UI elements
        Button loginButton = findViewById(R.id.button4);
        loginButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                EditText usernameEditText = findViewById(R.id.editText2);
                EditText passwordEditText = findViewById(R.id.editTextTextPassword2);

                String enteredUsername = usernameEditText.getText().toString();
                String enteredPassword = passwordEditText.getText().toString();

                // Retrieve stored user and password from SharedPreferences
                String savedUsername = mPreferences.getString("username", "");
                String savedPassword = mPreferences.getString("password", "");

                if (enteredUsername.equals(savedUsername) && enteredPassword.equals(savedPassword)) {
                    // Successful login
                    Toast.makeText(Log_in.this, "Login successful!", Toast.LENGTH_SHORT).show();

                    // Start the main activity
                    Intent intent = new Intent(Log_in.this, User_Home.class);
                    startActivity(intent);
                    finish(); // Close the login activity
                } else {
                    // Invalid login
                    Toast.makeText(Log_in.this, "Invalid username or password", Toast.LENGTH_SHORT).show();
                }
            }
        });
    }
}
