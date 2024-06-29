<?php

include("config.php");

// REGISTER
if (isset($_POST["username"])) {
    $username = mysqli_real_escape_string($connection, $_POST["username"]);
    $password = mysqli_real_escape_string($connection, $_POST["password"]);
    // Verificar que los campos no estén vacíos
    if ($username != "" && $password != "") {
        // Verificar si el nombre de usuario no está tomado
        if (mysqli_num_rows(mysqli_query($connection, "SELECT * FROM users WHERE username = '$username'")) == 0) {
            // Encriptar la contraseña
            $hashedPassword = password_hash($password, PASSWORD_DEFAULT);

            // Insertar el usuario con la contraseña encriptada
            mysqli_query($connection, "INSERT INTO users(username, password) VALUES('$username', '$hashedPassword')");
            echo "Registrando nueva cuenta: Usuario " . $username;
        } else {
            echo "Este usuario no está disponible. Por favor cree otro usuario.";
        }
    } else {
        echo "Ambos campos son requeridos.";
    }

// LOGIN
} else if (isset($_POST["loginUsername"])) {
    $username = mysqli_real_escape_string($connection, $_POST["loginUsername"]);
    $password = mysqli_real_escape_string($connection, $_POST["loginPassword"]);
    // Verificar que los campos no estén vacíos
    if ($username != "" && $password != "") {
        // Buscar el usuario en la base de datos
        $sql = "SELECT * FROM users WHERE username = '$username'";
        $result = mysqli_query($connection, $sql);

        if (mysqli_num_rows($result) > 0) {
            $user = mysqli_fetch_assoc($result);
            // Verificar la contraseña encriptada
            if (password_verify($password, $user['password'])) {
                echo 1; // Inicio exitoso
                // Aquí puedes iniciar la sesión y redirigir al usuario a la página deseada
                session_start();
                $_SESSION['username'] = $username;
                // header("Location: dashboard.php"); // Redirigir a la página de inicio después de iniciar sesión
                // exit();
            } else {
                echo 2; // Contraseña incorrecta
            }
        } else {
            echo 3; // Usuario no encontrado
        }
    } else {
        echo "Ambos campos son requeridos.";
    }
} else {
    echo "Unity Login, Logout and Register";
}
?>
