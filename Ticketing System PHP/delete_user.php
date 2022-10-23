<?php 
include 'functions.php';                    // Includes functions
session_start();                            // Enables $_SESSION variables
checkLogin();                               // Checks if the user is logged in
checkPrivs();                               // Checks if the user has the required privileges
deleteUser();                               // Deletes the user from the DB
header("Location: mng_users.php");          // Redirects when done
exit;
?>