using SplashKitSDK;

namespace ShapeDrawer
{
    public class MyCircle : Shape
    {
        // Fields
        private int _radius;

        // Constructor
        public MyCircle() : this(Color.Blue, 100+41, 100+41, 50+41)
        {
        }
        public MyCircle(Color color, int x, int y, int radius) : base(color)
        {
            X = x;
            Y = y;
            Radius = radius;
        }

        // Properties
        public int Radius
        {
            get { return _radius; }
            set { _radius = value; }
        }

        // Methods
        public override void Draw()
        {
            if (Selected) DrawOutline();
            SplashKit.FillCircle(Color, X, Y, Radius);
        }

        public override void DrawOutline()
        {
            int outlineThickness = 7; //5+2
            SplashKit.FillCircle(Color.Black, X, Y, Radius + outlineThickness);
        }

        public override bool IsAt(Point2D pt)
        {
            // By Distance Formula
            // = √(x2-x1)^2 + (y2-y1)^2
            // And then we get the distnace between mouse click and circle area
            // If that distance is smaller than and equal the circle's radius
            // of course, it is inside the circle
            // return Math.Sqrt(Math.Pow(pt.X - X, 2) + Math.Pow(pt.Y - Y, 2)) <= Radius;

            return SplashKit.PointInCircle(pt,
                    new Circle()
                    {
                        Center =
                        new Point2D() { X = this.X, Y = this.Y },
                        Radius = this.Radius
                    });
        }
    }
}
