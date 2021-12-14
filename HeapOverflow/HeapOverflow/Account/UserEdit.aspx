<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserEdit.aspx.cs" Inherits="HeapOverflow.Account.UserEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>HeapOverflow</title>
	<link rel="stylesheet" href="../Resources/Css/Index.css" />
	<link rel="stylesheet" href="../Resources/Css/UserEdit.css" />
	<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
	<script src="../Resources/Js/Index.js"></script>
</head>
<body>
	<form id="user_edit" runat="server">
		<header>
			<div class="navbar">
				<nav class="navigation hide" id="navigation">
					<ul class="nav-list">
						<span class="close-icon" onclick="showIconBar()"><i class="fa fa-close"></i></span>
						<li class="nav-item">
							<asp:Button ID="btn_home" runat="server" Text="Home" OnClick="btn_home_Click" />
						</li>
						<li class="nav-item">
							<asp:Button ID="btn_account" runat="server" Text="Account" OnClick="btn_account_Click" />
						</li>
					</ul>
				</nav>
				<a href="#" class="bar-icon" id="iconBar"><i class="fa fa-bars" onclick="hideIconBar()"></i></a>
				<div class="brand">Heap Overflow</div>
				<div class="account">
					<asp:Button ID="btn_logout" runat="server" Text="Logout" CssClass="logout" OnClick="btn_logout_Click" />
				</div>
			</div>
		</header>
		<div class="container">
			<center>
				<div class="login-body">
					<asp:Image ID="img_profilePhoto" runat="server"></asp:Image>
					<asp:FileUpload ID="fup_profilePhoto" runat="server"></asp:FileUpload>

					<div class="login-label">Name: </div>
					<asp:TextBox ID="tb_name" runat="server"></asp:TextBox>

					<div class="login-label">Surname: </div>
					<asp:TextBox ID="tb_surname" runat="server"></asp:TextBox>

					<div class="login-label">Description: </div>
					<asp:TextBox ID="tb_description" TextMode="MultiLine" runat="server"></asp:TextBox>

					<asp:Button ID="btn_save" runat="server" type="button" Text="Save" CssClass="btn-login-body" OnClick="btn_save_Click" />
					<br />

					<asp:Label ID="lbl_message" runat="server" Text="Something message"></asp:Label>
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

