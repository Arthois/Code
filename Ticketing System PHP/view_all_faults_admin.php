<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">          <!-- Metadata -->
    <link rel="stylesheet" href="style.css">
    <title>All Faults</title>
</head>
<body>
<nav>
    <div class="topnav">
        <a class="active" href="admin_account_area.php">My Account</a>
        <a href="report_fault_form_admin.php">Report Fault</a>
        <a href="view_my_reported_faults_admin.php">My Reports</a>
        <a href="view_all_faults_admin.php">All Faults</a>                          <!-- Navigation Bar -->
        <a href="search_fault_form_admin.php">Search Faults</a>
        <a href="mng_users.php">Manage Users</a>
        <a href="logout.php">Log Out</a>
    </div>
</nav>
<div class="container">
<table>
    <thead>                 <!-- Table heads below -->
        <tr>
            <th>ID</th><th>Title</th><th>Description</th><th>Location</th><th>Date</th><th>Fault Status</th><th>Job Complete</th><th>Edit</th><th>Delete</th>
        </tr>
    </thead>
    <tbody>
        <?php
        include 'functions.php';
        session_start();                                                // Enables session variables
        checkLogin();
        checkPrivs();
        $uid = $_SESSION["uid"];                                        // Gets user id from sessions variable
        
        include 'dbconnect.php';

        $count = 0;                                                     // Starts counter


        
        try {
            $conn = new PDO("mysql:host=$servername;dbname=$database", $username, $password); //building a new PDO connection object
            
            $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION); // set the PDO error mode to exception
            
            $sql = "SELECT * FROM faults";                                  // SQL query
            
            foreach($conn->query($sql, PDO::FETCH_ASSOC) as $row)           // For everytime we go through the table loads the columns in the $row array
            {
                $count++;                                                   // itterates the counter with each go
                echo '<tr>';
                echo '<td>'. $row['ID'] . '</td>';
                echo '<td>'. $row['Title'] . '</td>';
                echo '<td>'. $row['Description'] . '</td>';                 // Displays the data in columns adding a new row with each go
                echo '<td>'. $row['Location'] . '</td>';
                echo '<td>'. $row['Date_Time'] . '</td>';
                echo '<td>'. $row['Fault_Status'] . '</td>';
                echo '<td>'. $row['Job_Complete'] . '</td>';
                echo '<td><a href="edit_fault_form.php?ID='.$row['ID'].'" class="button">Edit Fault</a></td>';      // Edit button
                echo '<td><a href="delete_faults.php?ID='.$row['ID'].'" class="dbutton" type="submit" onclick="return confirm(\'Are you sure you?\');">Delete Fault</a></td>'; // Delete button
                echo '</tr>';
            }
            echo "<p1 class='results'>Results found: $count</p1>"; // Displays result count, through CSS sorcery displays the count above the table
        }
        catch(PDOException $e)               // Catches errors if any
        {
            echo "Error" . $e->getMessage(); //Retrieves and displays error
        }
        ?>
    </tbody>
</table>
</div>
</body>
</html>