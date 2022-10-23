<?php 
include 'functions.php';                        // Includes functions
session_start();                                // Enables $_SESSION variables
checkLogin();                                   // Checks if the user is logged in
checkPrivs();                                   // Checks if the user has required privileges
changePrivs();                                  // Changes selected users privileges to admin or regular user
header("Location: mng_users.php");              // Redirects when done
exit;
?>