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
                    DisplayHelper.DisplayCuboids(composite);
                    break;
                case "-Tetrahedron":
                    DisplayHelper.DisplayTetrahedrons(composite);
                    break;
                case "-Cylinder":
                    DisplayHelper.DisplayCylinders(composite);
                    break;
                case "-Composite":
                    DisplayHelper.DisplayCompositeShape(composite);
                    break;
                case "-All":
                    DisplayHelper.DisplayAllShapes(composite, tetra1, cuboid1);
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Invalid argument. Use -Cuboid, -Tetrahedron, -Cylinder, -Composite, or -All.");
                    Console.ResetColor();
                    break;
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("No argument provided. Use -Cuboid, -Tetrahedron, -Cylinder, -Composite, or -All.");
            Console.ResetColor();
        }
    }
}