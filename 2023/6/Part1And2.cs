
namespace _6;

public class Part1And2
{
    [Fact]
    public void Test1()
    {
        var input = """
        Time:      7
        Distance:  9
        """;

        var combinations = CalculateCombinations(input);

        Assert.Equal(4, combinations);
    }

    [Fact]
    public void Test2()
    {
        var input = """
        Time:      7  15   30
        Distance:  9  40  200
        """;

        var combinations = CalculateCombinations(input);

        Assert.Equal(288, combinations);
    }

    [Fact]
    public void Test3()
    {
        var input = """
        Time:        56     97     77     93
        Distance:   499   2210   1097   1440
        """;

        var combinations = CalculateCombinations(input);

        Assert.Equal(1710720, combinations);
    }

    [Fact]
    public void Test4()
    {
        var input = """
        Time:        56977793
        Distance:   499221010971440
        """;

        var combinations = CalculateCombinations(input);

        Assert.Equal(35349468, combinations);
    }

    private static long CalculateCombinations(string input)
    {
        var lines = input.Split(Environment.NewLine);
        var times = lines[0].Split(':')[1].Trim().Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
        var distances = lines[1].Split(':')[1].Trim().Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();

        var combinations = new long[times.Length];
        for (var x = 0; x < times.Length; x++)
        {
            var solutions = 0;
            while (distances[x] < (times[x] / 2 - solutions) * (times[x] - (times[x] / 2 - solutions))) solutions++;
            combinations[x] = (solutions * 2) - (times[x] % 2 == 0 ? 1 : 0);
        }

        return combinations.Aggregate((a, b) => a * b);
    }
}