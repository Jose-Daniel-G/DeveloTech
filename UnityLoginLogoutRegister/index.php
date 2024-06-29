<?php

include("config.php");

if (isset($_POST["username"])){
    $username = mysqli_real_escape_string($connection, $_POST["username"]);
    $password = mysqli_real_escape_string($connection, $_POST["password"]);
    //check they are empty?
    if ($username != "" && $password != "") {
        //Check if the username has not taken
        if (mysqli_num_rows(mysqli_query($connection, "SELECT * FROM users WHERE username = '$username'")) == 0) {
            mysqli_query($connection, "INSERT INTO users(username, password) VALUES('$username', '$password')");
            echo "Registrando nueva cuenta: Usuario ".$username." y contraseña: ".$password;
        }else{
            echo "Este usuario no esta disponible. Por favor cree otro usuario";
        }
    }else{
        echo "Ambos campos son requeridos";
    }

}else if (isset($_POST["loginUsername"])){
    $username = mysqli_real_escape_string($connection, $_POST["loginUsername"]);
    $password = mysqli_real_escape_string($connection, $_POST["loginPassword"]);
    //check they are empty?
    if ($username != "" && $password != "") {
        //Check are entered username and password matched
        $sql = "SELECT * FROM users WHERE username = '$username' AND password = '$password'";
        if (mysqli_num_rows(mysqli_query($connection, $sql)) > 0) {
            echo 1;
            // echo "Inicio exitoso! Usuario ".$username." y Contraseña ".$password;
        }else{
           echo 2;
            // echo "Fallo de Inicio! Usuario incorrecto o/y Contraseña";
        }
    }else{
        echo "Ambos campos son requeridos";
    }
}else{
    echo "Unity Login, Logout and Register";
}