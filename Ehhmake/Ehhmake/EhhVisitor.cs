using Ehhmake.Content;
using static System.Enum;

namespace Ehhmake;

public class EhhVisitor : EhhBaseVisitor<object?> {
    
    private enum ObjectName {
        ehh,
        tehhxt = 1,
        rehhct = 2,
        linehh = 3,
        circlehh = 4,
        polyLinehhs = 5,
        ehhlipse = 6,
        text = 1,
        rect = 2,
        line = 3,
        circle = 4,
        polyLines = 5,
        ellipse = 6
    }

    public override object? VisitProgram(EhhParser.ProgramContext context) {
        
        var firstChild = context.GetChild(0);

        if (firstChild is not EhhParser.ObjectContext myObject) return base.VisitProgram(context);
        if (myObject.objectIdentifier().preObjectName().GetText() == "ehh") return base.VisitProgram(context);
        
        Console.WriteLine("Ehh object not defined at the top of the program");
        Environment.Exit(1);
        return base.VisitProgram(context);
    }

    public override object? VisitObject(EhhParser.ObjectContext context) {
        
        var preDefinedObjectName = context.objectIdentifier().preObjectName().GetText();
        var objectName = string.Empty;
        var objectContext = context.attribPair();

        #region CurlyBracesCheck
        
        if (context.LB().GetText() != "{") {
            Console.WriteLine($"Curly braces not found in \'{objectName}\' object");
            return base.VisitObject(context);
        }
        
        if (context.RB().GetText() != "}") {
            Console.WriteLine($"Closing bracket not found in \'{objectName}\' object");
            return base.VisitObject(context);
        }
        
        #endregion

        try {
            objectName = context.objectIdentifier().objectName().GetText();
            try {
                var storedObjectContext = EhhmageComplete.ObjectNames[preDefinedObjectName];
                switch (storedObjectContext) {
                    case EhhmageComplete.Text text:
                        InsertText(objectContext, objectName, text.Clone());
                        break;

                    case EhhmageComplete.Rectangle rectangle:
                        DrawRect(objectContext, objectName, rectangle.Clone());
                        break;
                    
                    case EhhmageComplete.Line line:
                        DrawLine(objectContext, objectName, line.Clone());
                        break;
                    
                    case EhhmageComplete.Circle circle:
                        DrawCircle(objectContext, objectName, circle.Clone());
                        break;
                    
                    case EhhmageComplete.PolyLines polyLines:
                        DrawPolyLines(objectContext, objectName, polyLines.Clone());
                        break;
                    
                    case EhhmageComplete.Ellipse ellipse:
                        DrawEllipse(objectContext, objectName, ellipse.Clone());
                        break;
                    
                    default:
                        Console.WriteLine($"Object \'{objectName}\' not identified");
                        break;
                }
            }
            catch{
                CompareLibraryDefinedObject(preDefinedObjectName, objectName, objectContext);
            }
        }
        catch {
            CompareLibraryDefinedObject(preDefinedObjectName, preDefinedObjectName, objectContext);
        }
        
        EhhmageComplete.Ehhmage.CreateImage();
        
        return base.VisitObject(context);
    }

    private static void CompareLibraryDefinedObject(string preDefinedObjectName, string objectName, IEnumerable<EhhParser.AttribPairContext> objectContext) {
        if(TryParse(preDefinedObjectName, out ObjectName objectNameEnum)) {
            switch (objectNameEnum) {
                case ObjectName.ehh:
                    InitializeObjectEhh(objectContext);
                    break;
                
                case ObjectName.tehhxt:
                    InsertText(objectContext, objectName);
                    break;
                
                case ObjectName.rehhct:
                    DrawRect(objectContext, objectName);
                    break;
                
                case ObjectName.linehh:
                    DrawLine(objectContext, objectName);
                    break;
                
                case ObjectName.circlehh:
                    DrawCircle(objectContext, objectName);
                    break;
                
                case ObjectName.polyLinehhs:
                    DrawPolyLines(objectContext, objectName);
                    break;
                
                case ObjectName.ehhlipse:
                    DrawEllipse(objectContext, objectName);
                    break;
                
                default:
                    Console.WriteLine($"Object \'{preDefinedObjectName}\' not identified");
                    break;
            }
        }
        else Console.WriteLine($"Object \'{preDefinedObjectName}\' not identified");
    }

