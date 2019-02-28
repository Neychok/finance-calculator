<%@ Page Title="Лизингов Калкулатор" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LeasingCalculator.aspx.cs" Inherits="FinanceCalculator.LeasingCalculator" %>
<%--http://www.moitepari.bg/kalkulatori/lizingov_kalkulator.aspx?s_=QlpoNDFBWSZTWdjKUWUAABIvgAAA8hAZIsQALuedYCAAVCVT1PU0DTRoGgZqDQKA00HqaGjRoYUwSmGU7AyoT7PQLDEKcKp9UI9shKfpToGQTLqMJ5Num3XMp2RxLGi5BYCjtKlEwgIn4u5IpwoSGxlKLKA%3d#details--%>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <html xmlns="http://www.w3.org/1999/xhtml">
        <head>
            <meta charset="utf-8"/>
            <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1"/>
            <meta name="viewport" content="width=device-width, initial-scale=1"/>
            <title>Лизингов Калкулатор</title>
            <link href="Content/LeasingCalculator.css" media="screen" rel="stylesheet" type="text/css"/>
            <!-- <script type="text/javascript" src="Scripts/LeasingCalculator.js"></script> -->
            <link href="Content/bootstrap.css" media="screen" rel="stylesheet" type="text/css"/>
            <script type="text/javascript" src="Scripts/jquery-3.3.1.min.js"></script>
            <script type="text/javascript" src="Scripts/bootstrap.min.js"></script>
        </head>
        <body id="body">
            <div class="jumbotron text-center">
                <h2 id="title">Лизингов Калкулатор</h2>
                <p id="description">Пресметнете оскъпяването на стоката, закупена чрез лизинг.</p>
            </div>
            <div class="container text-center" id="mainContainer">
                <form name="mainForm" class="form-horizontal col-md-2" id="mainForm">
                    <div class="form-group text-left">
                        <div class="text-center col-md-10">
                            <label id="subLabel">На Годишния Процент На Разходите (ГПР)</label>
                            <br />
                            <br />
                        </div>
                        <div class="form-group">
                            <label for="input1" class="col-sm-6 control-label">Цена на стоката с ДДС *</label>
                            <div class="col-sm-4">
                                <div class="input-group">
                                    <span class="input-group-addon">$</span>
                                    <asp:TextBox type="number" min="0.01" step="0.01" class="form-control input-sm" id="input1" required="required" placeholder="Моля въведете цена" runat="server"></asp:TextBox>
                                </div>
                                <asp:Label class="col-sm-6 control-label" id="error1" text="" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="input2" class="col-sm-6 control-label">Първоначална вноска*</label>
                            <div class="col-sm-4">
                                <div class="input-group">
                                    <span class="input-group-addon">$</span>
                                    <asp:TextBox type="number" min="0.01" step="0.01" class="form-control input-sm" id="input2" required="required" placeholder="Във валута" runat="server"></asp:TextBox>
                                </div>
                                <asp:Label class="col-sm-6 control-label" id="error2" text="" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="input3" class="col-sm-6 control-label">Период на лизинга *</label>
                            <div class="col-sm-4">
                                <div class="input-group">
                                    <span class="input-group-addon">$</span>
                                    <asp:TextBox type="number" min="0.01" step="0.01" class="form-control input-sm" id="input3" required="required" placeholder="В месеци" runat="server"></asp:TextBox>
                                </div>
                                <asp:Label class="col-sm-6 control-label" id="error3" text="" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="input4" class="col-sm-6 control-label">Месечна вноска *</label>
                            <div class="col-sm-4">
                                <div class="input-group">
                                    <span class="input-group-addon">$</span>
                                    <asp:TextBox type="number" min="0.01" step="0.01" class="form-control input-sm" id="input4" required="required" placeholder="Във валута" runat="server"></asp:TextBox>
                                </div>
                                <asp:Label class="col-sm-6 control-label" id="error4" text="" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="input5" class="col-sm-6 control-label">Първоначална такса за обработка</label>
                            <div class="col-sm-4">
                                <div class="input-group">
                                    <span class="input-group-addon">$</span>
                                    <asp:TextBox type="number" min="0.01" step="0.01" class="form-control input-sm" id="input5" placeholder="В % или валута" runat="server"></asp:TextBox>
                                    <asp:DropDownList class="form-control"  ID="drop5" AppendDataBoundItems="true" runat="server">
                                        <asp:ListItem Text="%"/>
                                        <asp:ListItem Text="Валута"/>
                                    </asp:DropDownList>
                                </div>
                                <asp:Label class="col-sm-6 control-label" id="error5" text="" runat="server"></asp:Label>
                            </div>
                            <br />
                            <br />
                        </div>
                        <div class="text-center col-md-10">
                            <br />
                            <br />
                            <label id="requiredFieldsLabel">Полетата отбелязани с * са задължителни!</label>
                            <br />
                            <br />
                        </div>
                        <div class="text-center col-md-10">
                            <!-- <button type="button" class="btn btn-primary" onclick="showLeasingResult();">Изчисли</button> -->
                            <asp:Button id="calculateButton" type="button" class="btn btn-primary" Text="Изчисли" onclick="CalculateResult" runat="server"/>
                        </div>
                    </div>
                </form>
            </div>
        </body>
        <script type="text/javascript">
            function showLeasingResult() {
                /*Create an empty table*/
                var main = document.getElementById("mainContainer");
                var div = document.createElement("div");
                div.setAttribute("class", "jumbotron text-center col-md-10");
                div.setAttribute("id", "leasingResultDiv");
                var paragraph = document.createElement("p");
                paragraph.innerHTML = "Резултати";
                div.appendChild(paragraph);
                var table = document.createElement("table");
                table.setAttribute("class", "table table-bordered");
                var tbody = document.createElement("tbody");
                table.appendChild(tbody);

                /*First table row*/
                var tr1 = document.createElement("tr");
                var inth1 = document.createElement("th");
                inth1.setAttribute("scope", "row");
                inth1.innerHTML = "Годишен процентен разход";
                tr1.appendChild(inth1);
                var in1td1 = document.createElement("td");
                in1td1.setAttribute("id", "in1td1");
                in1td1.innerHTML =   " %";
                tr1.appendChild(in1td1);
                tbody.appendChild(tr1);

                /*Second table row*/
                var tr2 = document.createElement("tr");
                var inth2 = document.createElement("th");
                inth2.setAttribute("scope", "row");
                inth2.innerHTML = "Общо изплатено с такси";
                tr2.appendChild(inth2);
                var in2td1 = document.createElement("td");
                in2td1.setAttribute("id", "in2td1");
                in2td1.innerHTML = 11100 + " BGN";
                tr2.appendChild(in2td1);
                tbody.appendChild(tr2);

                /*Third table row*/
                var tr3 = document.createElement("tr");
                var inth3 = document.createElement("th");
                inth3.setAttribute("scope", "row");
                inth3.innerHTML = "Общо такси";
                tr3.appendChild(inth3);
                var in3td1 = document.createElement("td");
                in3td1.setAttribute("id", "in3td1");
                in3td1.innerHTML = 100 + " BGN";
                tr3.appendChild(in3td1);
                tbody.appendChild(tr3);

                /*Attach table to results div & attach results div to page body*/
                div.appendChild(table);
                main.appendChild(div);
            }
        </script>
    </html>
</asp:Content>
