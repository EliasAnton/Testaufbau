``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.19044.2965/21H2/November2021Update)
AMD Ryzen 7 5800H with Radeon Graphics, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.402
  [Host]     : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2


```
|                         Method | NumberOfOrders |          Mean |       Error |      StdDev |
|------------------------------- |--------------- |--------------:|------------:|------------:|
| **GetOrdersWithArticlesAndPrices** |              **1** |      **3.120 ms** |   **0.0505 ms** |   **0.0448 ms** |
| **GetOrdersWithArticlesAndPrices** |             **10** |     **32.531 ms** |   **0.5344 ms** |   **0.4463 ms** |
| **GetOrdersWithArticlesAndPrices** |            **100** |    **278.244 ms** |   **5.5178 ms** |   **5.6664 ms** |
| **GetOrdersWithArticlesAndPrices** |           **1000** |  **3,014.062 ms** |  **25.4181 ms** |  **23.7761 ms** |
| **GetOrdersWithArticlesAndPrices** |          **10000** | **66,313.544 ms** | **746.4333 ms** | **698.2142 ms** |
