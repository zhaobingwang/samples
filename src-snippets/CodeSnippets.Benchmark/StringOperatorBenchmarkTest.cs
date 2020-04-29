using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSnippets.Benchmark
{
    public class StringOperatorBenchmarkTest
    {
        //[Params(1, 100, 1000, 10000, 100000)]
        [Params(1, 100)]
        public int LoopCount;

        [Benchmark]
        public void FoamatLongString()
        {
            StringOperator op = new StringOperator(LoopCount);
            op.FoamatLongString();
        }

        [Benchmark]
        public void FoamatShortString()
        {
            StringOperator op = new StringOperator(LoopCount);
            op.FoamatShortString();
        }

        [Benchmark]
        public void InterpolationLongString()
        {
            StringOperator op = new StringOperator(LoopCount);
            op.InterpolationLongString();
        }

        [Benchmark]
        public void InterpolationShortString()
        {
            StringOperator op = new StringOperator(LoopCount);
            op.InterpolationShortString();
        }

        [Benchmark]
        public void StringBuilder()
        {
            StringOperator op = new StringOperator(LoopCount);
            op.StringBuilder();
        }
    }
}
