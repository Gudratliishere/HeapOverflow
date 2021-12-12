<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminPanel.aspx.cs" Inherits="HeapOverflow.Home.AdminPanel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>Admin Panel</title>
	<link rel="stylesheet" href="../Resources/Css/Admin.css" />
	<link rel="stylesheet" href="../Resources/Css/AdminPanel.css" />
	<script src="../Resources/Js/AdminPanel.js"></script>
</head>
<body>
	<form id="admin_panel" runat="server">
		<div>
			<div class="search">
				<asp:TextBox ID="tb_search" runat="server" placeholder="Search by name..."></asp:TextBox>
				<asp:Button ID="btn_search" runat="server" Text="Search" OnClick="btn_search_Click" />
				<input type="button" class="btn-filter" onclick="showHideFilter()" value="Filter" />
			</div>
			<div class="filter hide" id="filter">
				<div class="search-status">
					<asp:DropDownList ID="ddl_status" runat="server" CssClass="ddl">
						<asp:ListItem Selected="True">1</asp:ListItem>
						<asp:ListItem>0</asp:ListItem>
					</asp:DropDownList>
					<asp:Button ID="btn_searchByStatus" runat="server" Text="Search" CssClass="btn-search" OnClick="btn_searchByStatus_Click" />
				</div>
				<div class="search-role">
					<asp:DropDownList ID="ddl_role" runat="server" CssClass="ddl">
						<asp:ListItem Selected="True">User</asp:ListItem>
						<asp:ListItem>Moderator</asp:ListItem>
					</asp:DropDownList>
					<asp:Button ID="btn_searchByRole" runat="server" Text="Search" CssClass="btn-search" OnClick="btn_searchByRole_Click" />
				</div>
			</div>
			<div class="users-table">
				<div class="table-head">
					<div class="username">Username</div>
					<div class="status">Status</div>
					<div class="role">Role</div>
					<div class="edit-button"></div>
				</div>
				<asp:PlaceHolder ID="ph_users" runat="server"></asp:PlaceHolder>
			</div>
		</div>
	</form>
</body>
</html>
