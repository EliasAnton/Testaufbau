using BenchmarkDotNet.Running;
using SerializationBenchmarks.Json;
using SerializationBenchmarks.Protobuf;

BenchmarkRunner.Run<ProtoSerialDeserialBenchmark>();
BenchmarkRunner.Run<JsonSerialDeserialBenchmark>();


//Examples:
// var exampleClass = new JsonSerialDeserialExample();
// exampleClass.SystemTextJsonSerialDeserialExample();
// exampleClass.NewtonsoftJsonSerialDeserialExample();