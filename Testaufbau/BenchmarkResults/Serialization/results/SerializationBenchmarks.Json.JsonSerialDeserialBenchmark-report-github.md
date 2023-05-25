``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.19044.2846/21H2/November2021Update)
AMD Ryzen 7 5800H with Radeon Graphics, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.402
  [Host]     : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2


```
|             Method |       Mean |    Error |   StdDev |
|------------------- |-----------:|---------:|---------:|
|   SerializeJsonStj |   370.8 ns |  4.79 ns |  4.48 ns |
|   SerializeJsonNsj |   724.3 ns |  8.44 ns |  7.90 ns |
| DeserializeJsonSTJ |   584.2 ns |  6.03 ns |  5.34 ns |
| DeserializeJsonNSJ | 1,200.9 ns | 21.44 ns | 20.05 ns |
