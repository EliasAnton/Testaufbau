``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.19044.2965/21H2/November2021Update)
AMD Ryzen 7 5800H with Radeon Graphics, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.402
  [Host]     : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2


```
|                     Method | NumberOfArticles |          Mean |      Error |     StdDev |
|--------------------------- |----------------- |--------------:|-----------:|-----------:|
|                **GetArticles** |                **1** |      **1.724 ms** |  **0.0173 ms** |  **0.0145 ms** |
|         GetReducedArticles |                1 |      3.678 ms |  0.0533 ms |  0.0472 ms |
| GetArticlesWithPriceChatty |                1 |      3.505 ms |  0.0244 ms |  0.0488 ms |
|  GetArticlesWithPriceBulky |                1 |      2.042 ms |  0.0187 ms |  0.0146 ms |
|                **GetArticles** |               **10** |      **1.827 ms** |  **0.0297 ms** |  **0.0278 ms** |
|         GetReducedArticles |               10 |      3.684 ms |  0.0607 ms |  0.0568 ms |
| GetArticlesWithPriceChatty |               10 |     19.404 ms |  0.3811 ms |  0.3565 ms |
|  GetArticlesWithPriceBulky |               10 |      2.285 ms |  0.0453 ms |  0.0745 ms |
|                **GetArticles** |              **100** |      **2.535 ms** |  **0.0477 ms** |  **0.0446 ms** |
|         GetReducedArticles |              100 |      3.860 ms |  0.0499 ms |  0.0416 ms |
| GetArticlesWithPriceChatty |              100 |    175.584 ms |  2.0780 ms |  1.8421 ms |
|  GetArticlesWithPriceBulky |              100 |      3.450 ms |  0.0414 ms |  0.0367 ms |
|                **GetArticles** |             **1000** |      **9.120 ms** |  **0.1811 ms** |  **0.3860 ms** |
|         GetReducedArticles |             1000 |      5.140 ms |  0.0612 ms |  0.0543 ms |
| GetArticlesWithPriceChatty |             1000 |  1,747.136 ms | 17.4654 ms | 16.3371 ms |
|  GetArticlesWithPriceBulky |             1000 |     15.707 ms |  0.2982 ms |  0.6546 ms |
|                **GetArticles** |            **10000** |     **68.935 ms** |  **1.3413 ms** |  **1.3774 ms** |
|         GetReducedArticles |            10000 |     15.177 ms |  0.2966 ms |  0.2774 ms |
| GetArticlesWithPriceChatty |            10000 | 17,406.282 ms | 72.2577 ms | 67.5899 ms |
|  GetArticlesWithPriceBulky |            10000 |    132.789 ms |  2.2503 ms |  4.1711 ms |
