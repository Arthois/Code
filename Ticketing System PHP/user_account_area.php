<?php
include 'functions.php';
session_start();
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">          <!-- Metadata -->
    <link rel="stylesheet" href="style.css">
    <title>User Area</title>
</head>
<body>
<nav>
    <div class="topnav">
        <a class="active" href="user_account_area.php">My Account</a>
        <a href="report_fault_form.php">Report Fault</a>
        <a href="view_my_reported_faults.php">My Reports</a>                        <!-- Navigation Bar -->
        <a href="view_all_faults.php">All Faults</a>
        <a href="search_fault_form.php">Search Faults</a>
        <a href="logout.php">Log Out</a>
    </div>
</nav>
<h1>Hello <?php echo $_SESSION["user"]?></h1>                                       <!-- Greets current user -->
<p2>Your Reports: <?php echo myReportsNo() ?></p2><br>                              <!-- Gets the number of reports the user has made -->
<p2>Last Login: <?php echo $_SESSION["last_login"]?></p2><br>                       <!-- Displays the last known login -->
<p2>Curren User: <?php echo $_SESSION["user"]?></p2>                                <!-- Displays current user -->
</body>
</html>
<?php
checkLogin();                                                   // Checks if the user is logged in
if($_SESSION["priv"] == 1)                                      // Checks if the user is admin
{
    header("Location: admin_account_area.php");                 // If so redirects
    exit;
}
?>