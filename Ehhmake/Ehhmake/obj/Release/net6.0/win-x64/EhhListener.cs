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
using Antlr4.Runtime.Misc;
using IParseTreeListener = Antlr4.Runtime.Tree.IParseTreeListener;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete listener for a parse tree produced by
/// <see cref="EhhParser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.6.6")]
[System.CLSCompliant(false)]
public interface IEhhListener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="EhhParser.program"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterProgram([NotNull] EhhParser.ProgramContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="EhhParser.program"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitProgram([NotNull] EhhParser.ProgramContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="EhhParser.object"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterObject([NotNull] EhhParser.ObjectContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="EhhParser.object"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitObject([NotNull] EhhParser.ObjectContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="EhhParser.objectIdentifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterObjectIdentifier([NotNull] EhhParser.ObjectIdentifierContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="EhhParser.objectIdentifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitObjectIdentifier([NotNull] EhhParser.ObjectIdentifierContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="EhhParser.symbol"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSymbol([NotNull] EhhParser.SymbolContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="EhhParser.symbol"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSymbol([NotNull] EhhParser.SymbolContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="EhhParser.preObjectName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPreObjectName([NotNull] EhhParser.PreObjectNameContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="EhhParser.preObjectName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPreObjectName([NotNull] EhhParser.PreObjectNameContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="EhhParser.objectName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterObjectName([NotNull] EhhParser.ObjectNameContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="EhhParser.objectName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitObjectName([NotNull] EhhParser.ObjectNameContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="EhhParser.attribPair"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAttribPair([NotNull] EhhParser.AttribPairContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="EhhParser.attribPair"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAttribPair([NotNull] EhhParser.AttribPairContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="EhhParser.attribValue"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAttribValue([NotNull] EhhParser.AttribValueContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="EhhParser.attribValue"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAttribValue([NotNull] EhhParser.AttribValueContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="EhhParser.attribName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAttribName([NotNull] EhhParser.AttribNameContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="EhhParser.attribName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAttribName([NotNull] EhhParser.AttribNameContext context);
}
} // namespace Ehhmake.Content