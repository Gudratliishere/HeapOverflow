<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="HeapOverflow.Home.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>HeapOverflow</title>
	<link rel="stylesheet" href="../Resources/Css/Index.css" />
	<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
	<script src="../Resources/Js/Index.js"></script>
</head>
<body>
	<form id="index" runat="server">
		<header>
			<div class="navbar">
				<nav class="navigation hide" id="navigation">
					<ul class="nav-list">
						<span class="close-icon" onclick="showIconBar()"><i class="fa fa-close"></i></span>
						<li class="nav-item">
							<a href="#">Home</a>
						</li>
						<li class="nav-item">
							<a href="#">Forum</a>
						</li>
						<li class="nav-item">
							<a href="#">Detail</a>
						</li>
					</ul>
				</nav>
				<a href="#" class="bar-icon" id="iconBar"><i class="fa fa-bars" onclick="hideIconBar()"></i></a>
				<div class="brand">Heap Overflow</div>
				<div class="account">
					<asp:Button ID="btn_login" runat="server" Text="Login" CssClass="login"/>
					<asp:Button ID="btn_register" runat="server" Text="Register" CssClass="register"/>
					<asp:Button ID="btn_logout" runat="server" Text="Logout" CssClass="logout"/>
				</div>
			</div>

			<!--search box-->
			<div class="search-box">
				<div>
					<select name="" id="">
						<option value="everything">Everything</option>
						<option value="titles">Titles</option>
						<option value="descriptions">Descriptions</option>
					</select>
					<input type="text" name="q" id="" placeholder="search..." />
					<button><i class="fa fa-search"></i></button>
				</div>
			</div>
		</header>
		<div class="container">
			<div class="subforum">

				<div class="posts-table">
					<div class="table-head">
						<div class="status">Status</div>
						<div class="subjects">Subjects</div>
						<div class="replies">Replies/Likes</div>
					</div>
					<div class="table-row">
						<div class="status"><i class="fa fa-fire"></i></div>
						<div class="subjects">
							<a href="#">Something dicussion.</a>
							<br />
							<span>Started by <b><a href="#">User</a></b></span>
						</div>
						<div class="replies">
							2 replies <br />
							12 likes
						</div>
					</div>
				</div>

				<hr class="subforum-devider" />
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

		<div class="pagination">
			pages: <a href="#">1</a><a href="#">2</a><a href="#">3</a><a href="#">4</a>
		</div>

		<footer>
			<span>&copy; &nbsp;Dunay Gudratli | All Rights Reserved.</span>
		</footer>
	</form>
</body>
</html>
