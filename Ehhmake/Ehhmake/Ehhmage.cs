using OpenCvSharp;

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
    
    private int fontScale = 1;
    private int thickness = 1;
    private int[] textPosition = { 0, 0 };
    private int[] textColor = { 255, 255, 255 };
    private string text = "Tehhxt";

    #region Setters

    public void SetFontScale(int fontScale) {
        this.fontScale = fontScale;
    }
    
    public void SetThickness(int thickness) {
        this.thickness = thickness;
    }
    
    public void SetTextPosition(int[] textPosition) {
        this.textPosition = textPosition;
    }
    
    public void SetTextColor(int[] textColor) {
        this.textColor = textColor;
    }
    
    public void SetText(string text) {
        this.text = text;
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
        Cv2.PutText(_ehhmage, text, new Point(textPosition[0], textPosition[1]), 
            HersheyFonts.HersheyPlain, fontScale, new Scalar(textColor[2], textColor[1], textColor[0]), thickness);
    }
    
}