    private static void InitializeObjectEhh(IEnumerable<EhhParser.AttribPairContext> context) {
        
        foreach (var attribPairContext in context) {
            var attribName = attribPairContext.ID().GetText();
            var attribValue = attribPairContext.attribValue().GetText();
        
            switch (attribName) {
                case nameof(EhhmageComplete.EhhmageAttribute.width): {
                    if (!int.TryParse(attribValue, out var width)) {
                        Console.WriteLine("Width attribute value is not a number");
                        break;
                    }
                    EhhmageComplete.Ehhmage.SetWidth(width);
                    break;
                }
        
                case nameof(EhhmageComplete.EhhmageAttribute.height): {
                    if (!int.TryParse(attribValue, out var height)) {
                        Console.WriteLine("Height attribute value is not a number");
                        break;
                    }
                    EhhmageComplete.Ehhmage.SetHeight(height);
                    break;
                }
        
                case nameof(EhhmageComplete.EhhmageAttribute.background): {
                    var background = attribValue.Split(',').Select(int.Parse).ToArray();
                    if (background.Length != 3) {
                        Console.WriteLine("Background attribute value is not a 3-tuple");
                        break;
                    }
                    EhhmageComplete.Ehhmage.SetBackground(background);
                    
                    break;
                }
                
                case nameof(EhhmageComplete.EhhmageAttribute.output): {
                    EhhmageComplete.Ehhmage.SetOutputName(attribValue);
                    break;
                }
                
                default:
                    Console.WriteLine($"{attribName} is not defined");
                    break;
            }
        }
        
        EhhmageComplete.Ehhmage.InitializeEhhMage();
        
    }

    private static void InsertText(IEnumerable<EhhParser.AttribPairContext> context, string objectName, EhhmageComplete.Text? text = null) {
        
        text ??= EhhmageComplete.Global.Text.Clone();
        
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
        if(!objectName.Equals(string.Empty)) EhhmageComplete.ObjectNames.Add(objectName, text);
        else EhhmageComplete.Global.Text = text.Clone();
        
    }

    private static void DrawRect(IEnumerable<EhhParser.AttribPairContext> context, string objectName, EhhmageComplete.Rectangle? rectangle = null) {
        
        rectangle ??= EhhmageComplete.Global.Rectangle.Clone();
        
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
                    if (attribValue == "no") {
                        rectangle.SetDoFill(false);
                        break;
                    }
                    
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
        if(!objectName.Equals(string.Empty))   EhhmageComplete.ObjectNames.Add(objectName, rectangle);
        else EhhmageComplete.Global.Rectangle = rectangle.Clone();
    }

    private static void DrawLine(IEnumerable<EhhParser.AttribPairContext> context, string objectName, EhhmageComplete.Line? line = null) {
        
        line ??= EhhmageComplete.Global.Line.Clone();
        
        foreach (var attribPairContext in context) {
            var attribName = attribPairContext.ID().GetText();
            var attribValue = attribPairContext.attribValue().GetText();

            switch (attribName) {
                case nameof(EhhmageComplete.LineAttribute.thickness): {
                    if (!int.TryParse(attribValue, out var thickness)) {
                        Console.WriteLine("Thickness attribute value is not a number");
                        break;
                    }
                    line.SetThickness(thickness);
                    break;
                }
                
                case nameof(EhhmageComplete.LineAttribute.startPosition): {
                    var lineStart = attribValue.Split(',').Select(int.Parse).ToArray();
                    if (lineStart.Length != 2) {
                        Console.WriteLine("LineStart attribute value is not a 2-tuple");
                        break;
                    }
                    line.SetStartPosition(lineStart);
                    break;
                }
                
                case nameof(EhhmageComplete.LineAttribute.endPosition): {
                    var lineEnd = attribValue.Split(',').Select(int.Parse).ToArray();
                    if (lineEnd.Length != 2) {
                        Console.WriteLine("LineEnd attribute value is not a 2-tuple");
                        break;
                    }
                    line.SetEndPosition(lineEnd);
                    break;
                }
                
                case nameof(EhhmageComplete.LineAttribute.color): {
                    var lineColor = attribValue.Split(',').Select(int.Parse).ToArray();
                    if (lineColor.Length != 3) {
                        Console.WriteLine("LineColor attribute value is not a 3-tuple");
                        break;
                    }
                    line.SetColor(lineColor);
                    break;
                }
                
                default:
                    Console.WriteLine($"{attribName} is not defined");
                    break;
            }
        }
        
        line.DrawLine();
        if(!objectName.Equals(string.Empty)) EhhmageComplete.ObjectNames.Add(objectName, line);
        else EhhmageComplete.Global.Line = line.Clone();
        
    }

