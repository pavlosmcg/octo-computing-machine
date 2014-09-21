using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembler
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args == null || args.Length == 0)
            {
                Console.WriteLine("Please specifiy a file path");
                return;
            }

            var assember = new Assembler();

            string[] lines = System.IO.File.ReadAllLines(args[0]);
            string[] assembledLines = assember.Assemble(lines);

            foreach (var line in assembledLines)
            {
                Console.WriteLine(line);
            }
        }
    }
}
