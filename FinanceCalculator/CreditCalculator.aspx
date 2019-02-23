<%@ Page Title="Кредитен Калкулатор" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreditCalculator.aspx.cs" Inherits="FinanceCalculator.CreditCalculator" %>
<%--http://www.moitepari.bg/kalkulatori/krediten_kalkulator.aspx?s_=QlpoNDFBWSZTWUooTWYAABp%2fykAAAACCAH8QJCRcAK9n3uAYAFAIYAAgAIIYomhDTT1PU0AyDaanqACVITAANJpgAADUa6tvqaqSSsNRzTaUwIsQpMu15aB3cTptLpVhvVE3k10WQhc%40y6IhzGAJvGFoJ2RfkoxJaTy6kuGiQ4vy8CjpjIPBKczIQkKtW5lIImhTiFnCE1teKAhCZUIXEqAUAdh6F4dh6Cg%2fi7kinChIJRQmswA%3d#details--%>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <html xmlns="http://www.w3.org/1999/xhtml">
        <head>
            <meta charset="utf-8"/>
            <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1"/>
            <meta name="viewport" content="width=device-width, initial-scale=1"/>
            <title>Кредитен Калкулатор</title>
            <link href="Content/CreditCalculator.css" media="screen" rel="stylesheet" type="text/css"/>
            <!-- <script type="text/javascript" src="Scripts/CreditCalculator.js"></script> -->
            <link href="Content/bootstrap.css" media="screen" rel="stylesheet" type="text/css"/>
            <script type="text/javascript" src="Scripts/jquery-3.3.1.min.js"></script>
            <script type="text/javascript" src="Scripts/bootstrap.min.js"></script>
        </head>
        <body id="body">
            <div class="jumbotron text-center">
                <h2 id="title">Кредитен Калкулатор</h2>
                <p id="description">Пресметнете месечни вноски и ГПР (Годишен Процент на Разходите)</p>
            </div>
            <div class="container text-center" id="mainContainer">
                <form name="mainForm" class="form-horizontal col-md-2" id="mainForm">
                    <div class="form-group text-left">
                        <div class="form-group">
                            <label for="input1" class="col-sm-6 control-label">Размер на кредита *</label>
                            <div class="col-sm-4">
                                <div class="input-group">
                                    <span class="input-group-addon">$</span>
                                    <asp:TextBox type="number" min="0.01" step="0.01" class="form-control input-sm" id="input1" required="required" placeholder="Във валута" runat="server"></asp:TextBox>
                                </div>
                                <asp:Label class="col-sm-6 control-label" id="error1" text="" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="input2" class="col-sm-6 control-label">Срок *</label>
                            <div class="col-sm-4">
                                <div class="input-group">
                                    <span class="input-group-addon">$</span>
                                    <asp:TextBox type="number" min="0.01" step="0.01" class="form-control input-sm" id="input2" required="required" placeholder="В месеци" runat="server"></asp:TextBox>
                                </div>
                                <asp:Label class="col-sm-6 control-label" id="error2" text="" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="input3" class="col-sm-6 control-label">Лихва *</label>
                            <div class="col-sm-4">
                                <div class="input-group">
                                    <span class="input-group-addon">$</span>
                                    <asp:TextBox type="number" min="0.01" step="0.01" class="form-control input-sm" id="input3" required="required" placeholder="В %" runat="server"></asp:TextBox>
                                </div>
                                <asp:Label class="col-sm-6 control-label" id="error3" text="" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="input4" class="col-sm-6 control-label">Вид вноски <sup>1</sup></label>
                            <div class="col-sm-4">
                                <div class="input-group">
                                    <span class="input-group-addon">$</span>
                                    <asp:DropDownList class="form-control" ID="drop_vid" AppendDataBoundItems="true" runat="server">
                                        <asp:ListItem Text="Анюитетни вноски"/>
                                        <asp:ListItem Text="Намаляващи вноски"/>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <br />
                            <br />
                        </div>
                        <div class="text-center col-md-10">
                            <br />
                            <br />
                            <button type="button" class="btn btn-info" data-toggle="collapse" data-target="#promoPeriod">Промоционален период</button>
                            <br />
                            <br />
                        </div>
                        <div id="promoPeriod" class="collapse col-md-10" style="width: 100%; margin-left: -1%;">
                            <div class="form-group">
                                <label for="input5" class="col-sm-6 control-label">Промоционален период</label>
                                <div class="col-sm-4" style="margin-left: 1%;">
                                    <div class="input-group">
                                        <span class="input-group-addon">$</span>
                                        <asp:TextBox type="number" min="0.01" step="0.01" class="form-control input-sm" id="input5" placeholder="В месеци" runat="server"></asp:TextBox>
                                    </div>
                                    <asp:Label class="col-sm-6 control-label" id="error5" text="" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="input6" class="col-sm-6 control-label">Промоционална лихва <sup>2</sup></label>
                                <div class="col-sm-4" style="margin-left: 1%;">
                                    <div class="input-group">
                                        <span class="input-group-addon">$</span>
                                        <asp:TextBox type="number" min="0.01" step="0.01" class="form-control input-sm" id="input6" placeholder="В %" runat="server"></asp:TextBox>
                                    </div>
                                    <asp:Label class="col-sm-6 control-label" id="error6" text="" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="input7" class="col-sm-6 control-label">Гратисен период</label>
                                <div class="col-sm-4" style="margin-left: 1%;">
                                    <div class="input-group">
                                        <span class="input-group-addon">$</span>
                                        <asp:TextBox type="number" min="0.01" step="0.01" class="form-control input-sm" id="input7" placeholder="В месеци" runat="server"></asp:TextBox>
                                    </div>
                                    <asp:Label class="col-sm-6 control-label" id="error7" text="" runat="server"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="text-center col-md-10">
                            <br />
                            <br />
                            <button type="button" class="btn btn-info" data-toggle="collapse" data-target="#taksi">Такси</button>
                            <br />
                            <br />
                        </div>
                        <div id="taksi" class="collapse col-md-10" style="width: 100%; margin-left: -1%;">
                            <div class="text-center col-md-10">
                                <label id="subLabel1">Първоначални такси</label>
                                <br />
                                <br />
                            </div>
                            <div class="form-group">
                                <label for="input8" class="col-sm-6 control-label">Такса кандидатстване</label>
                                <div class="col-sm-4" style="margin-left: 1%;">
                                    <div class="input-group">
                                        <span class="input-group-addon">$</span>
                                        <asp:TextBox type="number" min="0.01" step="0.01" class="form-control input-sm" id="input8" placeholder="В % или валута" runat="server"></asp:TextBox>
                                        <asp:DropDownList class="form-control" ID="drop8" AppendDataBoundItems="true" runat="server">
                                            <asp:ListItem Text="Валута"/>
                                            <asp:ListItem Text="%"/>
                                        </asp:DropDownList>
                                    </div>
                                    <asp:Label class="col-sm-6 control-label" id="error8" text="" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="input9" class="col-sm-6 control-label">Такса обработка</label>
                                <div class="col-sm-4" style="margin-left: 1%;">
                                    <div class="input-group">
                                        <span class="input-group-addon">$</span>
                                        <asp:TextBox type="number" min="0.01" step="0.01" class="form-control input-sm" id="input9" placeholder="В % или валута" runat="server"></asp:TextBox>
                                        <asp:DropDownList class="form-control" ID="drop9" AppendDataBoundItems="true" runat="server">
                                            <asp:ListItem Text="%"/>
                                            <asp:ListItem Text="Валута"/>
                                        </asp:DropDownList>
                                    </div>
                                    <asp:Label class="col-sm-6 control-label" id="error9" text="" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="input10" class="col-sm-6 control-label">Други такси</label>
                                <div class="col-sm-4" style="margin-left: 1%;">
                                    <div class="input-group">
                                        <span class="input-group-addon">$</span>
                                        <asp:TextBox type="number" min="0.01" step="0.01" class="form-control input-sm" id="input10" placeholder="В % или валута" runat="server"></asp:TextBox>
                                        <asp:DropDownList class="form-control" ID="drop10" AppendDataBoundItems="true" runat="server">
                                            <asp:ListItem Text="Валута"/>
                                            <asp:ListItem Text="%"/>
                                        </asp:DropDownList>
                                    </div>
                                    <asp:Label class="col-sm-6 control-label" id="error10" text="" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="text-center col-md-10">
                                <br />
                                <br />
                                <label id="subLabel2">Годишни такси</label>
                                <br />
                                <br />
                            </div>
                            <div class="form-group">
                                <label for="input11" class="col-sm-6 control-label">Годишна такса управление</label>
                                <div class="col-sm-4" style="margin-left: 1%;">
                                    <div class="input-group">
                                        <span class="input-group-addon">$</span>
                                        <asp:TextBox type="number" min="0.01" step="0.01" class="form-control input-sm" id="input11" placeholder="В % или валута" runat="server"></asp:TextBox>
                                        <asp:DropDownList class="form-control" ID="drop11" AppendDataBoundItems="true" runat="server">
                                            <asp:ListItem Text="Валута"/>
                                            <asp:ListItem Text="%"/>
                                        </asp:DropDownList>
                                    </div>
                                    <asp:Label class="col-sm-6 control-label" id="error11" text="" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="input12" class="col-sm-6 control-label">Други годишни такси <sup>3</sup></label>
                                <div class="col-sm-4" style="margin-left: 1%;">
                                    <div class="input-group">
                                        <span class="input-group-addon">$</span>
                                        <asp:TextBox type="number" min="0.01" step="0.01" class="form-control input-sm" id="input12" placeholder="В % или валута" runat="server"></asp:TextBox>
                                        <asp:DropDownList class="form-control" ID="drop12" AppendDataBoundItems="true" runat="server">
                                            <asp:ListItem Text="Валута"/>
                                            <asp:ListItem Text="%"/>
                                        </asp:DropDownList>
                                    </div>
                                    <asp:Label class="col-sm-6 control-label" id="error12" text="" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="text-center col-md-10">
                                <br />
                                <br />
                                <label id="subLabel3">Месечни такси</label>
                                <br />
                                <br />
                            </div>
                            <div class="form-group">
                                <label for="input13" class="col-sm-6 control-label">Месечна такса управление</label>
                                <div class="col-sm-4" style="margin-left: 1%;">
                                    <div class="input-group">
                                        <span class="input-group-addon">$</span>
                                        <asp:TextBox type="number" min="0.01" step="0.01" class="form-control input-sm" id="input13" placeholder="В % или валута" runat="server"></asp:TextBox>
                                        <asp:DropDownList class="form-control" ID="drop13" AppendDataBoundItems="true" runat="server">
                                            <asp:ListItem Text="Валута"/>
                                            <asp:ListItem Text="%"/>
                                        </asp:DropDownList>
                                    </div>
                                    <asp:Label class="col-sm-6 control-label" id="error13" text="" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="input14" class="col-sm-6 control-label">Други месечни такси <sup>4</sup></label>
                                <div class="col-sm-4" style="margin-left: 1%;">
                                    <div class="input-group">
                                        <span class="input-group-addon">$</span>
                                        <asp:TextBox type="number" min="0.01" step="0.01" class="form-control input-sm" id="input14" placeholder="В % или валута" runat="server"></asp:TextBox>
                                        <asp:DropDownList class="form-control" ID="drop14" AppendDataBoundItems="true" runat="server">
                                            <asp:ListItem Text="Валута"/>
                                            <asp:ListItem Text="%"/>
                                        </asp:DropDownList>
                                    </div>
                                    <asp:Label class="col-sm-6 control-label" id="error14" text="" runat="server"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="text-center col-md-10">
                            <br />
                            <br />
                            <label id="requiredFieldsLabel">Полетата отбелязани с * са задължителни!</label>
                            <br />
                            <br />
                        </div>
                        <div class="text-center col-md-10">
                            <!-- <button type="button" class="btn btn-primary" onclick="showCreditResult();">Изчисли</button> -->
                            <asp:Button id="calculateButton" type="button" class="btn btn-primary" Text="Изчисли" onclick="CalculateResult" runat="server"/>
                        </div>
                    </div>
                </form>
            </div>
        </body>
        <script type="text/javascript">
            function showCreditResult() {
                /*Create an empty table*/
                var main = document.getElementById("mainContainer");
                var div = document.createElement("div");
                div.setAttribute("class", "jumbotron text-center col-md-10");
                div.setAttribute("id", "creditResultDiv");
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
                in1td1.innerHTML = <%=GPR%> + " %";
                tr1.appendChild(in1td1);
                tbody.appendChild(tr1);

                /*Second table row*/
                var tr2 = document.createElement("tr");
                var inth2 = document.createElement("th");
                inth2.setAttribute("scope", "row");
                inth2.innerHTML = "Погасени с лихви и такси";
                tr2.appendChild(inth2);
                var in2td1 = document.createElement("td");
                in2td1.setAttribute("id", "in2td1");
                in2td1.innerHTML = <%=pogaseni%> + " BGN";
                tr2.appendChild(in2td1);
                tbody.appendChild(tr2);

                /*Third table row*/
                var tr3 = document.createElement("tr");
                var inth3 = document.createElement("th");
                inth3.setAttribute("scope", "row");
                inth3.innerHTML = "Такси и комисионни";
                tr3.appendChild(inth3);
                var in3td1 = document.createElement("td");
                in3td1.setAttribute("id", "in3td1");
                in3td1.innerHTML = <%=taksi%> + " BGN";
                tr3.appendChild(in3td1);
                tbody.appendChild(tr3);

                /*Fourth table row*/
                var tr4 = document.createElement("tr");
                var inth4 = document.createElement("th");
                inth4.setAttribute("scope", "row");
                inth4.innerHTML = "Лихви";
                tr4.appendChild(inth4);
                var in4td1 = document.createElement("td");
                in4td1.setAttribute("id", "in4td1");
                in4td1.innerHTML = <%=lihvi%> + " BGN";
                tr4.appendChild(in4td1);
                tbody.appendChild(tr4);

                /*Fifth table row*/
                var tr5 = document.createElement("tr");
                var inth5 = document.createElement("th");
                inth5.setAttribute("scope", "row");
                inth5.innerHTML = "Вноски";
                tr5.appendChild(inth5);
                var in4td1 = document.createElement("td");
                in4td1.setAttribute("id", "in5td1");
                in4td1.innerHTML = <%=vnoski%> + " BGN";
                tr5.appendChild(in4td1);
                tbody.appendChild(tr5);

                /*Attach table to results div & attach results div to page body*/
                div.appendChild(table);
                main.appendChild(div);
            }
        </script>
    </html>
</asp:Content>
