<?php
	
	include('conexionMysql.php');

	if( !empty( $_GET ) ){
		$updateUser = "update user set UserName = '".$_GET['UserName']."', Speed =  ".$_GET['Speed'].", Time = ".$_GET['Time'].", Item = ".$_GET['Item']." where ID = ".$_GET['ID'].";";
		$user = "select * from user;";

		$sth = mysqli_query($conexion, $updateUser);

		if (!$sth) {
			echo "Fallo";
			printf("Errormessage: %s\n", mysqli_error($conexion));
		}
		else{
			echo "Cuenta actualizada correctamente";
		}
	}

?>  