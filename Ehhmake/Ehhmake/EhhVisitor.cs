using Ehhmake.Content;
using OpenCvSharp;

namespace Ehhmake;

public class EhhVisitor : EhhBaseVisitor<object?> {

    public override object? VisitStart(EhhParser.StartContext context) {
        if (context.LB().GetText() != "{") {
            Console.WriteLine("Curly braces not found in \'ehh\' method");
            return base.VisitStart(context);
        }
        
        if (context.RB().GetText() != "}") {
            Console.WriteLine("Closing bracket not found in \'ehh\' method");
            return base.VisitStart(context);
        }
        
        var width = int.Parse(context.widthValue().GetText());
        var height = int.Parse(context.heightValue().GetText());

        var color = context.colorValue().GetText().Split(',');
        var rgb = Array.ConvertAll(color, int.Parse);
        
        
        const string outputDirectory = @"G:\Projects\My Rule\Ehhmake\Ehhmake\Ehhmake\Content\";
        var outputName = outputDirectory + context.outputValue().GetText();
        
        //Creating Image
        var image = new Mat(height, width, MatType.CV_8UC3, new Scalar(rgb[2], rgb[1], rgb[0]));
        Cv2.ImWrite(outputName, image);

        Console.WriteLine($"{outputName} is created");
        

        return base.VisitStart(context);
    }
    
}