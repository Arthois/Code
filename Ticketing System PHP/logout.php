<?php
session_start();                    // Enables $_SESSION variables
unset($_SESSION["login"]);          // Unsets the variable
session_destroy();                  // Series of functions to ensure the session variables are unset and destroyed, then saved empty
session_write_close();
header('Location: index.php');      // Redirects back to welcome/home page of the site
die;                                // Haha Dies? Nah, if serious same as exit;
?>