using BenchmarkDotNet.Running;
using SerializationBenchmarks.Grpc;


BenchmarkRunner.Run<ProtoSerialDeserialBenchmark>();
//BenchmarkRunner.Run<JsonSerialDeserialBenchmark>();



//Examples:
// var exampleClass = new JsonSerialDeserialExample();
// exampleClass.SystemTextJsonSerialDeserialExample();
// exampleClass.NewtonsoftJsonSerialDeserialExample();