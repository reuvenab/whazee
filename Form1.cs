using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace whazee
{
    public partial class Form1 : Form
    {
       
        
        public Form1()
        {
            InitializeComponent();
            Routes.DrawMode = TabDrawMode.OwnerDrawFixed;

            Routes1.View = View.Details;
            Routes1.Columns.Add("Route", 400, HorizontalAlignment.Left);
            Routes1.Columns.Add("Duration", -2, HorizontalAlignment.Left);
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
            //OfflineTest();
            //return;


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
            Routes1.Items.Clear();
            if (e.Error != null)
            {
                var lvi = new ListViewItem("Error:");
                lvi.SubItems.Add(e.Error.Message);
                Routes1.Items.Add(lvi);
                return;
            }
            ProcessData(e.Result);
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

            var newTabPages = new List<TabPage>();
            foreach (var routeResult in routeResults)
            {
                ListBox lb =
                    (from TabPage tabPage in Routes.TabPages
                        where tabPage.Text == routeResult.Item1
                        select (ListBox) tabPage.Controls[0]).FirstOrDefault();
                List<TimeSpan> ds;

                if (lb == null)
                {
                    var ntp = new TabPage {Text = routeResult.Item1, Tag = notChanged };
                    ds = new List<TimeSpan>();
                    lb = new ListBox
                    {
                        //DisplayMember = "Name",
                        //ValueMember = "Titles",
                        Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom,
                        //Top = tb.Height,
                        //Width = t.Width / 4,
                        //Height = t.Height - tb.Height,
                        //Tag = ds
                    };
                    ntp.Controls.Add(lb);
                    ntp.AutoSize = true;
                    newTabPages.Add(ntp);
                }
                else
                {
                    ds = (List<TimeSpan>)lb.DataSource;
                }
                ds.Insert(0, routeResult.Item2);
                lb.DataSource = null;
                lb.DataSource = ds;
            }
            Routes.TabPages.AddRange(newTabPages.ToArray());

            if (0 < Routes.TabPages.Count)
            {
                ColorRoutes();
            }
              
        }

        private TimeSpan FirstTimeSpan(TabPage ts)
        {
            var lb = (ListBox)ts.Controls[0];
            var ds = (List<TimeSpan>)lb.DataSource;
            return ds[0];
        }

        private TimeSpan SecondTimeSpan(TabPage ts)
        {
            var lb = (ListBox)ts.Controls[0];
            var ds = (List<TimeSpan>) lb.DataSource;
            return (1 < ds.Count) ? ds[1] : ds[0];
        }

        private Color improved = Color.Green;
        private Color notChanged = Color.Gray;
        private Color worsened = Color.Red;


        private void ColorRoutes()
        {
            var minimalRoute = Routes.TabPages[0];
            var minTimeSpan = FirstTimeSpan(minimalRoute);
            foreach (TabPage tabPage in Routes.TabPages)
            {
                var curTimeSpan = FirstTimeSpan(tabPage);
                var prevTimeSpan = SecondTimeSpan(tabPage);
                if (curTimeSpan < minTimeSpan)
                {
                    minimalRoute.Font = new Font(minimalRoute.Font.FontFamily, minimalRoute.Font.SizeInPoints);
                    minimalRoute = tabPage;
                }

                if (curTimeSpan < prevTimeSpan)
                {
                    tabPage.Tag = improved;
                }
                else
                {
                    tabPage.Tag = prevTimeSpan < curTimeSpan ? worsened : notChanged;
                }
            }
            minimalRoute.Tag = Color.Gold;
            //Routes.TabPages.Remove(minimalRoute);
            //Routes.TabPages.Insert(0, minimalRoute);
                //new Font(minimalRoute.Font.FontFamily, minimalRoute.Font.SizeInPoints, FontStyle.Bold); 
            this.Refresh();
        }

        private void Routes_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabPage tp = Routes.TabPages[e.Index];
            Color bc = (Color) tp.Tag;

            using (Brush br = new SolidBrush(bc))
            {
                e.Graphics.FillRectangle(br, e.Bounds);
                Font f = e.Font;
                if (bc == Color.Gold)
                    f = new Font(f.FontFamily, f.SizeInPoints, FontStyle.Bold);
                SizeF sz = e.Graphics.MeasureString(tp.Text, e.Font);
                e.Graphics.DrawString(tp.Text, e.Font, Brushes.Black, e.Bounds.Left + (e.Bounds.Width - sz.Width) / 2, e.Bounds.Top + (e.Bounds.Height - sz.Height) / 2 + 1);
                Rectangle rect = e.Bounds;
                rect.Offset(0, 1);
                rect.Inflate(0, -1);
                e.Graphics.DrawRectangle(Pens.DarkGray, rect);
                e.DrawFocusRectangle();
            }
        }
    }
}
