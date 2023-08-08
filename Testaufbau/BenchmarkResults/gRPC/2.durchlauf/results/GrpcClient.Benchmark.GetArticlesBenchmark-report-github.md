``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.19044.2965/21H2/November2021Update)
AMD Ryzen 7 5800H with Radeon Graphics, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.402
  [Host]     : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2


```
|                     Method | NumberOfArticles |          Mean |      Error |     StdDev |
|--------------------------- |----------------- |--------------:|-----------:|-----------:|
|                **GetArticles** |                **1** |      **1.563 ms** |  **0.0205 ms** |  **0.0192 ms** |
|         GetReducedArticles |                1 |      3.465 ms |  0.0668 ms |  0.0625 ms |
| GetArticlesWithPriceChatty |                1 |      3.139 ms |  0.0586 ms |  0.0548 ms |
|  GetArticlesWithPriceBulky |                1 |      6.772 ms |  0.0812 ms |  0.0760 ms |
|                **GetArticles** |               **10** |      **1.636 ms** |  **0.0227 ms** |  **0.0212 ms** |
|         GetReducedArticles |               10 |      3.495 ms |  0.0612 ms |  0.0573 ms |
| GetArticlesWithPriceChatty |               10 |     17.508 ms |  0.3443 ms |  0.3381 ms |
|  GetArticlesWithPriceBulky |               10 |      9.534 ms |  0.0877 ms |  0.0820 ms |
|                **GetArticles** |              **100** |      **2.288 ms** |  **0.0339 ms** |  **0.0317 ms** |
|         GetReducedArticles |              100 |      3.562 ms |  0.0482 ms |  0.0403 ms |
| GetArticlesWithPriceChatty |              100 |    156.752 ms |  0.9636 ms |  0.7523 ms |
|  GetArticlesWithPriceBulky |              100 |     10.887 ms |  0.2079 ms |  0.2135 ms |
|                **GetArticles** |             **1000** |      **8.722 ms** |  **0.1742 ms** |  **0.4037 ms** |
|         GetReducedArticles |             1000 |      5.360 ms |  0.1045 ms |  0.0873 ms |
| GetArticlesWithPriceChatty |             1000 |  1,573.788 ms | 20.3529 ms | 19.0381 ms |
|  GetArticlesWithPriceBulky |             1000 |     20.208 ms |  0.3986 ms |  0.3914 ms |
|                **GetArticles** |            **10000** |     **66.749 ms** |  **1.1103 ms** |  **0.9843 ms** |
|         GetReducedArticles |            10000 |     13.668 ms |  0.0804 ms |  0.0628 ms |
| GetArticlesWithPriceChatty |            10000 | 15,675.662 ms | 34.3526 ms | 28.6860 ms |
|  GetArticlesWithPriceBulky |            10000 |    139.682 ms |  2.7744 ms |  4.4802 ms |
