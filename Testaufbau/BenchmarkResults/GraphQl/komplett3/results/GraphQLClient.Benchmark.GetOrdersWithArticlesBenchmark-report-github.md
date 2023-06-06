``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.19045.2965/22H2/2022Update)
AMD Ryzen 7 5800H with Radeon Graphics, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.402
  [Host]     : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2


```
|                         Method | NumberOfOrders |          Mean |      Error |     StdDev |
|------------------------------- |--------------- |--------------:|-----------:|-----------:|
| **GetOrdersWithArticlesAndPrices** |              **1** |      **3.071 ms** |  **0.0323 ms** |  **0.0252 ms** |
| **GetOrdersWithArticlesAndPrices** |             **10** |     **35.698 ms** |  **0.6723 ms** |  **0.6289 ms** |
| **GetOrdersWithArticlesAndPrices** |            **100** |    **300.028 ms** |  **5.1655 ms** |  **4.5791 ms** |
| **GetOrdersWithArticlesAndPrices** |           **1000** |  **3,225.967 ms** | **21.2419 ms** | **19.8697 ms** |
| **GetOrdersWithArticlesAndPrices** |          **10000** | **65,400.840 ms** | **82.1079 ms** | **76.8038 ms** |
