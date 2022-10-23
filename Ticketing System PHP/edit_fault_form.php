<?php
include 'functions.php';                                                        // Includes functions
session_start();                                                                // Enables $_SESSION variables
checkLogin();                                                                   // Checks if the user is logged in
checkPrivs();                                                                   // Checks if the user has the required privileges
$id = $_GET["ID"];                                                              // Gets ID of the column that will be edited
if($id == "")                                                                   // Checks if ID is not empty
{
    header("Location: view_all_faults_admin.php");                              // If empty redirects
    exit;
}

include 'dbconnect.php';                                                        // DB Credentials

try
{
    $conn = new PDO("mysql:host=$servername;dbname=$database", $username, $password);   // Creates new connection using PDO
    $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);                     // Sets PDO error exception
    $sql = "SELECT * FROM faults WHERE `ID`= $id";                                      //SQL query

    foreach($conn->query($sql, PDO::FETCH_ASSOC) as $row)                               //Finds the row in the DB with the ID
    {
        $title = $row["Title"];
        $location = $row["Location"];
        $description = $row["Description"];                                             // Sets all the variables that will be sent 
        $status = $row["Fault_Status"];
        $complete = $row["Job_Complete"];
    }
}
catch(PDOException $e)
{
    echo $sql . "<br>" . $e->getMessage();                                              // Catches and throws an error if encounters any
}
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">              <!-- Metadata for the page displayed -->
    <link rel="stylesheet" href="style.css">
    <title>Edit Fault</title>
</head>
<body>
<nav>
    <div class="topnav">
        <a class="active" href="admin_account_area.php">My Account</a>
        <a href="report_fault_form.php">Report Fault</a>
        <a href="view_my_reported_faults.php">My Reports</a>                            <!-- Navigation bar at the top of the page -->
        <a href="view_all_faults_admin.php">All Faults</a>
        <a href="search_fault_form.php">Search Faults</a>
        <a href="mng_users.php">Manage Users</a>
        <a href="logout.php">Log Out</a>
    </div>
</nav>
<div class="report-form-form">                                                          <!-- The Start of the form for editing the fault -->
        <form action="edit_faults.php" method="POST">
            <p>Faults Title</p>
            <input type="text" style="margin-top: 10px;" value="<?php echo $title;?>" name="title" maxlength="15" placeholder="Title.. 15char" required>  <!-- Faults Title we retrieved before -->
            <br>
            <p>Faults Location</p>
            <input type="text" style="margin-top: 10px;" value="<?php echo $location;?>" name="location" maxlength="15" placeholder="Location.. 15char" required> <!-- Faults Location we retrieved before -->
            <br>
            <p>Faults Description</p>
            <textarea type="text" style="margin-top: 10px;" value="<?php echo $description;?>" name="description" maxlength="40" placeholder="Fault Description.. 40char" required><?php echo $description;?></textarea>  <!-- Faults Description we retrieved before -->
            <br>
            <input type="hidden" name= "id" value="<?php echo $id;?>">  <!-- Faults ID we retrieved before -->
            <p>Faults Current Status</p>
            <div id="fault_status">     <!-- Faults Status we retrieved before -->
                <input type="radio" id="started" value="Started.." <?php if($status=='Started..'){?> checked="checked" <?php }?> name="group1"> <!-- Automatically checks the radio button according to the faults status -->
                <label for="started">Started..</label>
                <input type="radio" id="notstarted" value="Not Started.." <?php if($status!='Started..'){?> checked="checked" <?php }?> name="group1">  <!-- If no status is current sets the status to 'Not started' before updating fault -->
                <label for="working">Not Started..</label>
            </div>
            <br>
            <p>Job Finished?</p>
            <div id="job_complete">     <!-- Job/Fault Complete/Done status we retrieved before -->
                <input type="radio" id="yes" value="Yes" <?php if($complete=='Yes'){?> checked="checked" <?php }?> name="group2">   <!-- Automatically checks the radio button according to the faults status -->
                <label for="yes">Yes</label>
                <input type="radio" id="no" value="No" <?php if($complete!='Yes'){?> checked="checked" <?php }?> name="group2">     <!-- If no status is current sets the status to 'No' before updating fault -->
                <label for="no">No</label>
            </div>
            <button type="submit" style="margin-top: 10px;margin-right:250px;" name="submit">Update Fault</button>  <!-- Submits form-->
            <button type="reset" style="margin-top: 10px;" name="clear">Clear Form</button>     <!-- Clears form-->
        </form>
    </div>
</body>
</html>
<?php
$error = $_GET["error"];        // Checks if we got any errors sent back from updating the form
showMessage($error);            // Shows the erros if any
?>