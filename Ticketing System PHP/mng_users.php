<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">              <!-- Metadata -->
    <link rel="stylesheet" href="style.css">
    <title>User Management</title>
</head>
<body>
<nav>
    <div class="topnav">
        <a class="active" href="admin_account_area.php">My Account</a>
        <a href="report_fault_form_admin.php">Report Fault</a>
        <a href="view_my_reported_faults_admin.php">My Reports</a>                            <!-- Navigation Bar -->
        <a href="view_all_faults_admin.php">All Faults</a>
        <a href="search_fault_form_admin.php">Search Faults</a>
        <a href="mng_users.php">Manage Users</a>
        <a href="logout.php">Log Out</a>
    </div>
</nav>
<div class="container">
<table>
    <thead>                                                                             <!-- Table Heads below -->
        <tr>
            <th>ID</th><th>Username</th><th>Privileges</th><th> </th><th> </th>
        </tr>
    </thead>
    <tbody>
        <?php 
            include 'functions.php';
            session_start();                                                        // Enables session variables
            checkLogin();                                                           // Checks if the user is logged in
            checkPrivs();                                                           // Checks if the user has the required privileges

            $uid = $_SESSION["uid"];
            include 'dbconnect.php';
            $count = 0;                                                             // Starts counter
            try
            {
                $conn = new PDO("mysql:host=$servername;dbname=$database", $username, $password);   // Creates a new PDO connection
                $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);                     // Sets PDO error mode
                $sql = "SELECT * FROM users";                                                       // SQL query
        
                foreach($conn->query($sql, PDO::FETCH_ASSOC) as $row)                               // For each row the query returns stores them in the $row array
                {
                    $count++;                                                                       // Itterates the counter with each row returned
                    echo '<tr>';
                    echo '<td>'. $row["ID"] . '</td>';
                    echo '<td>'. $row["user_name"] . '</td>';                                       // Displays the data retrieved
                    echo '<td>'. $row["priv"] . '</td>';
                    echo '<td><a href="delete_user.php?ID='.$row['ID'].'" class="dbutton" onclick="return confirm(\'Are you sure you?\');">Remove User</a></td>';  // Delete button with relevant links for functionality
                    echo '<td><a href="change_privs.php?ID='.$row['ID'].'" class="button" onclick="return confirm(\'Are you sure you?\');">Change Privileges</a></td>'; // Changes privileges button with relevant links for functionality
                    echo '</tr>';
                }
                echo "<p1 class='results'>Results found: $count</p1>";                              // With some CSS sorcery displays the result number at the top of the table
            }
            catch(PDOException $e)
            {
                echo "Error: " . $e->getMessage();                                                  // Retrieves and displays errors if any
            }
        ?>
        </tbody>
</table>
</div>
</body>
</html>