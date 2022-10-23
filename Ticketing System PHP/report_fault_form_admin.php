<!DOCTYPE html>
<html lang="en">
<head>
<meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">      <!-- Metadata -->
    <link rel="stylesheet" href="style.css">
    <title>Report Fault</title>
</head>
<body>
<nav>
    <div class="topnav">
        <a class="active" href="user_account_area.php">My Account</a>
        <a href="report_fault_form_admin.php">Report Fault</a>
        <a href="view_my_reported_faults.php">My Reports</a>                    <!-- Navigation Bar -->
        <a href="view_all_faults.php">All Faults</a>
        <a href="search_fault_form.php">Search Faults</a>
        <a href="mng_users.php">Manage Users</a>
        <a href="logout.php">Log Out</a>
    </div>
</nav>
    <div class="report-form-form">                                              <!-- Fault reporting form -->
        <form action="report_fault.php" method="POST">                          <!-- Information snet forward with $_POST -->
            <p>Faults Title</p>
            <input type="text" style="margin-top: 10px;" name="title" placeholder="Title.. 15char" maxlength="15" required>
            <br>
            <p>Faults Location</p>
            <input type="text" style="margin-top: 10px;" name="location" placeholder="Location.. 15char" maxlength="15" required>
            <br>
            <p>Short Faults Description</p>
            <textarea type="text" style="margin-top: 10px;" name="description" placeholder="Fault Description.. 40char" maxlength="40" required></textarea>
            <br>
            <button type="submit" style="margin-top: 10px;margin-right:250px;" name="submit">Report Fault</button>
            <button type="reset" style="margin-top: 10px;" name="clear">Clear Form</button>
        </form>
    </div>
</body>
</html>
<?php
session_start();
require_once 'functions.php';                                   // Functions

checkLogin();
checkPrivs();
$report = $_GET["report"];                                      // Gets any error value
showMessage($report);                                           // Displays error according to error value
?>