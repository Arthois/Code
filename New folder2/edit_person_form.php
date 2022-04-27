<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Edit a person</title>
    <script type="text/javascript" src="https://ff.kis.v2.scr.kaspersky-labs.com/FD126C42-EBFA-4E12-B309-BB3FDD723AC1/main.js?attr=j7EO_NtEW0XlRj7S63w_ywWnpcwTJg3Gm0Qdys40-3zLHxyzA54f19Tkv-lpmZxh8j0IlugCSYExZw6AugmBWi3ORx9FzNJj0hHzPTYZZCDIvuGHRIur3eBFQ_lgc7OB-i-bUz_wWIbJwJ3qVoVfJbdhh0k6oxtUeRnTUVvqIgs5ghm2u2kAOcmhceybT2_o1eFxeItHViKaVyBthQ6HdrT6tdAZhFgL2YUacmi8-oYv4-a2d_jmDVUoCCD4PI2bQcH56ubzUFkyN9m6JfPicLN1FpNSq4VkUfCdl70iNJUN49YxE2vwANdeBY2khtEUufRBcxsn1HxzYcLyucE670A54XFxYNozemb8jnWEUTgPYCu0VBiHjpy8hEpGh7lOGevJLrA-1FIApl3rdUiQ1AboFPW4igKvpWwNIKrZ0bfwUcAAtcf2Y844IPX4BhAK" charset="UTF-8"></script><link rel="stylesheet" crossorigin="anonymous" href="https://ff.kis.v2.scr.kaspersky-labs.com/E3E8934C-235A-4B0E-825A-35A08381A191/abn/main.css?attr=aHR0cHM6Ly9kb2MtMGctYWMtZG9jcy5nb29nbGV1c2VyY29udGVudC5jb20vZG9jcy9zZWN1cmVzYy81Y3M4b25wZjlpYWRvdHR1NWJybW9vOG44ZHVpOGQ1ai84bzk5YnJkdnZ0bnBmbWU2anA2bmJrdWszaTlhZzlxYi8xNjUxMDYwNjUwMDAwLzA0NTUxMjU1NzcxMjA2MDY0NDIxLzE1OTQ3MzAwMjgxOTUyMTAyNTY5Wi8xbjJGdVNFWGIyQlFQWFNEQ3FPU1ZoczNkOWVuY3JuSHA_ZT1kb3dubG9hZCZub25jZT01cWI1MTZuZTVuajJzJnVzZXI9MTU5NDczMDAyODE5NTIxMDI1NjlaJmhhc2g9Z3J1YXVqcjI5bGg1NzFpNm4xdmJxa21zOGttZTg0Z3A"/><style>
        body{
            font-family: Arial, Helvetica, sans-serif;
        }
    </style>
</head>
<body>
    <form action="edit_person.php" method="post">
        <p>Firstname</p>
        <input type="text" name= "first_name" value="<?php echo $firstname;?>">
        <p>Lastname</p>
        <input type="text" name= "last_name" value="<?php echo $lastname;?>">
        <p>Email</p>
        <input type="email" name= "email" value="<?php echo $email;?>">
        <p>Gender</p>
        <input type="text" name= "gender" value="<?php echo $gender;?>">
        <p>Occupation</p>
        <input type="text" name= "occupation" value="<?php echo $occupation;?>">
        <p>Skill</p>
        <input type="text" name= "skill" value="<?php echo $skill;?>">
        <p>Car</p>
        <input type="text" name= "car" value="<?php echo $car;?>">
        <p>Education</p>
        <input type="text" name= "education" value="<?php echo $education;?>">
        <input type="hidden" name= "id" value="<?php echo $id;?>">
        <br />
        <input type="submit" value="update">

    </form>
</body>
</html>