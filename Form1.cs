using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Newtonsoft.Json;

namespace whazee
{
    public partial class Form1 : Form
    {

        class RouteData : List<TimeSpan>
        {
            DateTime lastUpdated;

            public RouteData(TimeSpan newTs)
            {
                Add(newTs);
            }

            public bool Expired => new TimeSpan(0,0,15) < (DateTime.Now - lastUpdated);

            public new void Add(TimeSpan newTs)
            {
                lastUpdated = DateTime.Now;
                base.Add(newTs);
            }
        }

        Dictionary<string, RouteData> _routesData = new Dictionary<string, RouteData>();


        public Form1()
        {
            InitializeComponent();
        }

        private readonly string _home2office = @"https://www.waze.com/il-RoutingManager/routingRequest?from=x%3A34.894434+y%3A31.954212&to=x%3A35.209636+y%3A31.802528&at=0&returnJSON=true&returnGeometries=true&returnInstructions=true&timeout=60000&nPaths=3&clientVersion=4.0.0&options=AVOID_TRAILS%3At%2CALLOW_UTURNS%3At";

        private readonly string _office2home =
            @"https://www.waze.com/il-RoutingManager/routingRequest?from=x:35.2114251+y:31.8023659&to=x:34.8944289+y:31.9550344&at=0&returnJSON=true&returnGeometries=true&returnInstructions=true&timeout=60000&nPaths=3&clientVersion=4.0.0&options=AVOID_TRAILS:t,ALLOW_UTURNS:t";

        private void OfflineTest()
        {
            ProcessData(File.ReadAllText(@"c:\temp\waze2-utf8.txt"));
        }

        private void Check_Click(object sender, EventArgs e)
        {

            //OfflineTest();
            //return;
            Check.Enabled = false;

            var client = new WebClient
            {
                Encoding = Encoding.UTF8,
                Headers =
                {
                    ["User-Agent"] =
                        @":Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/55.0.2883.87 Safari/537.36"
                }
            };

            client.DownloadStringCompleted += client_DownloadStringCompleted;
            client.DownloadStringAsync(new Uri(_office2home));
        }


        private void client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                Text = $"{DateTime.Now} - Error: {e.Error.Message}";
            }
            else
            {
                ProcessData(e.Result);
            }
            Check.Enabled = true;
        }


        private class RouteResults : List<Tuple<string, TimeSpan>>
        {
        }

        private void ProcessData(string alternatives)
        {
            var routeResults = new RouteResults();
            var route = JsonConvert.DeserializeObject<ClassLibrary.Route>(alternatives);
            foreach (ClassLibrary.Alternative alternative in route.alternatives)
            {
                var results = alternative.response.results;
                var ts = new TimeSpan(0, 0, results.Sum(result => result.crossTime));

                var rn = alternative.response.routeName;
                routeResults.Add(new Tuple<string, TimeSpan>(rn, ts));
            }

            foreach (var routeResult in routeResults)
            {
                RouteData rd;
                if (!_routesData.TryGetValue(routeResult.Item1, out rd))
                {
                    _routesData.Add(routeResult.Item1, new RouteData(routeResult.Item2));
                }
                else
                {
                    rd.Add(routeResult.Item2);
                }
            }

            _routesData = _routesData.Where(routeData => !routeData.Value.Expired).ToDictionary(routeData => routeData.Key, routeData => routeData.Value);

            TrafficChart.BeginInit();
            {
                TrafficChart.Series.Clear();
                TrafficChart.Legends.Clear();

                foreach (var curRoute in _routesData)
                {
                    var series = new Series(curRoute.Key) { IsVisibleInLegend = true, ChartType = SeriesChartType.Line };
                    
                    var seriesData = curRoute.Value.Select(ts => (ts.Hours == 0) ? ts.Minutes : (ts.Hours*60+ts.Minutes)).Take(20).ToList();

                    series.Points.DataBindY(seriesData);
                    TrafficChart.Series.Add(series);
                    TrafficChart.Legends.Add(curRoute.Key);
                }
            }
            TrafficChart.EndInit();
            //var lg = TrafficChart.Legends;
        }

        private string _wazeUrl;

        
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!Check.Enabled)
                return;
            Check_Click(sender, e);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            FiveMinTimer.Enabled = checkBox1.Checked;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var chart = new Chart
            {
                Width = 800,
                Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right,
                //Left = Form1.Left + lb.Width,
                //Top = lb.Top
            };
            ChartArea chartArea1 = new ChartArea();
            chart.ChartAreas.Add(chartArea1);

            Home.Checked = true;
        }

        private void Home_CheckedChanged(object sender, EventArgs e)
        {
            _wazeUrl = _office2home;
        }

        private void Work_CheckedChanged(object sender, EventArgs e)
        {
            _wazeUrl = _home2office;
        }
    }
}
