using Ehhmake.Content;

namespace Ehhmake;

public class EhhVisitor : EhhBaseVisitor<object?> {
    
    private readonly Ehhmage _ehhmage = new();

    public override object? VisitStart(EhhParser.StartContext context) {
        if (context.LB().GetText() != "{") {
            Console.WriteLine("Curly braces not found in \'ehh\' function");
            return base.VisitStart(context);
        }
        
        if (context.RB().GetText() != "}") {
            Console.WriteLine("Closing bracket not found in \'ehh\' function");
            return base.VisitStart(context);
        }

        foreach (var attribPairContext in context.attribPair()) {
            var attribName = attribPairContext.ID().GetText();
            var attribValue = attribPairContext.attribValue().GetText();

            switch (attribName) {
                case nameof(Ehhmage.Attribute.width): {
                    if (!int.TryParse(attribValue, out var width)) {
                        Console.WriteLine("Width attribute value is not a number");
                        break;
                    }
                    _ehhmage.SetWidth(width);
                    break;
                }

                case nameof(Ehhmage.Attribute.height): {
                    if (!int.TryParse(attribValue, out var height)) {
                        Console.WriteLine("Height attribute value is not a number");
                        break;
                    }
                    _ehhmage.SetHeight(height);
                    break;
                }

                case nameof(Ehhmage.Attribute.background): {
                    var background = attribValue.Split(',').Select(int.Parse).ToArray();
                    if (background.Length != 3) {
                        Console.WriteLine("Background attribute value is not a 3-tuple");
                        break;
                    }
                    _ehhmage.SetBackground(background);
                    
                    break;
                }
                
                case nameof(Ehhmage.Attribute.output): {
                    _ehhmage.SetOutputName(attribValue);
                    break;
                }
                    
            }
        }
        
        _ehhmage.CreateImage();
        
        return base.VisitStart(context);
    }
    
}