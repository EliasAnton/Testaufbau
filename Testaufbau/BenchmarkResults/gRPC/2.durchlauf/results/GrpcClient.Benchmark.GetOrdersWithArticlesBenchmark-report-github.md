``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.19044.2965/21H2/November2021Update)
AMD Ryzen 7 5800H with Radeon Graphics, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.402
  [Host]     : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2


```
|                         Method | NumberOfOrders |           Mean |       Error |      StdDev |
|------------------------------- |--------------- |---------------:|------------:|------------:|
| **GetOrdersWithArticlesAndPrices** |              **1** |       **3.001 ms** |   **0.0576 ms** |   **0.0592 ms** |
| **GetOrdersWithArticlesAndPrices** |             **10** |      **32.059 ms** |   **0.3922 ms** |   **0.3477 ms** |
| **GetOrdersWithArticlesAndPrices** |            **100** |     **285.412 ms** |   **5.1139 ms** |   **5.6841 ms** |
| **GetOrdersWithArticlesAndPrices** |           **1000** |   **4,573.666 ms** |  **14.0727 ms** |  **13.1636 ms** |
| **GetOrdersWithArticlesAndPrices** |          **10000** | **226,036.055 ms** | **207.3365 ms** | **183.7984 ms** |
