using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TakeLastMethodTests
{
    [CoreJob(true)]
    [ClrJob]
    public class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<Program>();
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

#if NETCORE
        //uncomment only for core only benchmarking
        //[Benchmark(Baseline = true)]
        //public string[] TakeLastExisting() => _iListMany.TakeLast(MANY).ToArray();
#endif

        [Benchmark]
        public string[] IEnumManyTakeMany() => _iEnumerableMany.TakeLastOld(MANY).ToArray();

        [Benchmark]
        public string[] IEnumManyTakeManyNew() => _iEnumerableMany.TakeLastNew(MANY).ToArray();

        [Benchmark]
        public string[] IListManyTakeMany() => _iListMany.TakeLastOld(MANY).ToArray();

        [Benchmark]
        public string[] IListManyTakeManyNew() => _iListMany.TakeLastNew(MANY).ToArray();

        [Benchmark]
        public string[] CustomManyTakeMany() => _customIteratorMany.TakeLastOld(MANY).ToArray();

        [Benchmark]
        public string[] CustomManyTakeManyNew() => _customIteratorMany.TakeLastNew(MANY).ToArray();

        [Benchmark]
        public string[] IEnumManyTakeFew() => _iEnumerableMany.TakeLastOld(FEW).ToArray();

        [Benchmark]
        public string[] IEnumManyTakeFewNew() => _iEnumerableMany.TakeLastNew(FEW).ToArray();

        [Benchmark]
        public string[] IListManyTakeFew() => _iListMany.TakeLastOld(FEW).ToArray();

        [Benchmark]
        public string[] IListManyTakeFewBew() => _iListMany.TakeLastNew(FEW).ToArray();

        [Benchmark]
        public string[] CustomManyTakeFew() => _customIteratorMany.TakeLastOld(FEW).ToArray();

        [Benchmark]
        public string[] CustomManyTakeFewNew() => _customIteratorMany.TakeLastNew(FEW).ToArray();

        [Benchmark]
        public string[] IEnumLessTakeMany() => _iEnumerableFew.TakeLastOld(MANY).ToArray();

        [Benchmark]
        public string[] IEnumLessTakeManyNew() => _iEnumerableFew.TakeLastNew(MANY).ToArray();

        [Benchmark]
        public string[] IListLessTakeMany() => _iListFew.TakeLastOld(MANY).ToArray();

        [Benchmark]
        public string[] IListLessTakeManyNew() => _iListFew.TakeLastNew(MANY).ToArray();

        [Benchmark]
        public string[] CustomLessTakeMany() => _customIteratorFew.TakeLastOld(MANY).ToArray();

        [Benchmark]
        public string[] CustomLessTakeManyNew() => _customIteratorFew.TakeLastNew(MANY).ToArray();

        [Benchmark]
        public string[] IEnumFewTakeFew() => _iEnumerableFew.TakeLastOld(FEW).ToArray();

        [Benchmark]
        public string[] IEnumFewTakeFewNew() => _iEnumerableFew.TakeLastNew(FEW).ToArray();

        [Benchmark]
        public string[] IListFewTakeFew() => _iListFew.TakeLastOld(FEW).ToArray();

        [Benchmark]
        public string[] IListFewTakeFewNew() => _iListFew.TakeLastNew(FEW).ToArray();

        [Benchmark]
        public string[] CustomFewTakeFew() => _customIteratorFew.TakeLastOld(FEW).ToArray();

        [Benchmark]
        public string[] CustomFewTakeFewNew() => _customIteratorFew.TakeLastNew(FEW).ToArray();
    }

    public static class Extensions
    {
        public static IEnumerable<TSource> TakeLastOld<TSource>(this IEnumerable<TSource> source, int count)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return count <= 0 ?
                new TSource[0] :
                TakeLastRegularIterator(source, count);
        }

        public static IEnumerable<TSource> TakeLastNew<TSource>(this IEnumerable<TSource> source, int count)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return count <= 0 ?
                new TSource[0] :
                TakeLastIterator(source, count);
        }


        private static IEnumerable<TSource> TakeIterator<TSource>(IEnumerable<TSource> source, int count)
        {
            foreach (TSource element in source)
            {
                yield return element;
                if (--count == 0) break;
            }
        }


        public static IEnumerable<TSource> TakeLastIterator<TSource>(this IEnumerable<TSource> source, int count)
        {
            if (source is IList<TSource> sourceList)
            {
                if (sourceList.Count > count)
                {
                    return sourceList.Skip(sourceList.Count - count);
                }
                else if (sourceList.Count > 0)
                {
                    return TakeIterator<TSource>(sourceList, sourceList.Count);
                }
                else
                {
                    return new TSource[0];
                }
            }

            return TakeLastRegularIterator(source, count);
        }


        private static IEnumerable<TSource> TakeLastRegularIterator<TSource>(IEnumerable<TSource> source, int count)
        {
            Queue<TSource> queue;

            using (IEnumerator<TSource> e = source.GetEnumerator())
            {
                if (!e.MoveNext())
                {
                    yield break;
                }

                queue = new Queue<TSource>();
                queue.Enqueue(e.Current);

                while (e.MoveNext())
                {
                    if (queue.Count < count)
                    {
                        queue.Enqueue(e.Current);
                    }
                    else
                    {
                        do
                        {
                            queue.Dequeue();
                            queue.Enqueue(e.Current);
                        }
                        while (e.MoveNext());
                        break;
                    }
                }
            }

            do
            {
                yield return queue.Dequeue();
            }
            while (queue.Count > 0);
        }
    }
}
