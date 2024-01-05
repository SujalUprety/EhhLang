using OpenCvSharp;
using Point = OpenCvSharp.Point;

namespace Ehhmake;

public static class EhhmageComplete {
    
    public enum EhhmageAttribute {
        width,
        height,
        background,
        output
    }
    
    public enum TextAttribute {
        fontScale,
        thickness,
        position,
        color,
        text
    }
    
    public enum RectangleAttribute {
        thickness,
        position,
        color,
        width,
        height,
        fillColor
    }
    
    public enum LineAttribute {
        startPosition,
        endPosition,
        color,
        thickness
    }
    
    public enum CircleAttribute {
        radius,
        position,
        color,
        thickness,
        fillColor
    }
    
    public enum PolyLinesAttribute {
        color,
        thickness,
        position,
        fillColor
    }
    
    public enum EllipseAttribute {
        thickness,
        position,
        color,
        axes,
        angle,
        startAngle,
        endAngle,
        fillColor
    }

    private static Mat _ehhmageOutput = new();
    public static readonly Dictionary<string, object?> ObjectNames = new();
    

    public static class Ehhmage {
        private static int _height  = 1080;
        private static int _width  = 1920;
        private static int[] _background  = { 0, 0, 0 };
        private static string _outputName  = "ehhmage.png";
        
        #region Setters
    
        public static void SetHeight(int height) {
            _height = height;
        }
        
        public static void SetWidth(int width) {
            _width = width;
        }
        
        public static void SetBackground(int[] background) {
            _background = background;
        }
        
        public static void SetOutputName(string outputName) {
            _outputName = outputName;
        }
    
        #endregion

        public static void InitializeEhhMage() {
            _ehhmageOutput = new Mat(_height, _width, MatType.CV_8UC3, new Scalar(_background[2], _background[1], _background[0]));
        }
        
        public static void CreateImage() {
            Cv2.ImWrite(_outputName, _ehhmageOutput);
            // Cv2.ImWrite(@"G:\Projects\My Rule\EhhLang Test"+_outputName, _ehhmageOutput);
        }
        
    }

    public class Text {
        private int _fontScale = 1;
        private int _thickness = 1;
        private int[] _position = { 0, 0 };
        private int[] _color = { 255, 255, 255 };
        private string _text = "Tehhxt";
    
        #region Setters
    
        public void SetFontScale(int fontScale) {
            _fontScale = fontScale;
        }
        
        public void SetThickness(int thickness) {
            _thickness = thickness;
        }
        
        public void SetPosition(int[] textPosition) {
            _position = textPosition;
        }
        
        public void SetColor(int[] textColor) {
            _color = textColor;
        }
        
        public void SetText(string text) {
            _text = text;
        }
    
        #endregion
        
        public Text Clone() {
            return new Text {
                _fontScale = _fontScale,
                _thickness = _thickness,
                _position = _position,
                _color = _color,
                _text = _text
            };
        }
        
        public void InsertText() {
            var textPosition = new Point(_position[0], _position[1]);
            var textColor = new Scalar(_color[2], _color[1], _color[0]);
            
            Cv2.PutText(_ehhmageOutput, _text, textPosition, HersheyFonts.HersheyPlain, _fontScale, textColor, _thickness);
        }
        
    }

    public class Rectangle {
        private int _thickness = 1;
        private int[] _position = { 0, 0 };
        private int[] _color = { 255, 255, 255 };
        private int _width = 100;
        private int _height = 100;
        private int[] _fillColor = { 255, 255, 255 };
        
        private bool _doFill = false;
        
        #region Setters
        
        public void SetThickness(int rectangleThickness) {
            _thickness = rectangleThickness;
        }
        
        public void SetPosition(int[] rectanglePosition) {
            _position = rectanglePosition;
        }
        
        public void SetColor(int[] rectangleColor) {
            _color = rectangleColor;
        }
        
        public void SetWidth(int rectangleWidth) {
            _width = rectangleWidth;
        }
        
