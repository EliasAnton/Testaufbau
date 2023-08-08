``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.19045.2965/22H2/2022Update)
AMD Ryzen 7 5800H with Radeon Graphics, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.402
  [Host]     : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2


```
|                         Method | NumberOfOrders |          Mean |       Error |      StdDev |
|------------------------------- |--------------- |--------------:|------------:|------------:|
| **GetOrdersWithArticlesAndPrices** |              **1** |      **4.214 ms** |   **0.0423 ms** |   **0.0353 ms** |
| **GetOrdersWithArticlesAndPrices** |             **10** |     **54.557 ms** |   **0.4328 ms** |   **0.3614 ms** |
| **GetOrdersWithArticlesAndPrices** |            **100** |    **465.059 ms** |   **3.8557 ms** |   **3.0103 ms** |
| **GetOrdersWithArticlesAndPrices** |           **1000** |  **4,813.997 ms** |  **17.5368 ms** |  **16.4039 ms** |
| **GetOrdersWithArticlesAndPrices** |          **10000** | **79,859.155 ms** | **218.3229 ms** | **204.2194 ms** |
