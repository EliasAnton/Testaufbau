``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.19044.2965/21H2/November2021Update)
AMD Ryzen 7 5800H with Radeon Graphics, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.402
  [Host]     : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2


```
|                     Method | NumberOfArticles |          Mean |       Error |      StdDev |        Median |
|--------------------------- |----------------- |--------------:|------------:|------------:|--------------:|
|                **GetArticles** |                **1** |      **1.702 ms** |   **0.0243 ms** |   **0.0190 ms** |      **1.704 ms** |
|         GetReducedArticles |                1 |      3.575 ms |   0.0628 ms |   0.0556 ms |      3.594 ms |
| GetArticlesWithPriceChatty |                1 |      3.363 ms |   0.0329 ms |   0.0274 ms |      3.362 ms |
|  GetArticlesWithPriceBulky |                1 |      1.996 ms |   0.0351 ms |   0.0293 ms |      1.987 ms |
|                **GetArticles** |               **10** |      **1.784 ms** |   **0.0310 ms** |   **0.0290 ms** |      **1.770 ms** |
|         GetReducedArticles |               10 |      3.622 ms |   0.0529 ms |   0.0495 ms |      3.624 ms |
| GetArticlesWithPriceChatty |               10 |     18.243 ms |   0.1999 ms |   0.1963 ms |     18.199 ms |
|  GetArticlesWithPriceBulky |               10 |      2.191 ms |   0.0331 ms |   0.0310 ms |      2.179 ms |
|                **GetArticles** |              **100** |      **2.773 ms** |   **0.0396 ms** |   **0.0370 ms** |      **2.765 ms** |
|         GetReducedArticles |              100 |      3.946 ms |   0.0522 ms |   0.0463 ms |      3.939 ms |
| GetArticlesWithPriceChatty |              100 |    167.197 ms |   1.9981 ms |   1.6685 ms |    166.990 ms |
|  GetArticlesWithPriceBulky |              100 |      3.793 ms |   0.0421 ms |   0.0394 ms |      3.773 ms |
|                **GetArticles** |             **1000** |     **11.752 ms** |   **0.3851 ms** |   **1.0797 ms** |     **11.213 ms** |
|         GetReducedArticles |             1000 |      7.512 ms |   0.0717 ms |   0.0671 ms |      7.482 ms |
| GetArticlesWithPriceChatty |             1000 |  1,725.205 ms |  17.5809 ms |  16.4452 ms |  1,725.656 ms |
|  GetArticlesWithPriceBulky |             1000 |     18.098 ms |   0.3524 ms |   0.5274 ms |     17.902 ms |
|                **GetArticles** |            **10000** |     **91.895 ms** |   **1.5763 ms** |   **1.3163 ms** |     **91.552 ms** |
|         GetReducedArticles |            10000 |     34.602 ms |   0.2020 ms |   0.1687 ms |     34.557 ms |
| GetArticlesWithPriceChatty |            10000 | 16,987.004 ms | 334.1953 ms | 328.2245 ms | 16,772.392 ms |
|  GetArticlesWithPriceBulky |            10000 |    159.040 ms |   3.0396 ms |   3.6185 ms |    158.059 ms |
