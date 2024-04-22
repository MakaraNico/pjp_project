
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using System;
using System.Globalization;
using System.IO;
using System.Threading;

namespace PLC_Lab8
{
    public class Program
    {

        public static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            var fileName = "input.txt";
            Console.WriteLine("Parsing: " + fileName);
            var inputFile = new StreamReader(fileName);
            AntlrInputStream input = new AntlrInputStream(inputFile);
            PLC_Lab8_exprLexer lexer = new PLC_Lab8_exprLexer(input);
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            PLC_Lab8_exprParser parser = new PLC_Lab8_exprParser(tokens);

            parser.AddErrorListener(new VerboseListener());

            IParseTree tree = parser.program();

            if (parser.NumberOfSyntaxErrors == 0)
            {
                //Console.WriteLine(tree.ToStringTree(parser));

                //new EvalVisitor().Visit(tree);

                var type_checker = new TypeChecker();
                ParseTreeWalker walker = new ParseTreeWalker();
                walker.Walk(type_checker, tree);

                if (Errors.NumberOfErrors == 0)
                {
                    InstructionGenerator instruction_generator = new InstructionGenerator(type_checker.Types, type_checker.SymbolTable);
                    var result = instruction_generator.Visit(tree);
                    Console.WriteLine(result);

                    string output = "output.txt";
                    File.WriteAllText(output, result);

                    var input_file = File.ReadAllText("output.txt");
                    VirtualMachine vm = new VirtualMachine(input_file);
                    vm.Run();

                }
                else
                {
                    Errors.PrintAndClearErrors();
                }
            }
        }
    }
}