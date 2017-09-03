<?php
	
	include('conexionMysql.php');

	if( !empty( $_GET ) ){
		$getUser = "select * from user where UserName = '".$_GET['userName']."' and Password = '".$_GET['password']."'";
		print getJsonSQL($conexion, $getUser);
	}

?>  