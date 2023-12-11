using OpenCvSharp;
using Ehhmake.GrammarContent;

namespace Ehhmake;

public class EhhVisitor : EhhBaseVisitor<int> {

    public override int VisitStart(EhhParser.StartContext context) {
        var width = int.Parse(context.widthValue().GetText());
        var height = int.Parse(context.heightValue().GetText());

        var color = context.colorValue().GetText().Split(',');
        var rgb = Array.ConvertAll(color, int.Parse);

        var outputName = context.outputValue().GetText();
        
        //Creating Image
        var image = new Mat(height, width, MatType.CV_8UC3, new Scalar(rgb[2], rgb[1], rgb[0]));
        Cv2.ImWrite(outputName, image);

        Console.WriteLine($"{outputName} is created");
        

        return base.VisitStart(context);
    }
    
}