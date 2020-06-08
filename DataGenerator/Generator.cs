using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
namespace DataGenerator {
    public class DataItem {
        public float Argument { get; set; }
        public float Value { get; set; }
        public float Value2 { get { return Value + 1; } }
        public float Value3 { get { return Value + 0.5f; } }
        public float Value4 { get { return Value - 1; } }
    }

    public class Generator {
        static int offsetCounter = 0;
        static void AddOneRecord(ObservableCollection<DataItem> result, long i)
        {
            offsetCounter++;
            int fArgument = offsetCounter;
            result.Add(new DataItem()
            {
                Argument = i,
                Value = (float)(Math.Sin(fArgument) +
                                                                                Math.Sin(fArgument / 100.0) +
                                                                               30 * Math.Sin(fArgument / 1000.0) +
                                                                               1000 * Math.Sin(fArgument / 100000.0))
            });
        }
        public static ObservableCollection<DataItem> Generate(long count)
        {
            ObservableCollection<DataItem> result = new ObservableCollection<DataItem>();
            for (long i = 0; i < count; i++)
                AddOneRecord(result, i);
            return result;
        }
        public static ObservableCollection<DataItem> Generate2DPoins(long count)
        {
            ObservableCollection<DataItem> result = new ObservableCollection<DataItem>();
            Assembly assembly = Assembly.GetExecutingAssembly();
            string resourceName = "DataGenerator.2dPointData.csv";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                string csv = reader.ReadToEnd();
                string[] lines = csv.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                long counter = count;
                foreach (string line in lines)
                {
                    if (line.Length < 5) continue;
                    string[] args = line.Split(new char[] { ',' });
                    result.Add(new DataItem() { Argument = (float)double.Parse(args[0], CultureInfo.InvariantCulture), Value = (float)double.Parse(args[1], CultureInfo.InvariantCulture) });
                    if (counter-- <= 0) break;

                }
            }
            return result;
        }
        public static ObservableCollection<DataItem> Generate2DPoins_Circle(long count)
        {
            ObservableCollection<DataItem> result = new ObservableCollection<DataItem>();
            for (double i = 0; i < count; i++)
            {
                double circleArg = Math.PI * 2 / 1000 * i;
                double circleAmp = 100 + i / 100;
                double x = circleAmp * Math.Cos(circleArg);
                double y = circleAmp * Math.Sin(circleArg);
                result.Add(new DataItem() { Argument = (float)x, Value = (float)y });
            }
            return result;
        }
        public static void UpdateSource(ObservableCollection<DataItem> chartSource)
        {
            float lastArgument = chartSource.Last().Argument;
            chartSource.RemoveAt(0);
            AddOneRecord(chartSource, (int)lastArgument + 1);
        }
    }
}
