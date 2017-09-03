<?php
	
	$conexion = mysqli_connect('localhost', 'root', '', 'gamedemo');

	function getJsonSQL($conexion, $sql){

		$sth = mysqli_query($conexion, $sql);

		if (!$sth) {
			printf("Errormessage: %s\n", mysqli_error($conexion));
		}

		$rows = array();

		$i = 0;
		while($r = mysqli_fetch_assoc($sth)) {
		    $rows[$i] = $r;
		    $i++;
		}

		return json_encode($rows);
	}

?>