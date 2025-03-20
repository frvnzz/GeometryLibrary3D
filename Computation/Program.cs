using System;
using GeometryLibrary;

class Program
{
    static void Main(string[] args)
    {
        var tetra1 = new Tetrahedron();
        var cuboid1 = new Cuboid();
        var cylinder1 = new Cylinder();

        var composite = new CompositeShape(new List<Shape> { tetra1, cuboid1, cylinder1 });
        composite.AddShape(new Cuboid(2, 3, 4));
        composite.AddShape(new Cylinder(1, 5));
        composite.AddShape(new Tetrahedron());
        composite.Sort();

        if (args.Length > 0)
        {
            switch (args[0])
            {
                case "-Cuboid":
                    DisplayCuboids(composite);
                    break;
                case "-Tetrahedron":
                    DisplayTetrahedrons(composite);
                    break;
                case "-Cylinder":
                    DisplayCylinders(composite);
                    break;
                case "-Composite":
                    DisplayCompositeShape(composite);
                    break;
                case "-All":
                    DisplayAllShapes(composite, tetra1, cuboid1);
                    break;
                default:
                    Console.WriteLine("Invalid argument. Use -Cuboid, -Tetrahedron, -Cylinder, -Composite, or -All.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("No argument provided. Use -Cuboid, -Tetrahedron, -Cylinder, -Composite, or -All.");
        }
    }

    private static void DisplayShape(Shape shape)
    {
        switch (shape)
        {
            case Tetrahedron tetra:
                Console.WriteLine($"Tetrahedron Area: {tetra.SurfaceArea()}, Volume: {tetra.Volume()}, Centroid: {tetra.Centroid()}");
                break;
            case Cuboid cuboid:
                Console.WriteLine($"Cuboid Area: {cuboid.SurfaceArea()}, Volume: {cuboid.Volume()}, Centroid: {cuboid.Centroid()}");
                break;
            case Cylinder cylinder:
                Console.WriteLine($"Cylinder Area: {cylinder.SurfaceArea()}, Volume: {cylinder.Volume()}, Height: {cylinder.Height()}, Bottom Area: {cylinder.BottomArea()}");
                break;
        }
    }

    private static void DisplayCuboids(CompositeShape composite)
    {
        Console.WriteLine("Cuboid objects in the composite shape:");
        foreach (var shape in composite)
        {
            if (shape is Cuboid cuboid)
            {
                Console.WriteLine($"Cuboid Area: {cuboid.SurfaceArea()}, Volume: {cuboid.Volume()}, Centroid: {cuboid.Centroid()}");
            }
        }
    }

    private static void DisplayTetrahedrons(CompositeShape composite)
    {
        Console.WriteLine("Tetrahedron objects in the composite shape:");
        foreach (var shape in composite)
        {
            if (shape is Tetrahedron tetra)
            {
                Console.WriteLine($"Tetrahedron Area: {tetra.SurfaceArea()}, Volume: {tetra.Volume()}, Centroid: {tetra.Centroid()}");
            }
        }
    }

    private static void DisplayCylinders(CompositeShape composite)
    {
        Console.WriteLine("Cylinder objects in the composite shape:");
        foreach (var shape in composite)
        {
            if (shape is Cylinder cylinder)
            {
                Console.WriteLine($"Cylinder Area: {cylinder.SurfaceArea()}, Volume: {cylinder.Volume()}, Height: {cylinder.Height()}, Bottom Area: {cylinder.BottomArea()}");
            }
        }
    }

    private static void DisplayCompositeShape(CompositeShape composite)
    {
        Console.WriteLine("Composite shape details:");
        Console.WriteLine($"Total Surface Area: {composite.SurfaceArea()}");
        Console.WriteLine($"Total Volume: {composite.Volume()}");
        Console.WriteLine("Shapes in the composite shape:");
        foreach (var shape in composite)
        {
            DisplayShape(shape);
        }
    }

    private static void DisplayAllShapes(CompositeShape composite, Shape shape1, Shape shape2)
    {
        DisplayCompositeShape(composite);
        Console.WriteLine("All shapes in the composite shape:");
        foreach (var shape in composite)
        {
            DisplayShape(shape);
        }

        var combinedShape = shape1 + shape2;
        Console.WriteLine($"Combined Shape Area: {combinedShape.SurfaceArea()}, Volume: {combinedShape.Volume()}");
    }
}