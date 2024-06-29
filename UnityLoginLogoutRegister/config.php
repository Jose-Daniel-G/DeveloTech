<?php

$dbname = "dbgame";
$host = "localhost";
$username = "root";
$password = "";

$connection = mysqli_connect($host, $username, $password, $dbname);

// if ($mysqli->connect_errno) {
//     echo "Fallo al conectar a MySQL: (" . $mysqli->connect_errno . ") " . $mysqli->connect_error;
// }