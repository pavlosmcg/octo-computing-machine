using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assembler.Instructions;

namespace Assembler.SymbolResolution
{
    public class SymbolResolver : ISymbolResolver
    {
        private IDictionary<string, int> symbolTable = new Dictionary<string, int>()
            {
                {"SP", 0},
                {"LCL", 1},
                {"ARG", 2},
                {"THIS", 3},
                {"THAT", 4},
                {"R0", 0},
                {"R1", 1},
                {"R2", 2},
                {"R3", 3},
                {"R4", 4},
                {"R5", 5},
                {"R6", 6},
                {"R7", 7},
                {"R8", 8},
                {"R9", 9},
                {"R10", 10},
                {"R11", 11},
                {"R12", 12},
                {"R13", 13},
                {"R14", 14},
                {"R15", 15},
                {"SCREEN", 16384},
                {"KBD", 24576}
            };

        private int _variableCounter = 15;

        public IInstruction[] ResolveSymbolicInstructions(IInstruction[] instructions)
        {
            // must go through labels first, removing them when they've been added to the symbol table!
            var linesWithLabelsRemoved = ResolveLabels(instructions);

            // then go through variables, resolving them after adding to table if not already there
            return ResolveVariables(linesWithLabelsRemoved);
        }

        private IInstruction[] ResolveLabels(IEnumerable<IInstruction> instructions)
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
                        return ResolveLabels(list); // recursively continue with the rest of the program to be assembled
                    }
                    list[line] = new UnknownInstruction(string.Format("Label '{0}' is not allowed or is defined more than once", labelInstruction.Label));
                }
            }

            return list.ToArray();
        }

        private IInstruction[] ResolveVariables(IEnumerable<IInstruction> instructions)
        {
            var list = instructions.ToList();
            for (var line = 0; line < list.Count(); line++)
            {
                if (list[line] is VariableInstruction)
                {
                    var variableInstruction = (VariableInstruction) list[line];
                    int address;

                    // if it's not in the symbol table, add the variable
                    if (!symbolTable.TryGetValue(variableInstruction.Label, out address))
                    {
                        address = ++_variableCounter; // get the next variable address
                        symbolTable.Add(variableInstruction.Label, address);
                    }

                    // convert this variable instruction into a resolved address instruction
                    list[line] = new AddressInstruction(address);
                }
            }

            return list.ToArray();
        }
    }
}