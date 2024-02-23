using System.Reflection;
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

        try {
            if (context.LB().GetText() != "{") {
                Console.WriteLine($"Curly braces not found in \'{preDefinedObjectName}\' object");
                return base.VisitObject(context);
            }

            if (context.RB().GetText() != "}") {
                Console.WriteLine($"Closing braces not found in \'{preDefinedObjectName}\' object");
                return base.VisitObject(context);
            }
        }
        catch {
            Console.WriteLine($"No braces found in \'{preDefinedObjectName}\' object. Error code: 0x00000000");
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
                        Console.WriteLine($"Object \'{objectName}\' not identified. Error code: 0x00000001");
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
                    Console.WriteLine($"Object \'{preDefinedObjectName}\' not identified. Error code: 0x00000002");
                    break;
            }
        }
        else Console.WriteLine($"Object \'{preDefinedObjectName}\' not identified. Error code: 0x00000003");
    }
    
    private static void InitializeObjectEhh(IEnumerable<EhhParser.AttribPairContext> context) {
        
        foreach (var attribPairContext in context) {
            var attribName = attribPairContext.attribName().GetText();
            var attribValue = attribPairContext.attribValue().GetText();
            
            var setterMethod = typeof(EhhmageComplete.Ehhmage).GetMethod("set" + attribName, BindingFlags.IgnoreCase | BindingFlags.Static | BindingFlags.Public);
            if (setterMethod is null)
                Console.WriteLine(attribName + " is not defined for object ehh");
            else {
                var value = AttributesSetters.GetAttributeValue("ehh", attribName, attribValue);
                setterMethod.Invoke(null, new [] {value});
            }
        }
        
        EhhmageComplete.Ehhmage.InitializeEhhMage();
        
    }

    private static void InsertText(IEnumerable<EhhParser.AttribPairContext> context, string objectName, EhhmageComplete.Text? text = null) {
        
        text ??= EhhmageComplete.Global.Text.Clone();
        
        foreach (var attribPairContext in context) {
            var attribName = attribPairContext.attribName().GetText();
            var attribValue = attribPairContext.attribValue().GetText();
            
            var setterMethod = text.GetType().GetMethod("set" + attribName, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);
            if (setterMethod is null)
                Console.WriteLine(attribName + " is not defined for object text");
            else {
                var value = AttributesSetters.GetAttributeValue(objectName, attribName, attribValue);
                setterMethod.Invoke(text, new [] {value});
            }
        }
        
        text.InsertText();
        if(!objectName.Equals(string.Empty)) EhhmageComplete.ObjectNames.Add(objectName, text);
        else EhhmageComplete.Global.Text = text.Clone();
        
    }

    private static void DrawRect(IEnumerable<EhhParser.AttribPairContext> context, string objectName, EhhmageComplete.Rectangle? rectangle = null) {
        
        rectangle ??= EhhmageComplete.Global.Rectangle.Clone();
        
        foreach (var attribPairContext in context) {
            var attribName = attribPairContext.attribName().GetText();
            var attribValue = attribPairContext.attribValue().GetText();
            
            var setterMethod = rectangle.GetType().GetMethod("set" + attribName, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);
            if (setterMethod is null)
                Console.WriteLine(attribName + " is not defined for object rectangle");
            else {
                var value = AttributesSetters.GetAttributeValue(objectName, attribName, attribValue);
                setterMethod.Invoke(rectangle, new [] {value});
            }
        }
        
        rectangle.DrawRectangle();
        if(!objectName.Equals(string.Empty))   EhhmageComplete.ObjectNames.Add(objectName, rectangle);
        else EhhmageComplete.Global.Rectangle = rectangle.Clone();
    }

    private static void DrawLine(IEnumerable<EhhParser.AttribPairContext> context, string objectName, EhhmageComplete.Line? line = null) {
        
        line ??= EhhmageComplete.Global.Line.Clone();
        
        foreach (var attribPairContext in context) {
            var attribName = attribPairContext.attribName().GetText();
            var attribValue = attribPairContext.attribValue().GetText();
            
            var setterMethod = line.GetType().GetMethod("set" + attribName, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);
            if (setterMethod is null)
                Console.WriteLine(attribName + " is not defined for object line");
            else {
                var value = AttributesSetters.GetAttributeValue(objectName, attribName, attribValue);
                setterMethod.Invoke(line, new [] {value});
            }
        }
        
        line.DrawLine();
        if(!objectName.Equals(string.Empty)) EhhmageComplete.ObjectNames.Add(objectName, line);
        else EhhmageComplete.Global.Line = line.Clone();
        
    }

    private static void DrawCircle(IEnumerable<EhhParser.AttribPairContext> context, string objectName, EhhmageComplete.Circle? circle = null) {
        
        circle ??= EhhmageComplete.Global.Circle.Clone();
        
        foreach (var attribPairContext in context) {
            var attribName = attribPairContext.attribName().GetText();
            var attribValue = attribPairContext.attribValue().GetText();
            
            var setterMethod = circle.GetType().GetMethod("set" + attribName, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);
            if (setterMethod is null)
                Console.WriteLine(attribName + " is not defined for object circle");
            else {
                var value = AttributesSetters.GetAttributeValue(objectName ,attribName, attribValue);
                setterMethod.Invoke(circle, new [] {value});
            }
        }
        
        circle.DrawCircle();
        if(!objectName.Equals(string.Empty)) EhhmageComplete.ObjectNames.Add(objectName, circle);
        else EhhmageComplete.Global.Circle = circle.Clone();
        
    }

    private static void DrawPolyLines(IEnumerable<EhhParser.AttribPairContext> context, string objectName, EhhmageComplete.PolyLines? polyLines = null) {
        
        polyLines ??= EhhmageComplete.Global.PolyLines.Clone();
        
        foreach (var attribPairContext in context) {
            var fullAttribName = attribPairContext.attribName().GetText();
            var attribName = attribPairContext.attribName().ID().GetText();
            var attribValue = attribPairContext.attribValue().GetText();
            
            var setterMethod = polyLines.GetType().GetMethod("set" + attribName, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);
            if (setterMethod is null)
                Console.WriteLine(attribName + " is not defined for object polyLines");
            else {
                var value = AttributesSetters.GetAttributeValue(objectName, fullAttribName, attribValue);
                setterMethod.Invoke(polyLines, new [] {value});
            }
        }
        
        polyLines.DrawPolyLines();
        if(!objectName.Equals(string.Empty)) EhhmageComplete.ObjectNames.Add(objectName, polyLines);
        else EhhmageComplete.Global.PolyLines = polyLines.Clone();
    }

    private static void DrawEllipse(IEnumerable<EhhParser.AttribPairContext> contexts, string objectName, EhhmageComplete.Ellipse? ellipse = null) {
        
        ellipse ??= EhhmageComplete.Global.Ellipse.Clone();
        
        foreach (var attribPairContext in contexts) {
            var attribName = attribPairContext.attribName().GetText();
            var attribValue = attribPairContext.attribValue().GetText();
            
            var setterMethod = ellipse.GetType().GetMethod("set" + attribName, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);
            if (setterMethod is null)
                Console.WriteLine(attribName + " is not defined for object ellipse");
            else {
                var value = AttributesSetters.GetAttributeValue("ellipse", attribName, attribValue);
                setterMethod.Invoke(ellipse, new [] {value});
            }
        }
        
        ellipse.DrawEllipse();
        
        if(!objectName.Equals(string.Empty)) EhhmageComplete.ObjectNames.Add(objectName, ellipse);
        else EhhmageComplete.Global.Ellipse = ellipse.Clone();
        
    }
    
}