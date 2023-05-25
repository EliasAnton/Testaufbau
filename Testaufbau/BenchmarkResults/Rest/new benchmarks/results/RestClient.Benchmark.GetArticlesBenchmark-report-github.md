``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.19045.2965/22H2/2022Update)
AMD Ryzen 7 5800H with Radeon Graphics, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.402
  [Host]     : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2


```
|                     Method | NumberOfArticles |          Mean |      Error |     StdDev |
|--------------------------- |----------------- |--------------:|-----------:|-----------:|
|                **GetArticles** |                **1** |      **1.505 ms** |  **0.0265 ms** |  **0.0248 ms** |
|         GetReducedArticles |                1 |      3.372 ms |  0.0640 ms |  0.0711 ms |
| GetArticlesWithPriceChatty |                1 |      2.981 ms |  0.0446 ms |  0.0417 ms |
|  GetArticlesWithPriceBulky |                1 |      6.615 ms |  0.0915 ms |  0.0855 ms |
|                **GetArticles** |               **10** |      **1.595 ms** |  **0.0220 ms** |  **0.0206 ms** |
|         GetReducedArticles |               10 |      3.417 ms |  0.0484 ms |  0.0452 ms |
| GetArticlesWithPriceChatty |               10 |     16.123 ms |  0.1576 ms |  0.1397 ms |
|  GetArticlesWithPriceBulky |               10 |      9.251 ms |  0.0599 ms |  0.0468 ms |
|                **GetArticles** |              **100** |      **2.454 ms** |  **0.0370 ms** |  **0.0346 ms** |
|         GetReducedArticles |              100 |      3.711 ms |  0.0566 ms |  0.0529 ms |
| GetArticlesWithPriceChatty |              100 |    148.898 ms |  1.9744 ms |  1.6487 ms |
|  GetArticlesWithPriceBulky |              100 |     10.710 ms |  0.0832 ms |  0.0778 ms |
|                **GetArticles** |             **1000** |     **10.512 ms** |  **0.1355 ms** |  **0.1267 ms** |
|         GetReducedArticles |             1000 |      7.095 ms |  0.0580 ms |  0.0514 ms |
| GetArticlesWithPriceChatty |             1000 |  1,477.025 ms | 18.8016 ms | 17.5870 ms |
|  GetArticlesWithPriceBulky |             1000 |     22.253 ms |  0.2110 ms |  0.1762 ms |
|                **GetArticles** |            **10000** |     **87.730 ms** |  **1.1615 ms** |  **1.0296 ms** |
|         GetReducedArticles |            10000 |     34.618 ms |  0.1725 ms |  0.1441 ms |
| GetArticlesWithPriceChatty |            10000 | 14,999.907 ms | 94.9948 ms | 84.2104 ms |
|  GetArticlesWithPriceBulky |            10000 |    166.533 ms |  3.2755 ms |  3.5047 ms |
