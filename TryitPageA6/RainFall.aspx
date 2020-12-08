<%@ Page Title="Home Page" MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="RainFall.aspx.cs" Inherits="TryitPageA6.RainFall" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <div>
        Elective Service :Rainfall Service</p>
    <p>
        (A)Description:Service will take a string of location then convert to latitude and longitude and search for the condition of rainfall.</p>
    <p>
        (B)The WCF service WSDL is at:<a href="http://webstrar59.fulton.asu.edu/Page0/Service1.svc?wsdl">http://webstrar59.fulton.asu.edu/Page0/Service1.svc?wsdl</a>
    <p>
        (C)Operation:Input: String of location, can be city or country<br />
                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                     Output: Condition of the rainfall in that area </p>
    <p>
        <asp:Label ID="LabelLocationName" runat="server" Text="PLease enter Location name:"></asp:Label>
        <asp:TextBox ID="LocationNameBox" runat="server"></asp:TextBox>
        <asp:Button ID="PopulationButton" runat="server" OnClick="PopulationButton_Click" Text="Invoke" />
    </p>
    <p>
        <asp:Label ID="ResultRainCondition" runat="server" Text="Result"></asp:Label>
    </p>
    </div>
 </asp:Content>