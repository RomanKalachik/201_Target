using DataGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WinCharts
{
    public partial class Form1 : Form
    {
        IList<DataItem> chartSource;
        long prevAvailable = 0;
        WPFChart.MainWindow window;

        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;
        }

        void AddMessageToLog(string message)
        {
            log.Text += message;
            log.SelectionStart = log.Text.Length;
            log.ScrollToCaret();
        }

        private void bindDataWin(object sender, EventArgs e)
        {
            series1.DataSource = chartSource;
            series1.DataSourceSorted = true;
            series1.ValueDataMembers.AddRange(new string[] { "Value" });
            series1.ArgumentDataMember = "Argument";
            series1.NumericSummaryOptions.SummaryFunction = "AVERAGE([Value])";
            series1.NumericSummaryOptions.MeasureUnit = 1000;
            LogMemConsumption();
        }


        private void bindDataWpf(object sender, EventArgs e)
        {
            window = new WPFChart.MainWindow();
            DevExpress.Xpf.Charts.XYDiagram2D diagram = new DevExpress.Xpf.Charts.XYDiagram2D();
            window.Chart.Diagram = diagram;
            diagram.EnableAxisXNavigation = true;
            diagram.EnableAxisYNavigation = true;
            var series = new DevExpress.Xpf.Charts.LineSeries2D();
            diagram.Series.Add(series);

            series.DataSource = chartSource;
            series.ArgumentDataMember = "Argument";
            series.ValueDataMember = "Value";

            window.Show();

            LogMemConsumption();
        }

        static String BytesToString(long byteCount)
        {
            string[] suf = { "B", "KB", "MB", "GB", "TB", "PB", "EB" };
            if (byteCount == 0)
                return "0" + suf[0];
            long bytes = Math.Abs(byteCount);
            int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            double num = Math.Round(bytes / Math.Pow(1024, place), 1);
            return (Math.Sign(byteCount) * num).ToString() + suf[place];
        }

        private void clearDataClick(object sender, EventArgs e)
        {
            chartSource = null;
            LogMemConsumption();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LogMemConsumption();
            series1 = chartControl1.Chart.Series[0];
        }

        private void generate_1K(object sender, EventArgs e)
        {
            chartSource = DataGenerator.Generator.Generate(10000);
            LogMemConsumption();
        }

        private void generateDataClick(object sender, EventArgs e)
        {
            chartSource = DataGenerator.Generator.Generate(1000000);
            LogMemConsumption();
        }

        void LogMemConsumption()
        {
            var available = GC.GetTotalMemory(true);
            if (prevAvailable > 0)
                AddMessageToLog(string.Format("available memory {0}" + Environment.NewLine,
                                              BytesToString(prevAvailable - available)));
            prevAvailable = available;
        }

        private void unBindDataClick(object sender, EventArgs e)
        {
            series1.DataSource = null;
            LogMemConsumption();
        }

        private void UnBindDataWpf(object sender, EventArgs e)
        {
            window?.Close();
            window = null;
            LogMemConsumption();
        }
    }
}