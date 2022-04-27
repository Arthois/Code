<?php
session_start(); // Sesiju funkcija 

//include 'check_login.php'; //Kolkas isjungta

?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>View orders</title>
<style>
    body{
        font-family:tahoma;
        background-color:#eee;

    }
    a.button {
        
        padding:5px;
        background-color:green;
        color:white;
        border-radius:3px;
        margin-top:3px;
        display:block;
        width:130px;
        text-decoration:none;
    }
    a.dbutton {
        
        padding:5px;
        background-color:red;
        color:white;
        border-radius:3px;
        margin-top:3px;
        display:block;
        width:130px;
        text-decoration:none;
    }
</style>
</head>

<body>
    <table>
        <tr>
            <th>ID</th><th>Firstname</th><th>Lastname</th><th>Email</th><th>Gender</th><th>Occupation</th><th>Skill</th><th>Car</th><th>Education</th><th>Edit</th><th>Delete</th>
        </tr>
    <?php
        
        //Duomenu bazes prisijungimo duomenys
       include 'dbconnect.php';
        
        try {
            $conn = new PDO("mysql:host=$servername;dbname=$database", $username, $password); ////Naujas prisijungimas
            // Naudojamas PDO metodas, Naudotas del taikomu apribojimu.
            $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
            //SQL uzklausa naudojant PDO::query funkcija.
            $sql = "SELECT * FROM t_people ORDER BY id DESC LIMIT 50";
            // Kiekvienas gautas rezultatas pereina per For Loop ir pradeda pildyti lentele  
            // $row yra Array su informacija gauta is kiekvienos SELECT uzklausos
                foreach($conn->query($sql, PDO::FETCH_ASSOC) as $row){
                    echo '<tr>';
                    echo '<td>'. $row['id'] . '</td>';
                    echo '<td>'. $row['first_name'] . '</td>';
                    echo '<td>'. $row['last_name'] . '</td>';
                    echo '<td>'. $row['email'] . '</td>';
                    echo '<td>'. $row['gender'] . '</td>';
                    echo '<td>'. $row['occupation'] . '</td>';
                    echo '<td>'. $row['skill'] . '</td>';
                    echo '<td>'. $row['car'] . '</td>';
                    echo '<td>'. $row['education'] . '</td>';
                    
                    // Naudojant echo prideda nuorodas prideti ir istrinti naudojant ID 
                    echo '<td><a href="edit_person.php?id='.$row['id'].'" class="button">Edit this person</a></td>';
                    echo '<td><a href="delete_person.php?id='.$row['id'].'" class="dbutton" onclick="return confirm(\'Are you sure you want to delete this item?\');">Delete this person</a></td>';
                    echo '</tr>';
                }
            
            }
        catch(PDOException $e)
            {
            echo $sql . "<br>" . $e->getMessage(); //Nepavykus gausime klaida
            }
        ?>


</body>
</html>