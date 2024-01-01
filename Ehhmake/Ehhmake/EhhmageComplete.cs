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

    private static Mat _ehhmageOutput = new();
    public static readonly Dictionary<string, object?> FunctionNames = new();
    

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
            // Cv2.ImShow(@"G:\Projects\My Rule\Ehhmake\Ehhmake\Ehhmake\Content\TestPrograms"+_outputName, _ehhmageOutput);
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
            Cv2.PutText(_ehhmageOutput, _text, new Point(_position[0], _position[1]), 
                HersheyFonts.HersheyPlain, _fontScale, new Scalar(_color[2], _color[1], _color[0]), _thickness);
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
        
            if (_doFill) {
                Cv2.Rectangle(_ehhmageOutput, rect, fillColor, Cv2.FILLED);
                _doFill = false;
            }
        
            Cv2.Rectangle(_ehhmageOutput, rect, rectColor, _thickness);
        }
        
    }

    public static class Global {
        internal static Text Text = new();
        internal static Rectangle Rectangle = new();
    }

}