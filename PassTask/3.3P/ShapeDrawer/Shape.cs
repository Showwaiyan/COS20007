using SplashKitSDK;

namespace ShapeDrawer
{
    public class Shape
    {
        // Fields
        private Color _color;
        private float _x;
        private float _y;
        private int _width;
        private int _height;
        private bool _selected = false;

        // Constructors
        public Shape(int param)
        {
            _color = Color.Chocolate;
            _x = 0.0f; _y = 0.0f;
            _width = param; _height = param;
        }

        // Properties
        public Color Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public float X
        {
            get { return _x; }
            set { _x = value; }
        }
        public float Y
        {
            get { return _y; }
            set { _y = value; }
        }

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

        public bool Selected
        {
            get { return this._selected; }
            set { this._selected = value; }
        }


        // Methods
        public void Draw()
        {
            if (this._selected) this.DrawOutline();
            SplashKit.FillRectangle(_color, _x, _y, _width, _height);
        }

        public bool IsAt(Point2D pt)
        {
            return (pt.X >= _x && pt.X <= _x + _width) && (pt.Y >= _y && pt.Y <= _y + _height);
        }

        public void DrawOutline()
        {
            int outlineThickness = 6; //5+!
            SplashKit.FillRectangle(Color.Black, _x-outlineThickness, _y-outlineThickness, _width+2*outlineThickness, _height+2*outlineThickness);
        }
    }
}
