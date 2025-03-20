using System;
using GeometryLibrary;

public static class DisplayHelper
{
    public static void DisplayShape(Shape shape)
    {
        switch (shape)
        {
            case Tetrahedron tetra:
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"Tetrahedron Area: {tetra.SurfaceArea()}, Volume: {tetra.Volume()}, Centroid: {tetra.Centroid()}");
                break;
            case Cuboid cuboid:
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Cuboid Area: {cuboid.SurfaceArea()}, Volume: {cuboid.Volume()}, Centroid: {cuboid.Centroid()}");
                break;
            case Cylinder cylinder:
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Cylinder Area: {cylinder.SurfaceArea()}, Volume: {cylinder.Volume()}, Height: {cylinder.Height()}, Bottom Area: {cylinder.BottomArea()}");
                break;
        }
        Console.ResetColor();
    }

    public static void DisplayCuboids(CompositeShape composite)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Cuboid objects in the composite shape:");
        foreach (var shape in composite)
        {
            if (shape is Cuboid cuboid)
            {
                Console.WriteLine($"Cuboid Area: {cuboid.SurfaceArea()}, Volume: {cuboid.Volume()}, Centroid: {cuboid.Centroid()}");
            }
        }
        Console.ResetColor();
    }

    public static void DisplayTetrahedrons(CompositeShape composite)
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("Tetrahedron objects in the composite shape:");
        foreach (var shape in composite)
        {
            if (shape is Tetrahedron tetra)
            {
                Console.WriteLine($"Tetrahedron Area: {tetra.SurfaceArea()}, Volume: {tetra.Volume()}, Centroid: {tetra.Centroid()}");
            }
        }
        Console.ResetColor();
    }

    public static void DisplayCylinders(CompositeShape composite)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Cylinder objects in the composite shape:");
        foreach (var shape in composite)
        {
            if (shape is Cylinder cylinder)
            {
                Console.WriteLine($"Cylinder Area: {cylinder.SurfaceArea()}, Volume: {cylinder.Volume()}, Height: {cylinder.Height()}, Bottom Area: {cylinder.BottomArea()}");
            }
        }
        Console.ResetColor();
    }

    public static void DisplayCompositeShape(CompositeShape composite)
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("Composite shape details:");
        Console.WriteLine($"Total Surface Area: {composite.SurfaceArea()}");
        Console.WriteLine($"Total Volume: {composite.Volume()}");
        Console.WriteLine("Shapes in the composite shape:");
        foreach (var shape in composite)
        {
            DisplayShape(shape);
        }
        Console.ResetColor();
    }

    public static void DisplayAllShapes(CompositeShape composite, Shape shape1, Shape shape2)
    {
        DisplayCompositeShape(composite);
        Console.WriteLine("All shapes in the composite shape:");
        foreach (var shape in composite)
        {
            DisplayShape(shape);
        }

        Console.ForegroundColor = ConsoleColor.DarkYellow;
        var combinedShape = shape1 + shape2;
        Console.WriteLine($"Combined Shape Area: {combinedShape.SurfaceArea()}, Volume: {combinedShape.Volume()}");
        Console.ResetColor();
    }

    public static void DemonstrateIsInAndCopyConstructor(CompositeShape composite, Shape shape)
    {
        var isInIndex = composite.IsIn(shape);
        if (isInIndex != -1)
        {
            var copiedShape = composite[isInIndex];
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Copied Shape Volume: {copiedShape.Volume()}");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Shape not found in the composite.");
            Console.ResetColor();
        }
    }
}