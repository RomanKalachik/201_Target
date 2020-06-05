using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace DataGenerator {
    public class DataItem {
        public float Argument { get; set; }
        public float Value { get; set; }
        public float Value2 { get { return Value + 50; } }
        public float Value3 { get { return Value + 10; } }
        public float Value4 { get { return Value + 30; } }
    }
    public class Generator {
        static int offsetCounter = 0;
        public static ObservableCollection<DataItem> Generate(long count) {
            ObservableCollection<DataItem> result = new ObservableCollection<DataItem>();
            for (long i = 0; i < count; i++)
                AddOneRecord(result, i);
            return result;
        }

        static void AddOneRecord(ObservableCollection<DataItem> result, long i) {
            offsetCounter++;
            var fArgument = offsetCounter;
            result.Add(new DataItem()
            {
                Argument = i,
                Value = (float)(Math.Sin(fArgument) +
                                                                                Math.Sin(fArgument / 100.0) +
                                                                               30 * Math.Sin(fArgument / 1000.0) +
                                                                               1000 * Math.Sin(fArgument / 100000.0))
            });
        }

        public static void UpdateSource(ObservableCollection<DataItem> chartSource) {
            float lastArgument = chartSource.Last().Argument;
            chartSource.RemoveAt(0);
            AddOneRecord(chartSource, (int)lastArgument + 1);
        }
    }
}
