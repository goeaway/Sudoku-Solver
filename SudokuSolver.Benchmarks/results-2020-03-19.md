``` ini

BenchmarkDotNet=v0.12.0, OS=Windows 10.0.18362
Intel Core i7-8700K CPU 3.70GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET Core SDK=2.2.103
  [Host]     : .NET Core 2.2.1 (CoreCLR 4.6.27207.03, CoreFX 4.6.27207.03), X64 RyuJIT
  DefaultJob : .NET Core 2.2.1 (CoreCLR 4.6.27207.03, CoreFX 4.6.27207.03), X64 RyuJIT


```
| Method | Difficulty |     Mean |    Error |   StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------- |----------- |---------:|---------:|---------:|-------:|------:|------:|----------:|
|  **Solve** |       **Easy** | **64.63 us** | **0.637 us** | **0.596 us** | **7.9346** |     **-** |     **-** |  **49.23 KB** |
|  **Solve** |     **Medium** | **66.37 us** | **1.123 us** | **1.050 us** | **7.9346** |     **-** |     **-** |  **49.23 KB** |
|  **Solve** |       **Hard** | **64.89 us** | **0.968 us** | **0.858 us** | **7.9346** |     **-** |     **-** |  **49.23 KB** |
|  **Solve** |     **Expert** | **64.30 us** | **0.294 us** | **0.261 us** | **7.9346** |     **-** |     **-** |  **49.23 KB** |
|  **Solve** | **BloodyHard** | **65.06 us** | **0.961 us** | **0.899 us** | **7.9346** |     **-** |     **-** |  **49.23 KB** |
