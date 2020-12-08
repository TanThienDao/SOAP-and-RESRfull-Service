<%@ Page Title="Login Page" MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TryitPageA6.Login" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <div>
    
            Elective Service: Login Service.</p>
        <p>
        (A)Description: Service will take user username and password and check if they input correct username and passowrd. <br />  The password got decrypt here.</p>
    <p>
        (B)The WCF service WSDL is at:<a href="http://webstrar59.fulton.asu.edu/Page0/Service1.svc?wsdl">http://webstrar59.fulton.asu.edu/Page0/Service1.svc?wsdl</a></p>
    <p>
        (C)Operation: Input string username and passowrd and output the true or false if the account login success or not.</p>
    <p>
        <asp:Label ID="UsernameLabel" runat="server" Text="Username:"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="PasswordLabel" runat="server" Text="Password:"></asp:Label>
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <asp:Button ID="LoginButton" runat="server" OnClick="LoginButton_Click" Text="Login" />
    </p>
    <p>
        <asp:Label ID="ResultLabel" runat="server" Text="Result"></asp:Label>
    </p>
        </div>
 </asp:Content>