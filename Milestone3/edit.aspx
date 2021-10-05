<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit.aspx.cs" Inherits="GUCera.edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            please enter first_name<br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            please enter last_name<br />
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            please enter your&nbsp; password<br />
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <br />
            please enter
            your gender<br />
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <br />
            please enter your email<br />
            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            <br />
            please enter your address<br />
            <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server" Text="update" OnClick="Button1_Click" />
            <br />
        </div>
    </form>
</body>
</html>
