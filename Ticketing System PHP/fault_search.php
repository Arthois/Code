<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">      <!-- Metadata -->
    <link rel="stylesheet" href="style.css">
    <title>Search Results</title>
</head>
<body>
<nav>
    <div class="topnav">
        <a class="active" href="user_account_area.php">My Account</a>
        <a href="report_fault_form.php">Report Fault</a>
        <a href="view_my_reported_faults.php">My Reports</a>                    <!-- Navigation Bar -->
        <a href="view_all_faults_admin.php">All Faults</a>
        <a href="search_fault_form.php">Search Faults</a>
        <a href="logout.php">Log Out</a>
    </div>
</nav>
<div class="container">                                                         <!-- Div for the Table heads -->
<table>
    <thead>
        <tr>
            <th>ID</th><th>Title</th><th>Description</th><th>Location</th><th>Date</th><th>Fault Status</th><th>Job Complete</th>
        </tr>   <!-- Table heads ^ -->
    </thead>
    <tbody>
<?php
session_start();                                                // Enables session variables
include 'functions.php';
checkLogin();
if($_SESSION["priv"] == 1)                                      // Checks if the user has the privileges
{
    header("Location: fault_search_admin.php");            // If not redirects
}
if(isset($_POST["submit"]))                                     // Checks if we got here by submitting the form for searching
{
    include 'dbconnect.php';
    
    $title = $_POST["stitle"];                                  // Grabs the variables we got by submitting the form
    $location = $_POST["slocation"];
    $description = $_POST["sdescription"];
    $id = $_POST["sid"];
    $count = 0;                                                     // Starts the counter
    
    if($title == "")                                                // Checks if theres anything to search with 
    {
        header("Location: search_fault_form.php?search=nosearch");
        exit;
    }
    
    try 
    {
        $conn = new PDO("mysql:host=$servername;dbname=$database", $username, $password);   // Creates new PDO connection
        $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);                     // Sets PDO error mode 
        $sql = "SELECT * FROM faults WHERE `Title` LIKE '$title%';";                        // SQL query
        foreach($conn->query($sql, PDO::FETCH_ASSOC) as $row)                               // For every time the querry goes through the DB and finds a matchng result
        {                                                                                   // It stores the collumns in the $row array
            $count++;                                                                       // Itterates the counter with each go
            echo '<tr>';
            echo '<td>'. $row['ID'] . '</td>';
            echo '<td>'. $row['Title'] . '</td>';
            echo '<td>'. $row['Description'] . '</td>';
            echo '<td>'. $row['Location'] . '</td>';                                        // Displays the results in the table as called
            echo '<td>'. $row['Date_Time'] . '</td>';
            echo '<td>'. $row['Fault_Status'] . '</td>';
            echo '<td>'. $row['Job_Complete'] . '</td>';
            echo '</tr>';
        }
        echo "<p1 class='results'>Results found: $count</p1>"; // Displays the number of found results Using CSS it is displayed at the top of the table
    }
    catch(PDOException $e)      // Catches errors if any 
    {
        echo "Error" . $e->getMessage();     // Displays the error if any
    }
}
else
{
    header("Location: search_fault_form_admin.php"); // If we got here without submitting the form redirects back to the form
    exit;
}
?>
    </tbody>
</table>
</div>
</body>
</html>