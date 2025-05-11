using System.IO;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class Drawing
    {
        // Fields
        private readonly List<Shape> _shapes;
        private Color _background;

        // Constructor
        public Drawing(Color background)
        {
            _shapes = new List<Shape>();
            _background = background;
        }
        public Drawing() : this(Color.White)
        {

        }

        // Property
        public List<Shape> SelectedShapes
        {
            // readonly property
            get
            {
                List<Shape> selectedShapes = new List<Shape>();
                foreach (Shape s in _shapes)
                {
                    if (s.Selected) selectedShapes.Add(s);
                }
                return selectedShapes;
            }
        }

        public int ShapeCount
        {
            // readonly property
            get { return this._shapes.Count; }
        }

        public Color Background
        {
            get { return this._background; }
            set { this._background = value; }
        }

        // Methods
        public void Draw()
        {
            SplashKit.ClearScreen(_background);
            foreach (Shape s in _shapes)
            {
                s.Draw();
            }
        }

        public void SelectShapesAt(Point2D pt)
        {
            foreach (Shape s in _shapes)
            {
                s.Selected = s.IsAt(pt);
            }
        }

        public void AddShape(Shape s)
        {
            _shapes.Add(s);
        }

        public void RemoveShape(Shape s)
        {
            _ = _shapes.Remove(s);
        }

        public void Save(string fileName)
        {
            StreamWriter writer = new StreamWriter(fileName);
            try
            {
                writer.WriteColor(Background);
                writer.WriteLine(ShapeCount);

                foreach (Shape s in _shapes) s.SaveTo(writer);
            }
            finally
            {
                writer.Close();
            }
        }

        public void Load(string fileName)
        {
            StreamReader reader = new StreamReader(fileName);
            try
            {
                Background = reader.ReadColor();
                int count = reader.ReadInteger();
                Shape s;

                _shapes.Clear();

                for (int i = 0; i < count; i++)
                {
                    string? kind = reader.ReadLine();
                    switch (kind)
                    {
                        case "Rectangle":
                            s = new MyRectangle();
                            break;
                        case "Circle":
                            s = new MyCircle();
                            break;
                        case "Line":
                            s = new MyLine();
                            break;
                        default:
                            throw new InvalidDataException($"Unknown shape kind: {kind}");
                    }
                    s.LoadFrom(reader);
                    AddShape(s);
                }
            }
            finally
            {
                reader.Close();
            }
        }
    }

}
