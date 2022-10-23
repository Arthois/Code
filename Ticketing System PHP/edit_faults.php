<?php
include 'functions.php';                                // Includes functions
session_start();                                        // Enables $_SESSION variables
checkLogin();                                           // Checks if the user is logged in
checkPrivs();                                           // Checks if the user has the required privileges
if(isset($_POST["submit"]))                             // Checks if we got here by submitting a from
{
    try
    {
        $title = $_POST["title"];
        $location = $_POST["location"];
        $description = $_POST["description"];           // All the variables we got through $_POST and $_SESSION
        $status = $_POST["group1"];
        $complete = $_POST["group2"];
        $id = $_POST["id"];
        $uid = $_SESSION["uid"];
    
        include 'dbconnect.php';
    
        $conn = new PDO("mysql:host=$servername;dbname=$database", $username, $password); // Creates a new PDO connection variable
        $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);                   // Sets the PDO error exception mode
        $sql = $conn->prepare("UPDATE faults SET Title = :title, Description = :description, Location = :location, Date_Time = current_timestamp(), Fault_Status = :status, Job_Complete = :complete, User_ID = :uid WHERE ID = :id");
        // SQL query which is going to be used with set variables that is going to be sent out.. This query method helps with avoiding SQL Injections
        $sql->bindParam(":title", $title);
        $sql->bindParam(":description", $description);
        $sql->bindParam(":location", $location);
        $sql->bindParam(":status", $status);                // Binds all the :variables we see in the query with the variables we got earlier
        $sql->bindParam(":complete", $complete);
        $sql->bindParam(":uid", $uid);
        $sql->bindParam(":id", $id);
        $sql->execute();
        header("Location: edit_fault_form.php?error=ok");   // If everything executes without erros we get redirected 
        exit;
    }
    catch(PDOException $e)                                  // Catches errors if any
    {
        echo "Error" . $e->getMessage();                    // Displays errors if any
    }
}
else
{
    header("Location: edit_fault_form.php?error=nosubmit"); // Redirects if we got here without submitting the from
    exit;
}
?>