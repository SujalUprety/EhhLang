﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.6.6
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from E:\Project\My Rule\Ehhmake\Ehhmake\Ehhmake\GrammarContent\Ehh.g4 by ANTLR 4.6.6

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace Ehhmake.GrammarContent {
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.6.6")]
[System.CLSCompliant(false)]
public partial class EhhLexer : Lexer {
	public const int
		T__0=1, T__1=2, T__2=3, T__3=4, T__4=5, T__5=6, LB=7, RB=8, INT=9, ID=10, 
		FILENAME=11, WS=12;
	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"T__0", "T__1", "T__2", "T__3", "T__4", "T__5", "LB", "RB", "INT", "ID", 
		"FILENAME", "WS"
	};


	public EhhLexer(ICharStream input)
		: base(input)
	{
		_interp = new LexerATNSimulator(this,_ATN);
	}

	private static readonly string[] _LiteralNames = {
		null, "'ehh'", "'width:'", "'height:'", "'background:'", "'output:'", 
		"','"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, null, null, null, null, null, "LB", "RB", "INT", "ID", "FILENAME", 
		"WS"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[System.Obsolete("Use Vocabulary instead.")]
	public static readonly string[] tokenNames = GenerateTokenNames(DefaultVocabulary, _SymbolicNames.Length);

	private static string[] GenerateTokenNames(IVocabulary vocabulary, int length) {
		string[] tokenNames = new string[length];
		for (int i = 0; i < tokenNames.Length; i++) {
			tokenNames[i] = vocabulary.GetLiteralName(i);
			if (tokenNames[i] == null) {
				tokenNames[i] = vocabulary.GetSymbolicName(i);
			}

			if (tokenNames[i] == null) {
				tokenNames[i] = "<INVALID>";
			}
		}

		return tokenNames;
	}

	[System.Obsolete("Use IRecognizer.Vocabulary instead.")]
	public override string[] TokenNames
	{
		get
		{
			return tokenNames;
		}
	}

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "Ehh.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override string SerializedAtn { get { return _serializedATN; } }

	public static readonly string _serializedATN =
		"\x3\xAF6F\x8320\x479D\xB75C\x4880\x1605\x191C\xAB37\x2\xE^\b\x1\x4\x2"+
		"\t\x2\x4\x3\t\x3\x4\x4\t\x4\x4\x5\t\x5\x4\x6\t\x6\x4\a\t\a\x4\b\t\b\x4"+
		"\t\t\t\x4\n\t\n\x4\v\t\v\x4\f\t\f\x4\r\t\r\x3\x2\x3\x2\x3\x2\x3\x2\x3"+
		"\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x4\x3\x4\x3\x4\x3\x4\x3\x4"+
		"\x3\x4\x3\x4\x3\x4\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3"+
		"\x5\x3\x5\x3\x5\x3\x5\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6"+
		"\x3\a\x3\a\x3\b\x3\b\x3\t\x3\t\x3\n\x6\nJ\n\n\r\n\xE\nK\x3\v\x6\vO\n\v"+
		"\r\v\xE\vP\x3\f\x6\fT\n\f\r\f\xE\fU\x3\r\x6\rY\n\r\r\r\xE\rZ\x3\r\x3\r"+
		"\x2\x2\x2\xE\x3\x2\x3\x5\x2\x4\a\x2\x5\t\x2\x6\v\x2\a\r\x2\b\xF\x2\t\x11"+
		"\x2\n\x13\x2\v\x15\x2\f\x17\x2\r\x19\x2\xE\x3\x2\b\x3\x2}}\x3\x2\x7F\x7F"+
		"\x3\x2\x32;\x4\x2\x43\\\x63|\x6\x2\x30\x30\x32;\x43\\\x63|\x5\x2\v\f\xF"+
		"\xF\"\"\x61\x2\x3\x3\x2\x2\x2\x2\x5\x3\x2\x2\x2\x2\a\x3\x2\x2\x2\x2\t"+
		"\x3\x2\x2\x2\x2\v\x3\x2\x2\x2\x2\r\x3\x2\x2\x2\x2\xF\x3\x2\x2\x2\x2\x11"+
		"\x3\x2\x2\x2\x2\x13\x3\x2\x2\x2\x2\x15\x3\x2\x2\x2\x2\x17\x3\x2\x2\x2"+
		"\x2\x19\x3\x2\x2\x2\x3\x1B\x3\x2\x2\x2\x5\x1F\x3\x2\x2\x2\a&\x3\x2\x2"+
		"\x2\t.\x3\x2\x2\x2\v:\x3\x2\x2\x2\r\x42\x3\x2\x2\x2\xF\x44\x3\x2\x2\x2"+
		"\x11\x46\x3\x2\x2\x2\x13I\x3\x2\x2\x2\x15N\x3\x2\x2\x2\x17S\x3\x2\x2\x2"+
		"\x19X\x3\x2\x2\x2\x1B\x1C\ag\x2\x2\x1C\x1D\aj\x2\x2\x1D\x1E\aj\x2\x2\x1E"+
		"\x4\x3\x2\x2\x2\x1F \ay\x2\x2 !\ak\x2\x2!\"\a\x66\x2\x2\"#\av\x2\x2#$"+
		"\aj\x2\x2$%\a<\x2\x2%\x6\x3\x2\x2\x2&\'\aj\x2\x2\'(\ag\x2\x2()\ak\x2\x2"+
		")*\ai\x2\x2*+\aj\x2\x2+,\av\x2\x2,-\a<\x2\x2-\b\x3\x2\x2\x2./\a\x64\x2"+
		"\x2/\x30\a\x63\x2\x2\x30\x31\a\x65\x2\x2\x31\x32\am\x2\x2\x32\x33\ai\x2"+
		"\x2\x33\x34\at\x2\x2\x34\x35\aq\x2\x2\x35\x36\aw\x2\x2\x36\x37\ap\x2\x2"+
		"\x37\x38\a\x66\x2\x2\x38\x39\a<\x2\x2\x39\n\x3\x2\x2\x2:;\aq\x2\x2;<\a"+
		"w\x2\x2<=\av\x2\x2=>\ar\x2\x2>?\aw\x2\x2?@\av\x2\x2@\x41\a<\x2\x2\x41"+
		"\f\x3\x2\x2\x2\x42\x43\a.\x2\x2\x43\xE\x3\x2\x2\x2\x44\x45\t\x2\x2\x2"+
		"\x45\x10\x3\x2\x2\x2\x46G\t\x3\x2\x2G\x12\x3\x2\x2\x2HJ\t\x4\x2\x2IH\x3"+
		"\x2\x2\x2JK\x3\x2\x2\x2KI\x3\x2\x2\x2KL\x3\x2\x2\x2L\x14\x3\x2\x2\x2M"+
		"O\t\x5\x2\x2NM\x3\x2\x2\x2OP\x3\x2\x2\x2PN\x3\x2\x2\x2PQ\x3\x2\x2\x2Q"+
		"\x16\x3\x2\x2\x2RT\t\x6\x2\x2SR\x3\x2\x2\x2TU\x3\x2\x2\x2US\x3\x2\x2\x2"+
		"UV\x3\x2\x2\x2V\x18\x3\x2\x2\x2WY\t\a\x2\x2XW\x3\x2\x2\x2YZ\x3\x2\x2\x2"+
		"ZX\x3\x2\x2\x2Z[\x3\x2\x2\x2[\\\x3\x2\x2\x2\\]\b\r\x2\x2]\x1A\x3\x2\x2"+
		"\x2\a\x2KPUZ\x3\b\x2\x2";
	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN.ToCharArray());
}
} // namespace Ehhmake.GrammarContent
