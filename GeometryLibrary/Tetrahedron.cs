namespace GeometryLibrary
{
    public class Tetrahedron : Shape
    {
        private double edge;
        private (double x, double y, double z)[] vertices = new (double x, double y, double z)[4];

        public Tetrahedron()
        {
            edge = new Random().NextDouble() * 10 + 1;
            InitializeVertices();
        }

        public Tetrahedron(double edgeLength)
        {
            edge = edgeLength;
            InitializeVertices();
        }
        
        public Tetrahedron(Tetrahedron other)
        {
            edge = other.edge;
            vertices = other.vertices.ToArray();
        }

        private void InitializeVertices()
        {
            double sqrt2 = Math.Sqrt(2);
            vertices[0] = (0, 0, 0);
            vertices[1] = (edge, 0, 0);
            vertices[2] = (edge / 2, edge * sqrt2 / 2, 0);
            vertices[3] = (edge / 2, edge / (2 * sqrt2), edge * sqrt2 / sqrt2);
        }

        public override double SurfaceArea() => Math.Sqrt(3) * edge * edge;
        public override double Volume() => Math.Pow(edge, 3) / (6 * Math.Sqrt(2));

        public (double x, double y, double z) Centroid()
        {
            double x = vertices.Average(v => v.x);
            double y = vertices.Average(v => v.y);
            double z = vertices.Average(v => v.z);
            return (x, y, z);
        }

        public override bool Equals(object? obj)
        {
            return obj is Tetrahedron t && Math.Abs(edge - t.edge) < 0.001;
        }

        public override int GetHashCode() => edge.GetHashCode();

        public static bool operator ==(Tetrahedron t1, Tetrahedron t2)
        {
            return t1.Equals(t2);
        }

        public static bool operator !=(Tetrahedron t1, Tetrahedron t2)
        {
            return !(t1 == t2);
        }
    }
}