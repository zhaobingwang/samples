using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Domain.Framework.ClickHouse.Entities
{
    public class Test : IEnumerable
    {
        public long I64Value { get; set; }
        public string StringValue { get; set; }
        public DateTime DateValue { get; set; }
        public DateTime DateTimeValue { get; set; }
        public double Float64Value { get; set; }
        public int I32Value { get; set; }
        public DateTime PartitionByValue { get; set; }
        public long PKI64 { get; set; }
        public string PKString { get; set; }

        public IEnumerator GetEnumerator()
        {
            yield return I64Value;
            yield return StringValue;
            yield return DateValue;
            yield return DateTimeValue;
            yield return Float64Value;
            yield return I32Value;
            yield return PartitionByValue;
            yield return PKI64;
            yield return PKString;
        }
    }
}
