<%@ Page Title="Login Page" MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="NaturalHazardPage.aspx.cs" Inherits="TryitPageA6.NaturalHazardPage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <div>
    <p>
        Requre Service: Natural Hazard Service.
    </p>
    <p>
        (A)Description: Service will return the Narutal Hazards (earthquake) as index value of a given latitude and longtitude.</p>
    <p>
        (B)The WCF service WSDL is at:<a href="http://webstrar59.fulton.asu.edu/Page0/Service1.svc?wsdl">http://webstrar59.fulton.asu.edu/Page0/Service1.svc?wsdl</a></p>
    <p>
        (C)Operation: Operation: decimal NaturalHazards(decimal latitude, decimal longitude); which take 2 decimal lattitide and longtitude
        <br/>then return decimal value reflecting the natural hazards at the location</p>
    <p>
        <asp:Label ID="LatitudeLabel" runat="server" Text="Latitude Box:"></asp:Label>
        <asp:TextBox ID="LattitudeBox" runat="server"></asp:TextBox>
        <asp:Label ID="LongtitudeLabel" runat="server" Text="LongtitudeLabel"></asp:Label>
        <asp:TextBox ID="LongtitudeBox" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Invoke" />
    </p>
    <p>
        <asp:Label ID="ResultLabel" runat="server" Text="Result"></asp:Label>
&nbsp;<asp:Label ID="RRRLabel" runat="server"></asp:Label>
    </p>
        </div>
</asp:Content>