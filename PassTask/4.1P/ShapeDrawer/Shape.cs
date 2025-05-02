using SplashKitSDK;

namespace ShapeDrawer
{
    public abstract class Shape
    {
        // Fields
        private Color _color;
        private float _x;
        private float _y;
        private bool _selected = false;

        // Constructors
        public Shape() : this(Color.Yellow)
        {
        }

        public Shape(Color color)
        {
            Color = color;
            _x = 0.0f; _y = 0.0f;
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

        public bool Selected
        {
            get { return this._selected; }
            set { _selected = value; }
        }


        // Methods
        public abstract void Draw();

        public abstract bool IsAt(Point2D pt);

        public abstract void DrawOutline();
    }
}
