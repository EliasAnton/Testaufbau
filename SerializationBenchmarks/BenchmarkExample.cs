using BenchmarkDotNet.Attributes;

namespace SerializationBenchmarks;

public class SingleVsFirst
{
    private readonly List<string> _haystack = new();
    private readonly int _haystackSize = 1000000;

    public SingleVsFirst()
    {
        //Add a large amount of items to our list.
        Enumerable.Range(1, _haystackSize).ToList().ForEach(x => _haystack.Add(x.ToString()));

        //One at the start.
        _haystack.Insert(0, _needles[0]);
        //One right in the middle.
        _haystack.Insert(_haystackSize / 2, _needles[1]);
        //One at the end.
        _haystack.Insert(_haystack.Count - 1, _needles[2]);
    }

    public List<string> _needles => new() { "StartNeedle", "MiddleNeedle", "EndNeedle" };

    [ParamsSource(nameof(_needles))] public string Needle { get; set; }

    [Benchmark]
    public string Single()
    {
        return _haystack.SingleOrDefault(x => x == Needle);
    }

    [Benchmark]
    public string First()
    {
        return _haystack.FirstOrDefault(x => x == Needle);
    }
}