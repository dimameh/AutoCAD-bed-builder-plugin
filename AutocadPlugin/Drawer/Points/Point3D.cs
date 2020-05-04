namespace AutocadPlugin.Drawer.Points
{
    public class Point3D
    {
        public float X { get; }
        public float Y { get; }
        public float Z { get; }

        public Point3D(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}