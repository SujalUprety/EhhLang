using OpenCvSharp;
using Point = OpenCvSharp.Point;

namespace Ehhmake;

public class Ehhmage {
    
    public enum EhhmageAttribute {
        width,
        height,
        background,
        output
    }
    
    public enum TextAttribute {
        fontScale,
        thickness,
        textPosition,
        textColor,
        text
    }
    
    public enum RectangleAttribute {
        thickness,
        rectanglePosition,
        rectangleColor,
        width,
        height,
        fillColor
    }

    #region EhhmageAttributes
    
    private int _height  = 1080;
    private int _width  = 1920;
    private int[] _background  = { 0, 0, 0 };
    private string _outputName  = "ehhmage.png";
    
    #region Setters

    public void SetHeight(int height) {
        _height = height;
    }
    
    public void SetWidth(int width) {
        _width = width;
    }
    
    public void SetBackground(int[] background) {
        _background = background;
    }
    
    public void SetOutputName(string outputName) {
        _outputName = outputName;
    }

    #endregion
    
    #endregion

    #region TextAttributes
    
    private int _fontScale = 1;
    private int _thickness = 1;
    private int[] _textPosition = { 0, 0 };
    private int[] _textColor = { 255, 255, 255 };
    private string _text = "Tehhxt";

    #region Setters

    public void SetFontScale(int fontScale) {
        _fontScale = fontScale;
    }
    
    public void SetThickness(int thickness) {
        _thickness = thickness;
    }
    
    public void SetTextPosition(int[] textPosition) {
        _textPosition = textPosition;
    }
    
    public void SetTextColor(int[] textColor) {
        _textColor = textColor;
    }
    
    public void SetText(string text) {
        _text = text;
    }

    #endregion

    #endregion
    
    #region RectangleAttributes
    
    private int _rectangleThickness = 1;
    private int[] _rectanglePosition = { 0, 0 };
    private int[] _rectangleColor = { 255, 255, 255 };
    private int _rectangleWidth = 100;
    private int _rectangleHeight = 100;
    private int[] _rectangleFillColor = { 255, 255, 255 };
    
    private bool _fillRectangle = false;
    
    #region Setters
    
    public void SetRectangleThickness(int rectangleThickness) {
        _rectangleThickness = rectangleThickness;
    }
    
    public void SetRectanglePosition(int[] rectanglePosition) {
        _rectanglePosition = rectanglePosition;
    }
    
    public void SetRectangleColor(int[] rectangleColor) {
        _rectangleColor = rectangleColor;
    }
    
    public void SetRectangleWidth(int rectangleWidth) {
        _rectangleWidth = rectangleWidth;
    }
    
    public void SetRectangleHeight(int rectangleHeight) {
        _rectangleHeight = rectangleHeight;
    }
    
    public void SetRectangleFillColor(int[] rectangleFillColor) {
        _rectangleFillColor = rectangleFillColor;
    }
    
    public void SetFillRectangle(bool fillRectangle) {
        _fillRectangle = fillRectangle;
    }

    #endregion
    
    #endregion
    
    private Mat _ehhmage = new();
    
    
    public void InitializeEhhMage() {
        _ehhmage = new Mat(_height, _width, MatType.CV_8UC3, new Scalar(_background[2], _background[1], _background[0]));
    }

    public void CreateImage() {
        Cv2.ImWrite(_outputName, _ehhmage);
        // Cv2.ImShow(@"G:\Projects\My Rule\Ehhmake\Ehhmake\Ehhmake\Content\"+_outputName, _ehhmage);
    }

    public void InsertText() {
        Cv2.PutText(_ehhmage, _text, new Point(_textPosition[0], _textPosition[1]), 
            HersheyFonts.HersheyPlain, _fontScale, new Scalar(_textColor[2], _textColor[1], _textColor[0]), _thickness);
    }

    public void DrawRectangle() {
        var rect = new Rect(_rectanglePosition[0], _rectanglePosition[1], _rectangleWidth, _rectangleHeight);
        var rectColor = new Scalar(_rectangleColor[2], _rectangleColor[1], _rectangleColor[0]);
        var fillColor = new Scalar(_rectangleFillColor[2], _rectangleFillColor[1], _rectangleFillColor[0]);
        
        if (_fillRectangle) {
            Cv2.Rectangle(_ehhmage, rect, fillColor, Cv2.FILLED);
            _fillRectangle = false;
        }
        
        Cv2.Rectangle(_ehhmage, rect, rectColor, _rectangleThickness);
    }
    
}