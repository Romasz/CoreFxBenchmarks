``` ini

BenchmarkDotNet=v0.11.4, OS=Windows 10.0.17763.379 (1809/October2018Update/Redstone5)
Intel Core i7-7820HQ CPU 2.90GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.1.505
  [Host]     : .NET Core 2.1.9 (CoreCLR 4.6.27414.06, CoreFX 4.6.27415.01), 64bit RyuJIT
  Job-FTITCG : .NET Core 46978f5e-7f77-4598-ba17-462c29c84838 (CoreCLR 4.6.27513.77, CoreFX 4.7.19.16601), 64bit RyuJIT

Runtime=Core  Toolchain=CoreRun  

```
|             Method |           Mean |         Error |        StdDev |
|------------------- |---------------:|--------------:|--------------:|
|  IEnumManyTakeMany |    55,419.8 ns |    387.431 ns |    362.403 ns |
|  IListManyTakeMany |    12,604.3 ns |     93.503 ns |     82.888 ns |
| CustomManyTakeMany | 1,223,763.6 ns |  9,015.410 ns |  8,433.020 ns |
|   IEnumManyTakeFew |       410.1 ns |      2.340 ns |      2.189 ns |
|   IListManyTakeFew |       180.6 ns |      1.500 ns |      1.404 ns |
|  CustomManyTakeFew | 1,094,212.5 ns | 11,083.325 ns | 10,367.349 ns |
|  IEnumLessTakeMany |     4,928.9 ns |     30.969 ns |     25.860 ns |
|  IListLessTakeMany |     1,068.7 ns |     11.259 ns |     10.532 ns |
| CustomLessTakeMany |    16,160.8 ns |    107.127 ns |    100.207 ns |
|    IEnumFewTakeFew |       402.5 ns |      4.281 ns |      4.004 ns |
|    IListFewTakeFew |       178.3 ns |      1.444 ns |      1.280 ns |
|   CustomFewTakeFew |    11,456.5 ns |     46.616 ns |     38.926 ns |
