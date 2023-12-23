using OpenCvSharp;

namespace Ehhmake;

public class Ehhmage {
    
    public enum Attribute {
        width,
        height,
        background,
        output
    }
    
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

    public void CreateImage() {
        var ehhmage = new Mat(_height, _width, MatType.CV_8UC3, new Scalar(_background[2], _background[1], _background[0]));
        Cv2.ImWrite(_outputName, ehhmage);
    }
    
}