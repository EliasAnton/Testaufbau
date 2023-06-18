``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.19045.3086/22H2/2022Update)
AMD Ryzen 7 5800H with Radeon Graphics, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.402
  [Host]     : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2


```
|               Method | NumberOfArticles |       Mean |      Error |     StdDev |
|--------------------- |----------------- |-----------:|-----------:|-----------:|
|          **GetArticles** |                **1** |   **1.069 ms** |  **0.0206 ms** |  **0.0237 ms** |
|   GetReducedArticles |                1 |   1.010 ms |  0.0154 ms |  0.0129 ms |
| GetArticlesWithPrice |                1 |   1.206 ms |  0.0191 ms |  0.0234 ms |
|          **GetArticles** |               **10** |   **1.173 ms** |  **0.0213 ms** |  **0.0209 ms** |
|   GetReducedArticles |               10 |   1.079 ms |  0.0098 ms |  0.0076 ms |
| GetArticlesWithPrice |               10 |   1.930 ms |  0.0110 ms |  0.0091 ms |
|          **GetArticles** |              **100** |   **2.161 ms** |  **0.0426 ms** |  **0.0456 ms** |
|   GetReducedArticles |              100 |   1.562 ms |  0.0264 ms |  0.0247 ms |
| GetArticlesWithPrice |              100 |   8.952 ms |  0.1757 ms |  0.1805 ms |
|          **GetArticles** |             **1000** |  **11.651 ms** |  **0.1233 ms** |  **0.1029 ms** |
|   GetReducedArticles |             1000 |   6.254 ms |  0.1079 ms |  0.0901 ms |
| GetArticlesWithPrice |             1000 |  71.041 ms |  0.4321 ms |  0.4042 ms |
|          **GetArticles** |            **10000** | **103.338 ms** |  **0.7706 ms** |  **0.6016 ms** |
|   GetReducedArticles |            10000 |  54.928 ms |  0.9212 ms |  0.7692 ms |
| GetArticlesWithPrice |            10000 | 725.548 ms | 14.2297 ms | 21.2983 ms |
