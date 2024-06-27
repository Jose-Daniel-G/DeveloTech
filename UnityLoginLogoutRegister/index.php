<?php

include("config.php");

if (isset($_POST["username"])){
    $username = mysqli_real_escape_string($connection, $_POST["username"]);
    $password = mysqli_real_escape_string($connection, $_POST["password"]);
    //check they are empty?
    if ($username != "" && $password != "") {
        mysqli_query($connection, "INSERT INTO users(username, password) VALUES('$username', '$password')");
        echo "Registrando nueva cuenta: Usuario ".$username." y contraseña: ".$password;
    }else{
        echo "Ambos campos son requeridos";
    }

// }else if (isset($_POST["LoginUsername"])){
//     $username = mysqli_real_escape_string($connection, $_POST["loginUsername"]);
//     $username = mysqli_real_escape_string($connection, $_POST["loginPassword"]);
//     //check they are empty?
//     if ($username != "" && $password != "") {
//         mysqli_query($connection, "INSERT INTO users(username, password) VALUES('$username', '$password')");
//         echo "Iniciando sesión: Usuario ".$username." y contraseña: ".$password;
//     }else{
//         echo "Ambos campos son requeridos";
//     }
}else{
    echo "Unity Login, Logout and Register";
}