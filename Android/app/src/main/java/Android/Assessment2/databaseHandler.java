package Android.Assessment2;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;
import android.util.Log;

import java.util.ArrayList;
import java.util.List;

public class databaseHandler extends SQLiteOpenHelper {


    public databaseHandler(Context context ) {
        super(context, Util.DATABASE_NAME, null, Util.DATABASE_VERSION);
    }

    @Override//Method that initialises the database table
    public void onCreate(SQLiteDatabase db) {
        String CREATE_CONTACT_TABLE = "CREATE TABLE " + Util.TABLE_NAME + "("
                + Util.KEY_ID + " INTEGER PRIMARY KEY,"
                + Util.KEY_NAME + " TEXT,"
                + Util.KEY_PRICE + " TEXT,"
                + Util.KEY_DESC + " TEXT,"
                + Util.KEY_ITEM_STATUS + " TEXT"+ ")";
        db.execSQL(CREATE_CONTACT_TABLE);
    }

    @Override// Method to upgrade the database
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
        String DROP_TABLE = String.valueOf(R.string.db_drop);
        db.execSQL(DROP_TABLE, new String[]{Util.DATABASE_NAME});
        onCreate(db);
    }

    public void addItem(Item item) {//Method to add an item to the database
        SQLiteDatabase db = this.getWritableDatabase();
        ContentValues values = new ContentValues();
        values.put(Util.KEY_NAME, item.getItemName());
        values.put(Util.KEY_PRICE, item.getPrice());
        values.put(Util.KEY_DESC, item.getDesc());
        values.put(Util.KEY_ITEM_STATUS, item.isPurchased() ? 1 : 0); // 1 for true, 0 for false

        db.insert(Util.TABLE_NAME, null, values);// Insert the row
        Log.d("DBHandler", "addItem: Item added");//Some log data for debugging
        db.close(); // Close the database connection
    }


    public Item getItem(int id) {// Method to get an item object from the database
        SQLiteDatabase db = this.getReadableDatabase();

        Cursor cursor = db.query(
                Util.TABLE_NAME,
                new String[]{ Util.KEY_ID, Util.KEY_NAME, Util.KEY_PRICE, Util.KEY_DESC, Util.KEY_ITEM_STATUS},
                Util.KEY_ID +"=?",
                new String[]{String.valueOf(id)},
                null, null, null);

        if (cursor != null)
            cursor.moveToFirst();

        Item item = new Item();
        item.setId(Integer.parseInt(cursor.getString(0)));
        item.setItemName(cursor.getString(1));
        item.setPrice(cursor.getString(2));
        item.setDesc(cursor.getString(3));
        item.setStatus(Boolean.parseBoolean(cursor.getString(4)));

        return item;
    }

    //Get all Items method to get the full database contents
    public List<Item> getAllItems() {
        List<Item> itemList = new ArrayList<>();

        SQLiteDatabase db = this.getReadableDatabase();

        // Select all items
        String selectAll = "SELECT * FROM " + Util.TABLE_NAME;
        Cursor cursor = db.rawQuery(selectAll, null);

        // Loop through the data
        if (cursor.moveToFirst()) {
            do {
                Item item = new Item(); // Provide default values
                item.setId(Integer.parseInt(cursor.getString(0)));
                item.setItemName(cursor.getString(1));
                item.setPrice(cursor.getString(2));
                item.setDesc(cursor.getString(3));
                item.setStatus(cursor.getInt(4) == 1); // Check if the value is 1 for true
                // Add items to the list
                itemList.add(item);
            } while (cursor.moveToNext());
        }
        cursor.close(); // Close the cursor
        return itemList;
    }

    //Update contact
    public int updateItem(Item item) {//Method that updates the items values in the database
        SQLiteDatabase db = this.getWritableDatabase();
        ContentValues values = new ContentValues();
        values.put(Util.KEY_NAME, item.getItemName());
        values.put(Util.KEY_PRICE, item.getPrice());
        values.put(Util.KEY_DESC, item.getDesc());
        values.put(Util.KEY_ITEM_STATUS, item.isPurchased());
        // Update the row
        return db.update(Util.TABLE_NAME, values, Util.KEY_ID + "=?",
                new String[]{String.valueOf(item.getId())});
    }

    //Method that deletes an item from the database
    public void deleteItem(Item item) {
        SQLiteDatabase db = this.getWritableDatabase();
        db.delete(Util.TABLE_NAME, Util.KEY_ID + "=?",
                new String[]{String.valueOf(item.getId())});
        db.close();
    }

    //Method to get the items count in the database
    public int getCount() {
        String countQuery = "SELECT * FROM " + Util.TABLE_NAME;
        SQLiteDatabase db = this.getReadableDatabase();
        Cursor cursor = db.rawQuery(countQuery, null);
        return cursor.getCount();
    }
}
