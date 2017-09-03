<?php
	
	include 'conexionMysql.php';

	$getUser = "select * from user";
	print getJsonSQL($conexion, $getUser);
	

?>  