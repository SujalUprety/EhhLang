using System.Reflection;

namespace Ehhmake;

public class EhhVisitor : EhhBaseVisitor<object?> {

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
            var objectName = context.objectIdentifier().objectName().GetText();
            try {
                var storedObjectContext = EhhmageComplete.ObjectNames[preDefinedObjectName];
                if(storedObjectContext is EhhmageComplete.IEhhmageObject storedEhhmageObjectContext) InsertObject(objectContext, objectName, storedEhhmageObjectContext.Clone());
                else Console.WriteLine($"Object \'{objectName}\' not identified. Error code: 0x00000001");
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
        if(preDefinedObjectName == "ehh") {
            InitializeObjectEhh(objectContext);
        }
        else InsertObject(objectContext, objectName, EhhmageComplete.EhhmageObjectFactory.CreateObject(preDefinedObjectName));
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
    
    private static void InsertObject(IEnumerable<EhhParser.AttribPairContext> context, string objectName, EhhmageComplete.IEhhmageObject ehhmageObject) {
        
        foreach (var attribPairContext in context) {
            var attribName = attribPairContext.attribName().GetText();
            var attribValue = attribPairContext.attribValue().GetText();
            
            var setterMethod = ehhmageObject.GetType().GetMethod("set" + attribName, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);
            if (setterMethod is null)
                Console.WriteLine(attribName + " is not defined for object " + objectName);
            else {
                var value = AttributesSetters.GetAttributeValue(objectName, attribName, attribValue);
                setterMethod.Invoke(ehhmageObject, new [] {value});
            }
        }
        
        ehhmageObject.InsertObject();
        EhhmageComplete.ObjectNames.Add(objectName, ehhmageObject);
    }
    
}