namespace GeometryLibrary
{
    public class Cylinder : Shape
    {
        private double radius, height;
        private (double x, double y, double z) bottomBase, topBase;

        public Cylinder()
        {
            var rand = new Random();
            radius = rand.NextDouble() * 5 + 1;
            height = rand.NextDouble() * 10 + 1;
            InitializeVertices();
        }

        public Cylinder(double r, double h)
        {
            radius = r;
            height = h;
            InitializeVertices();
        }

        public Cylinder(Cylinder other)
        {
            radius = other.radius;
            height = other.height;
            bottomBase = other.bottomBase;
            topBase = other.topBase;
        }

        private void InitializeVertices()
        {
            bottomBase = (0, 0, 0);
            topBase = (0, 0, height);
        }

        public double Height() => height;

        public double BottomArea() => Math.PI * radius * radius;

        public override double SurfaceArea() => 2 * Math.PI * radius * (radius + height);

        public override double Volume() => Math.PI * radius * radius * height;

        public override bool Equals(object? obj)
        {
            return obj is Cylinder c && Math.Abs(Volume() - c.Volume()) < 0.001;
        }

        public override int GetHashCode() => Volume().GetHashCode();

        public static bool operator ==(Cylinder c1, Cylinder c2)
        {
            return c1.Equals(c2);
        }

        public static bool operator !=(Cylinder c1, Cylinder c2)
        {
            return !(c1 == c2);
        }
    }
}