<!DOCTYPE html>
<html >
<head>
  <meta charset="UTF-8">
  <title>Page Game-Demo</title>
      <link rel="stylesheet" href="css/style.css">
</head>
 
<body>
<form action="userAccount.php" method="post" enctype="multipart/form-data">
	  <h2>Login</h2>
		<p>
			<label for="userName" class="floatLabel">User Name</label>
			<input id="userName" name="userName" type="text">
		</p>
		<p>
			<label for="password" class="floatLabel">Password</label>
			<input id="password" name="password" type="password">
		</p>
		<p>
			<input type="submit" value="Login" id="submit">
		</p>
		
</form>
<form action="createAccount.php" method="post" enctype="multipart/form-data">
	<p>
		<input type="submit" value="Create My Account" id="submit">
	</p>
</form>
<br><br>
<div id="wrapper">
  <h1>Users Game Data </h1>
  
  <table id="keywords" cellspacing="0" cellpadding="0">
    <thead>
      <tr>
        <th><span>ID</span></th>
        <th><span>UserName</span></th>
        <th><span>Speed</span></th>
        <th><span>Time</span></th>
        <th><span>Item</span></th>
        <th><span>Score</span></th>
      </tr>
    </thead>
    <tbody>
      	<?php 
      		$jsonData = file_get_contents("http://127.0.0.1/services/getAllUsers.php");
      		if(!empty($jsonData))
			{
				$users = json_decode($jsonData);

				foreach ($users as $key => $value) { ?>
					<tr>
						<td> <?php echo $value->ID; ?> </td>
						<td> <?php echo $value->UserName; ?> </td>
						<td> <?php echo $value->Speed; ?> </td>
						<td> <?php echo $value->Time; ?> </td>
						<td> <?php echo $value->Item; ?> </td>
						<td> <?php echo $value->Score; ?> </td>
					</tr>
				<?php
				}
			}
		?>
       </tr>
    </tbody>
  </table>
 </div> 




  <script src='http://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js'></script>

    <script src="js/index.js"></script>

</body>
</html>
