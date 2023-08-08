``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.19044.2965/21H2/November2021Update)
AMD Ryzen 7 5800H with Radeon Graphics, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.402
  [Host]     : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2


```
|               Method | NumberOfArticles |         Mean |      Error |     StdDev |
|--------------------- |----------------- |-------------:|-----------:|-----------:|
|          **GetArticles** |                **1** |     **2.179 ms** |  **0.0408 ms** |  **0.0400 ms** |
|   GetReducedArticles |                1 |     2.080 ms |  0.0393 ms |  0.0348 ms |
| GetArticlesWithPrice |                1 |     3.623 ms |  0.0415 ms |  0.0389 ms |
|          **GetArticles** |               **10** |     **2.290 ms** |  **0.0217 ms** |  **0.0192 ms** |
|   GetReducedArticles |               10 |     2.160 ms |  0.0403 ms |  0.0377 ms |
| GetArticlesWithPrice |               10 |    16.989 ms |  0.3254 ms |  0.3196 ms |
|          **GetArticles** |              **100** |     **3.573 ms** |  **0.0466 ms** |  **0.0413 ms** |
|   GetReducedArticles |              100 |     2.802 ms |  0.0383 ms |  0.0358 ms |
| GetArticlesWithPrice |              100 |   149.242 ms |  2.9038 ms |  2.9820 ms |
|          **GetArticles** |             **1000** |    **14.836 ms** |  **0.2890 ms** |  **0.3549 ms** |
|   GetReducedArticles |             1000 |     8.392 ms |  0.1527 ms |  0.1353 ms |
| GetArticlesWithPrice |             1000 | 1,471.330 ms | 13.8069 ms | 12.9150 ms |
|          **GetArticles** |            **10000** |    **99.135 ms** |  **1.8671 ms** |  **3.1704 ms** |
|   GetReducedArticles |            10000 |    52.343 ms |  0.8836 ms |  1.9019 ms |
| GetArticlesWithPrice |            10000 | 8,211.363 ms | 63.9251 ms | 59.7956 ms |
