using static Ehhmake.EhhmageComplete;

namespace Ehhmake;

public static class AttributesSetters {
    
    private static readonly Dictionary<(Type, string), (Action<object, object> Setter, Type Type)> ActionMaps = new() {
        
        //Ehhmage Attributes
        { (typeof(Ehhmage), nameof(Attributes.width)), ((obj, arg) => Ehhmage.SetWidth((int)arg), typeof(int))},
        { (typeof(Ehhmage),nameof(Attributes.height)), ((obj,arg) => Ehhmage.SetHeight((int)arg), typeof(int))},
        { (typeof(Ehhmage),nameof(Attributes.background)), ((obj, arg) => Ehhmage.SetBackground((int[])arg), typeof(int[]))},
        { (typeof(Ehhmage),nameof(Attributes.output)), ((obj, arg) => Ehhmage.SetOutputName((string)arg), typeof(string))},
        
        //TextAttributes
        { (typeof(Text), nameof(Attributes.fontScale)), ((obj, arg) => ((Text)obj).SetFontScale((int)arg), typeof(int))},
        { (typeof(Text), nameof(Attributes.thickness)), ((obj, arg) => ((Text)obj).SetThickness((int)arg), typeof(int))},
        { (typeof(Text), nameof(Attributes.position)), ((obj, arg) => ((Text)obj).SetPosition((int[])arg), typeof(int[]))},
        { (typeof(Text), nameof(Attributes.color)), ((obj, arg) => ((Text)obj).SetColor((int[])arg), typeof(int[]))},
        { (typeof(Text), nameof(Attributes.text)), ((obj, arg) => ((Text)obj).SetText((string)arg), typeof(string))},
        
        //RectangleAttributes
        { (typeof(Rectangle), nameof(Attributes.position)), ((obj, arg) => ((Rectangle)obj).SetPosition((int[])arg), typeof(int[]))},
        { (typeof(Rectangle), nameof(Attributes.color)), ((obj, arg) => ((Rectangle)obj).SetColor((int[])arg), typeof(int[]))},
        { (typeof(Rectangle), nameof(Attributes.width)), ((obj, arg) => ((Rectangle)obj).SetWidth((int)arg), typeof(int))},
        { (typeof(Rectangle), nameof(Attributes.height)), ((obj, arg) => ((Rectangle)obj).SetHeight((int)arg), typeof(int))},
        { (typeof(Rectangle), nameof(Attributes.thickness)), ((obj, arg) => ((Rectangle)obj).SetThickness((int)arg), typeof(int))},
        { (typeof(Rectangle), nameof(Attributes.fillColor)), ((obj, arg) => ((Rectangle)obj).SetFillColor((int[])arg), typeof(int[]))},
        
        //LineAttributes
        { (typeof(Line), nameof(Attributes.startPosition)), ((obj, arg) => ((Line)obj).SetStartPosition((int[])arg), typeof(int[]))},
        { (typeof(Line), nameof(Attributes.endPosition)), ((obj, arg) => ((Line)obj).SetEndPosition((int[])arg), typeof(int[]))},
        { (typeof(Line), nameof(Attributes.thickness)), ((obj, arg) => ((Line)obj).SetThickness((int)arg), typeof(int))},
        { (typeof(Line), nameof(Attributes.color)), ((obj, arg) => ((Line)obj).SetColor((int[])arg), typeof(int[]))},
        
        //CircleAttributes
        { (typeof(Circle), nameof(Attributes.position)), ((obj, arg) => ((Circle)obj).SetPosition((int[])arg), typeof(int[]))},
        { (typeof(Circle), nameof(Attributes.color)), ((obj, arg) => ((Circle)obj).SetColor((int[])arg), typeof(int[]))},
        { (typeof(Circle), nameof(Attributes.radius)), ((obj, arg) => ((Circle)obj).SetRadius((int)arg), typeof(int))},
        { (typeof(Circle), nameof(Attributes.fillColor)), ((obj, arg) => ((Circle)obj).SetFillColor((int[])arg), typeof(int[]))},
        { (typeof(Circle), nameof(Attributes.thickness)), ((obj, arg) => ((Circle)obj).SetThickness((int)arg), typeof(int))},
        
        //PolyLineAttributes
        { (typeof(PolyLines), nameof(Attributes.color)), ((obj, arg) => ((PolyLines)obj).SetColor((int[])arg), typeof(int[]))},
        { (typeof(PolyLines), nameof(Attributes.thickness)), ((obj, arg) => ((PolyLines)obj).SetThickness((int)arg), typeof(int))},
        { (typeof(PolyLines), nameof(Attributes.fillColor)), ((obj, arg) => ((PolyLines)obj).SetFillColor((int[])arg), typeof(int[]))},
        
        //EllipseAttributes
        { (typeof(Ellipse), nameof(Attributes.position)), ((obj, arg) => ((Ellipse)obj).SetPosition((int[])arg), typeof(int[]))},
        { (typeof(Ellipse), nameof(Attributes.color)), ((obj, arg) => ((Ellipse)obj).SetColor((int[])arg), typeof(int[]))},
        { (typeof(Ellipse), nameof(Attributes.axes)), ((obj, arg) => ((Ellipse)obj).SetAxes((int[])arg), typeof(int[]))},
        { (typeof(Ellipse), nameof(Attributes.fillColor)), ((obj, arg) => ((Ellipse)obj).SetFillColor((int[])arg), typeof(int[]))},
        { (typeof(Ellipse), nameof(Attributes.thickness)), ((obj, arg) => ((Ellipse)obj).SetThickness((int)arg), typeof(int))},
        { (typeof(Ellipse), nameof(Attributes.angle)), ((obj, arg) => ((Ellipse)obj).SetAngle((int)arg), typeof(int))},
        { (typeof(Ellipse), nameof(Attributes.startAngle)), ((obj, arg) => ((Ellipse)obj).SetStartAngle((int)arg), typeof(int))},
        { (typeof(Ellipse), nameof(Attributes.endAngle)), ((obj, arg) => ((Ellipse)obj).SetEndAngle((int)arg), typeof(int))},
    };
    
