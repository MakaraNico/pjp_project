using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PLC_Lab8
{
    public class VirtualMachine
    {
        private Stack<object> stack = new Stack<object>();
        private List<string[]> code = new List<string[]>();
        Dictionary<string, object> memory = new Dictionary<string, object>();

        public VirtualMachine(string code)
        {
            //this.code = code.Split("\n\r".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(x => x.Split(" ")).ToList();
            this.code = code.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                     .Select(line => SplitIgnoringQuotes(line))
                     .ToList();
        }

        private string[] SplitIgnoringQuotes(string input)
        {
            var matches = Regex.Matches(input, @"[^\s""']+|""([^""]*)""|'([^']*)'");
            return matches.Cast<Match>().Select(m => m.Groups[1].Value != "" ? m.Groups[1].Value : m.Groups[2].Value != "" ? m.Groups[2].Value : m.Value).ToArray();
        }

        public void Run()
        {
            for (int i = 0; i < this.code.Count; i++) {
                if (this.code[i][0].StartsWith("push")) {
                    if (this.code[i][1] == "I") {
                        stack.Push(int.Parse(this.code[i][2]));
                    } else if (this.code[i][1] == "F") {
                        stack.Push(float.Parse(this.code[i][2]));
                    } else if (this.code[i][1] == "B") {
                        stack.Push(bool.Parse(this.code[i][2]));
                    } else {
                        stack.Push(this.code[i][2].ToString());
                    }
                } else if (this.code[i][0].Equals("print")) {
                    int print_num = int.Parse(this.code[i][1]);
                    string s = "";
                    for (int j = 0; j < print_num; j++)
                    {
                        s = stack.Pop().ToString() + s;
                    }
                    Console.WriteLine(s);
                } else if (this.code[i][0].Equals("save")) {
                    var value = stack.Pop();
                    memory[this.code[i][1]] = value;
                } else if (this.code[i][0].Equals("load")) {
                    stack.Push(memory[this.code[i][1]]);
                } else if (this.code[i][0].Equals("pop")) {
                    stack.Pop();
                } else if (this.code[i][0].Equals("uminus")) {
                    var value = stack.Pop();
                    if (typeof(int) == value.GetType()) {
                        stack.Push((int)value * (-1));
                    } else if (typeof(float) == value.GetType()) {
                        float f = -1;
                        stack.Push(Convert.ToSingle(value) * f);
                    }
                } else if (this.code[i][0].Equals("itof")) {
                    var value = stack.Pop();
                    if (value.GetType() == typeof(int)) {
                        stack.Push(Convert.ToSingle(value));
                    }
                } else if (this.code[i][0].Equals("read")) {

                    /*
                    using(StreamReader std_in_file = new StreamReader("stdin.txt")) {
                        Console.SetIn(std_in_file);
                        string input_line;
                        while((input_line = std_in_file.ReadLine()) != null) {
                            Console.WriteLine(input_line);

                        }
                    }
                    */

                    var read = Console.ReadLine();
                    if (this.code[i][1].Equals("I")) {
                        this.stack.Push(Convert.ToInt32(read));
                    } else if (this.code[i][1].Equals("F")) {
                        this.stack.Push((float)Convert.ToDouble(read));
                    } else if (this.code[i][1].Equals("S")) {
                        this.stack.Push(read.ToString());
                    } else {
                        this.stack.Push(Convert.ToBoolean(read));
                    }


                } else if (this.code[i][0].Equals("not")) {
                    var value = stack.Pop();
                    if (value.GetType() == typeof(bool)) {
                        stack.Push(!(bool)value);
                    }
                } else if (this.code[i][0].Equals("fjmp")) {
                    var value = stack.Pop();
                    if (value is bool) {
                        if ((bool)value == false) {
                            for (int j = 0; j < this.code.Count; j++) {
                                if (this.code[j].Length > 1) {
                                    if (this.code[j][0].Equals("label") && this.code[j][1] == this.code[i][1]) {
                                        i = j; break;
                                    }
                                }
                            }
                        }
                    }
                } else if (this.code[i][0].Equals("jmp")) {
                    for (int j = 0; j < this.code.Count; j++) {
                        if (this.code[j].Length > 1) {
                            if (this.code[j][0].Equals("label") && this.code[j][1] == this.code[i][1]) {
                                i = j; break;
                            }
                        }
                    }
                } else if (this.code[i][0].Equals("label")) {
                    continue;
                } else {
                    var right = stack.Pop();
                    var left = stack.Pop();
                    switch (this.code[i][0])
                    {
                        case "add" when left is int && right is int: stack.Push((int)left + (int)right); break;
                        case "add": stack.Push((float)(left is int ? (int)left : (float)left) + (float)(right is int ? (int)right : (float)right)); break;
                        case "sub" when left is int && right is int: stack.Push((int)left - (int)right); break;
                        case "sub": stack.Push((float)(left is int ? (int)left : (float)left) - (float)(right is int ? (int)right : (float)right)); break;
                        case "div" when left is int && right is int: stack.Push((int)left / (int)right); break;
                        case "div": stack.Push((float)(left is int ? (int)left : (float)left) / (float)(right is int ? (int)right : (float)right)); break;
                        case "mul" when left is int && right is int: stack.Push((int)left * (int)right); break;
                        case "mul": stack.Push((float)(left is int ? (int)left : (float)left) * (float)(right is int ? (int)right : (float)right)); break;
                        case "mod": stack.Push((int)left % (int)right); break;
                        case "concat": stack.Push((string)left + (string)right); break;
                        case "lt" when left is int && right is int: stack.Push((int)left < (int)right); break;
                        case "lt": stack.Push((float)(left is int ? (int)left : (float)left) < (float)(right is int ? (int)right : (float)right)); break;
                        case "gt" when left is int && right is int: stack.Push((int)left > (int)right); break;
                        case "gt": stack.Push((float)(left is int ? (int)left : (float)left) > (float)(right is int ? (int)right : (float)right)); break;
                        case "eq" when left is string && right is string: stack.Push(left.Equals(right)); break;
                        case "eq": stack.Push(left == right); break;
                        case "and" when left is bool && right is bool: stack.Push((bool)left && (bool)right); break;
                        case "or" when left is bool && right is bool: stack.Push((bool)left || (bool)right); break;
                    }

                }
            }
        }
    }
}
