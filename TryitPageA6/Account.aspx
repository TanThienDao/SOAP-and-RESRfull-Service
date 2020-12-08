<%@ Page Title="Login Page" MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="Account.aspx.cs" Inherits="TryitPageA6.Account" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <div>
    
        
        Elective Service: Account service.</p>
    <p>
        (A) Description: Account Service will aske user to input thier username and password, and store date on the server host for the login service to check.</p>
    <p>
        (B)The WCF service WSDL is at:<a href="http://webstrar59.fulton.asu.edu/Page0/Service1.svc?wsdl">http://webstrar59.fulton.asu.edu/Page0/Service1.svc?wsdl</a> 
    </p>
    <p>
        (C)Operation: Input String username and password; will thake this 2 infor and store in .Json file and the password store is encrypted.</p>
    <p>
        <br />
        <asp:Label ID="usernameLabel" runat="server" Text="Username: "></asp:Label>
        <asp:TextBox ID="UsernameBox" runat="server" Width="186px"></asp:TextBox>
    </p>
    <p>

        <asp:Label ID="PassowordLabel" runat="server" Text="Password"></asp:Label>
        <asp:TextBox ID="PasswordBox" runat="server" Width="198px"></asp:TextBox>
    </p>
    <p>

         <asp:Button ID="CreatedButton" runat="server" Text="Create" OnClick="CreatedButton_Click" />
    </p>
    <p>

         <asp:Label ID="ResultLabel" runat="server" Text="Result"></asp:Label>
    </p>
        </div>
 </asp:Content>