namespace GeometryLibrary
{
    public class Cuboid : Shape
    {
        private double length, width, height;
        private (double x, double y, double z)[] vertices = new (double x, double y, double z)[8];

        public Cuboid()
        {
            var rand = new Random();
            length = rand.NextDouble() * 10 + 1;
            width = rand.NextDouble() * 10 + 1;
            height = rand.NextDouble() * 10 + 1;
            InitializeVertices();
        }

        public Cuboid(double l, double w, double h)
        {
            length = l;
            width = w;
            height = h;
            InitializeVertices();
        }

        public Cuboid(Cuboid other)
        {
            length = other.length;
            width = other.width;
            height = other.height;
            vertices = other.vertices.ToArray();
        }

        private void InitializeVertices()
        {
            vertices[0] = (0, 0, 0);
            vertices[1] = (length, 0, 0);
            vertices[2] = (length, width, 0);
            vertices[3] = (0, width, 0);
            vertices[4] = (0, 0, height);
            vertices[5] = (length, 0, height);
            vertices[6] = (length, width, height);
            vertices[7] = (0, width, height);
        }

        public override double SurfaceArea() => 2 * (length * width + width * height + height * length);
        public override double Volume() => length * width * height;

        public (double x, double y, double z) Centroid()
        {
            double x = vertices.Average(v => v.x);
            double y = vertices.Average(v => v.y);
            double z = vertices.Average(v => v.z);
            return (x, y, z);
        }

        public override bool Equals(object? obj)
        {
            return obj is Cuboid c && Math.Abs(Volume() - c.Volume()) < 0.001;
        }

        public override int GetHashCode() => Volume().GetHashCode();

        public static bool operator ==(Cuboid c1, Cuboid c2)
        {
            return c1.Equals(c2);
        }

        public static bool operator !=(Cuboid c1, Cuboid c2)
        {
            return !(c1 == c2);
        }
    }
}