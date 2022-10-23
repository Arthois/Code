<?php
session_start();                                                                // Enables $_SESSION variables
if(isset($_SESSION["login"]) && $_SESSION["priv"] == 1)                         // Checks if the user is logged in as admin
{
    header("Location: admin_account_area.php");                                 // If so redirects
    exit;
}
if(isset($_SESSION["login"]) && $_SESSION["priv"] == 0)                         // Checks if the user is logged in as a regular user
{
    header("Location: user_account_area.php");                                  // If so redirects
    exit;
}
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">          <!-- Metadata -->
    <link rel="stylesheet" href="style.css">
    <title>Login</title>
</head>
<body>
    <nav>
        <div class="topnav">
            <a class="active" href="index.php">Home Page</a>
            <a href="login_form.php">Login</a>                                      <!-- Navigation Bar -->
            <a href="register_form.php">Sign Up</a>
        </div>
    </nav>
    <div class="enterlog">
        <p>Enter Login Credentials</p>
    </div>
    <div class="login">                                                             <!-- HTML form for login below -->
        <form action ="login.php" method="POST">
            <label for="user_name">User Name</label>
            <input type="text" style="margin-top: 10px;" placeholder="Username" id ="user_name" name="user_name" required>
            <br>
            <label for="user_password">Password</label>
            <input type="password" style="margin-top: 10px;" placeholder="Password" id ="user_password" name="user_password" required>
            <br>
            <button type="submit">Login</button>
        </form>
    </div>
</body>
</html>
<?php
require_once 'functions.php';                   // Includes required functions
$error = $_GET["error"];                        // Sets the error through $_GET[]
showMessage($error);                            // Retrieves the message set in the functions.php file
?>