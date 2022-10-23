<?php
include 'functions.php';                                            // Includes functions
session_start();                                                    // Enables $_SESSION variables
checkLogin();                                                       // Checks if the user is logged in
checkPrivs();                                                       // Checks if the user has the required privileges
$id = $_GET["ID"];                                                  // Gets id of the column

if($id == "")                                                       // Checks if ID is not empty
{
    header("Location: view_all_faults_admin.php?error=noid");       // If its empty redirects
    exit;
}

include 'dbconnect.php';                                            // DB credentials

try
{
    $conn = new PDO("mysql:host=$servername;dbname=$database", $username, $password); // Creates new connection using PDO
    $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);                   // Sets PDO error exception
    $sql = $conn->prepare("DELETE FROM faults WHERE ID = :id");                       // SQL query 
    $sql->bindParam(":id", $id);                                                      // Binds ID from before to :id variable
    $sql->execute();                                                                  // Executes query
    header("Location: view_all_faults_admin.php");                                    // Redirects if no errors are encountered
    exit;
}
catch(PDOException $e)
{
    echo "Error: " . $e->getMessage();                              // Throws error and retrieves message
}
?>