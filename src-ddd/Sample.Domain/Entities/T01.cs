using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Domain.Entities
{
    public class T01
    {
        public long Id { get; set; }
        public string StringValue { get; set; }
        public int IntValue { get; set; }
        public DateTime DateTimeValue { get; set; }
        public bool BooleanValue { get; set; }
        public int? IntNullableValue { get; set; }
        public DateTime? DateTimeNullableValue { get; set; }
        public bool? BooleanNullableValue { get; set; }
    }
}
