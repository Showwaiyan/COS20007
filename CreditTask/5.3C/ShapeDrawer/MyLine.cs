using System.IO;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class MyLine : Shape
    {
        // Fields
        private float _endX;
        private float _endY;

        // Constructor
        public MyLine() : this(Color.Red, SplashKit.MouseX(), SplashKit.MouseY(), SplashKit.MouseX() + new Random().Next(-150, 150), new Random().Next(0, 601))
        {

        }

        public MyLine(Color color, float startX, float startY, float endX, float endY) : base(color)
        {
            X = startX;
            Y = startY;
            EndX = endX;
            EndY = endY;
        }

        // Properties
        public float EndX
        {
            get { return _endX; }
            set { _endX = value; }
        }
        public float EndY
        {
            get { return _endY; }
            set { _endY = value; }
        }

        // Methods
        public override void Draw()
        {
            if (Selected) DrawOutline();
            SplashKit.DrawLine(Color, X, Y, EndX, EndY);
        }

        public override void DrawOutline()
        {
            int circleRadius = 5;
            SplashKit.FillCircle(Color.Black, X, Y, circleRadius);
            SplashKit.FillCircle(Color.Black, EndX, EndY, circleRadius);
        }

        public override bool IsAt(Point2D pt)
        {
            return SplashKit.PointOnLine(pt,
                new Line()
                {
                    StartPoint = new Point2D() { X = this.X, Y = this.Y },
                    EndPoint = new Point2D() { X = this.EndX, Y = this.EndY },
                });
        }

        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Line");
            base.SaveTo(writer);
            writer.WriteLine(EndX);
            writer.WriteLine(EndY);
        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            EndX = reader.ReadInteger();
            EndY = reader.ReadInteger();
        }
    }
}
