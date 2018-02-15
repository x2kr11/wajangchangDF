<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GuildRanking.aspx.cs" Inherits="WebApplication2.GuildRanking" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
        <p>
            <asp:TextBox ID="TextBox2" runat="server" Height="448px" Width="1009px"></asp:TextBox>
        </p>
    </form>
</body>
</html>
