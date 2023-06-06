``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.19045.2965/22H2/2022Update)
AMD Ryzen 7 5800H with Radeon Graphics, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.402
  [Host]     : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2


```
|                     Method | NumberOfArticles |          Mean |      Error |     StdDev |
|--------------------------- |----------------- |--------------:|-----------:|-----------:|
|                **GetArticles** |                **1** |      **1.548 ms** |  **0.0269 ms** |  **0.0251 ms** |
|         GetReducedArticles |                1 |      3.457 ms |  0.0668 ms |  0.0937 ms |
| GetArticlesWithPriceChatty |                1 |      3.091 ms |  0.0553 ms |  0.0518 ms |
|  GetArticlesWithPriceBulky |                1 |      6.643 ms |  0.0859 ms |  0.0804 ms |
|                **GetArticles** |               **10** |      **1.618 ms** |  **0.0247 ms** |  **0.0231 ms** |
|         GetReducedArticles |               10 |      3.466 ms |  0.0660 ms |  0.0649 ms |
| GetArticlesWithPriceChatty |               10 |     16.798 ms |  0.0995 ms |  0.0777 ms |
|  GetArticlesWithPriceBulky |               10 |      9.400 ms |  0.0939 ms |  0.0879 ms |
|                **GetArticles** |              **100** |      **2.255 ms** |  **0.0377 ms** |  **0.0353 ms** |
|         GetReducedArticles |              100 |      3.590 ms |  0.0523 ms |  0.0489 ms |
| GetArticlesWithPriceChatty |              100 |    155.005 ms |  2.9390 ms |  3.0181 ms |
|  GetArticlesWithPriceBulky |              100 |     10.437 ms |  0.1296 ms |  0.1149 ms |
|                **GetArticles** |             **1000** |      **8.627 ms** |  **0.1723 ms** |  **0.4027 ms** |
|         GetReducedArticles |             1000 |      4.839 ms |  0.0664 ms |  0.0589 ms |
| GetArticlesWithPriceChatty |             1000 |  1,532.519 ms | 18.5040 ms | 17.3087 ms |
|  GetArticlesWithPriceBulky |             1000 |     20.043 ms |  0.3874 ms |  0.3805 ms |
|                **GetArticles** |            **10000** |     **68.443 ms** |  **1.3263 ms** |  **1.8592 ms** |
|         GetReducedArticles |            10000 |     14.960 ms |  0.2948 ms |  0.3027 ms |
| GetArticlesWithPriceChatty |            10000 | 15,285.744 ms | 71.9421 ms | 67.2947 ms |
|  GetArticlesWithPriceBulky |            10000 |    138.457 ms |  2.7534 ms |  3.8599 ms |
