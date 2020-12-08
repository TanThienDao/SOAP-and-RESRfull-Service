<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TryitPage.aspx.cs" Inherits="TryitPageA6._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h3>ASP.NET Here is Tan Thien Dao Services </h3>
        
        
    </div>
    <div>
        <p>
            
            <a runat="server" href="~/NaturalHazardPage">Natural Hazards Service</a><br />
            <a runat="server" href="~/NewsForcus">NewsFocus</a><br />
            <a runat="server" href="~/RainFall">RainFall</a><br />
            <a runat="server" href="~/StatePopulation">State Population (RESTfull service)</a><br />
            <a runat="server" href="~/Account">AcountCreate</a><br />
            <a runat="server" href="~/Login">login service</a></p>
        <p>
            
            
        </p>

    </div>
    

</asp:Content>
