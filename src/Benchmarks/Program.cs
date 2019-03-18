using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Horology;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Benchmarks
{
    public class Program
    {
        static void Main(string[] args)
        {
            BenchmarkSwitcher
                .FromAssembly(typeof(Program).Assembly)
                .Run(args, ManualConfig.Create(DefaultConfig.Instance)
                                       .With(SummaryStyle.Default.WithTimeUnit(TimeUnit.Microsecond)));
        }

        public IEnumerable<string> _iListMany;
        public IEnumerable<string> _iEnumerableMany;
        public IEnumerable<string> _customIteratorMany;

        public IEnumerable<string> _iListFew;
        public IEnumerable<string> _iEnumerableFew;
        public IEnumerable<string> _customIteratorFew;


        private IEnumerable<T> CustomIterator<T>(IEnumerable<T> source, Func<T, T> funcResult)
        {
            foreach (var item in source)
                yield return funcResult(item);
        }

        private const int LENGTH_MANY = 10000;
        private const int LENGTH_FEW = 100;
        private const int MANY = 1000;
        private const int FEW = 3;

        [GlobalSetup]
        public void Setup()
        {
            var iterator = Enumerable.Range(0, LENGTH_MANY).Select(i => i.ToString());

            _iEnumerableMany = iterator;
            _iListMany = iterator.ToList();
            _customIteratorMany = CustomIterator(iterator, (x) => x + " custom");

            iterator = Enumerable.Range(0, LENGTH_FEW).Select(i => i.ToString());
            _iEnumerableFew = iterator;
            _iListFew = iterator.ToList();
            _customIteratorFew = CustomIterator(iterator, (x) => x + " custom");
        }

        [Benchmark]
        public string[] IEnumManyTakeMany() => _iEnumerableMany.TakeLast(MANY).ToArray();

        [Benchmark]
        public string[] IListManyTakeMany() => _iListMany.TakeLast(MANY).ToArray();

        [Benchmark]
        public string[] CustomManyTakeMany() => _customIteratorMany.TakeLast(MANY).ToArray();

        [Benchmark]
        public string[] IEnumManyTakeFew() => _iEnumerableMany.TakeLast(FEW).ToArray();

        [Benchmark]
        public string[] IListManyTakeFew() => _iListMany.TakeLast(FEW).ToArray();

        [Benchmark]
        public string[] CustomManyTakeFew() => _customIteratorMany.TakeLast(FEW).ToArray();

        [Benchmark]
        public string[] IEnumLessTakeMany() => _iEnumerableFew.TakeLast(MANY).ToArray();

        [Benchmark]
        public string[] IListLessTakeMany() => _iListFew.TakeLast(MANY).ToArray();

        [Benchmark]
        public string[] CustomLessTakeMany() => _customIteratorFew.TakeLast(MANY).ToArray();

        [Benchmark]
        public string[] IEnumFewTakeFew() => _iEnumerableFew.TakeLast(FEW).ToArray();

        [Benchmark]
        public string[] IListFewTakeFew() => _iListFew.TakeLast(FEW).ToArray();

        [Benchmark]
        public string[] CustomFewTakeFew() => _customIteratorFew.TakeLast(FEW).ToArray();
    }
}
