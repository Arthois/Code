<?php
$servername = "ServerName";
$username = "Username";    //Database login credentials
$password = "Password";
$database = "Database Name";

try 
{
    $conn = new PDO("mysql:host=$servername;dbname=$database", $username, $password);
    $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
}                                                                                    //Connecting via PDO method
catch(PDOException $e) 
{
    echo "Connection failed: " . $e->getMessage();
}
?>