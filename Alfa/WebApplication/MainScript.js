
google.charts.load("current", { packages: ['corechart'] });
google.charts.setOnLoadCallback(drawChart);


function drawChart() {

    var data = google.visualization.arrayToDataTable([
        ["Месяц", "Выручка"],
        ['Январь', 22000],
        ['Февраль', 25000],
        ['Март', 76900],
        ['Апрель', 99900],
        ['Май', 40000],
        ['Июнь', 33000],
        ['Июль', 7700],
        ['Август', 6000],
        ['Сентябрь', 97000],
        ['Октябрь', 43789],
        ['Ноябрь', 26785],
        ['Декабрь', 45321]
    ]);


    var view = new google.visualization.DataView(data);
    view.setColumns([0, 1,
        {
            calc: "stringify",
            sourceColumn: 1,
            type: "string",
            role: "annotation"
        }
    ]);

    var options = {
        title: "",
        width: 600,
        height: 300,
        bar: { groupWidth: "95%" },
        legend: { position: "none" },
    };
    var chart = new google.visualization.ColumnChart(document.getElementById("columnchart"));
    chart.draw(view, options);

    var table = new google.visualization.Table(document.getElementById('dataTable'));

    table.draw(data, { showRowNumber: true, width: '100%', height: '100%' });
}

google.charts.load('current', { 'packages': ['table'] });
