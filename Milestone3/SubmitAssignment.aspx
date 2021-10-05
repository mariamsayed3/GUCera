<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SubmitAssignment.aspx.cs" Inherits="Milestone3.SubmitAssignment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
                                <link rel="stylesheet" href="StyleSheet1.css">

    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="topnav">
         <a href="StudentHome.aspx">Home</a>
         <a href="AvaliableCourses.aspx">Available Courses</a>
         <a href="CreditCard.aspx">Add Credit Card</a>
         <a href="PromoCode.aspx">Promo Codes</a>
            <a href="viewAssignments.aspx">Assignments</a>
            <a class="active" href="SubmitAssignment.aspx">Submit assignment</a>
            <a href="ViewGrades.aspx">Grades</a>
            <a href="AddFeedback.aspx">Add a Feedback</a>
            <a href="ViewCertificates.aspx">Certificates</a>
    </div>
            <asp:Label runat="server" CssClass="info">
            Submit as Assigment
        </asp:Label>
        <asp:Label runat="server" CssClass="info2">
            Type:
        </asp:Label>
            <asp:TextBox ID="AssignmentType" runat="server" CssClass="labels"></asp:TextBox>
            <asp:Label runat="server" CssClass="info2">
            Number:
        </asp:Label>
            <asp:TextBox ID="AssignmentNumber" runat="server" CssClass="labels"></asp:TextBox>
            <asp:Label runat="server" CssClass="info2">
            Course ID:
        </asp:Label>
            <asp:TextBox ID="CourseId" runat="server" CssClass="labels"></asp:TextBox>
        <br />
            <asp:Button ID="Button1" runat="server" OnClick="SubmitAssign" Text="Submit Assignment" Height="44px" BorderStyle="Outset" CssClass="button2"/>
    </form>
</body>
</html>
