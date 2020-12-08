<%@ Page Title="Home Page"Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TryItPage.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
       
    </title>
    <link rel ="stylesheet" type="text/css"href="~/Styles/Site.css">
    
</head>
<body>
    <form id="form1" runat="server">
        <div class="title">
            <h2>TryIt Page</h2>

        </div>
        <br />
        <hr style="margin-bottom: 0px" />
        <p>
            <h3 style="text-align: left"> <a href="http://webstrar59.fulton.asu.edu/index.html">return to main page!</a></h3>
        </p>

    <div= class="main">
    <p>
        Require Service 1: Natural Hazards Service.

    </p>
    <p>
        (A)Description: Service will return the Narutal Hazards (earthquake) as index value of a given latitude and longtitude.
        <br/>
        (B)The WCF service WSDL is at: <span class="Apple-converted-space">&nbsp;</span><a href="http://localhost:59179/Service1.svc?wsdl">http://localhost:59179/Service1.svc?wsdl </a>
        <br/>
        This service can be used for building decision and insurance premium.
        <br/>
        (C)Operation: decimal NaturalHazards(decimal latitude, decimal longitude); which take 2 decimal lattitide and longtitude
        <br/>then return decimal value reflecting the natural hazards at the location

    </p>
        
        
        <p>
            <asp:Label ID="Label4" runat="server" Text="Latitude Box"></asp:Label>
            <asp:TextBox ID="LatBox" runat="server"></asp:TextBox>
            <asp:Label ID="Label3" runat="server" Text="Longtitude Box"></asp:Label>
            <asp:TextBox ID="LongBOx" runat="server"></asp:TextBox>
            <asp:Button ID="NatHazButton" runat="server" OnClick="NatHazButton_Click" Text="Invoke" />
        </p>
       
        <p>
            <asp:Label ID="Label1" runat="server" Text="Result: "></asp:Label>
            <asp:TextBox ID="ResultNarHaz" runat="server" Width="946px"></asp:TextBox>
        </p>
        </div>
        <hr />
        <div>
        <p>
            Require Service 2: NewsForcus
        </p>
        <p>
            (A)Description: Find news about specific topics, for example, find all (as many as possible)
            news articles about ASU (Arizona State University).
            <br/>
            (B)The WCF service WSDL is at: <span class="Apple-converted-space">&nbsp;</span><a href="http://localhost:59038/Service1.svc?wsdl">http://localhost:59038/Service1.svc?wsdl </a>
            <br />
            (C)Operation: string[] NewsFocus(string[] topics); Which 
             
            take a string of topic and return list of URL topic article.

            <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>

        </p>
        <p>
        <asp:Label ID="Label2" runat="server" Text="A list of search topic. (please separate bu commas)"></asp:Label>
        <asp:TextBox ID="InputNewForcusBox" runat="server"  Width="735px"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Invoke" />
        </p>
        <p>
            <asp:Label ID="Label5" runat="server" Text="List of URL articles: "></asp:Label>
            <asp:TextBox ID="OutPutNewForcusBox" runat="server" Height="295px" style="margin-bottom: 0px" Width="1508px" TextMode="MultiLine"></asp:TextBox>
        </p>
        </div>
    </form>
    

   
       
    
</body>
</html>
