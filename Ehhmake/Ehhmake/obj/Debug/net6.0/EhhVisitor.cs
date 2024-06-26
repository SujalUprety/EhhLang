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
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete generic visitor for a parse tree produced
/// by <see cref="EhhParser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.6.6")]
[System.CLSCompliant(false)]
public interface IEhhVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="EhhParser.program"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitProgram([NotNull] EhhParser.ProgramContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="EhhParser.object"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitObject([NotNull] EhhParser.ObjectContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="EhhParser.objectIdentifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitObjectIdentifier([NotNull] EhhParser.ObjectIdentifierContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="EhhParser.symbol"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSymbol([NotNull] EhhParser.SymbolContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="EhhParser.preObjectName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPreObjectName([NotNull] EhhParser.PreObjectNameContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="EhhParser.objectName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitObjectName([NotNull] EhhParser.ObjectNameContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="EhhParser.attribPair"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAttribPair([NotNull] EhhParser.AttribPairContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="EhhParser.attribValue"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAttribValue([NotNull] EhhParser.AttribValueContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="EhhParser.attribName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAttribName([NotNull] EhhParser.AttribNameContext context);
}
} // namespace Ehhmake.Content
