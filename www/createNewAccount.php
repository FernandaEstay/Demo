<!DOCTYPE html>
<html >
<head>
  <meta charset="UTF-8">
  <title>Account User</title>
      <link rel="stylesheet" href="css/style.css">
</head>
 <body>

 <?php
 	$userName = trim($_POST['UserName']);
 	$password = trim($_POST['Password']);
 	$Speed = trim($_POST['Speed']);
 	$time = trim($_POST['Time']);
 	$item = trim($_POST['Item']);

 	$url = "http://127.0.0.1/services/createUserAccount.php?UserName=".$userName."&Password=".$password."&Speed=".$Speed."&Time=".$time."&Item=".$item;
	$Data = file_get_contents($url);
	echo "<h1>".$Data."</h1>";
?>
</body>
</html>