        public void SetHeight(int rectangleHeight) {
            _height = rectangleHeight;
        }
        
        public void SetFillColor(int[] rectangleFillColor) {
            _fillColor = rectangleFillColor;
        }
        
        public void SetDoFill(bool fillRectangle) {
            _doFill = fillRectangle;
        }
    
        #endregion

        public Rectangle Clone() {
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
        
        public void DrawRectangle() {
            var rect = new Rect(_position[0], _position[1], _width, _height);
            var rectColor = new Scalar(_color[2], _color[1], _color[0]);
            var fillColor = new Scalar(_fillColor[2], _fillColor[1], _fillColor[0]);
            
            if (_doFill) Cv2.Rectangle(_ehhmageOutput, rect, fillColor, Cv2.FILLED);
            Cv2.Rectangle(_ehhmageOutput, rect, rectColor, _thickness);
        }
        
    }

    public class Line {
        private int[] startPosition = { 0, 0 };
        private int[] endPosition = { 0, 0 };
        private int[] color = { 255, 255, 255 };
        private int thickness = 1;
        
        #region Setters
        
        public void SetStartPosition(int[] lineStartPosition) {
            startPosition = lineStartPosition;
        }
        
        public void SetEndPosition(int[] lineEndPosition) {
            endPosition = lineEndPosition;
        }
        
        public void SetColor(int[] lineColor) {
            color = lineColor;
        }
        
        public void SetThickness(int lineThickness) {
            thickness = lineThickness;
        }
        
        #endregion
        
        public Line Clone() {
            return new Line {
                startPosition = startPosition,
                endPosition = endPosition,
                color = color,
                thickness = thickness
            };
        }
        
        public void DrawLine() {
            var start = new Point(startPosition[0], startPosition[1]);
            var end = new Point(endPosition[0], endPosition[1]);
            var lineColor = new Scalar(color[2], color[1], color[0]);
            
            Cv2.Line(_ehhmageOutput, start, end, lineColor, thickness);
        }
    }

    public class Circle {
        private int radius = 1;
        private int[] position = { 0, 0 };
        private int[] color = { 255, 255, 255 };
        private int thickness = 1;
        private int[] fillColor = { 255, 255, 255 };
        
        private bool doFill = false;
        
        #region Setters
        
        public void SetRadius(int circleRadius) {
            radius = circleRadius;
        }
        
        public void SetPosition(int[] circlePosition) {
            position = circlePosition;
        }
        
        public void SetColor(int[] circleColor) {
            color = circleColor;
        }
        
        public void SetThickness(int circleThickness) {
            thickness = circleThickness;
        }
        
        public void SetFillColor(int[] circleFillColor) {
            fillColor = circleFillColor;
        }
        
        public void SetDoFill(bool fillCircle) {
            doFill = fillCircle;
        }
        
        #endregion
        
        public Circle Clone() {
            return new Circle {
                radius = radius,
                position = position,
                color = color,
                thickness = thickness,
                fillColor = fillColor,
                doFill = doFill
            };
        }
        
        public void DrawCircle() {
            var circlePosition = new Point(position[0], position[1]);
            var circleColor = new Scalar(color[2], color[1], color[0]);
            var circleFillColor = new Scalar(fillColor[2], fillColor[1], fillColor[0]);
            
            if (doFill) Cv2.Circle(_ehhmageOutput, circlePosition, radius, circleFillColor, Cv2.FILLED);
            Cv2.Circle(_ehhmageOutput, circlePosition, radius, circleColor, thickness);
        }
        
    }

    public class PolyLines {
        private int[] color = { 255, 255, 255 };
        private int thickness = 1;
        private List<List<int>> positions = new();
        private int[] fillColor = { 255, 255, 255 };
        
        private bool doFill = false;
        
        #region Setters
        
        public void SetColor(int[] polyLinesColor) {
            color = polyLinesColor;
        }
        
