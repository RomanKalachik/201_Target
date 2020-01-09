using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGenerator
{
    public class DataItem
    {
        public double Argument { get; set; }
        public double Value { get; set; }
    }
    public class Generator
    {
        public static List<DataItem> Generate(long count) {
            var result = new List<DataItem>();
            for (long i = 0; i < count; i++)
                
                result.Add(new DataItem() { Argument = i, Value =       Math.Sin(i) +
                                                                    Math.Sin(i / 100.0) +
                                                                   30* Math.Sin(i / 1000.0) +
                                                                   1000*Math.Sin(i/100000.0)});
            return result;
        } 
    }
}
