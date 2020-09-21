using DataGenerator;
using DevExpress.XtraCharts;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using WPFChart;
namespace WinCharts {
    public partial class Form1 : Form {
        ObservableCollection<DataItem> chartSource;
        ViewType[] excludedViewTypes = new ViewType[] {
            ViewType.BoxPlot,
            ViewType.Bubble,
            ViewType.Point,
            ViewType.ScatterLine,
            ViewType.ScatterPolarLine,
            ViewType.ScatterRadarLine,
            ViewType.PolarPoint,
            ViewType.RadarPoint,
            ViewType.Pie,
            ViewType.Doughnut,
            ViewType.NestedDoughnut,
            ViewType.Pie3D,
            ViewType.Doughnut3D,
            ViewType.Funnel,
            ViewType.Funnel3D
        };
        long prevAvailable = 0;
        Series series;
        Timer timer;
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
            series = new Series();
            chartControl1.Series.Add(series);
            series.AllowResample = true;
            series.BindToData(chartSource, "Argument", "Value");
            series.ChangeView((ViewType)seriesTypeCombo.SelectedItem);
            AllowInteractionsIn3D();
            series.SetFinancialDataMembers("Argument", "Value4", "Value2", "Value", "Value3");

            XYDiagram2D d2d = chartControl1.Diagram as XYDiagram2D;
            if (d2d != null) {
                d2d.ZoomingOptions.AxisXMaxZoomPercent = 100000000;
                d2d.ZoomingOptions.AxisYMaxZoomPercent = 100000000;
            }

            var d3d = chartControl1.Diagram as DevExpress.XtraCharts.Diagram3D;
            if(d3d != null) {
                d3d.RuntimeRotation = true;
                d3d.RuntimeScrolling = true;
                d3d.RuntimeZooming = true;
            }

            Bar3DSeriesView view = series.View as Bar3DSeriesView;
            if(view != null) {
                view.BarDepthAuto = false;
                view.BarDepth = 10000;
                view.BarWidth = 10000;
            }

            //series1.ArgumentDataMember = "Argument";
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
            DevExpress.Xpf.Charts.XYSeries2D series = (DevExpress.Xpf.Charts.XYSeries2D)Activator.CreateInstance(Type.GetType("DevExpress.Xpf.Charts." + seriesTypeCombo.SelectedItem + ", DevExpress.Xpf.Charts.v20.2"));
            series.AllowResample = true;
            window.Chart.CrosshairEnabled = true;
            diagram.Series.Add(series);

            series.DataSource = chartSource;
            series.ArgumentDataMember = "Argument";
            series.ValueDataMember = "Value";
            DevExpress.Xpf.Charts.FinancialSeries2D finSeries = series as DevExpress.Xpf.Charts.FinancialSeries2D;
            if (finSeries != null) {
                finSeries.OpenValueDataMember = "Value2";
                finSeries.CloseValueDataMember = "Value3";
                finSeries.LowValueDataMember = "Value4";
            }
            window.Show();

            LogMemConsumption();
        }
        void button10_Click(object sender, EventArgs e) {
            GenerateCore(120 * 1000 * 1000);
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
        void Form1_Load(object sender, EventArgs e) {
            dataTypeCombo.Items.AddRange(new object[] {
                "Generate",
               "Generate2DPoins",
                "Generate2DPoins_Circle"
            });
            dataTypeCombo.SelectedIndex = 0;

            foreach (ViewType viewType in Enum.GetValues(typeof(ViewType))) {
                if (!excludedViewTypes.Contains(viewType)) {
                    seriesTypeCombo.Items.Add(viewType);
                }
            }

            seriesTypeCombo.SelectedIndex = 0;

            LogMemConsumption();
        }
        void generate_20K(object sender, EventArgs e) {
            GenerateCore(20000);
        }
        void generate10Points(object sender, EventArgs e) {
            GenerateCore(10);
        }
        void generate20MPoints(object sender, EventArgs e) {
            GenerateCore(20 * 1000 * 1000);
        }
        void GenerateCore(long count) {
            chartSource = (ObservableCollection<DataItem>)typeof(Generator).InvokeMember((string)dataTypeCombo.SelectedItem, BindingFlags.Static | BindingFlags.Public | BindingFlags.InvokeMethod, null, null, new object[] { count });
            LogMemConsumption();
        }
        void generateDataClick(object sender, EventArgs e) {
            GenerateCore(1000000);
        }
        void LogMemConsumption() {
            long available = GC.GetTotalMemory(true);
            if (prevAvailable > 0)
                AddMessageToLog(string.Format("available memory {0}" + Environment.NewLine,
                                              BytesToString(prevAvailable - available)));
            prevAvailable = available;
        }
        void seriesTypeCombo_SelectedIndexChanged(object sender, EventArgs e) {
            foreach (Series series in chartControl1.Series)
                series.ChangeView((ViewType)seriesTypeCombo.SelectedItem);
            AllowInteractionsIn3D();
        }

        private void AllowInteractionsIn3D() {
            var s3d = chartControl1.Diagram as Diagram3D;
            if (s3d != null) {
                s3d.RuntimeRotation = true;
                s3d.RuntimeScrolling = true;
                s3d.RuntimeZooming = true;
            }
        }

        void startRealtimeUpdates(object sender, EventArgs e) {
            timer = new Timer();
            timer.Interval = 300;
            timer.Tick += (s, ee) => {
                if (chartSource == null) return;
                for (int i = 0; i < 1000; i++) {
                    Generator.UpdateSource(chartSource);
                }
            };
            timer.Start();
        }
        void unBindDataClick(object sender, EventArgs e) {
            series.DataSource = null;
            LogMemConsumption();
        }
        void UnBindDataWpf(object sender, EventArgs e) {
            window?.Close();
            window = null;
            LogMemConsumption();
        }
        void x10WinClick(object sender, EventArgs e) {
            if (chartSource == null) return;
            for (int i = 0; i < 10; i++) {
                chartSource = Generator.Generate(chartSource.Count);
                bindDataWin(null, null);
            }
        }
        void x10WpfClick(object sender, EventArgs e) {
            if (chartSource == null) return;
            for (int i = 0; i < 10; i++) {
                chartSource = Generator.Generate(chartSource.Count);
                bindDataWpf(null, null);
            }
        }
       
    }
}