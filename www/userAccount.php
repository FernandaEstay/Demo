<!DOCTYPE html>
<html >
<head>
  <meta charset="UTF-8">
  <title>Account User</title>
      <link rel="stylesheet" href="css/style.css">
</head>
 
<?php
	if ( isset($_POST['userName']) && isset($_POST['password']) ){
		$jsonData = file_get_contents("http://127.0.0.1/services/getUser.php?userName=".$_POST['userName']."&password=".$_POST['password']);
		$user = json_decode($jsonData);
	}

?>

<body>
<form action="updateAccount.php" method="post" enctype="multipart/form-data">
	  <h2>My Account</h2>
	    <?php 
      		if(!empty($user))
			{
				foreach ($user as $key => $value) { 
				?>

		<p>
			<label class="floatLabel">ID</label>
			<input id="ID" name="ID" type="hidden" value="<?php echo $value->ID; ?> ">
		</p>
		<p>
			<label class="floatLabel">User Name</label>
			<input id="UserName" name="UserName" type="text" value="<?php echo $value->UserName; ?> ">
		</p>
		<p>
			<label class="floatLabel">Speed</label>
			<input id="Speed" name="Speed" type="text" value="<?php echo $value->Speed; ?> ">
		</p>
		<p>
			<label class="floatLabel">Time</label>
			<input id="Time" name="Time" type="text" value="<?php echo $value->Time; ?> ">
		</p>
		<p>
			<label class="floatLabel">Item Value</label>
			<input id="Item" name="Item" type="text" value="<?php echo $value->Item; ?> ">
		</p>
		<p>
			<label class="floatLabel">Score</label>
			<input id="Score" name="Score" type="text" disabled value="<?php echo $value->Score; ?> ">
		</p>
		<p>
			<input type="submit" value="Update My Account" id="submit">
		</p>
				<?php
				}
			}
		?>
		
</form>