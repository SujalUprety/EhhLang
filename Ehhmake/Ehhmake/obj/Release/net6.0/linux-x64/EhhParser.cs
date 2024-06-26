﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.6.6
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from G:\Projects\My Rule\EhhLang\Ehhmake\Ehhmake\Content\Ehh.g4 by ANTLR 4.6.6

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace Ehhmake.Content {
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using System.Collections.Generic;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.6.6")]
[System.CLSCompliant(false)]
public partial class EhhParser : Parser {
	public const int
		T__0=1, T__1=2, T__2=3, T__3=4, T__4=5, LB=6, RB=7, INT=8, ID=9, STRING=10, 
		NEWLINE=11, WS=12;
	public const int
		RULE_program = 0, RULE_object = 1, RULE_objectIdentifier = 2, RULE_symbol = 3, 
		RULE_preObjectName = 4, RULE_objectName = 5, RULE_attribPair = 6, RULE_attribValue = 7, 
		RULE_attribName = 8;
	public static readonly string[] ruleNames = {
		"program", "object", "objectIdentifier", "symbol", "preObjectName", "objectName", 
		"attribPair", "attribValue", "attribName"
	};

	private static readonly string[] _LiteralNames = {
		null, "'::'", "':'", "','", "'['", "']'"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, null, null, null, null, "LB", "RB", "INT", "ID", "STRING", 
		"NEWLINE", "WS"
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

	public override string SerializedAtn { get { return _serializedATN; } }

	public EhhParser(ITokenStream input)
		: base(input)
	{
		_interp = new ParserATNSimulator(this,_ATN);
	}
	public partial class ProgramContext : ParserRuleContext {
		public ITerminalNode Eof() { return GetToken(EhhParser.Eof, 0); }
		public ObjectContext[] @object() {
			return GetRuleContexts<ObjectContext>();
		}
		public ObjectContext @object(int i) {
			return GetRuleContext<ObjectContext>(i);
		}
		public ITerminalNode[] NEWLINE() { return GetTokens(EhhParser.NEWLINE); }
		public ITerminalNode NEWLINE(int i) {
			return GetToken(EhhParser.NEWLINE, i);
		}
		public ProgramContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_program; } }
		public override void EnterRule(IParseTreeListener listener) {
			IEhhListener typedListener = listener as IEhhListener;
			if (typedListener != null) typedListener.EnterProgram(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IEhhListener typedListener = listener as IEhhListener;
			if (typedListener != null) typedListener.ExitProgram(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IEhhVisitor<TResult> typedVisitor = visitor as IEhhVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitProgram(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public ProgramContext program() {
		ProgramContext _localctx = new ProgramContext(_ctx, State);
		EnterRule(_localctx, 0, RULE_program);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 24;
			_errHandler.Sync(this);
			_la = _input.La(1);
			while (_la==ID) {
				{
				{
				State = 18; @object();
				State = 20;
				_errHandler.Sync(this);
				_la = _input.La(1);
				if (_la==NEWLINE) {
					{
					State = 19; Match(NEWLINE);
					}
				}

				}
				}
				State = 26;
				_errHandler.Sync(this);
				_la = _input.La(1);
			}
			State = 27; Match(Eof);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ObjectContext : ParserRuleContext {
		public ObjectIdentifierContext objectIdentifier() {
			return GetRuleContext<ObjectIdentifierContext>(0);
		}
		public ITerminalNode LB() { return GetToken(EhhParser.LB, 0); }
		public ITerminalNode RB() { return GetToken(EhhParser.RB, 0); }
		public AttribPairContext[] attribPair() {
			return GetRuleContexts<AttribPairContext>();
		}
		public AttribPairContext attribPair(int i) {
			return GetRuleContext<AttribPairContext>(i);
		}
		public ObjectContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_object; } }
		public override void EnterRule(IParseTreeListener listener) {
			IEhhListener typedListener = listener as IEhhListener;
			if (typedListener != null) typedListener.EnterObject(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IEhhListener typedListener = listener as IEhhListener;
			if (typedListener != null) typedListener.ExitObject(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IEhhVisitor<TResult> typedVisitor = visitor as IEhhVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitObject(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public ObjectContext @object() {
		ObjectContext _localctx = new ObjectContext(_ctx, State);
		EnterRule(_localctx, 2, RULE_object);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 29; objectIdentifier();
			State = 30; Match(LB);
			State = 34;
			_errHandler.Sync(this);
			_la = _input.La(1);
			while (_la==ID) {
				{
				{
				State = 31; attribPair();
				}
				}
				State = 36;
				_errHandler.Sync(this);
				_la = _input.La(1);
			}
			State = 37; Match(RB);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ObjectIdentifierContext : ParserRuleContext {
		public PreObjectNameContext preObjectName() {
			return GetRuleContext<PreObjectNameContext>(0);
		}
		public SymbolContext symbol() {
			return GetRuleContext<SymbolContext>(0);
		}
		public ObjectNameContext objectName() {
			return GetRuleContext<ObjectNameContext>(0);
		}
		public ObjectIdentifierContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_objectIdentifier; } }
		public override void EnterRule(IParseTreeListener listener) {
			IEhhListener typedListener = listener as IEhhListener;
			if (typedListener != null) typedListener.EnterObjectIdentifier(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IEhhListener typedListener = listener as IEhhListener;
			if (typedListener != null) typedListener.ExitObjectIdentifier(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IEhhVisitor<TResult> typedVisitor = visitor as IEhhVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitObjectIdentifier(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public ObjectIdentifierContext objectIdentifier() {
		ObjectIdentifierContext _localctx = new ObjectIdentifierContext(_ctx, State);
		EnterRule(_localctx, 4, RULE_objectIdentifier);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 39; preObjectName();
			State = 43;
			_errHandler.Sync(this);
			_la = _input.La(1);
			if (_la==T__0) {
				{
				State = 40; symbol();
				State = 41; objectName();
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class SymbolContext : ParserRuleContext {
		public SymbolContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_symbol; } }
		public override void EnterRule(IParseTreeListener listener) {
			IEhhListener typedListener = listener as IEhhListener;
			if (typedListener != null) typedListener.EnterSymbol(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IEhhListener typedListener = listener as IEhhListener;
			if (typedListener != null) typedListener.ExitSymbol(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IEhhVisitor<TResult> typedVisitor = visitor as IEhhVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitSymbol(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public SymbolContext symbol() {
		SymbolContext _localctx = new SymbolContext(_ctx, State);
		EnterRule(_localctx, 6, RULE_symbol);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 45; Match(T__0);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class PreObjectNameContext : ParserRuleContext {
		public ITerminalNode[] ID() { return GetTokens(EhhParser.ID); }
		public ITerminalNode ID(int i) {
			return GetToken(EhhParser.ID, i);
		}
		public ITerminalNode[] INT() { return GetTokens(EhhParser.INT); }
		public ITerminalNode INT(int i) {
			return GetToken(EhhParser.INT, i);
		}
		public PreObjectNameContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_preObjectName; } }
		public override void EnterRule(IParseTreeListener listener) {
			IEhhListener typedListener = listener as IEhhListener;
			if (typedListener != null) typedListener.EnterPreObjectName(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IEhhListener typedListener = listener as IEhhListener;
			if (typedListener != null) typedListener.ExitPreObjectName(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IEhhVisitor<TResult> typedVisitor = visitor as IEhhVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitPreObjectName(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public PreObjectNameContext preObjectName() {
		PreObjectNameContext _localctx = new PreObjectNameContext(_ctx, State);
		EnterRule(_localctx, 8, RULE_preObjectName);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 47; Match(ID);
			State = 51;
			_errHandler.Sync(this);
			_la = _input.La(1);
			while (_la==INT || _la==ID) {
				{
				{
				State = 48;
				_la = _input.La(1);
				if ( !(_la==INT || _la==ID) ) {
				_errHandler.RecoverInline(this);
				} else {
					if (_input.La(1) == TokenConstants.Eof) {
						matchedEOF = true;
					}

					_errHandler.ReportMatch(this);
					Consume();
				}
				}
				}
				State = 53;
				_errHandler.Sync(this);
				_la = _input.La(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ObjectNameContext : ParserRuleContext {
		public ITerminalNode[] ID() { return GetTokens(EhhParser.ID); }
		public ITerminalNode ID(int i) {
			return GetToken(EhhParser.ID, i);
		}
		public ITerminalNode[] INT() { return GetTokens(EhhParser.INT); }
		public ITerminalNode INT(int i) {
			return GetToken(EhhParser.INT, i);
		}
		public ObjectNameContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_objectName; } }
		public override void EnterRule(IParseTreeListener listener) {
			IEhhListener typedListener = listener as IEhhListener;
			if (typedListener != null) typedListener.EnterObjectName(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IEhhListener typedListener = listener as IEhhListener;
			if (typedListener != null) typedListener.ExitObjectName(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IEhhVisitor<TResult> typedVisitor = visitor as IEhhVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitObjectName(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public ObjectNameContext objectName() {
		ObjectNameContext _localctx = new ObjectNameContext(_ctx, State);
		EnterRule(_localctx, 10, RULE_objectName);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 54; Match(ID);
			State = 58;
			_errHandler.Sync(this);
			_la = _input.La(1);
			while (_la==INT || _la==ID) {
				{
				{
				State = 55;
				_la = _input.La(1);
				if ( !(_la==INT || _la==ID) ) {
				_errHandler.RecoverInline(this);
				} else {
					if (_input.La(1) == TokenConstants.Eof) {
						matchedEOF = true;
					}

					_errHandler.ReportMatch(this);
					Consume();
				}
				}
				}
				State = 60;
				_errHandler.Sync(this);
				_la = _input.La(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class AttribPairContext : ParserRuleContext {
		public AttribNameContext attribName() {
			return GetRuleContext<AttribNameContext>(0);
		}
		public AttribValueContext attribValue() {
			return GetRuleContext<AttribValueContext>(0);
		}
		public ITerminalNode NEWLINE() { return GetToken(EhhParser.NEWLINE, 0); }
		public AttribPairContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_attribPair; } }
		public override void EnterRule(IParseTreeListener listener) {
			IEhhListener typedListener = listener as IEhhListener;
			if (typedListener != null) typedListener.EnterAttribPair(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IEhhListener typedListener = listener as IEhhListener;
			if (typedListener != null) typedListener.ExitAttribPair(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IEhhVisitor<TResult> typedVisitor = visitor as IEhhVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitAttribPair(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public AttribPairContext attribPair() {
		AttribPairContext _localctx = new AttribPairContext(_ctx, State);
		EnterRule(_localctx, 12, RULE_attribPair);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 61; attribName();
			State = 62; Match(T__1);
			State = 63; attribValue();
			State = 65;
			_errHandler.Sync(this);
			_la = _input.La(1);
			if (_la==NEWLINE) {
				{
				State = 64; Match(NEWLINE);
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class AttribValueContext : ParserRuleContext {
		public ITerminalNode[] INT() { return GetTokens(EhhParser.INT); }
		public ITerminalNode INT(int i) {
			return GetToken(EhhParser.INT, i);
		}
		public ITerminalNode ID() { return GetToken(EhhParser.ID, 0); }
		public ITerminalNode STRING() { return GetToken(EhhParser.STRING, 0); }
		public AttribValueContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_attribValue; } }
		public override void EnterRule(IParseTreeListener listener) {
			IEhhListener typedListener = listener as IEhhListener;
			if (typedListener != null) typedListener.EnterAttribValue(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IEhhListener typedListener = listener as IEhhListener;
			if (typedListener != null) typedListener.ExitAttribValue(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IEhhVisitor<TResult> typedVisitor = visitor as IEhhVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitAttribValue(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public AttribValueContext attribValue() {
		AttribValueContext _localctx = new AttribValueContext(_ctx, State);
		EnterRule(_localctx, 14, RULE_attribValue);
		try {
			State = 75;
			_errHandler.Sync(this);
			switch ( Interpreter.AdaptivePredict(_input,7,_ctx) ) {
			case 1:
				EnterOuterAlt(_localctx, 1);
				{
				State = 67; Match(INT);
				}
				break;

			case 2:
				EnterOuterAlt(_localctx, 2);
				{
				State = 68; Match(INT);
				State = 69; Match(T__2);
				State = 70; Match(INT);
				State = 71; Match(T__2);
				State = 72; Match(INT);
				}
				break;

			case 3:
				EnterOuterAlt(_localctx, 3);
				{
				State = 73; Match(ID);
				}
				break;

			case 4:
				EnterOuterAlt(_localctx, 4);
				{
				State = 74; Match(STRING);
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class AttribNameContext : ParserRuleContext {
		public ITerminalNode ID() { return GetToken(EhhParser.ID, 0); }
		public ITerminalNode INT() { return GetToken(EhhParser.INT, 0); }
		public AttribNameContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_attribName; } }
		public override void EnterRule(IParseTreeListener listener) {
			IEhhListener typedListener = listener as IEhhListener;
			if (typedListener != null) typedListener.EnterAttribName(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IEhhListener typedListener = listener as IEhhListener;
			if (typedListener != null) typedListener.ExitAttribName(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IEhhVisitor<TResult> typedVisitor = visitor as IEhhVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitAttribName(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public AttribNameContext attribName() {
		AttribNameContext _localctx = new AttribNameContext(_ctx, State);
		EnterRule(_localctx, 16, RULE_attribName);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 77; Match(ID);
			State = 81;
			_errHandler.Sync(this);
			_la = _input.La(1);
			if (_la==T__3) {
				{
				State = 78; Match(T__3);
				State = 79; Match(INT);
				State = 80; Match(T__4);
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public static readonly string _serializedATN =
		"\x3\xAF6F\x8320\x479D\xB75C\x4880\x1605\x191C\xAB37\x3\xEV\x4\x2\t\x2"+
		"\x4\x3\t\x3\x4\x4\t\x4\x4\x5\t\x5\x4\x6\t\x6\x4\a\t\a\x4\b\t\b\x4\t\t"+
		"\t\x4\n\t\n\x3\x2\x3\x2\x5\x2\x17\n\x2\a\x2\x19\n\x2\f\x2\xE\x2\x1C\v"+
		"\x2\x3\x2\x3\x2\x3\x3\x3\x3\x3\x3\a\x3#\n\x3\f\x3\xE\x3&\v\x3\x3\x3\x3"+
		"\x3\x3\x4\x3\x4\x3\x4\x3\x4\x5\x4.\n\x4\x3\x5\x3\x5\x3\x6\x3\x6\a\x6\x34"+
		"\n\x6\f\x6\xE\x6\x37\v\x6\x3\a\x3\a\a\a;\n\a\f\a\xE\a>\v\a\x3\b\x3\b\x3"+
		"\b\x3\b\x5\b\x44\n\b\x3\t\x3\t\x3\t\x3\t\x3\t\x3\t\x3\t\x3\t\x5\tN\n\t"+
		"\x3\n\x3\n\x3\n\x3\n\x5\nT\n\n\x3\n\x2\x2\x2\v\x2\x2\x4\x2\x6\x2\b\x2"+
		"\n\x2\f\x2\xE\x2\x10\x2\x12\x2\x2\x3\x3\x2\n\vW\x2\x1A\x3\x2\x2\x2\x4"+
		"\x1F\x3\x2\x2\x2\x6)\x3\x2\x2\x2\b/\x3\x2\x2\x2\n\x31\x3\x2\x2\x2\f\x38"+
		"\x3\x2\x2\x2\xE?\x3\x2\x2\x2\x10M\x3\x2\x2\x2\x12O\x3\x2\x2\x2\x14\x16"+
		"\x5\x4\x3\x2\x15\x17\a\r\x2\x2\x16\x15\x3\x2\x2\x2\x16\x17\x3\x2\x2\x2"+
		"\x17\x19\x3\x2\x2\x2\x18\x14\x3\x2\x2\x2\x19\x1C\x3\x2\x2\x2\x1A\x18\x3"+
		"\x2\x2\x2\x1A\x1B\x3\x2\x2\x2\x1B\x1D\x3\x2\x2\x2\x1C\x1A\x3\x2\x2\x2"+
		"\x1D\x1E\a\x2\x2\x3\x1E\x3\x3\x2\x2\x2\x1F \x5\x6\x4\x2 $\a\b\x2\x2!#"+
		"\x5\xE\b\x2\"!\x3\x2\x2\x2#&\x3\x2\x2\x2$\"\x3\x2\x2\x2$%\x3\x2\x2\x2"+
		"%\'\x3\x2\x2\x2&$\x3\x2\x2\x2\'(\a\t\x2\x2(\x5\x3\x2\x2\x2)-\x5\n\x6\x2"+
		"*+\x5\b\x5\x2+,\x5\f\a\x2,.\x3\x2\x2\x2-*\x3\x2\x2\x2-.\x3\x2\x2\x2.\a"+
		"\x3\x2\x2\x2/\x30\a\x3\x2\x2\x30\t\x3\x2\x2\x2\x31\x35\a\v\x2\x2\x32\x34"+
		"\t\x2\x2\x2\x33\x32\x3\x2\x2\x2\x34\x37\x3\x2\x2\x2\x35\x33\x3\x2\x2\x2"+
		"\x35\x36\x3\x2\x2\x2\x36\v\x3\x2\x2\x2\x37\x35\x3\x2\x2\x2\x38<\a\v\x2"+
		"\x2\x39;\t\x2\x2\x2:\x39\x3\x2\x2\x2;>\x3\x2\x2\x2<:\x3\x2\x2\x2<=\x3"+
		"\x2\x2\x2=\r\x3\x2\x2\x2><\x3\x2\x2\x2?@\x5\x12\n\x2@\x41\a\x4\x2\x2\x41"+
		"\x43\x5\x10\t\x2\x42\x44\a\r\x2\x2\x43\x42\x3\x2\x2\x2\x43\x44\x3\x2\x2"+
		"\x2\x44\xF\x3\x2\x2\x2\x45N\a\n\x2\x2\x46G\a\n\x2\x2GH\a\x5\x2\x2HI\a"+
		"\n\x2\x2IJ\a\x5\x2\x2JN\a\n\x2\x2KN\a\v\x2\x2LN\a\f\x2\x2M\x45\x3\x2\x2"+
		"\x2M\x46\x3\x2\x2\x2MK\x3\x2\x2\x2ML\x3\x2\x2\x2N\x11\x3\x2\x2\x2OS\a"+
		"\v\x2\x2PQ\a\x6\x2\x2QR\a\n\x2\x2RT\a\a\x2\x2SP\x3\x2\x2\x2ST\x3\x2\x2"+
		"\x2T\x13\x3\x2\x2\x2\v\x16\x1A$-\x35<\x43MS";
	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN.ToCharArray());
}
} // namespace Ehhmake.Content
