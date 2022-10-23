<?php
include 'functions.php';
session_start();                                            // Enables session variables
checkLogin();                                               // Checks if the user is logged in

$uid = $_SESSION["uid"];
$title = $_POST["title"];                                   // Sets $_SESSION and $_POST variables
$location = $_POST["location"];
$description = $_POST["description"];

try
{
    if($_SERVER["REQUEST_METHOD"] == "POST")                // Checks if we got here by submitting the form
    {
        include 'dbconnect.php';

        $conn = new PDO("mysql:host=$servername;dbname=$database", $username, $password);       // Creates new PDO connection
        $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);                         // Sets PDO error mode
        $sql = $conn->prepare("INSERT INTO faults (`ID`, `Title`, `Description`, `Location`, `Date_Time`, `Fault_Status`, `Job_Complete`, `User_ID`) VALUES (NULL, :title, :description, :location, current_timestamp(), '', '', :uid)");
        $sql->bindParam(":title", $title);                              // SQL query for adding report to DB ^
        $sql->bindParam(":description", $description);
        $sql->bindParam(":location", $location);                        // Binds :variables with $variables
        $sql->bindParam(":uid", $uid);
        $sql->execute();                                                // executes query
        if($_SESSION["priv"] != 1)
        {
            header("Location: report_fault_form.php?report=OK");            // redirects to report form again if succesful
            exit;
        }
        header("Location: report_fault_form_admin.php?report=OK");
        exit;

    }
}
catch(PDOException $e)                                                  // Catches errors if any
{
    echo $e->getMessage();                                              // Retrieves and displays message
    if($_SESSION["priv"] != 1)
    {
        header("Location: report_fault_form.php?report=NO");                // Redirects back to from with an error value
        exit;
    }
    header("Location: report_fault_form_admin.php?report=NO");
    exit;
}
?>