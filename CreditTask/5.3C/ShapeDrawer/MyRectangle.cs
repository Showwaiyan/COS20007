using System.IO;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class MyRectangle : Shape
    {
        // Fields
        private int _width;
        private int _height;

        // Constructor
        public MyRectangle() : this(Color.Green, 0.0f, 0.9f, 100 + 41, 100 + 41)
        {

        }
        public MyRectangle(Color color, float x, float y, int width, int height) : base(color)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        // Properties
        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }
        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }

        // Methods
        public override void Draw()
        {
            if (Selected) this.DrawOutline();
            SplashKit.FillRectangle(Color, X, Y, Width, Height);
        }

        public override void DrawOutline()
        {
            int outlineThickness = 6; //5+1
            SplashKit.FillRectangle(Color.Black, X - outlineThickness, Y - outlineThickness, Width + 2 * outlineThickness, Height + 2 * outlineThickness);
        }

        public override bool IsAt(Point2D pt)
        {
            return (pt.X >= X && pt.X <= X + Width) && (pt.Y >= Y && pt.Y <= Y + Height);
        }

        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Rectangle");
            base.SaveTo(writer);
            writer.WriteLine(Width);
            writer.WriteLine(Height);
        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            Width = reader.ReadInteger();
            Height = reader.ReadInteger();
        }
    }
}
