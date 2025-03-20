namespace GeometryLibrary
{
    public abstract class Shape : IComparable<Shape>
    {
        public abstract double SurfaceArea();
        public abstract double Volume();

        public int CompareTo(Shape? other)
        {
            if (other == null) return 1;
            return Volume().CompareTo(other.Volume());
        }

        public static CompositeShape operator +(Shape s1, Shape s2)
        {
            return new CompositeShape(new List<Shape> { s1, s2 });
        }
    }
}
