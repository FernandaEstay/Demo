<!DOCTYPE html>
<html >
<head>
  <meta charset="UTF-8">
  <title>Create Account </title>
      <link rel="stylesheet" href="css/style.css">
</head>
 
<body>
<form action="createNewAccount.php" method="post" enctype="multipart/form-data">
	  <h2>Create Account</h2>
		<p>
			<label class="floatLabel">User Name</label>
			<input id="UserName" name="UserName" type="text">
		</p>
		<p>
			<label class="floatLabel">Password</label>
			<input id="Password" name="Password" type="password">
		</p>
		<p>
			<label class="floatLabel">Speed</label>
			<input id="Speed" name="Speed" type="text" >
		</p>
		<p>
			<label class="floatLabel">Time</label>
			<input id="Time" name="Time" type="text" >
		</p>
		<p>
			<label class="floatLabel">Item Value</label>
			<input id="Item" name="Item" type="text" >
		</p>
		<p>
			<input type="submit" value="Create My Account" id="submit">
		</p>

</form>