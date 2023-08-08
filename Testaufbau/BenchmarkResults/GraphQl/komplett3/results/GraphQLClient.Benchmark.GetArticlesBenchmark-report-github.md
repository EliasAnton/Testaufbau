``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.19045.2965/22H2/2022Update)
AMD Ryzen 7 5800H with Radeon Graphics, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.402
  [Host]     : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2


```
|               Method | NumberOfArticles |         Mean |      Error |     StdDev |
|--------------------- |----------------- |-------------:|-----------:|-----------:|
|          **GetArticles** |                **1** |     **1.047 ms** |  **0.0118 ms** |  **0.0092 ms** |
|   GetReducedArticles |                1 |     1.005 ms |  0.0083 ms |  0.0070 ms |
| GetArticlesWithPrice |                1 |     1.852 ms |  0.0315 ms |  0.0280 ms |
|          **GetArticles** |               **10** |     **1.154 ms** |  **0.0150 ms** |  **0.0125 ms** |
|   GetReducedArticles |               10 |     1.073 ms |  0.0079 ms |  0.0062 ms |
| GetArticlesWithPrice |               10 |     9.042 ms |  0.0440 ms |  0.0343 ms |
|          **GetArticles** |              **100** |     **2.133 ms** |  **0.0210 ms** |  **0.0164 ms** |
|   GetReducedArticles |              100 |     1.527 ms |  0.0284 ms |  0.0266 ms |
| GetArticlesWithPrice |              100 |    80.180 ms |  0.6761 ms |  0.5646 ms |
|          **GetArticles** |             **1000** |    **11.245 ms** |  **0.1319 ms** |  **0.1169 ms** |
|   GetReducedArticles |             1000 |     6.207 ms |  0.1071 ms |  0.0950 ms |
| GetArticlesWithPrice |             1000 |   792.642 ms |  9.9559 ms |  9.3127 ms |
|          **GetArticles** |            **10000** |    **99.281 ms** |  **1.4888 ms** |  **1.3926 ms** |
|   GetReducedArticles |            10000 |    52.172 ms |  0.8842 ms |  0.8271 ms |
| GetArticlesWithPrice |            10000 | 8,430.205 ms | 72.4358 ms | 67.7565 ms |
