using DataGenerator;
using DevExpress.XtraCharts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;
using WPFChart;

namespace WinCharts {
    public partial class Form1 : Form {
        ObservableCollection<DataItem> chartSource;
        long prevAvailable = 0;
        MainWindow window;

        public Form1() {
            InitializeComponent();
        }

        void AddMessageToLog(string message) {
            log.Text += message;
            log.SelectionStart = log.Text.Length;
            log.ScrollToCaret();
        }

        void bindDataWin(object sender, EventArgs e) {
            var series = new DevExpress.XtraCharts.Series();
            chartControl1.Series.Add(series);
            series.AllowResample = true;
            series.BindToData(chartSource, "Argument", "Value");
            series.View = (XYDiagramSeriesViewBase)Activator.CreateInstance(Type.GetType("DevExpress.XtraCharts." + viewTypeNames[seriesTypeCombo.SelectedIndex] + ", DevExpress.XtraCharts.v20.2"));
            series.SetFinancialDataMembers("Argument", "Value", "Value2", "Value3", "Value4");

            var d2d = chartControl1.Diagram as DevExpress.XtraCharts.XYDiagram2D;
            d2d.ZoomingOptions.AxisXMaxZoomPercent = 100000000;
            d2d.ZoomingOptions.AxisYMaxZoomPercent = 100000000;
            series1.ArgumentDataMember = "Argument";
            LogMemConsumption();
        }


        void bindDataWpf(object sender, EventArgs e) {
            if (window == null || !window.IsVisible)
                window = new MainWindow();
            DevExpress.Xpf.Charts.XYDiagram2D diagram;
            diagram = window.Chart.Diagram as DevExpress.Xpf.Charts.XYDiagram2D;
            if (diagram == null)
                diagram = new DevExpress.Xpf.Charts.XYDiagram2D();
            window.Chart.Diagram = diagram;
            diagram.EnableAxisXNavigation = true;
            diagram.EnableAxisYNavigation = true;
            diagram.NavigationOptions = new DevExpress.Xpf.Charts.NavigationOptions() { AxisXMaxZoomPercent = 100000000, AxisYMaxZoomPercent = 100000000 };
            var series = (DevExpress.Xpf.Charts.XYSeries2D)Activator.CreateInstance(Type.GetType("DevExpress.Xpf.Charts." + seriesTypeCombo.SelectedItem + ", DevExpress.Xpf.Charts.v20.2"));
            series.AllowResample = true;
            window.Chart.CrosshairEnabled = true;
            diagram.Series.Add(series);

            series.DataSource = chartSource;
            series.ArgumentDataMember = "Argument";
            series.ValueDataMember = "Value";
            var finSeries = series as DevExpress.Xpf.Charts.FinancialSeries2D;
            if (finSeries != null ) {
                finSeries.OpenValueDataMember = "Value2";
                finSeries.CloseValueDataMember = "Value3";
                finSeries.LowValueDataMember = "Value4";
            }
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
            chartControl1.Series.Clear();
            LogMemConsumption();
        }
        string[] viewTypeNames = new string[] {
            "LineSeriesView",
            "SplineSeriesView",
            "SplineAreaSeriesView",
            "StackedSplineAreaSeriesView",
            "AreaSeriesView",
            "StepAreaSeriesView",
            "StackedStepAreaSeriesView",
            "StackedAreaSeriesView",
            "StackedBarSeriesView",
            "CandleStickSeriesView",
            "StockSeriesView"
        };
        void Form1_Load(object sender, EventArgs e) {
            seriesTypeCombo.Items.AddRange(new object[] {
                                               "LineSeries2D",
                                               "SplineSeries2D",
                                               "SplineAreaSeries2D",
                                               "SplineAreaStackedSeries2D",
                                               "AreaSeries2D",
                                               "AreaStepSeries2D",
                                               "AreaStepStackedSeries2D",
                                               "AreaStackedSeries2D",
                                               "BarStackedSeries2D",
                                               "CandleStickSeries2D",
                                               "StockSeries2D",
            });
            seriesTypeCombo.SelectedIndex = 0;

            LogMemConsumption();
            series1 = chartControl1.Chart.Series[0];
        }

        void generate_20K(object sender, EventArgs e) {
            chartSource = Generator.Generate(20000);
            LogMemConsumption();
        }

        void generateDataClick(object sender, EventArgs e) {
            chartSource = Generator.Generate(1000000);
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
            chartSource = Generator.Generate(10);
            LogMemConsumption();

        }

        void generate20MPoints(object sender, EventArgs e) {
            chartSource = Generator.Generate(20 * 1000 * 1000);
            LogMemConsumption();
        }

        void button10_Click(object sender, EventArgs e) {
            chartSource = Generator.Generate(120 * 1000 * 1000);
            LogMemConsumption();
        }
        Timer timer;

        void startRealtimeUpdates(object sender, EventArgs e) {
            timer = new Timer();
            timer.Interval = 300;
            timer.Tick += (s, ee) =>
            {
                if (chartSource == null) return;
                for (int i = 0; i < 1000; i++) {
                    Generator.UpdateSource(chartSource);
                }
            };
            timer.Start();
        }

        private void x10WinClick(object sender, EventArgs e)
        {
            if (chartSource == null) return;
            for (int i = 0; i < 10; i++)
            {
                chartSource = Generator.Generate(chartSource.Count);
                bindDataWin(null, null);
            }
        }

        private void x10WpfClick(object sender, EventArgs e)
        {
            if (chartSource == null) return;
            for (int i = 0; i < 10; i++)
            {
                chartSource = Generator.Generate(chartSource.Count);
                bindDataWpf(null, null);
            }
        }
    }
}