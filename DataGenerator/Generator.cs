using System;
using System.Collections.Generic;
using System.Linq;

namespace DataGenerator
{
    public class DataItem
    {
        public float Argument { get; set; }
        public float Value { get; set; }
    }
    public class Generator
    {
        public static List<DataItem> Generate(long count)
        {
            List<DataItem> result = new List<DataItem>();
            for (long i = 0; i < count; i++)

                result.Add(new DataItem()
                {
                    Argument = i,
                    Value = (float)(Math.Sin(i) +
                                                                    Math.Sin(i / 100.0) +
                                                                   30 * Math.Sin(i / 1000.0) +
                                                                   1000 * Math.Sin(i / 100000.0))
                });
            return result;
        }
    }
}
