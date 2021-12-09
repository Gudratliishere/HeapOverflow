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
			<div class="topic-container">
				<div class="head">
					<div class="author">Author</div>
					<div class="content">Topic: topic title</div>
				</div>

				<div class="body">
					<div class="authors">
						<div class="username">Username</div>
						<div class="content">Just a random topic</div>
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
				<br />
				<span>Latest Post: <b><a href="#">Random Post</a> on some date by <a href="#">User</a></b></span>
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
