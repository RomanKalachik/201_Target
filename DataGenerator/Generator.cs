using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGenerator {
    public class DataItem {
        public object Argument { get; set; }
        public object Value { get; set; }
    }
    public class Generator<T> where T : struct, IComparable,
          IComparable<T>,
          IConvertible,
          IEquatable<T> {
        public static List<object> Generate(long count) {
            var result = new List<object>();
            for (Single i = 0; i < count; i++) {
                Single currentValue = (float)(Math.Sin(i) +
                                                                    Math.Sin(i / 100.0) +
                                                                   30 * Math.Sin(i / 1000.0) +
                                                                   1000 * Math.Sin(i / 100000.0));

                result.Add(new DataItem() { Argument = i, Value = currentValue });
            }
            return result;
        }
    }
}
