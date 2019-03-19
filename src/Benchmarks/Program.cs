using BenchmarkDotNet.Analysers;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Filters;
using BenchmarkDotNet.Horology;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Toolchains.CoreRun;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Benchmarks
{
    public class Program
    {
        private class Config : ManualConfig
        {
            public Config(string artifactsFolder)
            {
                ArtifactsPath = Path.Combine(Directory.GetCurrentDirectory(), artifactsFolder);
                Encoding = System.Text.Encoding.ASCII;
                Options = ConfigOptions.Default;
                SummaryStyle = SummaryStyle.Default.WithTimeUnit(TimeUnit.Microsecond);
                UnionRule = ConfigUnionRule.Union;
                //Orderer = new DefaultOrderer(SummaryOrderPolicy.Declared, MethodOrderPolicy.Alphabetical);

                Add(ConsoleLogger.Default);
                Add(DefaultColumnProviders.Instance);
                Add(MarkdownExporter.GitHub);
                Add(DefaultConfig.Instance.GetAnalysers().ToArray());
                Add(DefaultConfig.Instance.GetValidators().ToArray());
                Add(Job.Default.With(Platform.X64).With(Jit.RyuJit).WithId("CoreApp").With(new CoreRunToolchain(new FileInfo(@"C:\Current\GithubProjects\corefx\artifacts\bin\testhost\netcoreapp-Windows_NT-Release-x64\shared\Microsoft.NETCore.App\9.9.9\CoreRun.exe"))));
                Add(Job.Default.With(Platform.X64).With(Jit.RyuJit).WithId("UAP").With(new CoreRunToolchain(new FileInfo(@"C:\Current\GithubProjects\corefx\artifacts\bin\testhost\uap-Windows_NT-Release-x64\UAPLayout\CoreRun.exe"))));
            }
        }

        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(new string[] { "-f", "*" }, new Config(args[0]));
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

            var coreFxAssemblyInfo = FileVersionInfo.GetVersionInfo(typeof(Regex).GetTypeInfo().Assembly.Location);
            var coreClrAssemblyInfo = FileVersionInfo.GetVersionInfo(typeof(object).GetTypeInfo().Assembly.Location);

            Console.WriteLine($"// CoreFx version: {coreFxAssemblyInfo.FileVersion}, location {typeof(Regex).GetTypeInfo().Assembly.Location}, product version {coreFxAssemblyInfo.ProductVersion}");
            Console.WriteLine($"// CoreClr version {coreClrAssemblyInfo.FileVersion}, location {typeof(object).GetTypeInfo().Assembly.Location}, product version {coreClrAssemblyInfo.ProductVersion}");
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
