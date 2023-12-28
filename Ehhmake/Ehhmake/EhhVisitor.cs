using Ehhmake.Content;
using static System.Enum;

namespace Ehhmake;

public class EhhVisitor : EhhBaseVisitor<object?> {
    
    private enum FunctionName {
        ehh,
        tehhxt = 1,
        rehhct = 2,
        text = 1,
        rect = 2
    }
    
    private readonly EhhmageComplete _ehhmageComplete = new();

    public override object? VisitProgram(EhhParser.ProgramContext context) {
        
        if (context.function()[0].functionIdentifier().preFunctionName().GetText() != "ehh") {
            Console.WriteLine("Main function Ehh not found");
            return base.VisitProgram(context);
        }

        foreach (var function in context.function()) {
            var preDefinedFunctionName = function.functionIdentifier().preFunctionName().GetText();
            var functionName = string.Empty;
            var functionContext = function.attribPair();

            #region CurlyBracesCheck
            
            if (function.LB().GetText() != "{") {
                Console.WriteLine($"Curly braces not found in \'{functionName}\' function");
                return base.VisitProgram(context);
            }
            
            if (function.RB().GetText() != "}") {
                Console.WriteLine($"Closing bracket not found in \'{functionName}\' function");
                return base.VisitProgram(context);
            }
            
            #endregion
            
            if(preDefinedFunctionName != "ehh")
                functionName = function.functionIdentifier().functionName().GetText();

            if(TryParse(preDefinedFunctionName, out FunctionName functionNameEnum)) {
                switch (functionNameEnum) {
                    case FunctionName.ehh:
                        InitializeFunctionEhh(functionContext);
                        break;

                    case FunctionName.tehhxt:
                        InsertText(functionContext, functionName);
                        break;

                    case FunctionName.rehhct:
                        DrawRect(functionContext, functionName);
                        break;

                    default:
                        Console.WriteLine($"Function \'{functionName}\' not identified");
                        break;
                }
            }
            else Console.WriteLine($"Function \'{functionName}\' not identified");
        }
        
        _ehhmageComplete.ehhmage.CreateImage();
        
        return base.VisitProgram(context);
    }

    private void InitializeFunctionEhh(IEnumerable<EhhParser.AttribPairContext> context) {
        
        foreach (var attribPairContext in context) {
            var attribName = attribPairContext.ID().GetText();
            var attribValue = attribPairContext.attribValue().GetText();
        
            switch (attribName) {
                case nameof(EhhmageComplete.EhhmageAttribute.width): {
                    if (!int.TryParse(attribValue, out var width)) {
                        Console.WriteLine("Width attribute value is not a number");
                        break;
                    }
                    _ehhmageComplete.ehhmage.SetWidth(width);
                    break;
                }
        
                case nameof(EhhmageComplete.EhhmageAttribute.height): {
                    if (!int.TryParse(attribValue, out var height)) {
                        Console.WriteLine("Height attribute value is not a number");
                        break;
                    }
                    _ehhmageComplete.ehhmage.SetHeight(height);
                    break;
                }
        
                case nameof(EhhmageComplete.EhhmageAttribute.background): {
                    var background = attribValue.Split(',').Select(int.Parse).ToArray();
                    if (background.Length != 3) {
                        Console.WriteLine("Background attribute value is not a 3-tuple");
                        break;
                    }
                    _ehhmageComplete.ehhmage.SetBackground(background);
                    
                    break;
                }
                
                case nameof(EhhmageComplete.EhhmageAttribute.output): {
                    _ehhmageComplete.ehhmage.SetOutputName(attribValue);
                    break;
                }
                
                default:
                    Console.WriteLine($"{attribName} is not defined");
                    break;
            }
        }
        
        _ehhmageComplete.ehhmage.InitializeEhhMage();
        
    }

