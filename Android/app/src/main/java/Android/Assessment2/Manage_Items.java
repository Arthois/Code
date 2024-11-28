package Android.Assessment2;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;

import androidx.annotation.Nullable;
import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import java.util.List;

public class Manage_Items extends AppCompatActivity implements View.OnClickListener {

    private RecyclerView recyclerView;
    private RecyclerViewAdapter recyclerViewAdapter;
    private List<Item> itemList;
    private databaseHandler database;
    private Button backButton;

    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_manage_items);

        // Initialises database
        database = new databaseHandler(this);
        // Initialises Back Button
        backButton = (Button) findViewById(R.id.backButton);
        backButton.setOnClickListener(this);
        // Initialises RecyclerView
        recyclerView = findViewById(R.id.recyclerView);
        recyclerView.setLayoutManager(new LinearLayoutManager(this));

        // Fetches data from the database
        itemList = database.getAllItems();

        // Initialises RecyclerViewAdapter
        recyclerViewAdapter = new RecyclerViewAdapter(this, itemList, database);

        // Sets the adapter to the RecyclerView
        recyclerView.setAdapter(recyclerViewAdapter);
    }

    @Override
    protected void onResume() {
        super.onResume();
        // Refreshes the RecyclerView with the latest data
        updateRecyclerView();
    }

    private void updateRecyclerView() {
        // Fetches the latest data from the database
        itemList.clear();
        itemList.addAll(database.getAllItems());

        // Updates the itemList in the adapter and notify data change
        recyclerViewAdapter.notifyDataSetChanged();
    }

    @Override// Back Button functionality
    public void onClick(View v) {
        int id = v.getId();
        if (id == R.id.backButton){
            Intent intent = new Intent(this, User_Home.class);
            finish();
            startActivity(intent);
        }
    }
}