        public void SetThickness(int polyLinesThickness) {
            thickness = polyLinesThickness;
        }
        
        public void SetPositions(int index, List<int> polyLinesPosition) {
            positions.Add(new List<int>());
            positions[index] = polyLinesPosition;
        }
        
        public void SetFillColor(int[] polyLinesFillColor) {
            fillColor = polyLinesFillColor;
        }
        
        public void SetDoFill(bool fillPolyLines) {
            doFill = fillPolyLines;
        }
        
        #endregion
        
        public PolyLines Clone() {
            return new PolyLines {
                color = color,
                thickness = thickness,
                positions = positions,
                fillColor = fillColor,
                doFill = doFill
            };
        }
        
        public void DrawPolyLines() {
            var polyLinesPositions = new Point[positions.Count];
            for (var i = 0; i < positions.Count; i++) {
                polyLinesPositions[i] = new Point(positions[i][0], positions[i][1]);
            }
            var polyLinesColor = new Scalar(color[2], color[1], color[0]);
            var polyLinesFillColor = new Scalar(fillColor[2], fillColor[1], fillColor[0]);
            
            if (doFill) Cv2.FillPoly(_ehhmageOutput, new[] { polyLinesPositions }, polyLinesFillColor);
            Cv2.Polylines(_ehhmageOutput, new[] { polyLinesPositions }, true, polyLinesColor, thickness);
        }
    }

    public class Ellipse {
        private int thickness = 1;
        private int[] position = { 0, 0 };
        private int[] color = { 255, 255, 255 };
        private int[] axes = { 1, 1 };
        private int angle = 0;
        private int startAngle = 0;
        private int endAngle = 360;
        private int[] fillColor = { 255, 255, 255 };
        
        private bool doFill = false;
        
        #region Setters
        
        public void SetThickness(int ellipseThickness) {
            thickness = ellipseThickness;
        }
        
        public void SetPosition(int[] ellipsePosition) {
            position = ellipsePosition;
        }
        
        public void SetColor(int[] ellipseColor) {
            color = ellipseColor;
        }
        
        public void SetAxes(int[] ellipseAxes) {
            axes = ellipseAxes;
        }
        
        public void SetAngle(int ellipseAngle) {
            angle = ellipseAngle;
        }
        
        public void SetStartAngle(int ellipseStartAngle) {
            startAngle = ellipseStartAngle;
        }
        
        public void SetEndAngle(int ellipseEndAngle) {
            endAngle = ellipseEndAngle;
        }
        
        public void SetFillColor(int[] ellipseFillColor) {
            fillColor = ellipseFillColor;
        }
        
        public void SetDoFill(bool fillEllipse) {
            doFill = fillEllipse;
        }
        
        #endregion
        
        public Ellipse Clone() {
            return new Ellipse {
                thickness = thickness,
                position = position,
                color = color,
                axes = axes,
                angle = angle,
                startAngle = startAngle,
                endAngle = endAngle,
                fillColor = fillColor,
                doFill = doFill
            };
        }
        
        public void DrawEllipse() {
            var ellipsePosition = new Point(position[0], position[1]);
            var ellipseColor = new Scalar(color[2], color[1], color[0]);
            var ellipseFillColor = new Scalar(fillColor[2], fillColor[1], fillColor[0]);
            
            if (doFill) Cv2.Ellipse(_ehhmageOutput, ellipsePosition, new Size(axes[0], axes[1]), angle, startAngle, endAngle, ellipseFillColor, Cv2.FILLED);
            Cv2.Ellipse(_ehhmageOutput, ellipsePosition, new Size(axes[0], axes[1]), angle, startAngle, endAngle, ellipseColor, thickness);
        }
    }

    public static class Global {
        internal static Text Text = new();
        internal static Rectangle Rectangle = new();
        internal static Line Line = new();
        internal static Circle Circle = new();
        internal static PolyLines PolyLines = new();
        internal static Ellipse Ellipse = new();
    }

}