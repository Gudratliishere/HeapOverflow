<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewPost.aspx.cs" Inherits="HeapOverflow.Home.NewPost" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>HeapOverflow</title>
	<link rel="stylesheet" href="../Resources/Css/Index.css" />
	<link rel="stylesheet" href="../Resources/Css/NewPost.css" />
	<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
	<script src="../Resources/Js/Index.js"></script>
</head>
<body>
	<form id="new_post" runat="server">
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
			</div>
		</header>

		<div class="container">
			<asp:TextBox ID="tb_name" runat="server" placeholder="Name"></asp:TextBox>
			<asp:TextBox ID="tb_topic" TextMode="MultiLine" runat="server" placeholder="Topic.."></asp:TextBox>
			<asp:Button ID="btn_post" runat="server" Text="Post" OnClick="btn_post_Click" />
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

