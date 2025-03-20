using System.Collections;

namespace GeometryLibrary
{
    public class CompositeShape : Shape, IEnumerable<Shape>
    {
        private List<Shape> shapes;

        public CompositeShape() => shapes = new List<Shape>();
        public CompositeShape(List<Shape> initialShapes) => shapes = initialShapes;
        public CompositeShape(int n)
        {
            shapes = new List<Shape>();
            var rand = new Random();
            for (int i = 0; i < n; i++)
            {
                int shapeType = rand.Next(3);
                switch (shapeType)
                {
                    case 0:
                        shapes.Add(new Tetrahedron(rand.NextDouble() * 10 + 1));
                        break;
                    case 1:
                        shapes.Add(new Cuboid(rand.NextDouble() * 10 + 1, rand.NextDouble() * 10 + 1, rand.NextDouble() * 10 + 1));
                        break;
                    case 2:
                        shapes.Add(new Cylinder(rand.NextDouble() * 5 + 1, rand.NextDouble() * 10 + 1));
                        break;
                }
            }
        }

        public void AddShape(Shape shape) => shapes.Add(shape);
        public Shape this[int index] => shapes[index];

        public int IsIn(Shape s) => shapes.IndexOf(s);

        public override double SurfaceArea() => shapes.Sum(s => s.SurfaceArea());
        public override double Volume() => shapes.Sum(s => s.Volume());

        public void Sort() => shapes.Sort();

        public IEnumerator<Shape> GetEnumerator() => shapes.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}