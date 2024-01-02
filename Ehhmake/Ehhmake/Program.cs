using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Ehhmake.Content;

namespace Ehhmake;

public abstract class Program {

    public static void Main(string[] args) {
        var input = File.ReadAllText(args[0]);

        // var input = File.ReadAllText(@"G:\Projects\My Rule\EhhLang\Ehhmake\Ehhmake\Content\TestPrograms\test2.ehh");

        var inputStream = new AntlrInputStream(input);
        var lexer = new EhhLexer(inputStream);
        var tokenStream = new CommonTokenStream(lexer);
        var parser = new EhhParser(tokenStream);
        
        var tree = parser.program();

        var visitor = new EhhVisitor();
        visitor.Visit(tree);
    }
    
}