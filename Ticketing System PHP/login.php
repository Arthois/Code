<?php
session_start();                                                                    //Enables session  variables
include 'functions.php';
try
{
    if($_SERVER["REQUEST_METHOD"] == "POST")                                        // Checks if we got here by submitting the login form
    {
        require_once 'dbconnect.php';           // For whatever reason this include/require works here but does not almost anywhere else.. Why though?
        $conn = new PDO("mysql:host=$servername;dbname=$database", $username, $password);       // Creates new PDO connection
        $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);                         // Sets PDO error mode
        $user = $_POST["user_name"];                                                            // Sets variables we got from the form
        $pwd =  $_POST["user_password"];
        $sql = $conn->prepare("SELECT * FROM users WHERE user_name = :user");   // SQL query for checking user credentials, for now its clear text.. Which is really insecure and should be at least hashed
        $sql->bindParam(":user", $user);                                                            // Binds the :variables with $variables
        $sql->execute();                                                                            // executes query

        if($sql->rowCount())                                                                        // If we find a matching row 
        {
            $row = $sql->fetch();                                                                   // Loads the columns into $row array
            $_SESSION["login"] = 1;
            $_SESSION["uid"] = $row["ID"];  
            $_SESSION["priv"] = $row["priv"];                                                       // Sets the $_SESSION variables
            $_SESSION["user"] = $row["user_name"];                                                  // Have a feeling this does not add security
            $_SESSION["password"] = $row["password"];                                               // Although might be useful for features in the future
            $checkpwd = password_verify($pwd, $row["password"]);

            lastLogin();                                                                            // Grabs the last known login and saves it
            logLogin();                                                                             // Logs the lates login

            if($checkpwd == true)
            {
                if($_SESSION["priv"] == 1)                                                              // Checks if the user has admin privileges
                {
                    header("Location: admin_account_area.php");                                         // if so redirects to admin area
                    exit();
                }
                else
                {
                    header("Location: user_account_area.php");                                          // if not the to user area
                    exit();
                }
            }
            else
            {
                header("Location: login_form.php?error=wronglogin");                                    // If the passwords do not match redirects
                exit();
            }
        }
        else
        {
            header("Location: login_form.php?error=wronglogin");                                    // If the query does not return any results redirects
            exit();
        }
    }
    else
    {
        echo "Hey..! You should not be doing that..";                                               // <-- He's right
    }
}
catch(PDOException $e)                                                                              // Catches errors if any
{
    echo $e->getMessage();                                                                          // Retrieves and displays error
}
?>