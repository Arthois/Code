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
        
        //Duomenu bazes prisijungimo Duomenys 
        include 'dbconnect.php';
        
        try {
            if($_SERVER['REQUEST_METHOD'] == 'POST') //Ar vartotjas atnaujintas?
            {
                
                $conn = new PDO("mysql:host=$servername;dbname=$database", $username, $password); //Naujas prisijungimas
                // Naudojamas PDO metodas
                $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
                
                $id = $_POST['id']; //ID kuri norime atnaujinti ar pakeisti
                //Kita informacija is ankstesnes formos
                $first_name = $_POST['first_name'];
                $last_name = $_POST['last_name'];
                $email = $_POST['email'];
                $gender = $_POST['gender'];
                $occupation = $_POST['occupation'];
                $skill = $_POST['skill'];
                $car = $_POST['car'];
                $education = $_POST['education'];
                
                // Paruosiamas SQL UPDATE uzklausa
                $sql = $conn->prepare("UPDATE t_people SET first_name = :firstname, last_name = :lastname, email = :email, gender = :gender, occupation = :occupation, skill = :skill, car = :car, education = :education WHERE id = :id");
                $sql -> bindParam(':firstname', $first_name);
                $sql -> bindParam(':lastname', $last_name);
                $sql -> bindParam(':email', $email);
                $sql -> bindParam(':gender', $gender);
                $sql -> bindParam(':occupation', $occupation);
                $sql -> bindParam(':skill', $skill);
                $sql -> bindParam(':car', $car);
                $sql -> bindParam(':education', $education);
                $sql -> bindParam(':id', $id);
                
                $sql -> execute(); //Vykdoma
                
                echo "Person updated";
            }
            else{
                $conn = new PDO("mysql:host=$servername;dbname=$database", $username, $password); //Naujas prisijungimas
                // Naudojamas PDO metodas
                $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);

                $id = $_GET['id']; //ID vartotojo kuri norime kaip nors pakeisti
                
                $sql = $conn->prepare("SELECT * FROM t_people WHERE id = :id");
                $sql -> bindParam(':id', $id); 

                $sql -> execute(); //Vykdyti

                

                $row = $sql->fetch();
                $firstname = $row['first_name'];
                $lastname = $row['last_name'];
                $email = $row['email'];
                $gender = $row['gender'];
                $occupation = $row['occupation'];
                $skill = $row['skill'];
                $car = $row['car'];
                $education = $row['education'];
                //Naudojam Include kad prideti visa esama informacija apie vartotoja
                include "edit_person_form.php";

                
            }
        }
        catch(PDOException $e)
            {
            echo $e->getMessage(); //Jei nepavyks prisijungti ar uzklausa bloga matysime klaida
            }
        ?>


</body>
</html>