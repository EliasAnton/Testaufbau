``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.19044.2846/21H2/November2021Update)
AMD Ryzen 7 5800H with Radeon Graphics, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.402
  [Host]     : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2


```
|          Method |     Mean |   Error |  StdDev |
|---------------- |---------:|--------:|--------:|
|   SerializeGrpc | 298.6 ns | 2.69 ns | 2.52 ns |
| DeserializeGrpc | 524.7 ns | 4.92 ns | 4.60 ns |
