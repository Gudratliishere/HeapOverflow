<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminUserEdit.aspx.cs" Inherits="HeapOverflow.Home.AdminUserEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edit Users</title>
	<link rel="stylesheet" href="../Resources/Css/Admin.css" />
	<link rel="stylesheet" href="../Resources/Css/AdminUserEdit.css" />
</head>
<body>
    <form id="admin_user_edit" runat="server">
        <div>
			<asp:Label ID="lbl_username" runat="server" Text="Username"></asp:Label>
			<asp:DropDownList ID="ddl_status" runat="server" CssClass="list">
				<asp:ListItem>1</asp:ListItem>
				<asp:ListItem>0</asp:ListItem>
			</asp:DropDownList>
			<asp:DropDownList ID="ddl_role" runat="server" CssClass="list">
				<asp:ListItem>USER</asp:ListItem>
				<asp:ListItem>MODERATOR</asp:ListItem>
			</asp:DropDownList>
			<asp:Button ID="btn_save" runat="server" Text="Save" OnClick="btn_save_Click" />
        </div>
    </form>
</body>
</html>
