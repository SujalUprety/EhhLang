﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.6.6
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from G:\Projects\My Rule\Ehhmake\Ehhmake\Ehhmake\Content\Ehh.g4 by ANTLR 4.6.6

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
	/// Enter a parse tree produced by <see cref="EhhParser.start"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStart([NotNull] EhhParser.StartContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="EhhParser.start"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStart([NotNull] EhhParser.StartContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="EhhParser.widthValue"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterWidthValue([NotNull] EhhParser.WidthValueContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="EhhParser.widthValue"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitWidthValue([NotNull] EhhParser.WidthValueContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="EhhParser.heightValue"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterHeightValue([NotNull] EhhParser.HeightValueContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="EhhParser.heightValue"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitHeightValue([NotNull] EhhParser.HeightValueContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="EhhParser.colorValue"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterColorValue([NotNull] EhhParser.ColorValueContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="EhhParser.colorValue"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitColorValue([NotNull] EhhParser.ColorValueContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="EhhParser.outputValue"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterOutputValue([NotNull] EhhParser.OutputValueContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="EhhParser.outputValue"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitOutputValue([NotNull] EhhParser.OutputValueContext context);
}
} // namespace Ehhmake.Content