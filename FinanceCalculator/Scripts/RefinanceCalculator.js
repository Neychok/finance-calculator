function showRefinanceResult() {
    /*Check if results div already exists. If it exists that means that the table exists as well*/
    var resultLabelDiv = document.getElementById("refinanceResultDiv");

    if (resultLabelDiv) { /*If so update all field's values to the new ones*/

        /*First table row*/
        var in1td1 = document.getElementById("in1td1"); /*First row element*/
        in1td1.innerHTML = 90 + " %";
        var in1td2 = document.getElementById("in1td2"); /*Second row element*/
        in1td2.innerHTML = 25 + " %";
        var in1td3 = document.getElementById("in1td3"); /*Third row element*/
        in1td3.innerHTML = 57 + " %";

        /*Second table row*/
        var in2td1 = document.getElementById("in2td1");
        in2td1.innerHTML = 34;
        var in2td2 = document.getElementById("in2td2");
        in2td2.innerHTML = 23;
        var in2td3 = document.getElementById("in2td3");
        in2td3.innerHTML = 67;

        /*Third table row*/
        var in3td1 = document.getElementById("in3td1");
        in3td1.innerHTML = 100.6;
        var in3td2 = document.getElementById("in3td2");
        in3td2.innerHTML = 2346.56;
        var in3td3 = document.getElementById("in3td3");
        in3td3.innerHTML = 690;

        /*Fourth table row*/
        var in4td1 = document.getElementById("in4td1");
        in4td1.innerHTML = 900.1;
        var in4td2 = document.getElementById("in4td2");
        in4td2.innerHTML = 608.345;
        var in4td3 = document.getElementById("in4td3");
        in4td3.innerHTML = 2.45;

        /*Fifth table row*/
        var in5td1 = document.getElementById("in5td1");
        in5td1.innerHTML = 3056;
        var in5td2 = document.getElementById("in5td2");
        in5td2.innerHTML = 7343.56;
        var in5td3 = document.getElementById("in5td3");
        in5td3.innerHTML = -1000.0;

    } else { /*If the table does not exist - create it and put all values in*/

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
        in1td1.innerHTML = 5 + " %";
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

        /*Attach table to results div & attach results div to page body*/
        div.appendChild(table);
        main.appendChild(div);
    }
}