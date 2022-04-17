<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgetPassword.aspx.cs" Inherits="HeapOverflow.Auth.EmailConfirmation" %>

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
	<form id="forget_password" runat="server">
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
			</div>
		</header>
		<div class="container">
			<center>
				<div class="login-body">
					<div class="email">
						<div class="login-label">Please enter your email:</div>
						<asp:TextBox ID="tb_email" runat="server"></asp:TextBox>

						<asp:Button ID="btn_send" runat="server" Text="Send" CssClass="btn-login-body" OnClick="btn_send_Click"/>
					</div>
					<asp:Panel ID="pnl_confirm" CssClass="confirm" runat="server" Visible="False">
						<div class="login-label">Please write code which was send to your email: </div>
						<asp:TextBox ID="tb_code" runat="server"></asp:TextBox>

						<asp:Button ID="btn_confirm" runat="server" Text="Confirm" CssClass="btn-login-body" OnClick="btn_confirm_Click" />
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

