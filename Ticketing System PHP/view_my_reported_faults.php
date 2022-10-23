<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">              <!-- Metadata -->
    <link rel="stylesheet" href="style.css">
    <title>My Reports</title>
</head>
<body>
<nav>
    <div class="topnav">
        <a class="active" href="user_account_area.php">My Account</a>
        <a href="report_fault_form.php">Report Fault</a>
        <a href="view_my_reported_faults.php">My Reports</a>                            <!-- Navigation Bar -->
        <a href="view_all_faults.php">All Faults</a>
        <a href="search_fault_form.php">Search Faults</a>
        <a href="logout.php">Log Out</a>
    </div>
</nav>
<div class="container">
<table>
    <thead>                                                                             <!-- Table Heads below -->
        <tr>
            <th>ID</th><th>Title</th><th>Description</th><th>Location</th><th>Date</th><th>Fault Status</th><th>Job Complete</th>
        </tr>
    </thead>
    <tbody>
        <?php
        include 'functions.php';
        session_start();                                                        // Enables session variables
        checkLogin();                                                           // Checks if the user is logged in
        if($_SESSION["priv"] == 1)                                              // Checks if the user has admin privileges
        {   
            header("Location: view_my_reported_faults_admin.php");              // If so redirects
            exit;
        }
        $uid = $_SESSION["uid"];
        include 'dbconnect.php';
        $count = 0;                                                             // Starts counter


        try 
        {
            $conn = new PDO("mysql:host=$servername;dbname=$database", $username, $password);   // Creates new PDO connection
            $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);                     // Sets PDO error mode
            $sql = "SELECT * FROM faults WHERE User_ID = $uid";                                 // SQL query
            
            foreach($conn->query($sql, PDO::FETCH_ASSOC) as $row)                               // For everytime we go through the table loads the columns in the $row array
            {
                $count++;                                                                       // Itterates counter with every go
                echo '<tr>';
                echo '<td>'. $row['ID'] . '</td>';
                echo '<td>'. $row['Title'] . '</td>';                                           // Displays data in columns 
                echo '<td>'. $row['Description'] . '</td>';
                echo '<td>'. $row['Location'] . '</td>';
                echo '<td>'. $row['Date_Time'] . '</td>';
                echo '<td>'. $row['Fault_Status'] . '</td>';
                echo '<td>'. $row['Job_Complete'] . '</td>';
                echo '</tr>';
            }
            echo "<p1 class='results'>Results found: $count</p1>";          // Displays result count, through CSS sorcery displays the count above the table
        }
        catch(PDOException $e)                          // Catches errors if any
        {
            echo "Error" . $e->getMessage();            // Retrieves and displays errors
        }
        ?>
    </tbody>
</table>
</div>
</body>
</html>