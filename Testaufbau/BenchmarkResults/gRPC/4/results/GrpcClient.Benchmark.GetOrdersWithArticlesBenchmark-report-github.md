``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.19045.2965/22H2/2022Update)
AMD Ryzen 7 5800H with Radeon Graphics, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.402
  [Host]     : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2


```
|                         Method | NumberOfOrders |          Mean |       Error |      StdDev |
|------------------------------- |--------------- |--------------:|------------:|------------:|
| **GetOrdersWithArticlesAndPrices** |              **1** |      **4.481 ms** |   **0.0860 ms** |   **0.0991 ms** |
| **GetOrdersWithArticlesAndPrices** |             **10** |     **56.877 ms** |   **0.9264 ms** |   **0.7736 ms** |
| **GetOrdersWithArticlesAndPrices** |            **100** |    **485.478 ms** |   **7.8818 ms** |   **6.9870 ms** |
| **GetOrdersWithArticlesAndPrices** |           **1000** |  **5,063.422 ms** |  **19.6068 ms** |  **17.3809 ms** |
| **GetOrdersWithArticlesAndPrices** |          **10000** | **83,858.900 ms** | **170.7264 ms** | **151.3445 ms** |
