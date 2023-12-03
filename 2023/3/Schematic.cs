namespace _3;

public static class Schematic
{
    internal static Dictionary<Position, int> MapDigitsToNumbers(Dictionary<Coordinate, char> digits)
    {
        var numbers = new Dictionary<Position, int>();

        Coordinate previousDigit = default;

        var currentNumber = new List<KeyValuePair<Coordinate, char>>();

        foreach (var digit in digits)
        {
            if (previousDigit == default || previousDigit.X == digit.Key.X - 1 && previousDigit.Y == digit.Key.Y)
            {
                currentNumber.Add(digit);
            }
            else
            {
                numbers.Add(new Position(currentNumber[0].Key, currentNumber.Count), int.Parse(string.Join("", currentNumber.Select(c => c.Value))));
                currentNumber = new List<KeyValuePair<Coordinate, char>> { digit };
            }

            previousDigit = digit.Key;
        }

        if (currentNumber.Count > 0) numbers.Add(new Position(currentNumber[0].Key, currentNumber.Count), int.Parse(string.Join("", currentNumber.Select(c => c.Value))));

        return numbers;
    }
}
