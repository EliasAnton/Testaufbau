``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.19044.2846/21H2/November2021Update)
AMD Ryzen 7 5800H with Radeon Graphics, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.402
  [Host]     : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2


```
|                  Method | NumberOfOrders |      Mean |     Error |    StdDev |
|------------------------ |--------------- |----------:|----------:|----------:|
| **GetOrdersWithOrderItems** |              **1** |  **2.077 ms** | **0.0410 ms** | **0.0472 ms** |
| **GetOrdersWithOrderItems** |             **10** |  **2.138 ms** | **0.0321 ms** | **0.0285 ms** |
| **GetOrdersWithOrderItems** |            **100** |  **2.708 ms** | **0.0504 ms** | **0.0472 ms** |
| **GetOrdersWithOrderItems** |           **1000** |  **8.294 ms** | **0.1562 ms** | **0.1461 ms** |
| **GetOrdersWithOrderItems** |          **10000** | **50.045 ms** | **0.9303 ms** | **0.8702 ms** |
