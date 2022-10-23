<?php
function invalidUser($user)                     //Function for checking if the username contains any symbols we chose to restrict
{
    if(!preg_match("/^[a-zA-Z0-9]*$/", $user))
    {
        return true;
    }
}

function pwdMatch($pwd, $rpwd)                  // Function for checking if the passwords match in the sign up page
{
    if($pwd !== $rpwd)
    {
        return false;
    }
    else
    {
        return true;
    }
}

function invalidPwd($pwd)                       // Function for checking if the password is atleast 6 characters long
{
    (int)$count = strlen($pwd);
    return $count;
}

function userTaken($conn, $user)                // Function for checking if the username is not already registered
{
    try {
        include 'dbconnect.php';
        $conn = new PDO("mysql:host=$servername;dbname=$database", $username, $password);       // Creates new PDO connection
        $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);                         // Sets PDO error mode 
        $sql = $conn->prepare("SELECT * FROM users WHERE user_name = '$user';");                // SQL query for checking if username is registered
        $sql->bindParam(':user', $user);                                                        // Binds :user with the $user variable
        $sql->execute();                                                                        // executes the query

        if($sql->rowCount())
        {                                                                                       
            $row = $sql->fetch();                                                               // Fetches results
            $_SESSION["user"] = $row["user_name"];                                              // Sets Session variable
            if($user == $row["user_name"])                                                      // If user Exists in the Db
            {
                return true;                                                                    // Returns true
            }
            else
            {
                return false;                                                                   // If user does not exist in the DB returns false
            }
            
        }
    }
    catch(PDOException $e)                                                                      // Catches any errors if any
    {
        echo $e->getMessage();                                                                  // Retrieves and displays message 
    }
}

function addUser($user, $pwd)                                                                   // Function to add a simple user
{
    try                                                                                         // Tries to run code below 
    {
        include 'dbconnect.php';
        $priv = 0;                                                                              // Sets user privileges
        $conn = new PDO("mysql:host=$servername;dbname=$database", $username, $password);       // Creates new PDO connection
        $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);                         // Sets PDO error mode
        $sql = $conn->prepare("INSERT INTO users (ID, user_name, password, priv) VALUES (ID = NULL, :user, :password, :priv)"); // SQL query for adding the user to the DB
        $hashed = password_hash($pwd, PASSWORD_DEFAULT);
        $sql->bindParam(':user', $user);
        $sql->bindParam(':password', $hashed);                                                  // Binds all the :variables with $variables
        $sql->bindParam(':priv', $priv);
        $sql -> execute();                                                                      // Executes query
        header("Location: login_form.php");                                                     // Redirects the user if user added succesfully
        exit();
    }
    catch(PDOException $e)                                                                      // Catches errors if any
    {   
        echo $e->getMessage();                                                                  // Retrieves and displays error
    }
}

function lastLogin()                                                                            // Function for getting the last user login
{
    include 'dbconnect.php';
    $sql= $conn->prepare("SELECT Date_Time FROM logins WHERE UID=:uid ORDER BY logins.Date_Time DESC");
    $sql->bindParam(":uid", $_SESSION["uid"]);
    $sql->execute();
    $row = $sql->fetch();
    $_SESSION["last_login"] = $row["Date_Time"];
}

function logLogin()                                                                             // Function for storing the time of login to login DB
{
    include 'dbconnect.php';
    $sql = $conn->prepare("INSERT INTO logins (`ID`, `UID`, `User_Name`, `Date_time`, `Privs`) VALUES (NULL, :uid, :user, current_timestamp(), :priv)");
    $sql->bindParam(":uid", $_SESSION["uid"]);
    $sql->bindParam(":user", $_SESSION["user"]);
    $sql->bindParam(":priv", $_SESSION["priv"]);
    $sql->execute();
}

function myReportsNo()                                                                          // Function for returning the number of user made reports
{
    session_start();
    $uid = $_SESSION["uid"];
    try
    {
        include 'dbconnect.php';
        $conn = new PDO("mysql:host=$servername;dbname=$database", $username, $password);
        $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
        $sql = $conn->prepare("SELECT COUNT(*)FROM faults WHERE USer_ID = :uid");
        $sql->bindParam(":uid", $uid);
        $sql->execute();
        $num = $sql->fetchColumn();
        return $num;
    }
    catch(PDOException $e)
    {
       echo "Error: " . $e->getMessage();
    }
}

function checkLogin()
{
    session_start();
    if(!isset($_SESSION['login']) || $_SESSION['login'] != 1)           //Checks if the user is logged in if not redirects
    {
        header("Location: login_form.php?error=nologin");
        exit;
    }
}

function checkPrivs()
{
    if($_SESSION["priv"] != 1)                                          // Checks if the user has required privileges if not redirects
    {   
        header("Location: user_account_area.php?error=nopriv");
        exit;
    }

}

