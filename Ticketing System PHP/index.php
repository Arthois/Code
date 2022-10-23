<?php session_start();?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">      <!-- Metadata -->
    <link rel="stylesheet" href="style.css">
    <title>Home Page</title>
</head>
<body>
<nav>
    <div class="topnav">
    <?php if(isset($_SESSION["login"]) && $_SESSION["priv"] == 1)                   // If the user is logged in and admin displays admin navigation bar
        {
    ?>
        <a class="active" href="admin_account_area.php">My Account</a>
        <a href="report_fault_form_admin.php">Report Fault</a>
        <a href="view_my_reported_faults_admin.php">My Reports</a>
        <a href="view_all_faults_admin.php">All Faults</a>                          <!-- Navigation Bar -->
        <a href="search_fault_form_admin.php">Search Faults</a>
        <a href="mng_users.php">Manage Users</a>
        <a href="logout.php">Log Out</a>
    <?php
        }
        elseif(isset($_SESSION["login"]) && $_SESSION["priv"] == 0)                 // If the user is logged in as a regular user will display a user navigation bar 
        {
    ?>
        <a class="active" href="user_account_area.php">My Account</a>
        <a href="report_fault_form.php">Report Fault</a>
        <a href="view_my_reported_faults.php">My Reports</a>                        <!-- Navigation Bar -->
        <a href="view_all_faults.php">All Faults</a>
        <a href="search_fault_form.php">Search Faults</a>
        <a href="logout.php">Log Out</a>
    <?php
        }
        else                                                                        // If the user is logged out will display the navigation bar below
        {
    ?>
        <a class="active" href="index.php">Home Page</a>
        <a href="login_form.php">Login</a>                                      <!-- Navigation Bar -->
        <a href="register_form.php">Sign Up</a>
    <?php
        }
    ?>
    </div>
</nav>

<h1>Hello And Welcome</h1>
<br>                                                                            <!-- Just some text -->
<br>
<p>This is just a simple welcome message to meet anyone who stumbles upon this page</p>
</body>
</html>