using Ehhmake.Content;
using static Ehhmake.EhhmageComplete;

namespace Ehhmake;

public static class AttributesSetters {

    private static Dictionary<string, Type> attributeTypes = new()
    {
        { nameof(Attributes.width), typeof(int) },
        { nameof(Attributes.height), typeof(int) },
        { nameof(Attributes.background), typeof(int[]) },
        { nameof(Attributes.output), typeof(string) },
        { nameof(Attributes.fontScale), typeof(int) },
        { nameof(Attributes.thickness), typeof(int) },
        { nameof(Attributes.position), typeof(int[]) },
        { nameof(Attributes.color), typeof(int[]) },
        { nameof(Attributes.text), typeof(string) },
        { nameof(Attributes.fillColor), typeof(object) },
        { nameof(Attributes.startPosition), typeof(int[]) },
        { nameof(Attributes.endPosition), typeof(int[]) },
        { nameof(Attributes.radius), typeof(int) },
        { nameof(Attributes.axes), typeof(int[]) },
        { nameof(Attributes.angle), typeof(int) },
        { nameof(Attributes.startAngle), typeof(int) },
        { nameof(Attributes.endAngle), typeof(int) }
    };

    public static object? GetAttributeValue(string objectName, string attribName, string attribValue) {
        
        if(!attributeTypes.TryGetValue(attribName, out var type)) {
            Console.WriteLine($"Error: {objectName} does not have an attribute named {attribName}.");
            Environment.Exit(1);
        }
        
        return type switch {
            Type when type == typeof(int) => ExtractValues.ExtractInt(objectName, attribName, attribValue),
            Type when type == typeof(int[]) => ExtractValues.ExtractIntArray(objectName, attribName, attribValue),
            Type when type == typeof(string) => ExtractValues.ExtractString(objectName, attribName, attribValue),
            Type when type == typeof(object) => ExtractValues.ExtractFillColor(objectName, attribName, attribValue),
            _ => null
        };
        
    }

}

public static class ExtractValues {

    public static int ExtractInt(string objectName, string attribName, string attribValue) {
        if(!int.TryParse(attribValue, out var value)) HandleError(objectName, attribName, "integer");
        return value;
    }
    
    public static int[] ExtractIntArray(string objectName, string attribName, string attribValue) {
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

    public static object ExtractFillColor(string objectName, string attribName, string attribValue) {
        if (attribValue == "no") return false;
        
        var values = attribValue.Split(',');
        if(values.Length == 3) {
            return ParseIntArray(objectName, attribName, values);
        }
        
        HandleError(objectName, attribName, "fillColor");
        return Enumerable.Empty<int>().ToArray();
    }
    
    private static void HandleError(string objectName, string attribName, string expectedType) {
        Console.WriteLine($"Error: {objectName} {attribName} must be a {expectedType}");
        Environment.Exit(1);
    }
    
}