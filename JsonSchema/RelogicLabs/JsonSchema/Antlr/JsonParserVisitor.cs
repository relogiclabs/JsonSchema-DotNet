//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.13.0
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from /home/zahid/Projects/JsonAssert2/JsonSchema/RelogicLabs/JsonSchema/Grammar/JsonParser.g4 by ANTLR 4.13.0

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace RelogicLabs.JsonSchema.Antlr {
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete generic visitor for a parse tree produced
/// by <see cref="JsonParser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.13.0")]
internal interface IJsonParserVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="JsonParser.json"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitJson([NotNull] JsonParser.JsonContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JsonParser.value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitValue([NotNull] JsonParser.ValueContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JsonParser.object"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitObject([NotNull] JsonParser.ObjectContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JsonParser.property"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitProperty([NotNull] JsonParser.PropertyContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JsonParser.array"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitArray([NotNull] JsonParser.ArrayContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>PrimitiveTrue</c>
	/// labeled alternative in <see cref="JsonParser.primitive"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPrimitiveTrue([NotNull] JsonParser.PrimitiveTrueContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>PrimitiveFalse</c>
	/// labeled alternative in <see cref="JsonParser.primitive"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPrimitiveFalse([NotNull] JsonParser.PrimitiveFalseContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>PrimitiveString</c>
	/// labeled alternative in <see cref="JsonParser.primitive"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPrimitiveString([NotNull] JsonParser.PrimitiveStringContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>PrimitiveInteger</c>
	/// labeled alternative in <see cref="JsonParser.primitive"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPrimitiveInteger([NotNull] JsonParser.PrimitiveIntegerContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>PrimitiveFloat</c>
	/// labeled alternative in <see cref="JsonParser.primitive"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPrimitiveFloat([NotNull] JsonParser.PrimitiveFloatContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>PrimitiveDouble</c>
	/// labeled alternative in <see cref="JsonParser.primitive"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPrimitiveDouble([NotNull] JsonParser.PrimitiveDoubleContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>PrimitiveNull</c>
	/// labeled alternative in <see cref="JsonParser.primitive"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPrimitiveNull([NotNull] JsonParser.PrimitiveNullContext context);
}
} // namespace RelogicLabs.JsonSchema.Antlr
