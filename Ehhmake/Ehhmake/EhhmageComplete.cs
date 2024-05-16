using OpenCvSharp;
using Point = OpenCvSharp.Point;

namespace Ehhmake;

public static class EhhmageComplete {

    public enum Attributes {
        width,
        height,
        background,
        output,
        fontScale,
        thickness,
        position,
        color,
        text,
        fillColor,
        startPosition,
        endPosition,
        radius,
        axes,
        angle,
        startAngle,
        endAngle,
    }

    private static Mat _ehhmageOutput = new();
    public static readonly Dictionary<string, object?> ObjectNames = new();

    public static class EhhmageObjectFactory {
        private static readonly Dictionary<string, Func<IEhhmageObject>> ObjectCreators =
            new ()
            {
                { "text", () => new Text() },
                { "rect", () => new Rectangle() },
                { "line", () => new Line() },
                { "circle", () => new Circle() },
                { "polyLines", () => new PolyLines() },
                { "ellipse", () => new Ellipse() }
            };
        
        public static IEhhmageObject CreateObject(string objectName) {
            if (ObjectCreators.TryGetValue(objectName, out var objectCreator)) return objectCreator();
            Console.WriteLine($"Error: {objectName} is not a valid object name.");
            Environment.Exit(1);
            return objectCreator();
        }
        
    }
    
    public static class Ehhmage {
        private static int _height  = 1080;
        private static int _width  = 1920;
        private static int[] _background  = { 0, 0, 0 };
        private static string _output  = "ehhmage.png";
        
        #region Setters
    
        public static void SetHeight(int height) => _height = height;
        public static void SetWidth(int width) => _width = width;
        public static void SetBackground(int[] background) => _background = background;
        public static void SetOutput(string output) => _output = output;
        
    
        #endregion

        public static void InitializeEhhMage() {
            _ehhmageOutput = new Mat(_height, _width, MatType.CV_8UC3, new Scalar(_background[2], _background[1], _background[0]));
        }
        
        public static void CreateImage() {
            Cv2.ImWrite(_output, _ehhmageOutput);
            // Cv2.ImWrite(@"G:\Projects\My Rule\EhhLang Test"+_outputName, _ehhmageOutput);
        }
        
    }
    
    public interface IEhhmageObject {
        public IEhhmageObject Clone();
        public void InsertObject();
    }

    private class Text : IEhhmageObject {
        private int _fontScale = 1;
        private int _thickness = 1;
        private int[] _position = { 0, 0 };
        private int[] _color = { 255, 255, 255 };
        private string _text = "Tehhxt";
    
        #region Setters
        
        public void SetFontScale(int fontScale) => _fontScale = fontScale;
        public void SetThickness(int thickness) => _thickness = thickness;
        public void SetPosition(int[] position) => _position = position;
        public void SetColor(int[] color) => _color = color;
        public void SetText(string text) => _text = text;
    
        #endregion
        
        public IEhhmageObject Clone() {
            return new Text {
                _fontScale = _fontScale,
                _thickness = _thickness,
                _position = _position,
                _color = _color,
                _text = _text
            };
        }
        
        public void InsertObject() {
            var textPosition = new Point(_position[0], _position[1]);
            var textColor = new Scalar(_color[2], _color[1], _color[0]);
            
            Cv2.PutText(_ehhmageOutput, _text, textPosition, HersheyFonts.HersheyPlain, _fontScale, textColor, _thickness);
        }
        
    }

    private class Rectangle : IEhhmageObject{
        private int _thickness = 1;
        private int[] _position = { 0, 0 };
        private int[] _color = { 255, 255, 255 };
        private int _width = 100;
        private int _height = 100;
        private int[] _fillColor = { 255, 255, 255 };
        
        private bool _doFill = false;
        
        #region Setters
        
        public void SetThickness(int thickness) => _thickness = thickness;
        public void SetPosition(int[] position) => _position = position;
        public void SetColor(int[] color) => _color = color;
        public void SetWidth(int width) => _width = width;
        public void SetHeight(int height) => _height = height;
        public void SetFillColor(object fillColor) {
            if(fillColor is bool color)  _doFill = color;
            else {
                _doFill = true;
                _fillColor = (int[])fillColor;
            }
        }
        
        #endregion

        public IEhhmageObject Clone() {
            return new Rectangle {
                _thickness = _thickness,
                _position = _position,
                _color = _color,
                _width = _width,
                _height = _height,
                _fillColor = _fillColor,
                _doFill = _doFill
            };
        }
        
        public void InsertObject() {
            var rect = new Rect(_position[0], _position[1], _width, _height);
            var rectColor = new Scalar(_color[2], _color[1], _color[0]);
            var fillColor = new Scalar(_fillColor[2], _fillColor[1], _fillColor[0]);
            
            if (_doFill) Cv2.Rectangle(_ehhmageOutput, rect, fillColor, Cv2.FILLED);
            Cv2.Rectangle(_ehhmageOutput, rect, rectColor, _thickness);
        }
        
    }

    private class Line : IEhhmageObject {
        private int[] _startPosition = { 0, 0 };
        private int[] _endPosition = { 0, 0 };
        private int[] _color = { 255, 255, 255 };
        private int _thickness = 1;
        
        #region Setters
        
        public void SetStartPosition(int[] startPosition) => this._startPosition = startPosition;
        public void SetEndPosition(int[] endPosition) => this._endPosition = endPosition;
        public void SetColor(int[] color) => this._color = color;
        public void SetThickness(int thickness) => this._thickness = thickness;
        
        #endregion
        
        public IEhhmageObject Clone() {
            return new Line {
                _startPosition = _startPosition,
                _endPosition = _endPosition,
                _color = _color,
                _thickness = _thickness
            };
        }
        