    public static void SetAttribute(Type objectType, object? obj, string attribName, string attribValue) {
        if (obj is null) SetStaticAttribute(objectType, attribName, attribValue);
        else SetInstanceAttribute(obj, attribName, attribValue);
    }
    
    private static void SetInstanceAttribute(object obj, string attribName, string attribValue) {
        var type = obj.GetType();
        if (ActionMaps.TryGetValue((type, attribName), out var action)) {
            var extractedValue = action.Type switch {
                Type t when t == typeof(int) => (object)ExtractValues.ExtractInt(type.Name, attribName, attribValue),
                Type t when t == typeof(int[]) => ExtractValues.ExtractIntArray(type.Name, attribName, attribValue),
                Type t when t == typeof(string) => ExtractValues.ExtractString(type.Name, attribName, attribValue),
                _ => null
            };
    
            if (extractedValue is not null) {
                action.Setter(obj, extractedValue);
            } else {
                Console.WriteLine($"{type.Name}.{attribName} must be a {action.Type.Name}.");
            }
        } else {
            Console.WriteLine($"{type.Name} does not have an attribute named {attribName}.");
        }
    }
    
    private static void SetStaticAttribute(Type type, string attribName, string attribValue) {
        if (ActionMaps.TryGetValue((type, attribName), out var action)) {
            var extractedValue = action.Type switch {
                Type t when t == typeof(int) => (object)ExtractValues.ExtractInt(type.Name, attribName, attribValue),
                Type t when t == typeof(int[]) => ExtractValues.ExtractIntArray(type.Name, attribName, attribValue),
                Type t when t == typeof(string) => ExtractValues.ExtractString(type.Name, attribName, attribValue),
                _ => null
            };
    
            if (extractedValue is not null) {
                action.Setter(null!, extractedValue);
            } else {
                Console.WriteLine($"{type.Name}.{attribName} must be a {action.Type.Name}.");
            }
        } else {
            Console.WriteLine($"{type.Name} does not have an attribute named {attribName}.");
        }
    }
    
}

public static class ExtractValues {

    public static int ExtractInt(string objectName, string attribName, string attribValue) {
        if(!int.TryParse(attribValue, out var value)) HandleError(objectName, attribName, "integer");
        return value;
    }
    
    public static int[] ExtractIntArray(string objectName, string attribName, string attribValue) {
        if(attribName == nameof(Attributes.fillColor)) {
            ParseFillColor(objectName, attribName, attribValue);
            return Enumerable.Empty<int>().ToArray();
        }
        
        var values = attribValue.Split(',');
        
        if((attribName == nameof(Attributes.background) && values.Length == 3) ||
           (attribName == nameof(Attributes.position) && values.Length == 2) ||
           (attribName == nameof(Attributes.color) && values.Length == 3) ||
           (attribName == nameof(Attributes.axes) && values.Length == 2)) {
            return ParseIntArray(objectName, attribName, values);
        }
        
        return Enumerable.Empty<int>().ToArray();
    }
    
    public static string ExtractString(string objectName, string attribName, string attribValue) {
        string value;
        if(attribValue.StartsWith('"') && attribValue.EndsWith('"')) {
            value = attribValue[1..^1];
        } else {
            HandleError(objectName, attribName, "string");
            value = "";
        }
        return value;
    }

    private static int[] ParseIntArray(string objectName, string attribName, IReadOnlyList<string> values) {
        var intValues = new int[values.Count];
        for(var i = 0; i < values.Count; i++) {
            if(!int.TryParse(values[i], out intValues[i])) HandleError(objectName, attribName, "integer array");
        }
        return intValues;
    }

    private static void ParseFillColor(string objectName, string attribName, string attribValue) {
        if (attribValue == "no") {
            
        }
    }
    
    private static void HandleError(string objectName, string attribName, string expectedType) {
        Console.WriteLine($"Error: {objectName} {attribName} must be a {expectedType}.");
        Environment.Exit(1);
    }
    
}