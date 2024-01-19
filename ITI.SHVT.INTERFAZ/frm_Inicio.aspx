<%@ Page Title="Inicio" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="frm_Inicio.aspx.vb" Inherits="ITI.SHVT.INTERFAZ.frm_Inicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <%--<asp:SqlDataSource ID="sds_MontoFlota" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        SelectCommand="up_parque_s_MontoFlotaParque" SelectCommandType="StoredProcedure"></asp:SqlDataSource>--%>

    <div class="container-fluid">
        <div class="row">
            <%--<div class="col-md-6">
                <div class="panel panel-primary">
                    <div class="panel-heading"><b>FACTURACIÓN POR TIPO DE CLIENTE</b></div>
                    <div class="panel-body">
                        <div class="col-md-6">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 2022<div id="piechart" style="width: 350px; height: 145px;"></div>
                        </div>
                        <div class="col-md-6">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;2023<div id="piechart1" style="width: 350px; height: 145px;"></div>
                        </div>
                    </div>
                </div>
            </div>--%>
            <%--<div class="col-md-4">
                <div class="panel panel-primary">
                    <div class="panel-heading"><b>FACTURACIÓN POR TIPO DE EQUIPO</b></div>
                    <div class="panel-body">
                        <div class="col-md-6">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 2022<div id="piechart2" style="width: 280px; height: 145px;"></div>
                        </div>
                        <div class="col-md-6">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;2023<div id="piechart22" style="width: 280px; height: 145px;"></div>
                        </div>
                    </div>
                </div>
            </div>--%>
            <div class="col-md-12">
                <div class="panel panel-primary">
                    <div class="panel-heading"><b>FACTURACIÓN ELECCON / EXTERNOS</b></div>
                    <div class="panel-body">
                        <div class="col-md-12">
                            <div id="chart_div" ></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div class="panel panel-primary">
                    <div class="panel-heading">FACTURACIÓN - GASTOS - RECUPERACIÓN DE VENTA</div>
                    <div class="panel-body">
                        <div class="col-md-12">
                            <div id="GraficoNuevo"></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div class="panel panel-primary">
                    <div class="panel-heading">FACTURACIÓN HUANTAJAYA EQUIPOS S.A.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  -&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; PROMEDIO FACTURACIÓN 2022: $ 65.712.294</div>
                    <div class="panel-body">
                        <div class="col-md-12">
                            <div id="chart_div2"></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>



    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <script type="text/javascript">
        google.charts.load('current', { 'packages': ['corechart'] });
        google.charts.setOnLoadCallback(drawChart);

        function drawChart() {

            var data = google.visualization.arrayToDataTable([
                ['Task', 'Hours per Day'],
                ['Work', 0],
                ['Externos', 523557767],
                ['Isi-Elec', 0],
                ['Eleccon', 264173094]
            ]);

            var options = {
                is3D: true,
                colors: ['green', '#152f63', '#f0ac00']
            };

            var chart = new google.visualization.PieChart(document.getElementById('piechart'));

            chart.draw(data, options);
        }
    </script>
    <script type="text/javascript">
        google.charts.load('current', { 'packages': ['corechart'] });
        google.charts.setOnLoadCallback(drawChart);

        function drawChart() {

            var data = google.visualization.arrayToDataTable([
                ['Task', 'Hours per Day'],
                ['Work', 0],
                ['Externos', 244391892],
                ['Isi-Elec', 0],
                ['Eleccon', 125128017]
            ]);

            var options = {
                is3D: true,
                colors: ['green', '#152f63', '#f0ac00']
            };

            var chart = new google.visualization.PieChart(document.getElementById('piechart1'));

            chart.draw(data, options);
        }
    </script>

    <script type="text/javascript">
        google.charts.load('current', { 'packages': ['corechart'] });
        google.charts.setOnLoadCallback(drawChart);

        function drawChart() {

            var data = google.visualization.arrayToDataTable([
                ['Task', 'Hours per Day'],
                ['Work', 0],
                ['U.Menores', 294108804],
                ['U.Mayores', 493622057]
            ]);

            var options = {
                is3D: true,
                colors: ['green', '#152f63', '#f0ac00']
            };

            var chart = new google.visualization.PieChart(document.getElementById('piechart2'));

            chart.draw(data, options);
        }
    </script>
    <script type="text/javascript">
        google.charts.load('current', { 'packages': ['corechart'] });
        google.charts.setOnLoadCallback(drawChart);

        function drawChart() {

            var data = google.visualization.arrayToDataTable([
                ['Task', 'Hours per Day'],
                ['Work', 0],
                ['U.Menores', 60233763],
                ['U.Mayores', 96946332]
            ]);

            var options = {
                is3D: true,
                colors: ['green', '#152f63', '#f0ac00']
            };

            var chart = new google.visualization.PieChart(document.getElementById('piechart22'));

            chart.draw(data, options);
        }
    </script>
    <script type="text/javascript">
        google.charts.load('current', { 'packages': ['corechart'] });
        google.charts.setOnLoadCallback(drawChart);

        function drawChart() {

            var data = google.visualization.arrayToDataTable([
                ['Task', 'Hours per Day'],
                ['Work', 0],
                ['Iquique', 740578567],
                ['Arica', 42129941]
            ]);

            var options = {
                is3D: true,
                colors: ['green', '#152f63', '#f0ac00']
            };

            var chart = new google.visualization.PieChart(document.getElementById('piechart3'));

            chart.draw(data, options);
        }
    </script>

    <script type="text/javascript">
        google.charts.load('current', { 'packages': ['corechart'] });
        google.charts.setOnLoadCallback(drawChart);

        function drawChart() {

            var data = google.visualization.arrayToDataTable([
                ['Task', 'Hours per Day'],
                ['Work', 0],
                ['Iquique', 669101900],
                ['Arica', 121229245]
            ]);

            var options = {
                is3D: true,
                colors: ['green', '#152f63', '#f0ac00']
            };

            var chart = new google.visualization.PieChart(document.getElementById('piechart33'));

            chart.draw(data, options);
        }
    </script>

    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>

    <script type="text/javascript">
        google.charts.load('current', { 'packages': ['gauge'] });
        google.charts.setOnLoadCallback(drawChart);

        function drawChart() {
            var data = google.visualization.arrayToDataTable([
                ['Label', 'Value'],
                ['ST', 2]
            ]);
            var options = {
                width: 400, height: 120,
                redFrom: 60, redTo: 100,
                yellowFrom: 20, yellowTo: 60,
                greenFrom: 0, greenTo: 20,
                minorTicks: 5
            };
            var chart = new google.visualization.Gauge(document.getElementById('chart_divST'));
            chart.draw(data, options);
        }
    </script>

    <script type="text/javascript">
        google.charts.load('current', { 'packages': ['gauge'] });
        google.charts.setOnLoadCallback(drawChart);

        function drawChart() {
            var data = google.visualization.arrayToDataTable([
                ['Label', 'Value'],

                ['STOCK', 8]
            ]);
            var options = {
                width: 400, height: 120,
                redFrom: 0, redTo: 10,
                yellowFrom: 10, yellowTo: 30,
                greenFrom: 30, greenTo: 100,
                minorTicks: 5
            };
            var chart = new google.visualization.Gauge(document.getElementById('chart_divSTOCK'));
            chart.draw(data, options);
        }
    </script>
    <script type="text/javascript">
        google.charts.load('current', { 'packages': ['gauge'] });
        google.charts.setOnLoadCallback(drawChart);

        function drawChart() {
            var data = google.visualization.arrayToDataTable([
                ['Label', 'Value'],

                ['ARRIENDO', 74]
            ]);
            var options = {
                width: 400, height: 120,
                redFrom: 0, redTo: 30,
                yellowFrom: 30, yellowTo: 60,
                greenFrom: 60, greenTo: 100,
                minorTicks: 5
            };
            var chart = new google.visualization.Gauge(document.getElementById('chart_divARRIENDO'));
            chart.draw(data, options);
        }
    </script>
    <script type="text/javascript">
        google.charts.load('current', { packages: ['corechart', 'bar'] });
        google.charts.setOnLoadCallback(drawAnnotations);

        function drawAnnotations() {
            var data = google.visualization.arrayToDataTable([
                ['Genre', 'Eleccon', 'Externos',
                    { role: 'annotation' }],

                ['Prom. 2022', 22014424, 43697870, ''],
                ['Enero', 30964017, 54618873, ''],
                ['Febrero', 28680981, 27242027, ''],
                ['Marzo', 19045037, 31625596, ''],
                ['Abril', 11460418, 24460737, ''],
                ['Mayo', 13327620, 45174692, ''],
                ['Junio', 10489261, 31580878, ''],
                ['Julio', 11160683, 29689089, ''],
                ['Agosto', 13942110, 30857977, ''],
                ['Septiembre', 15114964, 40900481, ''],
                ['Octubre', 14834175, 98965869, '']

            ]);

            var options = {
                width: 1500,
                height: 200,
                legend: { position: 'botton', maxLines: 3 },
                bar: { groupWidth: '85%' },
                colors: ['green', '#152f63'],
                isStacked: true,
            };

            var chart = new google.visualization.ColumnChart(document.getElementById('chart_div'));
            chart.draw(data, options);
        } </script>


    <script type="text/javascript">
        google.charts.load('current', { packages: ['corechart', 'bar'] });
        google.charts.setOnLoadCallback(drawAnnotations);

        function drawAnnotations() {
            var data = google.visualization.arrayToDataTable([
                ['Genre', 'U. Menores', 'Generadores', ' Mov. Tierra', 'Otros',
                    { role: 'annotation' }],

               
                
                ['Ene 23', 25071527, 17119292, 38873686, 4068385, ''],
                ['Feb 23', 24896463, 17681902, 9040357, 4304286, ''],
                ['Mar 23', 24967576, 16355457, 7127600, 2220000, ''],
                ['Abr 23', 11139118, 14905131, 6378800, 3498106, ''],
                ['May 23', 21080061, 13797331, 17728400, 5896520, ''],
                ['Jun 23', 11489575, 16930901, 8237063, 5412600, ''],
                ['Jul 23', 12780302, 16304488, 6638000, 5126982, ''],
                ['Ago 23', 12659086, 13538034, 13658000, 4944967, ''],
                ['Sep 23', 20887253, 14176220, 14434533, 6517439, ''],
                ['Oct 23', 12999535, 11518515, 80779200, 8502794, '']


            ]);

            var options = {
                width: 1650,
                height: 350,
                legend: { position: 'botton', maxLines: 4 },
                bar: { groupWidth: '85%' },
                colors: ['#152f63', 'Yellow', '#f4c303', '#40afde'],
                isStacked: true,
            };

            var chart = new google.visualization.ColumnChart(document.getElementById('chart_div2'));
            chart.draw(data, options);
        } </script>




    <script type="text/javascript">
        google.charts.load('current', { 'packages': ['line', 'corechart'] });
        google.charts.setOnLoadCallback(drawChart);

        function drawChart() {

            var button = document.getElementById('change-chart');
            var chartDiv = document.getElementById('chart_div');

            var data = new google.visualization.DataTable();
            data.addColumn('date', 'Meses');
            data.addColumn('number', "Facturación");
            data.addColumn('number', "Gastos");
            data.addColumn('number', "Recuperación de venta");

            data.addRows([
                // [new Date(2022, 0),   72272466,  69580959, 64393335],
                //[new Date(2022, 1),   75696567,  62599036, 65572527],
                // [new Date(2022, 2),   63934383,  76857455, 85161985],
               
                [new Date(2023, 0), 85582890, 60883572, 114840492],
                [new Date(2023, 1), 55923008, 64371411, 61997571],
                [new Date(2023, 2), 50670633, 66402219, 90251510],
                [new Date(2023, 3), 35921155, 54708760, 60233875],
                [new Date(2023, 4), 58502312, 55694371, 39783276],
                [new Date(2023, 5), 42070139, 55518487, 59106340],
                [new Date(2023, 6), 40849772, 56530226, 52048646],
                [new Date(2023, 7), 44800087, 49173898, 45913966],
                [new Date(2023, 8), 56015445, 57774057, 74848093],
                [new Date(2023, 9), 113800044, 64449646, 67715461]
                //[new Date(2023, 9), 0, 0, 0]

                //[new Date(2022, 10),   0,  0, 0],
                // [new Date(2022, 11),   0,  0, 0]
            ]);

            var materialOptions = {
                chart: {
                    title: ''
                },
                width: 1650,
                height: 350,
                series: {
                    // Gives each series an axis name that matches the Y-axis below.
                    //0: {axis: 'Millones'},
                    //1: {axis: 'Daylight'}
                },
                axes: {
                    // Adds labels to each axis; they don't have to match the axis names.
                    y: {
                        Temps: { label: 'Temps (Celsius)' },
                      
                    }
                }
            };

            var classicOptions = {
                title: 'Average Temperatures and Daylight in Iceland Throughout the Year',
                width: 900,
                height: 500,
                // Gives each series an axis that matches the vAxes number below.
                series: {
                    0: { targetAxisIndex: 0 },
                    // 1: {targetAxisIndex: 1}
                },
                vAxes: {
                    // Adds titles to each axis.
                    0: { title: 'Temps (Celsius)' },
                    //1: {title: 'Daylight'}
                },
                hAxis: {
                    ticks: [new Date(2014, 0), new Date(2014, 1), new Date(2014, 2), new Date(2014, 3),
                    new Date(2014, 4), new Date(2014, 5), new Date(2014, 6), new Date(2014, 7),
                    new Date(2014, 8), new Date(2014, 9), new Date(2014, 10), new Date(2014, 11)
                    ]
                },
                vAxis: {
                    viewWindow: {
                        max: 30
                    }
                }
            };

            function drawMaterialChart() {
                var materialChart = new google.charts.Line(GraficoNuevo);
                materialChart.draw(data, materialOptions);
                button.innerText = 'Change to Classic';
                button.onclick = drawClassicChart;
            }

            function drawClassicChart() {
                var classicChart = new google.visualization.LineChart(GraficoNuevo);
                classicChart.draw(data, classicOptions);
                button.innerText = 'Change to Material';
                button.onclick = drawMaterialChart;
            }

            drawMaterialChart();

        }
    </script>

</asp:Content>
