using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace wazer
{
    public partial class Form1 : Form
    {
       
        
        public Form1()
        {
            InitializeComponent();
            Routes.View = View.Details;
            Routes.Columns.Add("Route", 400, HorizontalAlignment.Left);
            Routes.Columns.Add("Duration", -2, HorizontalAlignment.Left);
        }

        //private string _home2Office =
            //@"https://www.waze.com/il-RoutingManager/routingRequest?from=x%3A34.894434+y%3A31.954212&to=x%3A35.209636+y%3A31.802528&at=0&returnJSON=true&returnGeometries=true&returnInstructions=true&timeout=60000&nPaths=3&clientVersion=4.0.0&options=AVOID_TRAILS%3At%2CALLOW_UTURNS%3At";


        private readonly string _office2home =
            @"https://www.waze.com/il-RoutingManager/routingRequest?from=x:35.2114251+y:31.8023659&to=x:34.8944289+y:31.9550344&at=0&returnJSON=true&returnGeometries=true&returnInstructions=true&timeout=60000&nPaths=3&clientVersion=4.0.0&options=AVOID_TRAILS:t,ALLOW_UTURNS:t";

        private void OfflineTest()
        {
            ProcessData(File.ReadAllText(@"c:\temp\waze2-utf8.txt"));
        }

        private void Check_Click(object sender, EventArgs e)
        {
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            client.Headers["User-Agent"] =
                @":Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/55.0.2883.87 Safari/537.36";

            client.DownloadStringCompleted += client_DownloadStringCompleted;
            client.DownloadStringAsync(new Uri(_office2home));
        }


        private void client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            Routes.Items.Clear();
            if (e.Error != null)
            {
                var lvi = new ListViewItem("Error:");
                lvi.SubItems.Add(e.Error.Message);
                Routes.Items.Add(lvi);
                return;
            }
            ProcessData(e.Result);
        }


        class RouteResults : List<Tuple<string, TimeSpan>>
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

            Routes.Items.Clear();
            foreach (var routeResult in routeResults)
            {
                var lvi = new ListViewItem(routeResult.Item1);
                lvi.SubItems.Add(routeResult.Item2.ToString());
                Routes.Items.Add(lvi);
            }

        }
    }
}
