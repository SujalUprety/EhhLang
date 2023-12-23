using Ehhmake.Content;

namespace Ehhmake;

public class EhhVisitor : EhhBaseVisitor<object?> {

    public override object? VisitStart(EhhParser.StartContext context) {
        if (context.LB().GetText() != "{") {
            Console.WriteLine("Curly braces not found in \'ehh\' function");
            return base.VisitStart(context);
        }
        
        if (context.RB().GetText() != "}") {
            Console.WriteLine("Closing bracket not found in \'ehh\' function");
            return base.VisitStart(context);
        }

        return base.VisitStart(context);
    }
    
}