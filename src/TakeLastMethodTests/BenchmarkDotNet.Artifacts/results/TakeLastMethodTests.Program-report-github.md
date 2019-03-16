``` ini

BenchmarkDotNet=v0.11.4, OS=Windows 10.0.17763.379 (1809/October2018Update/Redstone5)
Intel Core i7-7820HQ CPU 2.90GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.1.505
  [Host] : .NET Core 2.1.9 (CoreCLR 4.6.27414.06, CoreFX 4.6.27415.01), 64bit RyuJIT
  Clr    : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3324.0
  Core   : .NET Core 2.1.9 (CoreCLR 4.6.27414.06, CoreFX 4.6.27415.01), 64bit RyuJIT


```
|                Method |  Job | Runtime |           Mean |          Error |         StdDev |         Median |  Ratio | RatioSD |
|---------------------- |----- |-------- |---------------:|---------------:|---------------:|---------------:|-------:|--------:|
|     IEnumManyTakeMany |  Clr |     Clr |   856,710.0 ns |  6,958.2858 ns |  6,508.7848 ns |   858,182.4 ns |   1.58 |    0.06 |
|     IEnumManyTakeMany | Core |    Core |   532,876.5 ns | 10,536.6607 ns | 20,798.3403 ns |   531,352.9 ns |   1.00 |    0.00 |
|                       |      |         |                |                |                |                |        |         |
|  IEnumManyTakeManyNew |  Clr |     Clr |   905,358.9 ns | 18,074.0355 ns | 43,994.7003 ns |   910,271.4 ns |   1.76 |    0.11 |
|  IEnumManyTakeManyNew | Core |    Core |   508,517.8 ns | 10,083.7343 ns | 15,699.1595 ns |   512,470.9 ns |   1.00 |    0.00 |
|                       |      |         |                |                |                |                |        |         |
|     IListManyTakeMany |  Clr |     Clr |   228,762.7 ns |  4,555.8672 ns |  9,408.6558 ns |   223,494.1 ns |   1.10 |    0.04 |
|     IListManyTakeMany | Core |    Core |   216,514.5 ns |  2,112.6515 ns |  1,976.1755 ns |   217,136.4 ns |   1.00 |    0.00 |
|                       |      |         |                |                |                |                |        |         |
|  IListManyTakeManyNew |  Clr |     Clr |    88,629.0 ns |  1,733.5731 ns |  2,749.6306 ns |    87,471.9 ns |  12.70 |    0.53 |
|  IListManyTakeManyNew | Core |    Core |     7,041.0 ns |    133.5575 ns |    137.1537 ns |     6,997.3 ns |   1.00 |    0.00 |
|                       |      |         |                |                |                |                |        |         |
|    CustomManyTakeMany |  Clr |     Clr | 1,178,310.2 ns | 23,370.6643 ns | 32,762.4073 ns | 1,163,912.2 ns |   1.44 |    0.05 |
|    CustomManyTakeMany | Core |    Core |   826,218.8 ns | 16,033.5650 ns | 17,155.7349 ns |   832,957.2 ns |   1.00 |    0.00 |
|                       |      |         |                |                |                |                |        |         |
| CustomManyTakeManyNew |  Clr |     Clr | 1,171,370.6 ns | 11,086.3788 ns |  9,827.7860 ns | 1,171,756.2 ns |   1.43 |    0.05 |
| CustomManyTakeManyNew | Core |    Core |   827,214.7 ns | 16,255.3747 ns | 26,249.4002 ns |   828,531.4 ns |   1.00 |    0.00 |
|                       |      |         |                |                |                |                |        |         |
|      IEnumManyTakeFew |  Clr |     Clr |   814,891.2 ns |  2,579.6437 ns |  2,154.1193 ns |   814,596.8 ns |   1.61 |    0.03 |
|      IEnumManyTakeFew | Core |    Core |   506,217.5 ns |  9,881.9598 ns |  9,243.5913 ns |   505,234.4 ns |   1.00 |    0.00 |
|                       |      |         |                |                |                |                |        |         |
|   IEnumManyTakeFewNew |  Clr |     Clr |   812,119.5 ns | 12,221.1007 ns | 10,833.6875 ns |   808,342.4 ns |   1.58 |    0.03 |
|   IEnumManyTakeFewNew | Core |    Core |   511,678.7 ns |  8,189.5061 ns |  7,660.4691 ns |   512,119.3 ns |   1.00 |    0.00 |
|                       |      |         |                |                |                |                |        |         |
|      IListManyTakeFew |  Clr |     Clr |   203,058.8 ns |  4,040.2575 ns |  7,285.4177 ns |   202,465.0 ns |   1.05 |    0.03 |
|      IListManyTakeFew | Core |    Core |   191,035.9 ns |  3,217.0653 ns |  3,009.2449 ns |   190,604.6 ns |   1.00 |    0.00 |
|                       |      |         |                |                |                |                |        |         |
|   IListManyTakeFewBew |  Clr |     Clr |    63,576.7 ns |  1,231.2432 ns |  1,804.7404 ns |    62,659.9 ns | 403.89 |   18.48 |
|   IListManyTakeFewBew | Core |    Core |       159.8 ns |      3.0082 ns |      2.8139 ns |       160.2 ns |   1.00 |    0.00 |
|                       |      |         |                |                |                |                |        |         |
|     CustomManyTakeFew |  Clr |     Clr | 1,108,636.0 ns | 12,537.7782 ns | 11,727.8455 ns | 1,104,802.8 ns |   1.33 |    0.04 |
|     CustomManyTakeFew | Core |    Core |   832,851.3 ns | 16,170.1127 ns | 21,586.6360 ns |   829,846.9 ns |   1.00 |    0.00 |
|                       |      |         |                |                |                |                |        |         |
|  CustomManyTakeFewNew |  Clr |     Clr | 1,118,136.3 ns |  4,944.8527 ns |  4,625.4183 ns | 1,118,240.1 ns |   1.32 |    0.03 |
|  CustomManyTakeFewNew | Core |    Core |   844,464.3 ns | 15,902.6132 ns | 18,313.4730 ns |   844,296.0 ns |   1.00 |    0.00 |
|                       |      |         |                |                |                |                |        |         |
|     IEnumLessTakeMany |  Clr |     Clr |    10,856.9 ns |    105.5720 ns |     98.7521 ns |    10,851.0 ns |   1.41 |    0.03 |
|     IEnumLessTakeMany | Core |    Core |     7,717.3 ns |    114.2437 ns |     95.3987 ns |     7,732.1 ns |   1.00 |    0.00 |
|                       |      |         |                |                |                |                |        |         |
|  IEnumLessTakeManyNew |  Clr |     Clr |    10,878.0 ns |     68.7877 ns |     64.3440 ns |    10,882.8 ns |   1.43 |    0.02 |
|  IEnumLessTakeManyNew | Core |    Core |     7,618.3 ns |     95.2394 ns |     79.5292 ns |     7,624.4 ns |   1.00 |    0.00 |
|                       |      |         |                |                |                |                |        |         |
|     IListLessTakeMany |  Clr |     Clr |     4,730.6 ns |     41.7993 ns |     39.0991 ns |     4,742.8 ns |   0.92 |    0.04 |
|     IListLessTakeMany | Core |    Core |     5,064.9 ns |     99.5665 ns |    171.7473 ns |     5,017.1 ns |   1.00 |    0.00 |
|                       |      |         |                |                |                |                |        |         |
|  IListLessTakeManyNew |  Clr |     Clr |     3,331.9 ns |     31.5267 ns |     26.3262 ns |     3,324.2 ns |   1.04 |    0.02 |
|  IListLessTakeManyNew | Core |    Core |     3,213.9 ns |     56.4084 ns |     52.7644 ns |     3,226.1 ns |   1.00 |    0.00 |
|                       |      |         |                |                |                |                |        |         |
|    CustomLessTakeMany |  Clr |     Clr |    14,899.9 ns |    293.2161 ns |    605.5422 ns |    14,797.7 ns |   1.40 |    0.05 |
|    CustomLessTakeMany | Core |    Core |    10,716.8 ns |    213.4485 ns |    209.6350 ns |    10,725.5 ns |   1.00 |    0.00 |
|                       |      |         |                |                |                |                |        |         |
| CustomLessTakeManyNew |  Clr |     Clr |    14,670.8 ns |    282.9278 ns |    277.8729 ns |    14,628.0 ns |   1.36 |    0.04 |
| CustomLessTakeManyNew | Core |    Core |    10,823.7 ns |    181.8189 ns |    170.0735 ns |    10,802.2 ns |   1.00 |    0.00 |
|                       |      |         |                |                |                |                |        |         |
|       IEnumFewTakeFew |  Clr |     Clr |     8,673.7 ns |    161.1580 ns |    150.7473 ns |     8,687.4 ns |   1.71 |    0.04 |
|       IEnumFewTakeFew | Core |    Core |     5,060.7 ns |    109.1095 ns |    102.0611 ns |     5,027.1 ns |   1.00 |    0.00 |
|                       |      |         |                |                |                |                |        |         |
|    IEnumFewTakeFewNew |  Clr |     Clr |     8,673.3 ns |    173.4307 ns |    225.5089 ns |     8,724.6 ns |   1.76 |    0.05 |
|    IEnumFewTakeFewNew | Core |    Core |     4,944.2 ns |     34.8422 ns |     32.5914 ns |     4,934.3 ns |   1.00 |    0.00 |
|                       |      |         |                |                |                |                |        |         |
|       IListFewTakeFew |  Clr |     Clr |     2,334.7 ns |     32.9774 ns |     30.8471 ns |     2,335.4 ns |   0.98 |    0.01 |
|       IListFewTakeFew | Core |    Core |     2,386.2 ns |     14.0406 ns |     12.4466 ns |     2,389.3 ns |   1.00 |    0.00 |
|                       |      |         |                |                |                |                |        |         |
|    IListFewTakeFewNew |  Clr |     Clr |       900.2 ns |     11.6123 ns |     10.8622 ns |       903.9 ns |   5.20 |    0.06 |
|    IListFewTakeFewNew | Core |    Core |       172.9 ns |      0.6448 ns |      0.5716 ns |       172.8 ns |   1.00 |    0.00 |
|                       |      |         |                |                |                |                |        |         |
|      CustomFewTakeFew |  Clr |     Clr |    12,040.9 ns |    236.0927 ns |    281.0516 ns |    11,990.1 ns |   1.42 |    0.04 |
|      CustomFewTakeFew | Core |    Core |     8,507.9 ns |     68.7168 ns |     60.9157 ns |     8,507.9 ns |   1.00 |    0.00 |
|                       |      |         |                |                |                |                |        |         |
|   CustomFewTakeFewNew |  Clr |     Clr |    11,788.3 ns |    148.2112 ns |    131.3853 ns |    11,815.5 ns |   1.37 |    0.02 |
|   CustomFewTakeFewNew | Core |    Core |     8,604.0 ns |     49.6448 ns |     46.4378 ns |     8,592.8 ns |   1.00 |    0.00 |
