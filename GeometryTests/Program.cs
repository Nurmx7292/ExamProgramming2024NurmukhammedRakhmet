using System;
using Geometry;
namespace GeometryTests;

class Program
{
    static void Main(string[] args)
    {
        Point point1 = new Point(3, 4);
        Console.WriteLine($"Point 1: {point1.X},{point1.Y} | IsOnAxis: {point1.IsOnAxis}");

        point1.ReflectX();
        Console.WriteLine($"Reflected X: {point1.X}");

        ColourfulPoint colourfulPoint = new ColourfulPoint(2, -3, PointColour.Red);
        Console.WriteLine($"Colourful Point: {colourfulPoint.Colour} | IsOnAxis: {colourfulPoint.IsOnAxis}");

        colourfulPoint.ChangeColour(PointColour.Green);
        Console.WriteLine($"Changed Colour: {colourfulPoint.Colour}");

        colourfulPoint.NextColour();
        Console.WriteLine($"Next Colour: {colourfulPoint.Colour}");

        Console.WriteLine($"Before Normalize: {colourfulPoint.X} {colourfulPoint.Y}");

        decimal distanceBefore = (decimal)Math.Sqrt((double)(colourfulPoint.X * colourfulPoint.X + colourfulPoint.Y * colourfulPoint.Y));
        Console.WriteLine($"Distance before Normalize: {distanceBefore}");

        colourfulPoint.Normalize();

        Console.WriteLine($"After Normalize: {colourfulPoint.X},{colourfulPoint.Y}");

        decimal distanceAfter = (decimal)Math.Sqrt((double)(colourfulPoint.X * colourfulPoint.X + colourfulPoint.Y * colourfulPoint.Y));
        Console.WriteLine($"Distance after Normalize: {distanceAfter}");

        Point point2 = new Point(-1, 2);
        colourfulPoint.Add(point2);
        Console.WriteLine($"Added Point 2: {colourfulPoint.X} {colourfulPoint.X}");

        Point sum = ColourfulPoint.Add(point1, point2);
        Console.WriteLine($"Sum of Point 1 and Point 2: {sum.X},{sum.Y}");
    }
}
