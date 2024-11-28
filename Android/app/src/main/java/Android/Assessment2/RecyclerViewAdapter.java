package Android.Assessment2;

import android.content.Context;
import android.content.Intent;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import java.util.List;

public class RecyclerViewAdapter extends RecyclerView.Adapter<RecyclerViewAdapter.ViewHolder> {
    // Initialises variables
    private Context context;
    private List<Item> itemList;
    private databaseHandler database;

    // Recycler constructor
    public RecyclerViewAdapter(Context context, List<Item> itemList, databaseHandler database) {
        this.context = context;     // Sets context
        this.itemList = itemList;   // Sets the item list
        this.database = database;   // Sets the database instance
    }

    @NonNull
    @Override// Sets Item layout in recycler
    public ViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View view = LayoutInflater.from(parent.getContext())
                .inflate(R.layout.item_layout, parent, false);
        return new ViewHolder(view);
    }

    @Override
    public void onBindViewHolder(@NonNull ViewHolder holder, int position) {
        Item item = itemList.get(position);

        holder.itemName.setText(item.getItemName());
        holder.itemPrice.setText(item.getPrice());
        holder.itemDesc.setText(item.getDesc());
        holder.itemStatus.setText(item.isPurchased() ? "Purchased" : "Not Purchased");
        // Sets up button actions
        holder.editButton.setOnClickListener(v -> {
            openEditItemActivity(item.getId());
            Toast.makeText(context, "Edit clicked for " + item.getItemName(), Toast.LENGTH_SHORT).show();
        });
        // Handles Delete button click
        holder.deleteButton.setOnClickListener(v -> {
            deleteItem(item);
            Toast.makeText(context, "Delete clicked for " + item.getItemName(), Toast.LENGTH_SHORT).show();
        });
        // Handles mark purchased button clicks
        holder.markPurchasedButton.setOnClickListener(v -> {
            int itemPosition = holder.getAdapterPosition(); // Gets items position from the recycler

            if (itemPosition != RecyclerView.NO_POSITION) {// If the item position is valid
                Item clickedItem = itemList.get(itemPosition);// Sets position

                // Updates the item status to purchased
                clickedItem.setStatus(true);

                // Updates the item in the database
                database.updateItem(clickedItem);

                // Notifies the adapter that data has changed
                notifyItemChanged(itemPosition);
                Toast.makeText(context, "Mark as Purchased clicked for " + item.getItemName(), Toast.LENGTH_SHORT).show();
            }
        });
    }

    private void deleteItem(Item item) {
        // Deletes the item from the database
        database.deleteItem(item);

        // Removes the item from the list
        itemList.remove(item);

        // Notifies the adapter that data has changed
        notifyDataSetChanged();
        Toast.makeText(context, "Deleted item: " + item.getItemName(), Toast.LENGTH_SHORT).show();
    }
    private void openEditItemActivity(int itemId) {
        // Creates an Intent to open EditItemActivity
        Intent intent = new Intent(context, Edit_Item.class);

        // Passes the item ID to EditItemActivity
        intent.putExtra("ITEM_ID", itemId);

        // Starts the EditItemActivity
        context.startActivity(intent);
    }

    @Override
    public int getItemCount() {
        return itemList.size();
    }

    // View Holder class to display the items in the recycler
    public class ViewHolder extends RecyclerView.ViewHolder implements View.OnClickListener {

        // Initialises variables
        public TextView itemName;
        public TextView itemStatus;
        public TextView itemPrice;
        public TextView itemDesc;
        public Button editButton;
        public Button deleteButton;
        public Button markPurchasedButton;

        public ViewHolder(@NonNull View itemView) {
            super(itemView);
            // Initialises the UI elements in the recycler for the items
            itemName = itemView.findViewById(R.id.itemName);
            itemPrice = itemView.findViewById(R.id.itemPrice);
            itemDesc = itemView.findViewById(R.id.itemDesc);
            itemStatus = itemView.findViewById(R.id.itemStatus);
            editButton = itemView.findViewById(R.id.editButton);
            deleteButton = itemView.findViewById(R.id.deleteButton);
            markPurchasedButton = itemView.findViewById(R.id.markAsPurchasedButton);
        }

        @Override
        public void onClick(View v) {
            // Handles item click events
            int position = getAdapterPosition(); // Gets the item position

            if (position != RecyclerView.NO_POSITION) {
                // Ensures that the item position is valid
                Item clickedItem = itemList.get(position);
            }
        }
    }
}
