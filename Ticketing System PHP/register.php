<?php
ob_start();
include_once 'dbconnect.php';
if(isset($_POST["submit"]))     // Checks if the page was reached by submitting the registration form
{
    $user = $_POST["user_name"];    // Grabs user data from the registration form
    $pwd = $_POST["pwd"];
    $rpwd = $_POST["rpwd"];

    require_once "dbconnect.php";                                           // DB credentials, works here as well, almost not anywhere else.. Why?
    require_once "functions.php";                                           // Includes Functions

    if(invalidUser($user) == true)                                          // Checks if the username is valid as in does not use any "ILLEGAL" symbols
    {
        header("Location: register_form.php?error=invaliduser");            // If True redirects
        exit();
    }    

    if(pwdMatch($pwd, $rpwd) == false)                                      // Checks if the passwords match
    {
        header("Location: register_form.php?error=pwdnomatch");             // If false redirects
        exit();
    }

    if(invalidPwd($pwd) < 6)                                                // Password less then 6 chatacters?
    {
        header("Location: register_form.php?error=pwdtooshort");            // Redirects, lets try again.
        exit();
    }

    if(userTaken($conn, $user) == true)                                     // Checks if the user is taken
    {
        header("Location: register_form.php?error=usertaken");              // If true redirects 
        exit();
    }

    addUser($user, $pwd);                                                   // If we got here, creates the user. Refer to functions.php for more info
}
else
{
    header("Location: index.php");  //If page was not reached by submitting the form, redirects
    die();
}
ob_end_flush();
?>