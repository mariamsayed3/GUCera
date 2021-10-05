<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="homeInstructor.aspx.cs" Inherits="GUCera.home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="StyleSheet1.css">
    <title></title>
</head>
<body>

    <form id="form1" runat="server">

    <div class="topnav">
  <a class="active" href="homeInstructor.aspx">Home</a>
  <a href="myAcceptedCourses.aspx">Accepted Courses</a>
  <a href="addCourse.aspx">Add Course</a>
  <a href="issueCertificates.aspx">Certify</a>
    </div>
    <br />
        <asp:Label ID="info" runat="server" Text="" CssClass="info"></asp:Label>
        <br />
        <asp:Button ID="logout" runat="server" Text="Log out" OnClick="logout_Click" CssClass="button"/>
    </form>
</body>
</html>