    private void InsertText(IEnumerable<EhhParser.AttribPairContext> context, string functionName) {

        var text = new EhhmageComplete.Text();
        
        foreach (var attribPairContext in context) {
            var attribName = attribPairContext.ID().GetText();
            var attribValue = attribPairContext.attribValue().GetText();

            switch (attribName) {
                case nameof(EhhmageComplete.TextAttribute.fontScale): {
                    if (!int.TryParse(attribValue, out var fontScale)) {
                        Console.WriteLine("FontScale attribute value is not a number");
                        break;
                    }
                    text.SetFontScale(fontScale);
                    break;
                }
                
                case nameof(EhhmageComplete.TextAttribute.thickness): {
                    if (!int.TryParse(attribValue, out var thickness)) {
                        Console.WriteLine("Thickness attribute value is not a number");
                        break;
                    }
                    text.SetThickness(thickness);
                    break;
                }
                
                case nameof(EhhmageComplete.TextAttribute.position): {
                    var textPosition = attribValue.Split(',').Select(int.Parse).ToArray();
                    if (textPosition.Length != 2) {
                        Console.WriteLine("TextPosition attribute value is not a 2-tuple");
                        break;
                    }
                    text.SetPosition(textPosition);
                    break;
                }
                
                case nameof(EhhmageComplete.TextAttribute.color): {
                    var textColor = attribValue.Split(',').Select(int.Parse).ToArray();
                    if (textColor.Length != 3) {
                        Console.WriteLine("TextColor attribute value is not a 3-tuple");
                        break;
                    }
                    text.SetColor(textColor);
                    break;
                }
                
                case nameof(EhhmageComplete.TextAttribute.text): {
                    if(attribValue.StartsWith('"') && attribValue.EndsWith('"')) {
                        text.SetText(attribValue[1..^1]);
                    } else {
                        Console.WriteLine("Text attribute value is not a string");
                    }
                    break;
                }
                
                default:
                    Console.WriteLine($"{attribName} is not defined");
                    break;
            }
            
        }
        
        text.InsertText();
        _ehhmageComplete.FunctionNames.Add(functionName, text);
    }

    private void DrawRect(IEnumerable<EhhParser.AttribPairContext> context, string functionName) {

        var rectangle = new EhhmageComplete.Rectangle();
        
        foreach (var attribPairContext in context) {
            var attribName = attribPairContext.ID().GetText();
            var attribValue = attribPairContext.attribValue().GetText();

            switch (attribName) {
                case nameof(EhhmageComplete.RectangleAttribute.thickness): {
                    if (!int.TryParse(attribValue, out var thickness)) {
                        Console.WriteLine("Thickness attribute value is not a number");
                        break;
                    }
                    rectangle.SetThickness(thickness);
                    break;
                }
                
                case nameof(EhhmageComplete.RectangleAttribute.position): {
                    var rectPosition = attribValue.Split(',').Select(int.Parse).ToArray();
                    if (rectPosition.Length != 2) {
                        Console.WriteLine("RectPosition attribute value is not a 2-tuple");
                        break;
                    }
                    rectangle.SetPosition(rectPosition);
                    break;
                }
                
                case nameof(EhhmageComplete.RectangleAttribute.color): {
                    var rectColor = attribValue.Split(',').Select(int.Parse).ToArray();
                    if (rectColor.Length != 3) {
                        Console.WriteLine("RectColor attribute value is not a 3-tuple");
                        break;
                    }
                    rectangle.SetColor(rectColor);
                    break;
                }
                
                case nameof(EhhmageComplete.RectangleAttribute.width): {
                    if (!int.TryParse(attribValue, out var rectWidth)) {
                        Console.WriteLine("RectWidth attribute value is not a number");
                        break;
                    }
                    rectangle.SetWidth(rectWidth);
                    break;
                }
                
                case nameof(EhhmageComplete.RectangleAttribute.height): {
                    if (!int.TryParse(attribValue, out var rectHeight)) {
                        Console.WriteLine("RectHeight attribute value is not a number");
                        break;
                    }
                    rectangle.SetHeight(rectHeight);
                    break;
                }
                
                case nameof(EhhmageComplete.RectangleAttribute.fillColor): {
                    var fillColor = attribValue.Split(',').Select(int.Parse).ToArray();
                    if (fillColor.Length != 3) {
                        Console.WriteLine("FillColor attribute value is not a 3-tuple");
                        break;
                    }
                    rectangle.SetDoFill(true);
                    rectangle.SetFillColor(fillColor);
                    break;
                }
                
                default:
                    Console.WriteLine($"{attribName} is not defined");
                    break;
            }
        }
        rectangle.DrawRectangle();
        _ehhmageComplete.FunctionNames.Add(functionName, rectangle);
    }
    
}