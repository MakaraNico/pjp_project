//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.6.6
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from C:\Users\render\Desktop\skola\skola_sesty_semestr\pjp\pjp_project-master\PLC_Lab8\PLC_Lab8_expr.g4 by ANTLR 4.6.6

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace PLC_Lab8 {
using Antlr4.Runtime.Misc;
using IParseTreeListener = Antlr4.Runtime.Tree.IParseTreeListener;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete listener for a parse tree produced by
/// <see cref="PLC_Lab8_exprParser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.6.6")]
[System.CLSCompliant(false)]
public interface IPLC_Lab8_exprListener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by the <c>writeExpr</c>
	/// labeled alternative in <see cref="PLC_Lab8_exprParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterWriteExpr([NotNull] PLC_Lab8_exprParser.WriteExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>writeExpr</c>
	/// labeled alternative in <see cref="PLC_Lab8_exprParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitWriteExpr([NotNull] PLC_Lab8_exprParser.WriteExprContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>forExpr</c>
	/// labeled alternative in <see cref="PLC_Lab8_exprParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterForExpr([NotNull] PLC_Lab8_exprParser.ForExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>forExpr</c>
	/// labeled alternative in <see cref="PLC_Lab8_exprParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitForExpr([NotNull] PLC_Lab8_exprParser.ForExprContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>whileExpr</c>
	/// labeled alternative in <see cref="PLC_Lab8_exprParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterWhileExpr([NotNull] PLC_Lab8_exprParser.WhileExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>whileExpr</c>
	/// labeled alternative in <see cref="PLC_Lab8_exprParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitWhileExpr([NotNull] PLC_Lab8_exprParser.WhileExprContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>readExpr</c>
	/// labeled alternative in <see cref="PLC_Lab8_exprParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterReadExpr([NotNull] PLC_Lab8_exprParser.ReadExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>readExpr</c>
	/// labeled alternative in <see cref="PLC_Lab8_exprParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitReadExpr([NotNull] PLC_Lab8_exprParser.ReadExprContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>ifExpr</c>
	/// labeled alternative in <see cref="PLC_Lab8_exprParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIfExpr([NotNull] PLC_Lab8_exprParser.IfExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>ifExpr</c>
	/// labeled alternative in <see cref="PLC_Lab8_exprParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIfExpr([NotNull] PLC_Lab8_exprParser.IfExprContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>declaration</c>
	/// labeled alternative in <see cref="PLC_Lab8_exprParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDeclaration([NotNull] PLC_Lab8_exprParser.DeclarationContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>declaration</c>
	/// labeled alternative in <see cref="PLC_Lab8_exprParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDeclaration([NotNull] PLC_Lab8_exprParser.DeclarationContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>parens1</c>
	/// labeled alternative in <see cref="PLC_Lab8_exprParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterParens1([NotNull] PLC_Lab8_exprParser.Parens1Context context);
	/// <summary>
	/// Exit a parse tree produced by the <c>parens1</c>
	/// labeled alternative in <see cref="PLC_Lab8_exprParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitParens1([NotNull] PLC_Lab8_exprParser.Parens1Context context);

	/// <summary>
	/// Enter a parse tree produced by the <c>printExpr</c>
	/// labeled alternative in <see cref="PLC_Lab8_exprParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPrintExpr([NotNull] PLC_Lab8_exprParser.PrintExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>printExpr</c>
	/// labeled alternative in <see cref="PLC_Lab8_exprParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPrintExpr([NotNull] PLC_Lab8_exprParser.PrintExprContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>empty</c>
	/// labeled alternative in <see cref="PLC_Lab8_exprParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterEmpty([NotNull] PLC_Lab8_exprParser.EmptyContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>empty</c>
	/// labeled alternative in <see cref="PLC_Lab8_exprParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitEmpty([NotNull] PLC_Lab8_exprParser.EmptyContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>mulDivMod</c>
	/// labeled alternative in <see cref="PLC_Lab8_exprParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterMulDivMod([NotNull] PLC_Lab8_exprParser.MulDivModContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>mulDivMod</c>
	/// labeled alternative in <see cref="PLC_Lab8_exprParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitMulDivMod([NotNull] PLC_Lab8_exprParser.MulDivModContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>parens</c>
	/// labeled alternative in <see cref="PLC_Lab8_exprParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterParens([NotNull] PLC_Lab8_exprParser.ParensContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>parens</c>
	/// labeled alternative in <see cref="PLC_Lab8_exprParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitParens([NotNull] PLC_Lab8_exprParser.ParensContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>bool</c>
	/// labeled alternative in <see cref="PLC_Lab8_exprParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBool([NotNull] PLC_Lab8_exprParser.BoolContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>bool</c>
	/// labeled alternative in <see cref="PLC_Lab8_exprParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBool([NotNull] PLC_Lab8_exprParser.BoolContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>string</c>
	/// labeled alternative in <see cref="PLC_Lab8_exprParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterString([NotNull] PLC_Lab8_exprParser.StringContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>string</c>
	/// labeled alternative in <see cref="PLC_Lab8_exprParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitString([NotNull] PLC_Lab8_exprParser.StringContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>assignment</c>
	/// labeled alternative in <see cref="PLC_Lab8_exprParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAssignment([NotNull] PLC_Lab8_exprParser.AssignmentContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>assignment</c>
	/// labeled alternative in <see cref="PLC_Lab8_exprParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAssignment([NotNull] PLC_Lab8_exprParser.AssignmentContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>unarySub</c>
	/// labeled alternative in <see cref="PLC_Lab8_exprParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterUnarySub([NotNull] PLC_Lab8_exprParser.UnarySubContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>unarySub</c>
	/// labeled alternative in <see cref="PLC_Lab8_exprParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitUnarySub([NotNull] PLC_Lab8_exprParser.UnarySubContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>float</c>
	/// labeled alternative in <see cref="PLC_Lab8_exprParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFloat([NotNull] PLC_Lab8_exprParser.FloatContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>float</c>
	/// labeled alternative in <see cref="PLC_Lab8_exprParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFloat([NotNull] PLC_Lab8_exprParser.FloatContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>int</c>
	/// labeled alternative in <see cref="PLC_Lab8_exprParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterInt([NotNull] PLC_Lab8_exprParser.IntContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>int</c>
	/// labeled alternative in <see cref="PLC_Lab8_exprParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitInt([NotNull] PLC_Lab8_exprParser.IntContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>andOr</c>
	/// labeled alternative in <see cref="PLC_Lab8_exprParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAndOr([NotNull] PLC_Lab8_exprParser.AndOrContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>andOr</c>
	/// labeled alternative in <see cref="PLC_Lab8_exprParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAndOr([NotNull] PLC_Lab8_exprParser.AndOrContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>gtLtEquNotEqu</c>
	/// labeled alternative in <see cref="PLC_Lab8_exprParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterGtLtEquNotEqu([NotNull] PLC_Lab8_exprParser.GtLtEquNotEquContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>gtLtEquNotEqu</c>
	/// labeled alternative in <see cref="PLC_Lab8_exprParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitGtLtEquNotEqu([NotNull] PLC_Lab8_exprParser.GtLtEquNotEquContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>bang</c>
	/// labeled alternative in <see cref="PLC_Lab8_exprParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBang([NotNull] PLC_Lab8_exprParser.BangContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>bang</c>
	/// labeled alternative in <see cref="PLC_Lab8_exprParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBang([NotNull] PLC_Lab8_exprParser.BangContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>addSubDot</c>
	/// labeled alternative in <see cref="PLC_Lab8_exprParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAddSubDot([NotNull] PLC_Lab8_exprParser.AddSubDotContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>addSubDot</c>
	/// labeled alternative in <see cref="PLC_Lab8_exprParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAddSubDot([NotNull] PLC_Lab8_exprParser.AddSubDotContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>id</c>
	/// labeled alternative in <see cref="PLC_Lab8_exprParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterId([NotNull] PLC_Lab8_exprParser.IdContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>id</c>
	/// labeled alternative in <see cref="PLC_Lab8_exprParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitId([NotNull] PLC_Lab8_exprParser.IdContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="PLC_Lab8_exprParser.program"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterProgram([NotNull] PLC_Lab8_exprParser.ProgramContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PLC_Lab8_exprParser.program"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitProgram([NotNull] PLC_Lab8_exprParser.ProgramContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="PLC_Lab8_exprParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStatement([NotNull] PLC_Lab8_exprParser.StatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PLC_Lab8_exprParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStatement([NotNull] PLC_Lab8_exprParser.StatementContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="PLC_Lab8_exprParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExpr([NotNull] PLC_Lab8_exprParser.ExprContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PLC_Lab8_exprParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExpr([NotNull] PLC_Lab8_exprParser.ExprContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="PLC_Lab8_exprParser.primitiveType"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPrimitiveType([NotNull] PLC_Lab8_exprParser.PrimitiveTypeContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PLC_Lab8_exprParser.primitiveType"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPrimitiveType([NotNull] PLC_Lab8_exprParser.PrimitiveTypeContext context);
}
} // namespace PLC_Lab8
