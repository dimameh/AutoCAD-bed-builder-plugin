namespace AutocadPlugin.Drawer.Points
{
    public class Point2D
    {
        public float X { set; get; }
        public float Y { set; get; }

        public Point2D(float x, float y)
        {
            X = x;
            Y = -y;
        }
    }
}