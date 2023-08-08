``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.19044.2965/21H2/November2021Update)
AMD Ryzen 7 5800H with Radeon Graphics, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.402
  [Host]     : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2


```
|               Method | NumberOfArticles |         Mean |      Error |     StdDev |
|--------------------- |----------------- |-------------:|-----------:|-----------:|
|          **GetArticles** |                **1** |     **1.084 ms** |  **0.0112 ms** |  **0.0105 ms** |
|   GetReducedArticles |                1 |     1.058 ms |  0.0205 ms |  0.0244 ms |
| GetArticlesWithPrice |                1 |     1.919 ms |  0.0268 ms |  0.0251 ms |
|          **GetArticles** |               **10** |     **1.185 ms** |  **0.0110 ms** |  **0.0092 ms** |
|   GetReducedArticles |               10 |     1.107 ms |  0.0217 ms |  0.0203 ms |
| GetArticlesWithPrice |               10 |     9.371 ms |  0.1696 ms |  0.1586 ms |
|          **GetArticles** |              **100** |     **2.165 ms** |  **0.0312 ms** |  **0.0277 ms** |
|   GetReducedArticles |              100 |     1.557 ms |  0.0102 ms |  0.0079 ms |
| GetArticlesWithPrice |              100 |    84.642 ms |  0.6412 ms |  0.5355 ms |
|          **GetArticles** |             **1000** |    **11.177 ms** |  **0.0864 ms** |  **0.0766 ms** |
|   GetReducedArticles |             1000 |     6.147 ms |  0.0639 ms |  0.0534 ms |
| GetArticlesWithPrice |             1000 |   820.182 ms |  8.7843 ms |  7.3352 ms |
|          **GetArticles** |            **10000** |   **100.656 ms** |  **1.6371 ms** |  **1.4512 ms** |
|   GetReducedArticles |            10000 |    52.337 ms |  0.6480 ms |  0.6061 ms |
| GetArticlesWithPrice |            10000 | 8,402.723 ms | 57.3451 ms | 50.8349 ms |
