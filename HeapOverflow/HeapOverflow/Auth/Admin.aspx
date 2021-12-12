<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="HeapOverflow.Auth.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sign in Admin</title>
	<link rel="stylesheet" href="../Resources/Css/Admin.css" />
	<link rel="stylesheet" href="../Resources/Css/Login.css" />
	<script src="../Resources/Js/Login.js"></script>
</head>
<body>
    <form id="admin" runat="server">
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
    </form>
</body>
</html>