    private static void DrawCircle(IEnumerable<EhhParser.AttribPairContext> context, string objectName, EhhmageComplete.Circle? circle = null) {
        
        circle ??= EhhmageComplete.Global.Circle.Clone();
        
        foreach (var attribPairContext in context) {
            var attribName = attribPairContext.ID().GetText();
            var attribValue = attribPairContext.attribValue().GetText();

            switch (attribName) {
                case nameof(EhhmageComplete.CircleAttribute.thickness): {
                    if (!int.TryParse(attribValue, out var thickness)) {
                        Console.WriteLine("Thickness attribute value is not a number");
                        break;
                    }
                    circle.SetThickness(thickness);
                    break;
                }
                
                case nameof(EhhmageComplete.CircleAttribute.position): {
                    var circlePosition = attribValue.Split(',').Select(int.Parse).ToArray();
                    if (circlePosition.Length != 2) {
                        Console.WriteLine("CirclePosition attribute value is not a 2-tuple");
                        break;
                    }
                    circle.SetPosition(circlePosition);
                    break;
                }
                
                case nameof(EhhmageComplete.CircleAttribute.color): {
                    var circleColor = attribValue.Split(',').Select(int.Parse).ToArray();
                    if (circleColor.Length != 3) {
                        Console.WriteLine("CircleColor attribute value is not a 3-tuple");
                        break;
                    }
                    circle.SetColor(circleColor);
                    break;
                }
                
                case nameof(EhhmageComplete.CircleAttribute.radius): {
                    if (!int.TryParse(attribValue, out var circleRadius)) {
                        Console.WriteLine("CircleRadius attribute value is not a number");
                        break;
                    }
                    circle.SetRadius(circleRadius);
                    break;
                }
                
                case nameof(EhhmageComplete.CircleAttribute.fillColor): {
                    if (attribValue == "no") {
                        circle.SetDoFill(false);
                        break;
                    }
                    
                    var fillColor = attribValue.Split(',').Select(int.Parse).ToArray();
                    if (fillColor.Length != 3) {
                        Console.WriteLine("FillColor attribute value is not a 3-tuple");
                        break;
                    }
                    circle.SetDoFill(true);
                    circle.SetFillColor(fillColor);
                    break;
                }
                
                default:
                    Console.WriteLine($"{attribName} is not defined");
                    break;
            }
        }
        
        circle.DrawCircle();
        if(!objectName.Equals(string.Empty)) EhhmageComplete.ObjectNames.Add(objectName, circle);
        else EhhmageComplete.Global.Circle = circle.Clone();
        
    }

    private static void DrawPolyLines(IEnumerable<EhhParser.AttribPairContext> context, string objectName, EhhmageComplete.PolyLines? polyLines = null) {
        
        polyLines ??= EhhmageComplete.Global.PolyLines.Clone();
        
        foreach (var attribPairContext in context) {
            var attribName = attribPairContext.ID().GetText();
            var attribValue = attribPairContext.attribValue().GetText();

            switch (attribName) {
                case nameof(EhhmageComplete.PolyLinesAttribute.thickness): {
                    if (!int.TryParse(attribValue, out var thickness)) {
                        Console.WriteLine("Thickness attribute value is not a number");
                        break;
                    }
                    polyLines.SetThickness(thickness);
                    break;
                }
                
                case nameof(EhhmageComplete.PolyLinesAttribute.color): {
                    var polyLinesColor = attribValue.Split(',').Select(int.Parse).ToArray();
                    if (polyLinesColor.Length != 3) {
                        Console.WriteLine("PolyLinesColor attribute value is not a 3-tuple");
                        break;
                    }
                    polyLines.SetColor(polyLinesColor);
                    break;
                }
                
                case nameof(EhhmageComplete.PolyLinesAttribute.position): {
                    if (!int.TryParse(attribPairContext.INT()?.GetText(), out var polyLinesPositionIndex)) {
                        Console.WriteLine("PolyLinesPosition Index not mentioned");
                        break;
                    }
                    var polyLinesPosition = attribValue.Split(',').Select(int.Parse).ToList();
                    if (polyLinesPosition.Count != 2) {
                        Console.WriteLine("PolyLinesPosition attribute value is not a 2-tuple");
                        break;
                    }
                    polyLines.SetPositions(polyLinesPositionIndex, polyLinesPosition);
                    break;
                }

                case nameof(EhhmageComplete.PolyLinesAttribute.fillColor): {
                    if (attribValue == "no") {
                        polyLines.SetDoFill(false);
                        break;
                    }
                    
                    var fillColor = attribValue.Split(',').Select(int.Parse).ToArray();
                    if (fillColor.Length != 3) {
                        Console.WriteLine("FillColor attribute value is not a 3-tuple");
                        break;
                    }
                    polyLines.SetDoFill(true);
                    polyLines.SetFillColor(fillColor);
                    break;
                }
                
                default:
                    Console.WriteLine($"{attribName} is not defined");
                    break;
            }
        }
        
        polyLines.DrawPolyLines();
        if(!objectName.Equals(string.Empty)) EhhmageComplete.ObjectNames.Add(objectName, polyLines);
        else EhhmageComplete.Global.PolyLines = polyLines.Clone();
    }

