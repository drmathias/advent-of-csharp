namespace _7;

public enum HandType { HighCard, OnePair, TwoPair, ThreeOfAKind, FullHouse, FourOfAKind, FiveOfAKind }

public record Hand
{
    public Hand(char First, char Second, char Third, char Forth, char Fifth) => Cards = new char[] { First, Second, Third, Forth, Fifth };

    public char[] Cards { get; }

    public static Hand Parse(string cards) => new(cards[0], cards[1], cards[2], cards[3], cards[4]);
}

public record Bid(Hand Hand, int Amount);
