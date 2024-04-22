using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using NotNullAttribute = Antlr4.Runtime.Misc.NotNullAttribute;

namespace PLC_Lab8
{
    public class InstructionGenerator : PLC_Lab8_exprBaseVisitor<string>
    {
        private ParseTreeProperty<Type> Types;
        private SymbolTable SymbolTable;
        private int Label {  get; set; }

        public InstructionGenerator(ParseTreeProperty<Type> types, SymbolTable symbolTable)
        {
            this.Types = types;
            this.SymbolTable = symbolTable;
            this.Label = 0;
        }

        private int NextLabel()
        {
            this.Label++;
            return this.Label - 1;
        }

        public override string VisitInt([NotNull] PLC_Lab8_exprParser.IntContext context)
        {
            var value = Convert.ToInt32(context.INT().GetText(), 10);
            return $"push I {value}\n";
        }

        public override string VisitFloat([NotNull] PLC_Lab8_exprParser.FloatContext context)
        {
            var value = (float)Convert.ToDouble(context.FLOAT().GetText());
            return $"push F {value}\n";
        }

        public override string VisitString([NotNull] PLC_Lab8_exprParser.StringContext context)
        {
            var value = context.STRING().GetText();
            return $"push S {value}\n";
        }

        public override string VisitBool([NotNull] PLC_Lab8_exprParser.BoolContext context)
        {
            var value = context.BOOL().GetText();
            return $"push B {value}\n";
        }

        public override string VisitId([NotNull] PLC_Lab8_exprParser.IdContext context)
        {
            return "load " + context.IDENTIFIER().GetText() + "\n";
        }

        public override string VisitParens([NotNull] PLC_Lab8_exprParser.ParensContext context)
        {
            return Visit(context.expr()); ;
        }

        public override string VisitPrimitiveType([NotNull] PLC_Lab8_exprParser.PrimitiveTypeContext context)
        {
            if (context.type.Text.Equals("int")) return "I";
            else if (context.type.Text.Equals("string")) return "S";
            else if (context.type.Text.Equals("bool")) return "B";
            else return "F";
        }

        public override string VisitAddSubDot([NotNull] PLC_Lab8_exprParser.AddSubDotContext context)
        {
            StringBuilder sb = new StringBuilder();

            var left = Visit(context.expr()[0]);
            var right = Visit(context.expr()[1]);

            var left_tmp = this.Types.Get(context.expr()[0]);
            var right_tmp = this.Types.Get(context.expr()[1]);

            sb.Append(left).Append(right);

            if (left_tmp == Type.Int && right_tmp == Type.Float) {
                sb.Append("itof").Append("\n");
            } else if (right_tmp == Type.Int && left_tmp == Type.Float) {
                sb.Append("itof").Append("\n");
            }

            if (context.op.Text.Equals("+")) {
                sb.Append("add").Append("\n");
            } else if (context.op.Text.Equals("-")) {
                sb.Append("sub").Append("\n");
            } else {
                sb.Append("concat").Append("\n");
            }

            return sb.ToString();
        }

        public override string VisitMulDivMod([NotNull] PLC_Lab8_exprParser.MulDivModContext context)
        {
            StringBuilder sb = new StringBuilder();

            var left = Visit(context.expr()[0]);
            var right = Visit(context.expr()[1]);


            var left_tmp = this.Types.Get(context.expr()[0]);
            var right_tmp = this.Types.Get(context.expr()[1]);

            sb.Append(left).Append(right);

            if (left_tmp == Type.Int && right_tmp == Type.Float)
            {
                sb.Append("itof").Append("\n");
            } else if (right_tmp == Type.Int && left_tmp == Type.Float)
            {
                sb.Append("itof").Append("\n");
            }

            if (context.op.Text.Equals("*")) {
                sb.Append("mul").Append("\n");
            } else if (context.op.Text.Equals("/")) {
                sb.Append("div").Append("\n");
            } else {
                sb.Append("mod").Append("\n");
            }
            return sb.ToString();
        }


        public override string VisitPrintExpr([NotNull] PLC_Lab8_exprParser.PrintExprContext context)
        {
            return Visit(context.expr());   
        }

        public override string VisitDeclaration([NotNull] PLC_Lab8_exprParser.DeclarationContext context)
        {
            StringBuilder sb = new StringBuilder();
            var type = Visit(context.primitiveType());
            foreach (var identifier in context.IDENTIFIER()) {
                switch (type) {
                    case "I":
                        sb.Append("push I 0\nsave ").Append(identifier).Append("\n");
                        break;
                    case "F":
                        sb.Append("push F 0.0\nsave ").Append(identifier).Append("\n");
                        break;
                    case "S":
                        sb.Append("push S \"\"\nsave ").Append(identifier).Append("\n");
                        break;
                    case "B":
                        sb.Append("push B false\nsave ").Append(identifier).Append("\n");
                        break;
                    default:
                        sb.Append("push ERROR\nsave ").Append(identifier).Append("\n");
                        break;
                }
            }
            return sb.ToString();
        }

