<?php
 // important function to allow session variables
 session_start();
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>Login</title>
</head>
<body>
    <?php
        
        //Duomenu bazes prisijungimo duomenys
        include 'dbconnect.php';
        
        try {
            if($_SERVER['REQUEST_METHOD'] == 'POST') //Ar vartotojas pateike prisijungimo duomenis
            {
                $conn = new PDO("mysql:host=$servername;dbname=$database", $username, $password); //Naujas prisijungimas
                // Naudojamas PDO metodas, Naudotas del taikomu apribojimu.
                $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
                
                
                // Issaugojamas vartotojo email is $_POST
                $user_email = $_POST['user_email'];
                // Issaugojamas vartotojo email is $_POST
                $user_password = $_POST['user_password'];
                
                //SQL uzklausa patikrinti ar vartotojas yra duomenu bazeje
                $sql = $conn->prepare("SELECT * FROM Users WHERE email = :email AND pword = :pword");
                $sql->bindParam(':email', $user_email);
                $sql->bindParam(':pword', $user_password);
                $sql -> execute(); //Vykdyti uzklausa
                
                if($sql->rowCount()) 
                    { //Tikrina ar yra rezultatai skaiciuojant eiles
                    
                        //Nustatoma sesija
                        $_SESSION['login'] = 1;

                        //Nustatoma vartotojo informacija is uzklausos
                        $row = $sql->fetch();

                        //Issaugojama vartotojo informacija i sesija
                        $_SESSION['user_id'] = $row['ID'];

                        //Nukreipia vartotoja i puslapi
                        header("Location: account_area.php");
                        
                    }
                else
                    {
                        echo "Wrong email or password";
                    }
                
            }
            else 
            {
                echo "You are here by mistake";
            }
        }
        catch(PDOException $e)
            {
                echo $e->getMessage();  //Jei neiseina kazka patikrinti gausime klaida
            }
        ?>


</body>
</html>