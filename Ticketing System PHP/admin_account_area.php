<?php
include 'functions.php';                                                        // Includes functions
session_start();                                                                // Enables $_SESSION variables
checkLogin();                                                                   // Checks if user is logged in
checkPrivs();                                                                   // Checks for privileges
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">  <!-- Metadata -->
    <link rel="stylesheet" href="style.css">
    <title>Admin Area</title>
</head>
<body>
<nav>
    <div class="topnav">
        <a class="active" href="admin_account_area.php">My Account</a>
        <a href="report_fault_form.php">Report Fault</a>
        <a href="view_my_reported_faults_admin.php">My Reports</a>    <!-- Navigation bar with links -->
        <a href="view_all_faults_admin.php">All Faults</a>
        <a href="search_fault_form_admin.php">Search Faults</a>
        <a href="mng_users.php">Manage Users</a>
        <a href="logout.php">Log Out</a>
    </div>
</nav>
<h1>Hello <?php echo $_SESSION["user"]?></h1>                          <!-- Greets current user -->
<p2>Your Reports: <?php echo myReportsNo() ?></p2><br>                 <!-- Shows user reports number -->
<p2>Last Login: <?php echo $_SESSION["last_login"]?></p2><br>          <!-- Displays last login -->
<p2>Curren User: <?php echo $_SESSION["user"]?></p2>                   <!-- Current user -->
</body>
</html>