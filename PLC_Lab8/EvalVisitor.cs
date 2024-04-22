using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLC_Lab8
{
    public class EvalVisitor : PLC_Lab8_exprBaseVisitor<(Type Type,object Value)>
    {
        SymbolTable symbolTable = new SymbolTable();

        private float ToFloat(object value)
        {
            if (value is int x) return (float)x;
            return (float)value;
        }

        private bool ToBool(object value)
        {
            return bool.TryParse(value.ToString(), out bool result);
        }

        public override (Type Type, object Value) VisitProgram([NotNull] PLC_Lab8_exprParser.ProgramContext context)
        {
            foreach (var statement in context.statement())
            {
                Visit(statement);
            }
            return (Type.Error, 0);
        }

        public override (Type Type, object Value) VisitDeclaration([NotNull] PLC_Lab8_exprParser.DeclarationContext context)
        {
            var type = Visit(context.primitiveType());
            foreach (var identifier in context.IDENTIFIER())
            {
                symbolTable.Add(identifier.Symbol, type.Type);
            }
            return (Type.Error, 0);
        }

        public override (Type Type, object Value) VisitPrintExpr([NotNull] PLC_Lab8_exprParser.PrintExprContext context)
        {
            var value = Visit(context.expr());
            if (value.Type == Type.Error)
            {
                Errors.PrintAndClearErrors();
            }
            return (Type.Error, 0);
        }

        public override (Type Type, object Value) VisitPrimitiveType([NotNull] PLC_Lab8_exprParser.PrimitiveTypeContext context)
        {
            if (context.type.Text.Equals("int")) return (Type.Int, 0);
            else if(context.type.Text.Equals("string")) return (Type.String, 0);
            else if(context.type.Text.Equals("bool")) return (Type.Bool, false);
            else return (Type.Float, 0);
        }

        public override (Type Type, object Value) VisitFloat([NotNull] PLC_Lab8_exprParser.FloatContext context)
        {
            return (Type.Float, float.Parse(context.FLOAT().GetText()));
        }

        public override (Type Type, object Value) VisitInt([NotNull] PLC_Lab8_exprParser.IntContext context)
        {
            return (Type.Int, int.Parse(context.INT().GetText()));
        }

        public override (Type Type, object Value) VisitString([NotNull] PLC_Lab8_exprParser.StringContext context)
        {
            return (Type.String, context.STRING().GetText());
        }

        public override (Type Type, object Value) VisitBool([NotNull] PLC_Lab8_exprParser.BoolContext context)
        {
            return (Type.Bool, bool.Parse(context.BOOL().GetText()));
        }

        public override (Type Type, object Value) VisitId([NotNull] PLC_Lab8_exprParser.IdContext context)
        {
            return symbolTable[context.IDENTIFIER().Symbol];
        }

        public override (Type Type, object Value) VisitParens([NotNull] PLC_Lab8_exprParser.ParensContext context)
        {
            return Visit(context.expr());
        }

        public override (Type Type, object Value) VisitAddSubDot([NotNull] PLC_Lab8_exprParser.AddSubDotContext context)
        {
            var left = Visit(context.expr()[0]);
            var right = Visit(context.expr()[1]);
            if (left.Type == Type.Error || right.Type == Type.Error) return (Type.Error, 0);
            if (left.Type == Type.Float || right.Type == Type.Float)
            {
                if (context.op.Type == PLC_Lab8_exprParser.ADD) return (Type.Float, ToFloat(left.Value) + ToFloat(right.Value));
                else return (Type.Float, ToFloat(left.Value) - ToFloat(right.Value));
            } else if (left.Type == Type.String || right.Type == Type.String)
            {
                if (context.op.Type == PLC_Lab8_exprParser.DOT)
                {
                    if (left.Type == Type.String && right.Type == Type.String)
                    {
                        return (Type.String, left.Value.ToString() + right.Value.ToString());
                    } else
                    {
                        Errors.ReportError(context.op, $"Dot used with Int or Float.");
                        return (Type.Error, 0);
                    }
                } else
                {
                    Errors.ReportError(context.op, $"Add or Sub used with string.");
                    return (Type.Error, 0);
                }
            }
            else
            {
                if (context.op.Type == PLC_Lab8_exprParser.ADD) return (Type.Int, (int)left.Value + (int)right.Value);
                else return (Type.Int, (int)left.Value - (int)right.Value);
            }
        }

        public override (Type Type, object Value) VisitMulDivMod([NotNull] PLC_Lab8_exprParser.MulDivModContext context)
        {
            var left = Visit(context.expr()[0]);
            var right = Visit(context.expr()[1]);
            if (left.Type == Type.Error || right.Type == Type.Error) return (Type.Error, 0);
            if (left.Type == Type.Float || right.Type == Type.Float)
            {
                if (context.op.Type == PLC_Lab8_exprParser.MUL)
                {
                    return (Type.Float, ToFloat(left.Value) * ToFloat(right.Value));
                }
                else if (context.op.Type == PLC_Lab8_exprParser.MOD)
                {
                    Errors.ReportError(context.op, $"Modulo used with float.");
                    return (Type.Error, 0);
                }
                else 
                {
                    return (Type.Float, ToFloat(left.Value) / ToFloat(right.Value));
                }
            }
            else
            {
                if (context.op.Type == PLC_Lab8_exprParser.MUL) return (Type.Int, (int)left.Value * (int)right.Value);
                else return (Type.Int, (int)left.Value / (int)right.Value);
            }
        }

        public override (Type Type, object Value) VisitForExpr([NotNull] PLC_Lab8_exprParser.ForExprContext context)
        {
            var cond = Visit(context.expr()[1]);
            var tmp = Visit(context.statement());
            if (tmp.Type == Type.Error) return (Type.Error, 0);
            if (cond.Type != Type.Bool)
            {
                Errors.ReportError(context.expr()[0].start, $"Expr is not bool.");
                return (Type.Error, 0);
            }
            return (Type.Error, 0);
        }

        public override (Type Type, object Value) VisitWriteExpr([NotNull] PLC_Lab8_exprParser.WriteExprContext context)
        {
            foreach (var expression in context.expr())
            {
                var res = Visit(expression);
                if (res.Type == Type.Error)
                {
                    Errors.PrintAndClearErrors();
                }
            }
            return (Type.Error, 0);
        }

        public override (Type Type, object Value) VisitGtLtEquNotEqu([NotNull] PLC_Lab8_exprParser.GtLtEquNotEquContext context)
        {
            var left = Visit(context.expr()[0]);
            var right = Visit(context.expr()[1]);
            if (left.Type == Type.Error || right.Type == Type.Error) return (Type.Error, 0);

            if (left.Type == Type.Int && right.Type == Type.Int)
            {
                if (context.op.Type == PLC_Lab8_exprParser.LT)
                {
                    if ((int)left.Value < (int)right.Value)
                    {
                        return (Type.Bool, true);
                    } else
                    {
                        return(Type.Bool, false);
                    }
                }
            }


            return (Type.Error, 0);
        }

        public override (Type Type, object Value) VisitWhileExpr([NotNull] PLC_Lab8_exprParser.WhileExprContext context)
        {
            //var value = Visit(context.expr());
            //if (value.Type != Type.Error) Console.WriteLine(value.Value);
            //else
            //{
            //    Errors.PrintAndClearErrors();
            //}
            return (Type.Error, 0);
        }

        public override (Type Type, object Value) VisitReadExpr([NotNull] PLC_Lab8_exprParser.ReadExprContext context)
        {
            //var value = Visit(context.expr());
            //if (value.Type != Type.Error) Console.WriteLine(value.Value);
            //else
            //{
            //    Errors.PrintAndClearErrors();
            //}
            return (Type.Error, 0);
        }

        public override (Type Type, object Value) VisitIfExpr([NotNull] PLC_Lab8_exprParser.IfExprContext context)
        {
            //var value = Visit(context.expr());
            //if (value.Type != Type.Error) Console.WriteLine(value.Value);
            //else
            //{
            //    Errors.PrintAndClearErrors();
            //}
            return (Type.Error, 0);
        }

        public override (Type Type, object Value) VisitAssignment([NotNull] PLC_Lab8_exprParser.AssignmentContext context)
        {
            var right = Visit(context.expr());
            var variable = symbolTable[context.IDENTIFIER().Symbol];
            if (variable.Type == Type.Error || right.Type == Type.Error) return (Type.Error, 0);
            if (variable.Type == Type.Int && right.Type == Type.Float)
            {
                Errors.ReportError(context.IDENTIFIER().Symbol, $"Variable '{context.IDENTIFIER().GetText()}' type is int, but the assigned value is float.");
                return (Type.Error, 0);
            }
            if (variable.Type == Type.Float && right.Type == Type.Int)
            {
                var value = (Type.Float, ToFloat(right.Value));
                symbolTable[context.IDENTIFIER().Symbol] = value;
                return value;
            }
            else if (variable.Type == Type.Bool)
            {
                var value = (Type.Bool, ToBool(right.Value));
                symbolTable[context.IDENTIFIER().Symbol] = value;
                return value;
            }
            else
            {
                symbolTable[context.IDENTIFIER().Symbol] = right;
                return right;
            }
        }

        /*
        public virtual Result VisitParens1([NotNull] PLC_Lab8_exprParser.Parens1Context context) { return VisitChildren(context); }
        public virtual Result VisitEmpty([NotNull] PLC_Lab8_exprParser.EmptyContext context) { return VisitChildren(context); }
        public virtual Result VisitUnarySub([NotNull] PLC_Lab8_exprParser.UnarySubContext context) { return VisitChildren(context); }
        public virtual Result VisitAndOr([NotNull] PLC_Lab8_exprParser.AndOrContext context) { return VisitChildren(context); }
        public virtual Result VisitGtLtEquNotEqu([NotNull] PLC_Lab8_exprParser.GtLtEquNotEquContext context) { return VisitChildren(context); }
        public virtual Result VisitBang([NotNull] PLC_Lab8_exprParser.BangContext context) { return VisitChildren(context); }
        public virtual Result VisitStatement([NotNull] PLC_Lab8_exprParser.StatementContext context) { return VisitChildren(context); }
        public virtual Result VisitExpr([NotNull] PLC_Lab8_exprParser.ExprContext context) { return VisitChildren(context); }
        */
        //TODO: Extend  codes here...
    }
}
