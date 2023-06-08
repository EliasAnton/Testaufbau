``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.19045.2965/22H2/2022Update)
AMD Ryzen 7 5800H with Radeon Graphics, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.402
  [Host]     : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2


```
|             Method |       Mean |    Error |   StdDev |
|------------------- |-----------:|---------:|---------:|
|   SerializeJsonStj |   752.9 ns |  3.67 ns |  3.43 ns |
|   SerializeJsonNsj | 1,689.8 ns | 15.32 ns | 14.33 ns |
| DeserializeJsonStj | 1,366.5 ns |  7.99 ns |  7.47 ns |
| DeserializeJsonNsj | 3,307.2 ns | 24.80 ns | 23.19 ns |
