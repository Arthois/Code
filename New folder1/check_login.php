<?php
session_start(); // Funkcija leidzianti "Ijungti" sesijas

if ($_SESSION['login'] != 1) {

    header("Location: login_form.html"); //Nukreipia i prisijungima

}
?>