using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLC_Lab8
{
    class TypeChecker : PLC_Lab8_exprBaseListener
    {
        public SymbolTable SymbolTable { get; } = new SymbolTable();
        public ParseTreeProperty<Type> Types { get; } = new ParseTreeProperty<Type>();


        public override void ExitDeclaration([NotNull] PLC_Lab8_exprParser.DeclarationContext context)
        {
            var type = Types.Get(context.primitiveType());
            foreach (var identifier in context.IDENTIFIER())
            {
                SymbolTable.Add(identifier.Symbol, type);
            }
        }

        public override void ExitPrimitiveType([NotNull] PLC_Lab8_exprParser.PrimitiveTypeContext context)
        {
            if (context.type.Text.Equals("int")) {
                Types.Put(context, Type.Int);
            } else if (context.type.Text.Equals("float")) {
                Types.Put(context, Type.Float);
            } else if (context.type.Text.Equals("bool")) {
                Types.Put(context, Type.Bool);
            } else if (context.type.Text.Equals("string")) {
                Types.Put(context, Type.String);
            } else {
                Types.Put(context, Type.Error);
            }
        }

        public override void ExitInt([NotNull] PLC_Lab8_exprParser.IntContext context)
        {
            Types.Put(context, Type.Int);
        }

        public override void ExitFloat([NotNull] PLC_Lab8_exprParser.FloatContext context)
        {
            Types.Put(context, Type.Float);
        }

        public override void ExitBool([NotNull] PLC_Lab8_exprParser.BoolContext context)
        {
            Types.Put(context, Type.Bool);
        }

        public override void ExitString([NotNull] PLC_Lab8_exprParser.StringContext context)
        {
            Types.Put(context, Type.String);
        }

        public override void ExitId([NotNull] PLC_Lab8_exprParser.IdContext context)
        {
            var tmp = SymbolTable[context.IDENTIFIER().Symbol];
            Types.Put(context, tmp.Type);
        }

        public override void ExitParens([NotNull] PLC_Lab8_exprParser.ParensContext context)
        {
            Types.Put(context, Types.Get(context.expr()));
        }

        public override void ExitMulDivMod([NotNull] PLC_Lab8_exprParser.MulDivModContext context)
        {
            string oper = context.op.Text;
            var left = this.Types.Get(context.expr()[0]);
            var right = this.Types.Get(context.expr()[1]);

            if (left == Type.Error || right == Type.Error) {
                Types.Put(context, Type.Error);
                return;
            }

            if (context.op.Type == PLC_Lab8_exprParser.MOD) {
                if (left == Type.Float || right == Type.Float) {
                    Errors.ReportError(context.MOD().Symbol, $"Operator {context.MOD().GetText()} can be used only with integers.");
                    Types.Put(context, Type.Error);
                    return;
                } else {
                    Types.Put(context, Type.Int);
                }
            }

            if (left == Type.Float || right == Type.Float) {
                Types.Put(context, Type.Float);
            } else {
                Types.Put(context, Type.Int);
            }
        }

        public override void ExitAddSubDot([NotNull] PLC_Lab8_exprParser.AddSubDotContext context)
        {
            var left = Types.Get(context.expr()[0]);
            var right = Types.Get(context.expr()[1]);
            if (left == Type.Error || right == Type.Error) {
                Types.Put(context, Type.Error);
                return;
            }

            if (left == Type.Float || right == Type.Float) {
                Types.Put(context, Type.Float);
            } else if (left == Type.Int && right == Type.Int) {
                Types.Put(context, Type.Int);
            } else if (left == Type.String && right == Type.String) {
                if (context.op.Type == PLC_Lab8_exprParser.ADD) {
                    Errors.ReportError(context.ADD().Symbol, $"Operator {context.ADD().GetText()} can not be used with string type");
                    Types.Put(context, Type.Error);
                } else if (context.op.Type == PLC_Lab8_exprParser.SUB) {
                    Errors.ReportError(context.SUB().Symbol, $"Operator {context.SUB().GetText()} can not be used with string type");
                    Types.Put(context, Type.Error);                    
                } else {
                    Types.Put(context, Type.String);
                }
            } else if ((left == Type.String && right != Type.String) || (left != Type.String && right == Type.String)) {
                if (context.op.Type == PLC_Lab8_exprParser.ADD) {
                    Errors.ReportError(context.ADD().Symbol, $"Operator {context.ADD().GetText()} can not be used with string type");
                    Types.Put(context, Type.Error);
                } else if (context.op.Type == PLC_Lab8_exprParser.SUB) {
                    Errors.ReportError(context.SUB().Symbol, $"Operator {context.SUB().GetText()} can not be used with string type");
                    Types.Put(context, Type.Error);
                } else {
                    Errors.ReportError(context.DOT().Symbol, $"Operator {context.DOT().GetText()} can be only used with string type");
                    Types.Put(context, Type.Error);
                }
            } else {
                Types.Put(context, Type.Error);
            }
        }

        public override void ExitAssignment([NotNull] PLC_Lab8_exprParser.AssignmentContext context)
        {
            var right = Types.Get(context.expr());
            var variable = SymbolTable[context.IDENTIFIER().Symbol];
            if (variable.Type == Type.Error || right == Type.Error) {
                Types.Put(context, Type.Error);
            }
            else if (variable.Type == Type.Int && right == Type.Float) {
                Errors.ReportError(context.IDENTIFIER().Symbol, $"Variable '{context.IDENTIFIER().GetText()}' type is int, but the assigned value is float.");
                Types.Put(context, Type.Error);
            }
            else {
                Types.Put(context, variable.Type);
            }
        }

        public override void ExitAndOr([NotNull] PLC_Lab8_exprParser.AndOrContext context)
        {
            var left = Types.Get(context.expr()[0]);
            var right = Types.Get(context.expr()[1]);

            if (left == Type.Bool && right == Type.Bool) {
                Types.Put(context, Type.Bool);
            } else {
                // error report
                Types.Put(context, Type.Error);
            }
        }

        public override void ExitUnarySub([NotNull] PLC_Lab8_exprParser.UnarySubContext context)
        {
            var type = Types.Get(context.expr());
            if (type == Type.Int || type == Type.Float) {
                Types.Put(context, type);
            } else {
                // error report
                Types.Put(context, Type.Error);
            }
        }

        public override void ExitGtLtEquNotEqu([NotNull] PLC_Lab8_exprParser.GtLtEquNotEquContext context)
        {
            var left = Types.Get(context.expr()[0]);
            var right = Types.Get(context.expr()[1]);

            if ((left == Type.Int || left == Type.Float) && (right == Type.Int || right == Type.Float)) {
                Types.Put(context, Type.Bool);
            } else if (left == Type.String && right == Type.String) {
                if (context.op.Type == PLC_Lab8_exprParser.EQUAL || context.op.Type == PLC_Lab8_exprParser.NOTEQUAL) {
                    Types.Put(context, Type.Bool);
                } else {
                    // report error
                    Types.Put(context, Type.Error);
                }
            } else {
                // error report
                Types.Put(context, Type.Error);
            }
        }

        public override void ExitIfExpr([NotNull] PLC_Lab8_exprParser.IfExprContext context)
        {
            var type = Types.Get(context.expr());
            if (type != Type.Bool)
            {
                Types.Put(context, Type.Error);
            }
        }

        public override void ExitWhileExpr([NotNull] PLC_Lab8_exprParser.WhileExprContext context)
        {
            var type = Types.Get(context.expr());
            if (type != Type.Bool)
            {
                Types.Put(context, Type.Error);
            }
        }

    }
}
