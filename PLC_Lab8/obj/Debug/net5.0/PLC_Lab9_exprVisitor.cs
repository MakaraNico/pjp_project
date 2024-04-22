//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.6.6
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from C:\Users\render\Desktop\skola\skola_sesty_semestr\pjp\pjp_project-master\PLC_Lab8\PLC_Lab9_new\PLC_Lab9\PLC_Lab9_expr.g4 by ANTLR 4.6.6

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace PLC_Lab8.PLC_Lab9_new.PLC_Lab9 {
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete generic visitor for a parse tree produced
/// by <see cref="PLC_Lab9_exprParser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.6.6")]
[System.CLSCompliant(false)]
public interface IPLC_Lab9_exprVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by the <c>declaration</c>
	/// labeled alternative in <see cref="PLC_Lab9_exprParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDeclaration([NotNull] PLC_Lab9_exprParser.DeclarationContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>printExpr</c>
	/// labeled alternative in <see cref="PLC_Lab9_exprParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPrintExpr([NotNull] PLC_Lab9_exprParser.PrintExprContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>mulDivMod</c>
	/// labeled alternative in <see cref="PLC_Lab9_exprParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMulDivMod([NotNull] PLC_Lab9_exprParser.MulDivModContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>parens</c>
	/// labeled alternative in <see cref="PLC_Lab9_exprParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitParens([NotNull] PLC_Lab9_exprParser.ParensContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>assignment</c>
	/// labeled alternative in <see cref="PLC_Lab9_exprParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAssignment([NotNull] PLC_Lab9_exprParser.AssignmentContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>addSub</c>
	/// labeled alternative in <see cref="PLC_Lab9_exprParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAddSub([NotNull] PLC_Lab9_exprParser.AddSubContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>id</c>
	/// labeled alternative in <see cref="PLC_Lab9_exprParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitId([NotNull] PLC_Lab9_exprParser.IdContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>float</c>
	/// labeled alternative in <see cref="PLC_Lab9_exprParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFloat([NotNull] PLC_Lab9_exprParser.FloatContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>int</c>
	/// labeled alternative in <see cref="PLC_Lab9_exprParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitInt([NotNull] PLC_Lab9_exprParser.IntContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="PLC_Lab9_exprParser.program"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitProgram([NotNull] PLC_Lab9_exprParser.ProgramContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="PLC_Lab9_exprParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStatement([NotNull] PLC_Lab9_exprParser.StatementContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="PLC_Lab9_exprParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpr([NotNull] PLC_Lab9_exprParser.ExprContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="PLC_Lab9_exprParser.primitiveType"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPrimitiveType([NotNull] PLC_Lab9_exprParser.PrimitiveTypeContext context);
}
} // namespace PLC_Lab8.PLC_Lab9_new.PLC_Lab9