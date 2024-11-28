package Android.Assessment2;
// Class that defines the items stored in the database
public class Item {

    // Initialises variables
    private String itemName;
    private boolean isPurchased;
    private int id;
    private String itemPrice;
    private String itemDesc;

    //Empty Item Constructor
    public Item() {
    }

    // Item Constructor with parameters
    public Item(String itemName, String price, String desc, boolean isPurchased) {
        this.itemName = itemName;
        this.itemPrice = price;
        this.itemDesc = desc;
        this.isPurchased = isPurchased;
    }

    // Getter method
    public int getId(){
        return id;
    }
    // Setter method
    public void setId(int id){
        this.id = id;
    }
    // Getter method
    public String getItemName() {
        return itemName;
    }
    // Setter method
    public void setItemName(String itemName) {
        this.itemName = itemName;
    }
    public String  getPrice() {
        return itemPrice;
    }
    public void setPrice(String itemPrice){
        this.itemPrice = itemPrice;
    }
    public String getDesc(){
        return itemDesc;
    }
    public void setDesc(String itemDesc){
        this.itemDesc = itemDesc;
    }
    public boolean isPurchased() {
        return isPurchased;
    }
    // Setter method
    public void setStatus(boolean status){
        this.isPurchased = status;
    }
    // Getter method
    public boolean getStatus(){
        return this.isPurchased;
    }
    @Override
    public String toString() {
        return itemName;
    }
}