<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">      <!-- Metadata -->
    <link rel="stylesheet" href="style.css">
    <title>Registration</title>
</head>
<body>
    <nav>
        <div class="topnav">
            <a class="active" href="index.php">Home Page</a>
            <a href="login_form.php">Login</a>                                  <!-- Navigation Bar -->
            <a href="register_form.php">Sign Up</a>
        </div>
    </nav>
    <p>Register User</p>
    <div class="signup-form-from">                                              <!-- Sign up form -->
        <form action="register.php" method="POST">                              <!-- Sends information using $_POST to next "page" -->
            <input type="text" style="margin-top: 10px;" name="user_name" placeholder="Username.." required>
            <br>
            <input type="password" style="margin-top: 10px;" name="pwd" placeholder="Password.." required>
            <br>
            <input type="password" style="margin-top: 10px;" name="rpwd" placeholder="Repeat Password.." required>
            <br>
            <button type="submit" style="margin-top: 10px;" name="submit">Submit</button>
        </form>
    </div>
</body>
</html>
<?php 
require_once 'functions.php';
$error = $_GET["error"];                        // Sets the error through $_GET[]
showMessage($error);                            // Retrieves the message set in the functions.php file
?>