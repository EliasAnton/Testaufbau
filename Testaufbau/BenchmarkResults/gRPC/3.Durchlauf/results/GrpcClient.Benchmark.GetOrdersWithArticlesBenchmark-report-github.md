``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.19045.2965/22H2/2022Update)
AMD Ryzen 7 5800H with Radeon Graphics, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.402
  [Host]     : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2


```
|                         Method | NumberOfOrders |          Mean |       Error |      StdDev |
|------------------------------- |--------------- |--------------:|------------:|------------:|
| **GetOrdersWithArticlesAndPrices** |              **1** |      **4.498 ms** |   **0.0672 ms** |   **0.0561 ms** |
| **GetOrdersWithArticlesAndPrices** |             **10** |     **57.364 ms** |   **0.4314 ms** |   **0.3368 ms** |
| **GetOrdersWithArticlesAndPrices** |            **100** |    **490.691 ms** |   **3.7763 ms** |   **3.1534 ms** |
| **GetOrdersWithArticlesAndPrices** |           **1000** |  **5,076.201 ms** |  **18.1880 ms** |  **17.0130 ms** |
| **GetOrdersWithArticlesAndPrices** |          **10000** | **84,442.999 ms** | **213.4445 ms** | **199.6561 ms** |
