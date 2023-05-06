using System;

public enum Direction
{
    Up,
    Down,
    Left,
    Right,
}

public static class DirectionExtensions
{
    public static float GetRotationAngle(this Direction direction) => direction switch
    {
        Direction.Up => 0,
        Direction.Down => 180,
        Direction.Left => -90,
        Direction.Right => 90,
        _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
    };
}