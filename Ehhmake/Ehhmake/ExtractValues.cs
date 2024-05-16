using System.Text.RegularExpressions;
using static Ehhmake.EhhmageComplete;

namespace Ehhmake;

public static class AttributesSetters {

    public class AttributeInfo {
        public Type Type { get; set; }
        public int ArrayLength { get;}
        
        public AttributeInfo(Type type, int arrayLength = 0) {
            Type = type;
            ArrayLength = arrayLength;
        }
    }

    public static readonly Dictionary<string, AttributeInfo> AttributeTypes = new()
    {
        { nameof(Attributes.width), new AttributeInfo(typeof(int)) },
        { nameof(Attributes.height), new AttributeInfo(typeof(int)) },
        { nameof(Attributes.background), new AttributeInfo(typeof(int[]), 3) },
        { nameof(Attributes.output), new AttributeInfo(typeof(string)) },
        { nameof(Attributes.fontScale), new AttributeInfo(typeof(int)) },
        { nameof(Attributes.thickness), new AttributeInfo(typeof(int)) },
        { nameof(Attributes.position), new AttributeInfo(typeof(int[]), 2) },
        { nameof(Attributes.color), new AttributeInfo(typeof(int[]), 3) },
        { nameof(Attributes.text), new AttributeInfo(typeof(string)) },
        { nameof(Attributes.fillColor), new AttributeInfo(typeof(object)) },
        { nameof(Attributes.startPosition), new AttributeInfo(typeof(int[]), 2) },
        { nameof(Attributes.endPosition), new AttributeInfo(typeof(int[]), 2) },
        { nameof(Attributes.radius), new AttributeInfo(typeof(int)) },
        { nameof(Attributes.axes), new AttributeInfo(typeof(int[]), 2) },
        { nameof(Attributes.angle), new AttributeInfo(typeof(int)) },
        { nameof(Attributes.startAngle), new AttributeInfo(typeof(int)) },
        { nameof(Attributes.endAngle), new AttributeInfo(typeof(int)) }
    };

    public static object? GetAttributeValue(string objectName, string attribName, string attribValue) {

        if (IsArray(attribName)) return ExtractValues.ExtractArrayAttribute(objectName, attribName, attribValue);
        
        if(!AttributeTypes.TryGetValue(attribName, out var attributeInfo)) {
            Console.WriteLine($"Error: {objectName} does not have an attribute named {attribName}.");
            Environment.Exit(1);
        }
        
        return attributeInfo.Type switch {
            not null when attributeInfo.Type == typeof(int) => ExtractValues.ExtractInt(objectName, attribName, attribValue),
            not null when attributeInfo.Type == typeof(int[]) => ExtractValues.ExtractIntArray(objectName, attribName, attribValue, attributeInfo.ArrayLength),
            not null when attributeInfo.Type == typeof(string) => ExtractValues.ExtractString(objectName, attribName, attribValue),
            not null when attributeInfo.Type == typeof(object) => ExtractValues.ExtractFillColor(objectName, attribName, attribValue),
            _ => null
        };
        
    }
    
    private static bool IsArray(string attribName) {
        var regex = new Regex(@"\[.*\]");
        return regex.IsMatch(attribName);
    }

}

public static class ExtractValues {

    public static int ExtractInt(string objectName, string attribName, string attribValue) {
        if(!int.TryParse(attribValue, out var value)) HandleError(objectName, attribName, "integer");
        return value;
    }
    
    public static int[] ExtractIntArray(string objectName, string attribName, string attribValue, int arrayLength) {
        var values = attribValue.Split(',');
        
        return values.Length == arrayLength ? ParseIntArray(objectName, attribName, values) : Enumerable.Empty<int>().ToArray();
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

    public static object ExtractArrayAttribute(string objectName, string attribName, string attribValue) {
        var attribNameWithoutBrackets = RemoveBrackets(attribName);
        var attribNameIndex = GetIndex(attribName);
        
        if(!AttributesSetters.AttributeTypes.TryGetValue(attribNameWithoutBrackets, out var attributeInfo)) {
            Console.WriteLine($"Error: {objectName} does not have an attribute named {attribNameWithoutBrackets}.");
            Environment.Exit(1);
        }
        
        if(attributeInfo.Type == typeof(int[])) {
            var values = ExtractIntArray(objectName, attribNameWithoutBrackets, attribValue, attributeInfo.ArrayLength);
            return (attribNameIndex, values);
        }

        Environment.Exit(1);
        return 0;
    }
    
    private static string RemoveBrackets(string attribName) {
        var regex = new Regex(@"\[.*\]");
        return regex.Replace(attribName, "");
    }
    
    private static int GetIndex(string attribName) {
        var regex = new Regex(@"\[.*\]");
        var match = regex.Match(attribName);

        if (match.Success) {
            var index = match.Value[1..^1];
            if (int.TryParse(index, out var result)) return result;
        }
        
        Console.WriteLine("Index is not integer");
        Environment.Exit(1);
        
        return 0;
    }
    
    private static void HandleError(string objectName, string attribName, string expectedType) {
        Console.WriteLine($"Error: {objectName} {attribName} must be a {expectedType}");
        Environment.Exit(1);
    }
    
}