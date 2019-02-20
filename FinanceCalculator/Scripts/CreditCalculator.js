function showCreditResult() {
    /*Check if results div already exists. If it exists that means that the table exists as well*/
    var resultLabelDiv = document.getElementById("creditResultDiv");
    if (resultLabelDiv) { /*If so update all field's values to the new ones*/
        /*First table row*/
        var in1td1 = document.getElementById("in1td1"); /*First row element*/
        in1td1.innerHTML = 7.45 + " %";

        /*Second table row*/
        var in2td1 = document.getElementById("in2td1");
        in2td1.innerHTML = 1545 + " BGN";

        /*Third table row*/
        var in3td1 = document.getElementById("in3td1");
        in3td1.innerHTML = 1.6 + " BGN";

        /*Fourth table row*/
        var in4td1 = document.getElementById("in4td1");
        in4td1.innerHTML = 134.9 + "BGN";

        /*Fifth table row*/
        var in5td1 = document.getElementById("in5td1");
        in5td1.innerHTML = 1545 + " BGN";
    } else {
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
        in1td1.innerHTML = 5.1161 + " %";
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
        in2td1.innerHTML = 10270.83 + " BGN";
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
        in3td1.innerHTML = 0.00 + " BGN";
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
        in4td1.innerHTML = 270.83 + " BGN";
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
        in4td1.innerHTML = 10270.83 + " BGN";
        tr5.appendChild(in4td1);
        tbody.appendChild(tr5);

        /*Attach table to results div & attach results div to page body*/
        div.appendChild(table);
        main.appendChild(div);
    }
}