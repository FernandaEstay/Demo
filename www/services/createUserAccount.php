<?php
	
	include('conexionMysql.php');

	if( !empty( $_GET ) )
	{
		$createUser = "INSERT INTO user (UserName, Password , Speed, Time, Item, Score) VALUES ('".$_GET['UserName']."','".$_GET['Password']."',".$_GET['Speed'].",".$_GET['Time'].",".$_GET['Item'].",0);";

		$sth = mysqli_query($conexion, $createUser);

		if (!$sth) {
			echo "Fallo";
			printf("Errormessage: %s\n", mysqli_error($conexion));
		}
		else{
			echo "Cuenta creada correctamente";
		}
	}

?>  