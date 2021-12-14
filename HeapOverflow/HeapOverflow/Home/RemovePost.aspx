<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RemovePost.aspx.cs" Inherits="HeapOverflow.Home.RemovePost" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>HeapOverflow</title>
	<link rel="stylesheet" href="../Resources/Css/Index.css" />
	<link rel="stylesheet" href="../Resources/Css/Register.css" />
	<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
	<script src="../Resources/Js/Index.js"></script>
</head>
<body>
	<form id="remove_post" runat="server">
		<header>
			<div class="navbar">
				<div class="brand">Heap Overflow</div>
			</div>
		</header>
		<div class="container">
			<center>
				<div class="login-body">
					<div class="login-label">Are you sure to remove Post? </div>
					<asp:Button ID="btn_remove" runat="server" Text="Remove" CssClass="btn-register-body" OnClick="btn_remove_Click" ></asp:Button>
				</div>
			</center>
		</div>

		<div class="forum-info">
			<div class="chart">
				Heap Overflow - Stats &nbsp;<i class="fa fa-bar-chart"></i>
			</div>
			<div>
				<span><u>5,359</u> Posts in <u>1,246</u> Topics by <u>45,215</u> Users</span>
			</div>
		</div>

		<footer>
			<span>&copy; &nbsp;Dunay Gudratli | All Rights Reserved.</span>
		</footer>
	</form>
</body>
</html>

