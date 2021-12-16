<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PostDetail.aspx.cs" Inherits="HeapOverflow.Home.PostDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>HeapOverflow</title>
	<link rel="stylesheet" href="../Resources/Css/Index.css" />
	<link rel="stylesheet" href="../Resources/Css/PostDetail.css" />
	<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
	<script src="../Resources/Js/Index.js"></script>
</head>
<body>
	<form id="postDetail" runat="server">
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
					<asp:Button ID="btn_login" runat="server" Text="Login" CssClass="login" OnClick="btn_login_Click" />
					<asp:Button ID="btn_register" runat="server" Text="Register" CssClass="register" OnClick="btn_register_Click" />
					<asp:Button ID="btn_logout" runat="server" Text="Logout" CssClass="logout" OnClick="btn_logout_Click" />
				</div>
			</div>
		</header>
		<div class="container">
			<div class="topic-container">
				<div class="head">
					<asp:Label ID="lbl_name" runat="server" Text="Post name" CssClass="content"></asp:Label>
					<asp:Button ID="btn_removePost" runat="server" Text="Remove" CssClass="remove" OnClick="btn_removePost_Click" Visible="False" />
				</div>

				<div class="body">
					<div class="authors">
						<asp:Button ID="btn_username" runat="server" Text="Username" CssClass="username" OnClick="btn_username_Click" />
						<br />
						<asp:Label ID="lbl_topic" runat="server" Text="Topic" CssClass="content"></asp:Label>
						<div class="like-dislike">
							<asp:Button ID="btn_postLike" runat="server" Text="Like (8)" CssClass="like" OnClick="btn_postLike_Click" />
							<asp:Button ID="btn_postDislike" runat="server" Text="Dislike (3)" CssClass="dislike" OnClick="btn_postDislike_Click" />
						</div>
					</div>
				</div>

				<div class="comment-body">
					<asp:PlaceHolder ID="ph_comment_item" runat="server"></asp:PlaceHolder>
					<div class="write-comment">
						<asp:TextBox ID="tb_comment" runat="server" TextMode="MultiLine" placeholder="Topic..."></asp:TextBox>
						<asp:Button ID="btn_postComment" runat="server" Text="Send" OnClick="btn_postComment_Click" />
					</div>
				</div>
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
