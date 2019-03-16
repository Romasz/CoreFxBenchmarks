``` ini

BenchmarkDotNet=v0.11.4, OS=Windows 10.0.17763.379 (1809/October2018Update/Redstone5)
Intel Core i7-7820HQ CPU 2.90GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.1.505
  [Host]     : .NET Core 2.1.9 (CoreCLR 4.6.27414.06, CoreFX 4.6.27415.01), 64bit RyuJIT
  Job-MYSMAZ : .NET Core 2c17fabb-c91f-4ea4-ac2c-34544d8b72ce (CoreCLR 4.6.27513.77, CoreFX 4.7.19.16601), 64bit RyuJIT

Runtime=Core  Toolchain=CoreRun  

```
|             Method |         Mean |      Error |     StdDev |
|------------------- |-------------:|-----------:|-----------:|
|  IEnumManyTakeMany |   884.548 us | 17.6581 us | 17.3426 us |
|  IListManyTakeMany |   234.611 us |  1.1647 us |  1.0895 us |
| CustomManyTakeMany | 1,228.409 us | 17.0377 us | 15.9371 us |
|   IEnumManyTakeFew |   804.662 us | 10.0045 us |  9.3582 us |
|   IListManyTakeFew |   178.044 us |  1.7431 us |  1.6305 us |
|  CustomManyTakeFew | 1,098.817 us | 10.8250 us | 10.1257 us |
|  IEnumLessTakeMany |    12.880 us |  0.0683 us |  0.0639 us |
|  IListLessTakeMany |     7.070 us |  0.0403 us |  0.0377 us |
| CustomLessTakeMany |    15.962 us |  0.1156 us |  0.1081 us |
|    IEnumFewTakeFew |     8.378 us |  0.0345 us |  0.0322 us |
|    IListFewTakeFew |     2.312 us |  0.0139 us |  0.0130 us |
|   CustomFewTakeFew |    11.436 us |  0.1005 us |  0.0940 us |