    private static void DrawEllipse(IEnumerable<EhhParser.AttribPairContext> contexts, string objectName, EhhmageComplete.Ellipse? ellipse = null) {
        
        ellipse ??= EhhmageComplete.Global.Ellipse.Clone();
        
        foreach (var attribPairContext in contexts) {
            var attribName = attribPairContext.ID().GetText();
            var attribValue = attribPairContext.attribValue().GetText();

            switch (attribName) {
                case nameof(EhhmageComplete.EllipseAttribute.thickness): {
                    if (!int.TryParse(attribValue, out var thickness)) {
                        Console.WriteLine("Thickness attribute value is not a number");
                        break;
                    }
                    ellipse.SetThickness(thickness);
                    break;
                }
                
                case nameof(EhhmageComplete.EllipseAttribute.position): {
                    var ellipsePosition = attribValue.Split(',').Select(int.Parse).ToArray();
                    if (ellipsePosition.Length != 2) {
                        Console.WriteLine("EllipsePosition attribute value is not a 2-tuple");
                        break;
                    }
                    ellipse.SetPosition(ellipsePosition);
                    break;
                }
                
                case nameof(EhhmageComplete.EllipseAttribute.color): {
                    var ellipseColor = attribValue.Split(',').Select(int.Parse).ToArray();
                    if (ellipseColor.Length != 3) {
                        Console.WriteLine("EllipseColor attribute value is not a 3-tuple");
                        break;
                    }
                    ellipse.SetColor(ellipseColor);
                    break;
                }
                
                case nameof(EhhmageComplete.EllipseAttribute.axes): {
                    var ellipseAxes = attribValue.Split(',').Select(int.Parse).ToArray();
                    if (ellipseAxes.Length != 2) {
                        Console.WriteLine("EllipseAxes attribute value is not a 2-tuple");
                        break;
                    }
                    ellipse.SetAxes(ellipseAxes);
                    break;
                }
                
                case nameof(EhhmageComplete.EllipseAttribute.angle): {
                    if (!int.TryParse(attribValue, out var ellipseAngle)) {
                        Console.WriteLine("EllipseAngle attribute value is not a number");
                        break;
                    }
                    ellipse.SetAngle(ellipseAngle);
                    break;
                }

                case nameof(EhhmageComplete.EllipseAttribute.startAngle): {
                    if (!int.TryParse(attribValue, out var ellipseStartAngle)) {
                        Console.WriteLine("EllipseStartAngle attribute value is not a number");
                        break;
                    }
                    ellipse.SetStartAngle(ellipseStartAngle);
                    break;
                }
                
                case nameof(EhhmageComplete.EllipseAttribute.endAngle): {
                    if (!int.TryParse(attribValue, out var ellipseEndAngle)) {
                        Console.WriteLine("EllipseEndAngle attribute value is not a number");
                        break;
                    }
                    ellipse.SetEndAngle(ellipseEndAngle);
                    break;
                }
                
                case nameof(EhhmageComplete.EllipseAttribute.fillColor): {
                    if (attribValue == "no") {
                        ellipse.SetDoFill(false);
                        break;
                    }
                    
                    var fillColor = attribValue.Split(',').Select(int.Parse).ToArray();
                    if (fillColor.Length != 3) {
                        Console.WriteLine("FillColor attribute value is not a 3-tuple");
                        break;
                    }
                    ellipse.SetDoFill(true);
                    ellipse.SetFillColor(fillColor);
                    break;
                }
                
                default:
                    Console.WriteLine($"{attribName} is not defined");
                    break;
            }
        }
        
        ellipse.DrawEllipse();
        
        if(!objectName.Equals(string.Empty)) EhhmageComplete.ObjectNames.Add(objectName, ellipse);
        else EhhmageComplete.Global.Ellipse = ellipse.Clone();
        
    }
    
}