        public override string VisitProgram([NotNull] PLC_Lab8_exprParser.ProgramContext context)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var stat in context.statement()) {
                var code = Visit(stat);
                if (!string.IsNullOrEmpty(code)) {
                    sb.Append(code);
                }
            }
            return sb.ToString();
        }

        public override string VisitAssignment([NotNull] PLC_Lab8_exprParser.AssignmentContext context)
        {
            StringBuilder sb = new StringBuilder();
            var value = Visit(context.expr());

            sb.Append(value);
            var symb = SymbolTable[context.IDENTIFIER().Symbol];
            if (symb.Type == Type.Float && this.Types.Get(context.expr()) == Type.Int) {
                sb.Append("itof").Append("\n");
            }
            sb.Append("save ").Append(context.IDENTIFIER().GetText()).Append("\n").Append("load ").Append(context.IDENTIFIER().GetText()).Append("\n");
            if (context.Parent.GetType() == typeof(PLC_Lab8_exprParser.PrintExprContext)) {
                sb.Append("pop").Append("\n");
            }
            return sb.ToString();
        }

        public override string VisitWriteExpr([NotNull] PLC_Lab8_exprParser.WriteExprContext context)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var expr in context.expr()) {
                string exprr = Visit(expr);
                if (!string.IsNullOrEmpty(exprr)) {
                    sb.Append(exprr);
                }

            }
            sb.Append("print ").Append(context.expr().Length).Append("\n");
            return sb.ToString();
        }

        public override string VisitReadExpr([NotNull] PLC_Lab8_exprParser.ReadExprContext context)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var identifier in context.IDENTIFIER()) {
                //string exprr = Visit(expr);
                var token = identifier.Symbol;
                var type = this.SymbolTable[token];

                if (type.Type == Type.Int) {
                    sb.Append("read ").Append("I").Append("\n");
                } else if (type.Type == Type.Float) {
                    sb.Append("read ").Append("F").Append("\n");
                } else if (type.Type == Type.Bool) {
                    sb.Append("read ").Append("B").Append("\n");
                } else {
                    sb.Append("read ").Append("S").Append("\n");
                }

                sb.Append("save ").Append(identifier).Append("\n");
            }
            return sb.ToString();
        }

        public override string VisitGtLtEquNotEqu([NotNull] PLC_Lab8_exprParser.GtLtEquNotEquContext context)
        {
            StringBuilder sb = new StringBuilder();
            var left = Visit(context.expr()[0]);
            var right = Visit(context.expr()[1]);

            var left_tmp = this.Types.Get(context.expr()[0]);
            var right_tmp = this.Types.Get(context.expr()[1]);


            sb.Append(left);
            if (left_tmp == Type.Int && right_tmp == Type.Float)
            {
                sb.Append("itof").Append("\n");
            }

            sb.Append(right);
            if (right_tmp == Type.Int && left_tmp == Type.Float)
            {
                sb.Append("itof").Append("\n");
            }

            if (context.op.Text.Equals(">")) {
                sb.Append("gt").Append("\n");
            } else if (context.op.Text.Equals("<")) {
                sb.Append("lt").Append("\n");
            } else if (context.op.Text.Equals("==")) {
                sb.Append("eq").Append("\n");
            } else {
                sb.Append("eq").Append("\n").Append("not").Append("\n");
            }

            return sb.ToString();
        }

        public override string VisitAndOr([NotNull] PLC_Lab8_exprParser.AndOrContext context)
        {
            StringBuilder sb = new StringBuilder();
            var left = Visit(context.expr()[0]);
            var right = Visit(context.expr()[1]);

            if (context.op.Text.Equals("&&")) {
                sb.Append(left).Append(right).Append("and\n");
            } else {
                sb.Append(left).Append(right).Append("or\n");
            }

            return sb.ToString();
        }

        public override string VisitIfExpr([NotNull] PLC_Lab8_exprParser.IfExprContext context)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(Visit(context.expr()));
            sb.Append("fjmp ").Append(NextLabel()).Append("\n");
            sb.Append(Visit(context.statement(0)));
            sb.Append("jmp ").Append(NextLabel()).Append("\n");
            sb.Append("label ").Append(this.Label - 2).Append("\n");
            if (context.statement(1) != null) {
                sb.Append(Visit(context.statement()[1]));
            }
            sb.Append("label ").Append(this.Label - 1).Append("\n");

            return sb.ToString();
        }

        public override string VisitParens1([NotNull] PLC_Lab8_exprParser.Parens1Context context)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var stat in context.statement()) {
                var code = Visit(stat);
                if (!string.IsNullOrEmpty(code)) {
                    sb.Append(code);
                }
            }
            return sb.ToString();
        }

        public override string VisitUnarySub([NotNull] PLC_Lab8_exprParser.UnarySubContext context)
        {
            var expr = Visit(context.expr());
            return expr.ToString() + "uminus\n";
        }

        public override string VisitBang([NotNull] PLC_Lab8_exprParser.BangContext context)
        {
            var expr = Visit(context.expr());
            return expr.ToString() + "not\n";
        }

        public override string VisitWhileExpr([NotNull] PLC_Lab8_exprParser.WhileExprContext context)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("label ").Append(NextLabel()).Append("\n");
            sb.Append(Visit(context.expr()));
            sb.Append("fjmp ").Append(NextLabel()).Append("\n");
            sb.Append(Visit(context.statement()));
            sb.Append("jmp ").Append(this.Label - 2).Append("\n");
            sb.Append("label ").Append(this.Label - 1).Append("\n");

            return sb.ToString();
        }
    }
}
