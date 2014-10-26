using System;
using System.Collections.Generic;
using System.Linq;
using Assembler.Instructions;

namespace Assembler.SymbolResolution.Hack
{
    public class HackLabelResolver : ILabelResolver
    {
        public IInstruction[] ResolveLabels(IDictionary<string, int> symbolTable, IEnumerable<IInstruction> instructions)
        {
            // figure out whether it's a label
            // if it's a label
            // -- if it doesn't exist add it to the table and remove the instruction
            // -- if it does already exist, change it to an unknown instruction
            var list = instructions.ToList();
            for (int line = 0; line < list.Count(); line++)
            {
                if (list[line] is LabelInstruction)
                {
                    var labelInstruction = (LabelInstruction) list[line];
                    int lineNumber;
                    if (!symbolTable.TryGetValue(labelInstruction.Label, out lineNumber))
                    {
                        lineNumber = line + 1; // get the number of the next line in the assembled program
                        symbolTable.Add(labelInstruction.Label, lineNumber);
                        list.RemoveAt(line);
                        return ResolveLabels(symbolTable, list); // recursively continue with the rest of the program to be assembled
                    }
                    list[line] = new UnknownInstruction(String.Format("Label '{0}' is not allowed or is defined more than once", labelInstruction.Label));
                }
            }

            return list.ToArray();
        }
    }
}