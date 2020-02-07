using DataGenerator;
using DevExpress.Xpf.Charts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using WPFChart;

namespace WinCharts {
    public partial class Form1 : Form {
        IList<object> chartSource;
        long prevAvailable = 0;
        MainWindow window;

        public Form1() {
            InitializeComponent();
            Load += Form1_Load;
        }

        void AddMessageToLog(string message) {
            log.Text += message;
            log.SelectionStart = log.Text.Length;
            log.ScrollToCaret();
        }

        void bindDataWin(object sender, EventArgs e) {
            series1.DataSource = chartSource;
            series1.DataSourceSorted = true;
            series1.ValueDataMembers.AddRange(new string[] { "Value" });
            series1.ArgumentDataMember = "Argument";
            LogMemConsumption();
        }


        void bindDataWpf(object sender, EventArgs e) {
            window = new MainWindow();
            XYDiagram2D diagram = new XYDiagram2D();
            window.Chart.Diagram = diagram;
            diagram.EnableAxisXNavigation = true;
            diagram.EnableAxisYNavigation = true;
            diagram.NavigationOptions = new NavigationOptions() { AxisXMaxZoomPercent = 1000000, AxisYMaxZoomPercent = 1000000 };
            Series series = (Series)Activator.CreateInstance(Type.GetType("DevExpress.Xpf.Charts." + seriesTypeCombo.SelectedItem + ", DevExpress.Xpf.Charts.v20.1"));
            window.Chart.CrosshairEnabled = true;
            diagram.Series.Add(series);

            series.DataSource = chartSource;
            series.ArgumentDataMember = "Argument";
            series.ValueDataMember = "Value";

            window.Show();

            LogMemConsumption();
        }

        static String BytesToString(long byteCount) {
            string[] suf = { "B", "KB", "MB", "GB", "TB", "PB", "EB" };
            if (byteCount == 0)
                return "0" + suf[0];
            long bytes = Math.Abs(byteCount);
            int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            double num = Math.Round(bytes / Math.Pow(1024, place), 1);
            return (Math.Sign(byteCount) * num).ToString() + suf[place];
        }

        void clearDataClick(object sender, EventArgs e) {
            chartSource = null;
            LogMemConsumption();
        }

        void Form1_Load(object sender, EventArgs e) {
            LogMemConsumption();
            series1 = chartControl1.Chart.Series[0];
        }

        void generate_20K(object sender, EventArgs e) {
            GenerateCore(20000);
            LogMemConsumption();
        }

        void generateDataClick(object sender, EventArgs e) {
            GenerateCore(1000000);
            LogMemConsumption();
        }

        void LogMemConsumption() {
            long available = GC.GetTotalMemory(true);
            if (prevAvailable > 0)
                AddMessageToLog(string.Format("available memory {0}" + Environment.NewLine,
                                              BytesToString(prevAvailable - available)));
            prevAvailable = available;
        }

        void unBindDataClick(object sender, EventArgs e) {
            series1.DataSource = null;
            LogMemConsumption();
        }

        void UnBindDataWpf(object sender, EventArgs e) {
            window?.Close();
            window = null;
            LogMemConsumption();
        }

        void generate10Points(object sender, EventArgs e) {
            GenerateCore(10);
            LogMemConsumption();

        }

        void generate20MPoints(object sender, EventArgs e) {
            GenerateCore(20 * 1000 * 1000);
            LogMemConsumption();
        }

        void button10_Click(object sender, EventArgs e) {

            GenerateCore(120 * 1000 * 1000);
            LogMemConsumption();
        }

        void GenerateCore(long count) {
            Type t = Type.GetType("System." + (string)dataTypeCombo.SelectedItem);
            Type genericClass = typeof(Generator<>);
            Type constructedClass = genericClass.MakeGenericType(t);
            chartSource = (IList<object>)constructedClass.InvokeMember("Generate", BindingFlags.InvokeMethod | BindingFlags.Static | BindingFlags.Public, null, null, new object[] { count });
        }

        void Form1_Load_1(object sender, EventArgs e) {
            dataTypeCombo.Items.AddRange(new object[] { "Double", "Single", "Decimal" });
            dataTypeCombo.SelectedIndex = 0;
            seriesTypeCombo.Items.AddRange(new object[] {"LineSeries2D",
                                               "SplineSeries2D",
                                               "SplineAreaSeries2D",
                                               "SplineAreaStackedSeries2D",
                                               "AreaSeries2D",
                                               "AreaStepSeries2D",
                                               "AreaStepStackedSeries2D",
                                               "AreaStackedSeries2D",
                                               //"BarSideBySideSeries2D", 
                                               //"BarSideBySideStackedSeries2D",
                                               "BarStackedSeries2D",
            });
            seriesTypeCombo.SelectedIndex = 0;

        }
    }
}