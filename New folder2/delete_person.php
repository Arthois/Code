<?php
session_start();

//include 'checklogin.php';
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>Document</title>
    
    <style>
    body{
        font-family:tahoma;
        background-color:#eee;

    }
    input[type=submit] {
        font-size:110%;
        background-color:green;
        color:white;
        border-radius: 4px;
    }
    select {
        width: 100%;
        padding: 16px 20px;
        border: none;
        border-radius: 4px;
        background-color: #fff;
        font-size:110%;
        margin:5px 0 5px 0;
        border:1px solid #333;
        }
</style>
</head>
<body>
    <?php
        
        //Duomenu bazes prisijungimo duomenys
        include 'dbconnect.php';
        
        try {
            
                
                $conn = new PDO("mysql:host=$servername;dbname=$database", $username, $password); //Naujas prisijungimas
                // Naudojamas PDO metodas
                $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);

                $id = $_GET['id']; //Vartojo ID kuri norime keisti
                
                $sql = $conn->prepare("DELETE FROM t_people WHERE id = :id");
                $sql -> bindParam(':id', $id); 

                $sql -> execute(); //Vykdyti

                echo 'Person deleted';
            }
        catch(PDOException $e)
            {
            echo $e->getMessage(); //Jei bloga uzklausa ar prisijungimas matysime klaida
            }
        ?>


</body>
</html>