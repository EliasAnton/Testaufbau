``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.19045.2965/22H2/2022Update)
AMD Ryzen 7 5800H with Radeon Graphics, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.402
  [Host]     : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2


```
|          Method |     Mean |   Error |  StdDev |
|---------------- |---------:|--------:|--------:|
|   SerializeGrpc | 518.0 ns | 1.64 ns | 1.53 ns |
| DeserializeGrpc | 638.3 ns | 6.35 ns | 5.63 ns |
