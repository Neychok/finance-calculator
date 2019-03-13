<%@ Page Title="Калкулатор За Рефинансиране" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RefinanceCalculator.aspx.cs" Inherits="FinanceCalculator.RefinanceCalculator" %>
<%--http://www.moitepari.bg/kalkulatori/kalkulator_refinansirane.aspx?s_=QlpoNDFBWSZTWU68wgAAABXvgEAAAAD6kCsnVAAuJ96gIAB1CVRpkDTQAAZNqBKnpBqJ6mgAGTJp6NKlHaU1NDiLoMoH4xt61xM24mYjW2ER6vDdL36Nju8SC42CPGaFLBMDMRZaNkWYkCaiJ8KUS2fAiyKLg9YhWExHYXzqWo8nNhdyRThQkE68wgA%3d#details--%>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <html xmlns="http://www.w3.org/1999/xhtml">
        <head>
            <meta charset="utf-8"/>
            <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1"/>
            <meta name="viewport" content="width=device-width, initial-scale=1"/>
            <title>Калкулатор За Рефинансиране</title>
            <link href="Content/RefinanceCalculator.css" media="screen" rel="stylesheet" type="text/css"/>
            <!-- <script type="text/javascript" src="Scripts/RefinanceCalculator.js"></script> -->
            <link href="Content/bootstrap.css" media="screen" rel="stylesheet" type="text/css"/>
            <script type="text/javascript" src="Scripts/jquery-3.3.1.min.js"></script>
            <script type="text/javascript" src="Scripts/bootstrap.min.js"></script>
        </head>
        <body id="body">
            <div class="jumbotron text-center">
                <h2 id="title">Калкулатор За Рефинансиране</h2>
                <p id="description">Пресметнете дали рефинансирането на задълженията Ви е изгодно.</p>
            </div>
            <div class="container text-center" id="mainContainer">
                <form name="mainForm" class="form-horizontal col-md-2" id="mainForm">
                    <div class="form-group text-left">
                        <div class="text-center col-md-10">
                            <label id="subLabel1">Настоящ кредит</label>
                            <br />
                            <br />
                        </div>
                        <div class="form-group">
                            <label for="input1" class="col-sm-6 control-label">Размер на кредита *</label>
                            <div class="col-sm-4">
                                <div class="input-group">
                                    <span class="input-group-addon">$</span>
                                    <asp:TextBox type="number" min="1" step="1" class="form-control input-sm" id="input1" required="required" placeholder="Във валута" runat="server"></asp:TextBox>
                                </div>
                                <asp:Label class="col-sm-6 control-label" id="error1" text="" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="input2" class="col-sm-6 control-label">Лихва *</label>
                            <div class="col-sm-4">
                                <div class="input-group">
                                    <span class="input-group-addon">$</span>
                                    <asp:TextBox type="number" min="0.01" step="0.01" class="form-control input-sm" id="input2" required="required" placeholder="В %" runat="server"></asp:TextBox>
                                </div>
                                <asp:Label class="col-sm-6 control-label" id="error2" text="" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="input3" class="col-sm-6 control-label">Срок на кредита *</label>
                            <div class="col-sm-4">
                                <div class="input-group">
                                    <span class="input-group-addon">$</span>
                                    <asp:TextBox type="number" min="1" step="1" class="form-control input-sm" id="input3" required="required" placeholder="В месеци" runat="server"></asp:TextBox>
                                </div>
                                <asp:Label class="col-sm-6 control-label" id="error3" text="" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="input4" class="col-sm-6 control-label">Брой на направените вноски *</label>
                            <div class="col-sm-4">
                                <div class="input-group">
                                    <span class="input-group-addon">$</span>
                                    <asp:TextBox type="number" min="1" step="1" class="form-control input-sm" id="input4" required="required" placeholder="Моля въведете броя вноски" runat="server"></asp:TextBox>
                                </div>
                                <asp:Label class="col-sm-6 control-label" id="error4" text="" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="input5" class="col-sm-6 control-label">Такса за предсрочно погасяване * <sup>5</sup></label>
                            <div class="col-sm-4">
                                <div class="input-group">
                                    <span class="input-group-addon">$</span>
                                    <asp:TextBox type="number" min="0.01" step="0.01" class="form-control input-sm" id="input5" required="required" placeholder="В %" runat="server"></asp:TextBox>
                                </div>
                                <asp:Label class="col-sm-6 control-label" id="error5" text="" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="text-center col-md-10">
                            <br/>
                            <br/>
                            <label id="subLabel2">Нов кредит</label>
                            <br/>
                            <br/>
                        </div>
                        <div class="form-group">
                            <label for="input6" class="col-sm-6 control-label">Лихва *</label>
                            <div class="col-sm-4">
                                <div class="input-group">
                                    <span class="input-group-addon">$</span>
                                    <asp:TextBox type="number" min="0.01" step="0.01" class="form-control input-sm" id="input6" required="required" placeholder="В %" runat="server"></asp:TextBox>
                                </div>
                                <asp:Label class="col-sm-6 control-label" id="error6" text="" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="input7" class="col-sm-6 control-label">Първоначални такси * <sup>6</sup></label>
                            <div class="col-sm-4">
                                <div class="input-group">
                                    <span class="input-group-addon">$</span>
                                    <asp:TextBox type="number" min="0.01" step="0.01" class="form-control input-sm" id="input7" required="required" placeholder="В %" runat="server"></asp:TextBox>
                                </div>
                                <asp:Label class="col-sm-6 control-label" id="error7" text="" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="input8" class="col-sm-6 control-label">Първоначални такси * <sup>7</sup></label>
                            <div class="col-sm-4">
                                <div class="input-group">
                                    <span class="input-group-addon">$</span>
                                    <asp:TextBox type="number" min="1" step="1" class="form-control input-sm" id="input8" required="required" placeholder="Във валута" runat="server"></asp:TextBox>
                                </div>
                                <asp:Label class="col-sm-6 control-label" id="error8" text="" runat="server"></asp:Label>
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
                            <!-- <button type="button" class="btn btn-primary" onclick="showRefinanceResult();">Изчисли</button> -->
                            <asp:Button id="calculateButton" type="button" class="btn btn-primary" Text="Изчисли" onclick="CalculateResult" runat="server"/>
                        </div>
                    </div>
                </form>
            </div>
        </body>
        <script type="text/javascript">
            function showRefinanceResult() {
                /*Create an empty table*/
                var main = document.getElementById("mainContainer");
                var div = document.createElement("div");
                div.setAttribute("class", "jumbotron text-center col-md-10");
                div.setAttribute("id", "refinanceResultDiv");
                var paragraph = document.createElement("p");
                paragraph.innerHTML = "Резултати";
                div.appendChild(paragraph);
                var table = document.createElement("table");
                table.setAttribute("class", "table table-bordered");
                var thead = document.createElement("thead");
                table.appendChild(thead);
                var th1 = document.createElement("th");
                th1.setAttribute("scope", "col");
                th1.innerHTML = "Резултат";
                thead.appendChild(th1);
                var th2 = document.createElement("th");
                th2.setAttribute("scope", "col");
                th2.innerHTML = "Текущ кредит";
                thead.appendChild(th2);
                var th3 = document.createElement("th");
                th3.setAttribute("scope", "col");
                th3.innerHTML = "Нов кредит";
                thead.appendChild(th3);
                var th4 = document.createElement("th");
                th4.setAttribute("scope", "col");
                th4.innerHTML = "+/- Спестявания";
                thead.appendChild(th4);
                var tbody = document.createElement("tbody");
                table.appendChild(tbody);

                /*First table row*/
                var tr1 = document.createElement("tr");
                var inth1 = document.createElement("th");
                inth1.setAttribute("scope", "row");
                inth1.innerHTML = "Лихва";
                tr1.appendChild(inth1);
                var in1td1 = document.createElement("td");
                in1td1.setAttribute("id", "in1td1");
                in1td1.innerHTML = <%= val %> + " %";
                tr1.appendChild(in1td1);
                var in1td2 = document.createElement("td");
                in1td2.setAttribute("id", "in1td2");
                in1td2.innerHTML = 7 + " %";
                tr1.appendChild(in1td2);
                var in1td3 = document.createElement("td");
                in1td3.setAttribute("id", "in1td3");
                in1td3.innerHTML = 1 + " %";
                tr1.appendChild(in1td3);
                tbody.appendChild(tr1);

                /*Second table row*/
                var tr2 = document.createElement("tr");
                var inth2 = document.createElement("th");
                inth2.setAttribute("scope", "row");
                inth2.innerHTML = "Срокове на кредитите";
                tr2.appendChild(inth2);
                var in2td1 = document.createElement("td");
                in2td1.setAttribute("id", "in2td1");
                in2td1.innerHTML = 12;
                tr2.appendChild(in2td1);
                var in2td2 = document.createElement("td");
                in2td2.setAttribute("id", "in2td2");
                in2td2.innerHTML = 7;
                tr2.appendChild(in2td2);
                var in2td3 = document.createElement("td");
                in2td3.setAttribute("id", "in2td3");
                in2td3.innerHTML = 1;
                tr2.appendChild(in2td3);
                tbody.appendChild(tr2);

                /*Third table row*/
                var tr3 = document.createElement("tr");
                var inth3 = document.createElement("th");
                inth3.setAttribute("scope", "row");
                inth3.innerHTML = "Такса за предсрочно погасяване";
                tr3.appendChild(inth3);
                var in3td1 = document.createElement("td");
                in3td1.setAttribute("id", "in3td1");
                in3td1.innerHTML = 1178.78;
                tr3.appendChild(in3td1);
                var in3td2 = document.createElement("td");
                in3td2.setAttribute("id", "in3td2");
                in3td2.innerHTML = "";
                tr3.appendChild(in3td2);
                var in3td3 = document.createElement("td");
                in3td3.setAttribute("id", "in3td3");
                in3td3.innerHTML = "";
                tr3.appendChild(in3td3);
                tbody.appendChild(tr3);

                /*Fourth table row*/
                var tr4 = document.createElement("tr");
                var inth4 = document.createElement("th");
                inth4.setAttribute("scope", "row");
                inth4.innerHTML = "Месечна вноска";
                tr4.appendChild(inth4);
                var in4td1 = document.createElement("td");
                in4td1.setAttribute("id", "in4td1");
                in4td1.innerHTML = 856.07;
                tr4.appendChild(in4td1);
                var in4td2 = document.createElement("td");
                in4td2.setAttribute("id", "in4td2");
                in4td2.innerHTML = 861.74;
                tr4.appendChild(in4td2);
                var in4td3 = document.createElement("td");
                in4td3.setAttribute("id", "in4td3");
                in4td3.innerHTML = -5.67;
                tr4.appendChild(in4td3);
                tbody.appendChild(tr4);

                /*Fifth table row*/
                var tr5 = document.createElement("tr");
                var inth5 = document.createElement("th");
                inth5.setAttribute("scope", "row");
                inth5.innerHTML = "Общо изплатени";
                tr5.appendChild(inth5);
                var in5td1 = document.createElement("td");
                in5td1.setAttribute("id", "in5td1");
                in5td1.innerHTML = 5992.52;
                tr5.appendChild(in5td1);
                var in5td2 = document.createElement("td");
                in5td2.setAttribute("id", "in5td2");
                in5td2.innerHTML = 8510.98;
                tr5.appendChild(in5td2);
                var in5td3 = document.createElement("td");
                in5td3.setAttribute("id", "in5td3");
                in5td3.innerHTML = -2518.46;
                tr5.appendChild(in5td3);
                tbody.appendChild(tr5);

                /*Sixth table row*/
                var tr6 = document.createElement("tr");
                var intd6 = document.createElement("td");
                intd6.setAttribute("id", "col");
                intd6.innerHTML = "ИЗГОДНО";
                tr6.appendChild(intd6);
                tbody.appendChild(tr6);

                /*Attach table to results div & attach results div to page body*/
                div.appendChild(table);
                main.appendChild(div);
            }
        </script>
    </html>
</asp:Content>