function changePrivs()
{
    checkLogin();                                                       // Checks if the user is logged in
    $id = $_GET["ID"];
    if($id == "")                                                       // Checks if ID is not empty
    {
        header("Location: mng_users.php?error=noid");                   // If its empty redirects
        exit;
    }
    try
    {
        include 'dbconnect.php';
        $conn = new PDO("mysql:host=$servername;dbname=$database", $username, $password);       // Creates a new PDO connection
        $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);                         // Sets PDO error mode
        $sql = $conn->prepare("SELECT priv FROM users WHERE ID = :id");                         // SQL query
        $sql->bindParam(":id", $id);                                                            // Binds :id to $id
        $sql->execute();                                                                        // Executes
        $privs = $sql->fetchColumn();                                                           // Stores the result
        if ($privs == 1)                                                                        // Checks what are current privileges
        {
            include 'dbconnect.php';
            $priv = 0;                                                                          // If admin privileges sets to regular user privileges
            $conn = new PDO("mysql:host=$servername;dbname=$database", $username, $password);   // Creates a new PDO connection MOST LIKELY dont need to do that cause already have an connection made before
            $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);                     // Sets PDO error mode
            $sql = $conn->prepare("UPDATE users SET priv = :priv WHERE ID = :id");              // SQL query
            $sql->bindParam(":priv", $priv);                                                    // Binds :variables with $variables
            $sql->bindParam(":id", $id);
            $sql->execute();                                                                    // Executes query
        }
        if ($privs == 0)                                                                        // If regular user priveleges changes do admin privileges further on
        {
            include 'dbconnect.php';
            $priv = 1;                                                                          // Sets privileges to admin
            $conn = new PDO("mysql:host=$servername;dbname=$database", $username, $password);   // Creates a new PDO connection MOST LIKELY dont need to do that cause already have an connection made before
            $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);                     // Sets PDO error mode
            $sql = $conn->prepare("UPDATE users SET priv = :priv WHERE ID = :id");              // Binds :variables with $variables
            $sql->bindParam(":priv", $priv);
            $sql->bindParam(":id", $id);
            $sql->execute();                                                                    // Executes query
        }
    }
    catch(PDOException $e)
    {
        echo "Error: " . $e->getMessage();                                                      // Retrieves and displays errors if any
    }    
}

function deleteUser()
    {   
    checkLogin();                                                       // Checks if the user is logged in
    checkPrivs();                                                       // Checks if the user hasthe required privileges
    $id = $_GET["ID"];                                                  // Gets id of the column

    if($id == "")                                                       // Checks if ID is not empty
    {
        header("Location: mng_users.php?error=noid");                   // If its empty redirects
        exit;
    }
    try
    {
        include 'dbconnect.php';                                                                // DB credentials
        $conn = new PDO("mysql:host=$servername;dbname=$database", $username, $password);       // Crestes a new PDO connection
        $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);                         // Sets PDO error mode
        $sql = $conn->prepare("DELETE FROM users WHERE ID = :id");                              // SQL query
        $sql->bindParam(":id", $id);                                                            // Binds :id to $id
        $sql->execute();                                                                        // Executes query
    }
    catch(PDOException $e)
    {
        echo "Error: " . $e->getMessage();                                                      // Retrieves and displays errors if any
    }
}

function showMessage($error)                                        // Functions for various erros retrieved through $_GET[]
{                                                                   // Fairly self explanatory no further comments needed for them..?
    if(isset($error))
    {
        if($error == "wronglogin")
        {
            echo "<p>Incorrect User Credentials. Try Again.</p>";
        }

        if($error == "invaliduser")
        {
            echo "<p>Symbols are not allowed in the username</p>";
        }

        if($error == "pwdnomatch")
        {
            echo "<p>Passwords do not match</p>";
        }

        if($error == "pwdtooshort")
        {
            echo "<p>Password must be at least 6 characters</p>";
        }

        if($error == "usertaken")
        {
            echo "<p>Username Taken, Please choose a different one</p>";
        }

        if($error == "nologin")
        {
            echo "<p>You Are Logged Out, Please Log In</p>";
        }

        if($error == "OK")
        {
            echo "<p>Report Has Been Sent Out Successfully</p>";
        }

        if($error == "NO")
        {
            echo "<p>Report Not Sent. Contact Support</p>";
        }

        if($error == "nosearch")
        {
            echo "<p>No Searching Criteria</p>";
        }

        if($error == "nofound" )
        {
            echo "<p>Could Not Find Anything</p>";
        }

        if($error == "ok")
        {
            echo "<p>Fault Updated Succesfully</p>";
        }

        if($error == "nosubmit")
        {
            echo "<p>Fault Must be Updated By Pressing Update Button</p>";
        }
    }
}
?>