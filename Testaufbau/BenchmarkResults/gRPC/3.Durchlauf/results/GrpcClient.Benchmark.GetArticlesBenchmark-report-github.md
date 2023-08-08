``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.19045.2965/22H2/2022Update)
AMD Ryzen 7 5800H with Radeon Graphics, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.402
  [Host]     : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2


```
|                     Method | NumberOfArticles |          Mean |      Error |     StdDev |
|--------------------------- |----------------- |--------------:|-----------:|-----------:|
|                **GetArticles** |                **1** |      **1.531 ms** |  **0.0210 ms** |  **0.0175 ms** |
|         GetReducedArticles |                1 |      3.380 ms |  0.0578 ms |  0.0513 ms |
| GetArticlesWithPriceChatty |                1 |      3.052 ms |  0.0532 ms |  0.0472 ms |
|  GetArticlesWithPriceBulky |                1 |      6.721 ms |  0.1193 ms |  0.1116 ms |
|                **GetArticles** |               **10** |      **1.602 ms** |  **0.0174 ms** |  **0.0145 ms** |
|         GetReducedArticles |               10 |      3.420 ms |  0.0546 ms |  0.0511 ms |
| GetArticlesWithPriceChatty |               10 |     16.754 ms |  0.1029 ms |  0.0859 ms |
|  GetArticlesWithPriceBulky |               10 |      9.267 ms |  0.1080 ms |  0.1010 ms |
|                **GetArticles** |              **100** |      **2.290 ms** |  **0.0445 ms** |  **0.0416 ms** |
|         GetReducedArticles |              100 |      3.556 ms |  0.0592 ms |  0.0554 ms |
| GetArticlesWithPriceChatty |              100 |    155.453 ms |  3.0543 ms |  2.9998 ms |
|  GetArticlesWithPriceBulky |              100 |     10.326 ms |  0.0948 ms |  0.0887 ms |
|                **GetArticles** |             **1000** |      **8.420 ms** |  **0.1665 ms** |  **0.3439 ms** |
|         GetReducedArticles |             1000 |      4.799 ms |  0.0912 ms |  0.0853 ms |
| GetArticlesWithPriceChatty |             1000 |  1,542.741 ms | 24.6900 ms | 21.8870 ms |
|  GetArticlesWithPriceBulky |             1000 |     20.262 ms |  0.3755 ms |  0.5504 ms |
|                **GetArticles** |            **10000** |     **65.855 ms** |  **1.2108 ms** |  **1.4414 ms** |
|         GetReducedArticles |            10000 |     14.807 ms |  0.2894 ms |  0.4057 ms |
| GetArticlesWithPriceChatty |            10000 | 15,436.894 ms | 50.9709 ms | 42.5630 ms |
|  GetArticlesWithPriceBulky |            10000 |    140.654 ms |  2.7111 ms |  3.7110 ms |
