<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="HeapOverflow.Account.User" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>HeapOverflow</title>
	<link rel="stylesheet" href="../Resources/Css/Index.css" />
	<link rel="stylesheet" href="../Resources/Css/User.css" />
	<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
	<script src="../Resources/Js/Index.js"></script>
</head>
<body>
	<form id="user" runat="server">
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
				<a href="../Home/Index.aspx" style="text-decoration: none; color: white;">
					<div class="brand">Heap Overflow</div>
				</a>
			</div>
		</header>
		<div class="container">
			<div class="subforum">
				<div>
					<asp:Image ID="img_profile" runat="server" ImageUrl="~/Image/example.jpg" />
					<asp:Label ID="lbl_name" runat="server" Text="Name"></asp:Label>
					<asp:Label ID="lbl_surname" runat="server" Text="Surname"></asp:Label>
					<asp:Button ID="btn_edit" runat="server" Text="Edit" OnClick="btn_edit_Click"/>
				</div>
				<asp:Label ID="lbl_post" runat="server" Text="Post: 10"></asp:Label>
				<p>
					<span>Description:</span>
					<br />
					<asp:Label ID="lbl_description" runat="server" Text="Descriptionsfnsdndokwds fs dfsdf sdcsd"></asp:Label>
				</p>
			</div>
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