        public void InsertObject() {
            var start = new Point(_startPosition[0], _startPosition[1]);
            var end = new Point(_endPosition[0], _endPosition[1]);
            var lineColor = new Scalar(_color[2], _color[1], _color[0]);
            
            Cv2.Line(_ehhmageOutput, start, end, lineColor, _thickness);
        }
    }

    private class Circle : IEhhmageObject {
        private int _radius = 1;
        private int[] _position = { 0, 0 };
        private int[] _color = { 255, 255, 255 };
        private int _thickness = 1;
        private int[] _fillColor = { 255, 255, 255 };
        
        private bool _doFill = false;
        
        #region Setters
        
        public void SetRadius(int radius) => _radius = radius;
        public void SetPosition(int[] position) => _position = position;
        public void SetColor(int[] color) => _color = color;
        public void SetThickness(int thickness) => _thickness = thickness;
        
        public void SetFillColor(object fillColor) {
            if(fillColor is bool color)  _doFill = color;
            else {
                _doFill = true;
                _fillColor = (int[])fillColor;
            }
        }
        
        #endregion
        
        public IEhhmageObject Clone() {
            return new Circle {
                _radius = _radius,
                _position = _position,
                _color = _color,
                _thickness = _thickness,
                _fillColor = _fillColor,
                _doFill = _doFill
            };
        }
        
        public void InsertObject() {
            var circlePosition = new Point(_position[0], _position[1]);
            var circleColor = new Scalar(_color[2], _color[1], _color[0]);
            var circleFillColor = new Scalar(_fillColor[2], _fillColor[1], _fillColor[0]);
            
            if (_doFill) Cv2.Circle(_ehhmageOutput, circlePosition, _radius, circleFillColor, Cv2.FILLED);
            Cv2.Circle(_ehhmageOutput, circlePosition, _radius, circleColor, _thickness);
        }
        
    }

    private class PolyLines : IEhhmageObject {
        private int[] _color = { 255, 255, 255 };
        private int _thickness = 1;
        private readonly List<int[]> _position = new();
        private int[] _fillColor = { 255, 255, 255 };
        
        private bool _doFill = false;
        
        #region Setters
        
        public void SetColor(int[] color) => _color = color;
        public void SetThickness(int thickness) => _thickness = thickness;
        
        public void SetPosition(object positionInfo) {
            var (index, position) = ((int, int[]))positionInfo;
            if( index >= _position.Count ) _position.Add(new int[2]);
            _position[index] = position;
        }
        
        public void SetFillColor(object fillColor) {
            if(fillColor is bool color)  _doFill = color;
            else {
                _doFill = true;
                _fillColor = (int[])fillColor;
            }
        }
        
        #endregion
        
        public IEhhmageObject Clone() {
            return new PolyLines {
                _color = _color,
                _thickness = _thickness,
                _fillColor = _fillColor,
                _doFill = _doFill
            };
        }
        
        public void InsertObject() {
            var polyLinesPositions = new Point[_position.Count];
            for (var i = 0; i < _position.Count; i++) {
                polyLinesPositions[i] = new Point(_position[i][0], _position[i][1]);
            }
            var polyLinesColor = new Scalar(_color[2], _color[1], _color[0]);
            var polyLinesFillColor = new Scalar(_fillColor[2], _fillColor[1], _fillColor[0]);
            
            if (_doFill) Cv2.FillPoly(_ehhmageOutput, new[] { polyLinesPositions }, polyLinesFillColor);
            Cv2.Polylines(_ehhmageOutput, new[] { polyLinesPositions }, true, polyLinesColor, _thickness);
        }
    }

    private class Ellipse : IEhhmageObject {
        private int _thickness = 1;
        private int[] _position = { 0, 0 };
        private int[] _color = { 255, 255, 255 };
        private int[] _axes = { 1, 1 };
        private int _angle = 0;
        private int _startAngle = 0;
        private int _endAngle = 360;
        private int[] _fillColor = { 255, 255, 255 };
        
        private bool _doFill = false;
        
        #region Setters
        
        public void SetThickness(int thickness) => _thickness = thickness;
        public void SetPosition(int[] position) => _position = position;
        public void SetColor(int[] color) => _color = color;
        public void SetAxes(int[] axes) => _axes = axes;
        public void SetAngle(int angle) => _angle = angle;
        public void SetStartAngle(int startAngle) => _startAngle = startAngle;
        public void SetEndAngle(int endAngle) => _endAngle = endAngle;
        public void SetFillColor(object fillColor) {
            if(fillColor is bool color)  _doFill = color;
            else {
                _doFill = true;
                _fillColor = (int[])fillColor;
            }
        }
        
        #endregion
        
        public IEhhmageObject Clone() {
            return new Ellipse {
                _thickness = _thickness,
                _position = _position,
                _color = _color,
                _axes = _axes,
                _angle = _angle,
                _startAngle = _startAngle,
                _endAngle = _endAngle,
                _fillColor = _fillColor,
                _doFill = _doFill
            };
        }
        
        public void InsertObject() {
            var ellipsePosition = new Point(_position[0], _position[1]);
            var ellipseColor = new Scalar(_color[2], _color[1], _color[0]);
            var ellipseFillColor = new Scalar(_fillColor[2], _fillColor[1], _fillColor[0]);
            
            if (_doFill) Cv2.Ellipse(_ehhmageOutput, ellipsePosition, new Size(_axes[0], _axes[1]), _angle, _startAngle, _endAngle, ellipseFillColor, Cv2.FILLED);
            Cv2.Ellipse(_ehhmageOutput, ellipsePosition, new Size(_axes[0], _axes[1]), _angle, _startAngle, _endAngle, ellipseColor, _thickness);
        }
    }

}