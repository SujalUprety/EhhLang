using System.ComponentModel;
using Ehhmake.Content;

namespace Ehhmake;

public class EhhVisitor : EhhBaseVisitor<object?> {
    
    private enum FunctionName {
        ehh,
        tehhxt,
        rehhct
    }
    
    private readonly Ehhmage _ehhmage = new();

    public override object? VisitProgram(EhhParser.ProgramContext context) {
        
        if (context.function()[0].ID().GetText() != "ehh") {
            Console.WriteLine("Main function Ehh not found");
            return base.VisitProgram(context);
        }

        foreach (var function in context.function()) {
            var functionName = function.ID().GetText();
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

            switch (functionName) {
                case nameof(FunctionName.ehh):
                    InitializeFunctionEhh(functionContext);
                    break;
                
                case nameof(FunctionName.tehhxt):
                    InsertText(functionContext);
                    break;
                
                case nameof(FunctionName.rehhct):
                    DrawRect(functionContext);
                    break;
                
                default:
                    Console.WriteLine($"Function \'{functionName}\' not defined");
                    break;
            }
        }
        
        _ehhmage.CreateImage();
        
        return base.VisitProgram(context);
    }

    private void InitializeFunctionEhh(IEnumerable<EhhParser.AttribPairContext> context) {
        
        foreach (var attribPairContext in context) {
            var attribName = attribPairContext.ID().GetText();
            var attribValue = attribPairContext.attribValue().GetText();
        
            switch (attribName) {
                case nameof(Ehhmage.EhhmageAttribute.width): {
                    if (!int.TryParse(attribValue, out var width)) {
                        Console.WriteLine("Width attribute value is not a number");
                        break;
                    }
                    _ehhmage.SetWidth(width);
                    break;
                }
        
                case nameof(Ehhmage.EhhmageAttribute.height): {
                    if (!int.TryParse(attribValue, out var height)) {
                        Console.WriteLine("Height attribute value is not a number");
                        break;
                    }
                    _ehhmage.SetHeight(height);
                    break;
                }
        
                case nameof(Ehhmage.EhhmageAttribute.background): {
                    var background = attribValue.Split(',').Select(int.Parse).ToArray();
                    if (background.Length != 3) {
                        Console.WriteLine("Background attribute value is not a 3-tuple");
                        break;
                    }
                    _ehhmage.SetBackground(background);
                    
                    break;
                }
                
                case nameof(Ehhmage.EhhmageAttribute.output): {
                    _ehhmage.SetOutputName(attribValue);
                    break;
                }
                    
            }
        }
        
        _ehhmage.InitializeEhhMage();
        
    }

    private void InsertText(IEnumerable<EhhParser.AttribPairContext> context) {
        
        foreach (var attribPairContext in context) {
            var attribName = attribPairContext.ID().GetText();
            var attribValue = attribPairContext.attribValue().GetText();

            switch (attribName) {
                case nameof(Ehhmage.TextAttribute.fontScale): {
                    if (!int.TryParse(attribValue, out var fontScale)) {
                        Console.WriteLine("FontScale attribute value is not a number");
                        break;
                    }
                    _ehhmage.SetFontScale(fontScale);
                    break;
                }
                
                case nameof(Ehhmage.TextAttribute.thickness): {
                    if (!int.TryParse(attribValue, out var thickness)) {
                        Console.WriteLine("Thickness attribute value is not a number");
                        break;
                    }
                    _ehhmage.SetThickness(thickness);
                    break;
                }
                
                case nameof(Ehhmage.TextAttribute.textPosition): {
                    var textPosition = attribValue.Split(',').Select(int.Parse).ToArray();
                    if (textPosition.Length != 2) {
                        Console.WriteLine("TextPosition attribute value is not a 2-tuple");
                        break;
                    }
                    _ehhmage.SetTextPosition(textPosition);
                    break;
                }
                
                case nameof(Ehhmage.TextAttribute.textColor): {
                    var textColor = attribValue.Split(',').Select(int.Parse).ToArray();
                    if (textColor.Length != 3) {
                        Console.WriteLine("TextColor attribute value is not a 3-tuple");
                        break;
                    }
                    _ehhmage.SetTextColor(textColor);
                    break;
                }
                
                case nameof(Ehhmage.TextAttribute.text): {
                    if(attribValue.StartsWith('"') && attribValue.EndsWith('"')) {
                        _ehhmage.SetText(attribValue[1..^1]);
                    } else {
                        Console.WriteLine("Text attribute value is not a string");
                    }
                    break;
                }
            }
            
        }
        
        _ehhmage.InsertText();
    }

    private void DrawRect(IEnumerable<EhhParser.AttribPairContext> context) {
        foreach (var attribPairContext in context) {
            var attribName = attribPairContext.ID().GetText();
            var attribValue = attribPairContext.attribValue().GetText();

            switch (attribName) {
                case nameof(Ehhmage.RectangleAttribute.thickness): {
                    if (!int.TryParse(attribValue, out var thickness)) {
                        Console.WriteLine("Thickness attribute value is not a number");
                        break;
                    }
                    _ehhmage.SetRectangleThickness(thickness);
                    break;
                }
                
                case nameof(Ehhmage.RectangleAttribute.rectanglePosition): {
                    var rectPosition = attribValue.Split(',').Select(int.Parse).ToArray();
                    if (rectPosition.Length != 2) {
                        Console.WriteLine("RectPosition attribute value is not a 2-tuple");
                        break;
                    }
                    _ehhmage.SetRectanglePosition(rectPosition);
                    break;
                }
                
                case nameof(Ehhmage.RectangleAttribute.rectangleColor): {
                    var rectColor = attribValue.Split(',').Select(int.Parse).ToArray();
                    if (rectColor.Length != 3) {
                        Console.WriteLine("RectColor attribute value is not a 3-tuple");
                        break;
                    }
                    _ehhmage.SetRectangleColor(rectColor);
                    break;
                }
                
                case nameof(Ehhmage.RectangleAttribute.width): {
                    if (!int.TryParse(attribValue, out var rectWidth)) {
                        Console.WriteLine("RectWidth attribute value is not a number");
                        break;
                    }
                    _ehhmage.SetRectangleWidth(rectWidth);
                    break;
                }
                
                case nameof(Ehhmage.RectangleAttribute.height): {
                    if (!int.TryParse(attribValue, out var rectHeight)) {
                        Console.WriteLine("RectHeight attribute value is not a number");
                        break;
                    }
                    _ehhmage.SetRectangleHeight(rectHeight);
                    break;
                }
                
                case nameof(Ehhmage.RectangleAttribute.fillColor): {
                    var fillColor = attribValue.Split(',').Select(int.Parse).ToArray();
                    if (fillColor.Length != 3) {
                        Console.WriteLine("FillColor attribute value is not a 3-tuple");
                        break;
                    }
                    _ehhmage.SetFillRectangle(true);
                    _ehhmage.SetRectangleFillColor(fillColor);
                    break;
                }
                
            }
        }
        _ehhmage.DrawRectangle();
    }
    
}