``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.19044.2965/21H2/November2021Update)
AMD Ryzen 7 5800H with Radeon Graphics, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.402
  [Host]     : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2


```
|                         Method | NumberOfOrders |          Mean |       Error |      StdDev |
|------------------------------- |--------------- |--------------:|------------:|------------:|
| **GetOrdersWithArticlesAndPrices** |              **1** |      **3.247 ms** |   **0.0645 ms** |   **0.1179 ms** |
| **GetOrdersWithArticlesAndPrices** |             **10** |     **36.664 ms** |   **0.7296 ms** |   **0.7165 ms** |
| **GetOrdersWithArticlesAndPrices** |            **100** |    **313.824 ms** |   **5.9499 ms** |   **6.1101 ms** |
| **GetOrdersWithArticlesAndPrices** |           **1000** |  **3,281.162 ms** |  **25.7327 ms** |  **24.0704 ms** |
| **GetOrdersWithArticlesAndPrices** |          **10000** | **64,717.229 ms** | **122.5409 ms** | **114.6249 ms** |
