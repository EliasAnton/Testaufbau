``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.19045.3086/22H2/2022Update)
AMD Ryzen 7 5800H with Radeon Graphics, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.402
  [Host]     : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2


```
|               Method | NumberOfArticles |       Mean |     Error |     StdDev |     Median |
|--------------------- |----------------- |-----------:|----------:|-----------:|-----------:|
| **GetArticlesWithPrice** |                **1** |   **2.322 ms** | **0.0222 ms** |  **0.0174 ms** |   **2.324 ms** |
| **GetArticlesWithPrice** |               **10** |   **6.465 ms** | **0.0298 ms** |  **0.0249 ms** |   **6.470 ms** |
| **GetArticlesWithPrice** |              **100** |   **8.270 ms** | **0.0466 ms** |  **0.0364 ms** |   **8.273 ms** |
| **GetArticlesWithPrice** |             **1000** |  **98.144 ms** | **9.5350 ms** | **27.6628 ms** | **107.243 ms** |
| **GetArticlesWithPrice** |            **10000** | **207.746 ms** | **4.0595 ms** |  **3.5987 ms** | **207.877 ms** |
