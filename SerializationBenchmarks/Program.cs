using System.Text.Json.Nodes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using SerializationBenchmarks.Grpc;
using SerializationBenchmarks.Json;


BenchmarkRunner.Run<ProtoSerialDeserialBenchmark>();
//BenchmarkRunner.Run<JsonSerialDeserialBenchmark>();



//Examples:
// var exampleClass = new JsonSerialDeserialExample();
// exampleClass.SystemTextJsonSerialDeserialExample();
// exampleClass.NewtonsoftJsonSerialDeserialExample();