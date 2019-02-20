<%@ Page Title="Контакти" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contacts.aspx.cs" Inherits="FinanceCalculator.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <html xmlns="http://www.w3.org/1999/xhtml">
        <head>
            <meta charset="utf-8"/>
            <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1"/>
            <meta name="viewport" content="width=device-width, initial-scale=1"/>
            <title>Контакти</title>
            <link href="Content/Contacts.css" media="screen" rel="stylesheet" type="text/css"/>
            <script type="text/javascript" src="Scripts/LeasingCalculator.js"></script>
            <link href="Content/bootstrap.css" media="screen" rel="stylesheet" type="text/css"/>
            <script type="text/javascript" src="Scripts/jquery-3.3.1.min.js"></script>
            <script type="text/javascript" src="Scripts/bootstrap.min.js"></script>
        </head>
        <body id="body">
            <h2 id="title">Контакти</h2>
            <h3 id="subTitle">Адрес</h3>
            <address>
                NBU IT Team 2016-2020<br />
                Sofia, Bulgaria<br />
                <abbr title="Phone">P:</abbr>
                +359-98052-6399
            </address>
            <address>
                <strong>Support: </strong><a href="mailto:Support@example.com">Support@example.com</a><br />
                <strong>Marketing: </strong><a href="mailto:Marketing@example.com">Marketing@example.com</a>
            </address>
        </body>
    </html>
</asp:Content>