<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HeapOverflow.Auth.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>HeapOverflow</title>
	<link rel="stylesheet" href="../Resources/Css/Index.css" />
	<link rel="stylesheet" href="../Resources/Css/Login.css" />
	<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
	<script src="../Resources/Js/Index.js"></script>
	<script src="../Resources/Js/Login.js"></script>
</head>
<body>
	<form id="login" runat="server">
		<header>
			<div class="navbar">
				<nav class="navigation hide" id="navigation">
					<ul class="nav-list">
						<span class="close-icon" onclick="showIconBar()"><i class="fa fa-close"></i></span>
						<li class="nav-item">
							<asp:Button ID="btn_home" runat="server" Text="Home" OnClick="btn_home_Click" />
						</li>
					</ul>
				</nav>
				<a href="#" class="bar-icon" id="iconBar"><i class="fa fa-bars" onclick="hideIconBar()"></i></a>
				<div class="brand">Heap Overflow</div>
				<div class="account">
					<asp:Button ID="btn_login" runat="server" Text="Login" CssClass="login" OnClick="btn_login_Click" />
					<asp:Button ID="btn_register" runat="server" Text="Register" CssClass="register" OnClick="btn_register_Click" />
					<asp:Button ID="btn_logout" runat="server" Text="Logout" CssClass="logout" />
				</div>
			</div>
		</header>
		<div class="container">
			<center>
				<div class="login-body">
					<div class="login-label">Username: </div>
					<asp:TextBox ID="tb_username" runat="server"></asp:TextBox>
					<div class="login-label">Password: </div>
					<asp:TextBox ID="tb_password" TextMode="Password" runat="server"></asp:TextBox>
					<div>
						<input type="checkbox" onclick="showHidePassword()" id="show-hide-pass-input"/>
						<label id="show-hide-pass-label" for="show-hide-pass-input">Show</label>
					</div>
					<asp:Button ID="btn_loginBody" runat="server" Text="Login" CssClass="btn-login-body" OnClick="btn_loginBody_Click"/>
					<br />
					<asp:Label ID="lbl_message" runat="server" Text=""></asp:Label>
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

		<div class="pagination">
			pages: <a href="#">1</a><a href="#">2</a><a href="#">3</a><a href="#">4</a>
		</div>

		<footer>
			<span>&copy; &nbsp;Dunay Gudratli | All Rights Reserved.</span>
		</footer>
	</form>
</body>
</html>

