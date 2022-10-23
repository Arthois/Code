<!DOCTYPE html>
<html lang="en">
<head>
<meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">      <!-- Metadata -->
    <link rel="stylesheet" href="style.css">
    <title>Search Faults</title>
</head>
<body>
<nav>
    <div class="topnav">
        <a class="active" href="user_account_area.php">My Account</a>
        <a href="report_fault_form.php">Report Fault</a>
        <a href="view_my_reported_faults.php">My Reports</a>                    <!-- Navigation Bar -->
        <a href="view_all_faults.php">All Faults</a>
        <a href="search_fault_form.php">Search Faults</a>
        <a href="logout.php">Log Out</a>
    </div>
</nav>
<p>Search Faults</p>
    <div class="search-form">                                                   <!-- Search form below -->
        <form action="fault_search.php" method="POST">
            <input type="text" style="margin-top: 10px;" name="stitle" maxlength="15" placeholder="Title.. 15char" required>
            <br>
            <button type="text" style="margin-top: 10px;" name="submit">Search</button>
        </form>
    </div>
</body>
</html>
<?php
session_start();                                                // Enables session variables
require_once 'functions.php';
checkLogin();
if($_SESSION["priv"] == 1)                                      // Checks if the user has the privileges
{
    header("Location: search_fault_form_admin.php");            // If not redirects
    exit;
}

$error = $_GET["search"];                                       // Gets error value
showMessage($error);                                            // Displays error
?>