function showLeasingResult() {
    /*Check if results div already exists. If it exists that means that the table exists as well*/
    var resultLabelDiv = document.getElementById("leasingResultDiv");

    if (resultLabelDiv) { /*If so update all field's values to the new ones*/

        /*First table row*/
        var in1td1 = document.getElementById("in1td1"); /*First row element*/
        in1td1.innerHTML = 33 + " %";

        /*Second table row*/
        var in2td1 = document.getElementById("in2td1"); /*First row element*/
        in2td1.innerHTML = 67 + " BGN";

        /*Third table row*/
        var in3td1 = document.getElementById("in3td1"); /*First row element*/
        in3td1.innerHTML = 90 + " BGN";

    } else { /*If the table does not exist - create it and put all values in*/

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
        in1td1.innerHTML = -81.68 + " %";
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
}