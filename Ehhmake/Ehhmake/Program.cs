using Antlr4.Runtime;
using Ehhmake.Content;

namespace Ehhmake;

public abstract class Program {

    public static void Main(string[] args) {
        // var input = File.ReadAllText(args[0]);

        const string filename = @"G:\Projects\My Rule\Ehhmake\Ehhmake\Ehhmake\Content\test.ehh";
        
        var input = File.ReadAllText(filename);
        var inputStream = new AntlrInputStream(input);
        var lexer = new EhhLexer(inputStream);
        var tokenStream = new CommonTokenStream(lexer);
        var parser = new EhhParser(tokenStream);

        var tree = parser.start();

        var visitor = new EhhVisitor();
        visitor.Visit(tree);
    }
    
}