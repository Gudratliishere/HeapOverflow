<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="HeapOverflow.Auth.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>HeapOverflow</title>
	<link rel="stylesheet" href="../Resources/Css/Index.css" />
	<link rel="stylesheet" href="../Resources/Css/Register.css" />
	<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
	<script src="../Resources/Js/Index.js"></script>
	<script src="../Resources/Js/Register.js"></script>
</head>
<body>
	<form id="register" runat="server">
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
				<a href="../Home/Index.aspx" style="text-decoration: none; color: white;">
					<div class="brand">Heap Overflow</div>
				</a>
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

					<div class="login-label">Email: </div>
					<asp:TextBox ID="tb_email" TextMode="Email" runat="server"></asp:TextBox>

					<div class="login-label">Password: </div>
					<asp:TextBox ID="tb_password" TextMode="Password" runat="server"></asp:TextBox>

					<div class="login-label">Confirm password: </div>
					<asp:TextBox ID="tb_cpassword" TextMode="Password" runat="server"></asp:TextBox>

					<div>
						<input type="checkbox" onclick="showHidePassword()" id="show-hide-pass-input" />
						<label id="show-hide-pass-label" for="show-hide-pass-input">Show</label>
					</div>

					<asp:Button ID="btn_registerBody" runat="server" Text="Register" CssClass="btn-register-body" OnClick="btn_registerBody_Click" />
					<br />
					<asp:Panel ID="pnl_emailConfirm" runat="server" Visible="False">
						<div class="login-label">Please enter code which was send to your email: </div>
						<asp:TextBox ID="tb_code" runat="server"></asp:TextBox>

						<asp:Button ID="btn_confirm" runat="server" Text="Confirm" CssClass="btn-register-body" OnClick="btn_confirm_Click" />
					</asp:Panel>

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

		<footer>
			<span>&copy; &nbsp;Dunay Gudratli | All Rights Reserved.</span>
		</footer>
	</form>
</body>
</html>

