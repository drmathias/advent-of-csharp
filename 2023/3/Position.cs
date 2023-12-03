namespace _3;

record struct Position(Coordinate Coordinate, int Length)
{
    public readonly bool IsAdjacent(Coordinate other) => (Coordinate.X - other.X == 1 || (Coordinate.X + Length - other.X >= 0
                                                                                        && Coordinate.X + Length - other.X <= Length))
                                                      && Math.Abs(other.Y - Coordinate.Y) <= 1;
}
