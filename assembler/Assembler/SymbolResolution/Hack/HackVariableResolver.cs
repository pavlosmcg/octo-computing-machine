using System.Collections.Generic;
using System.Linq;
using Assembler.Instructions;

namespace Assembler.SymbolResolution.Hack
{
    public class HackVariableResolver : IVariableResolver
    {
        public IInstruction[] ResolveVariables(IDictionary<string, int> symbolTable, IEnumerable<IInstruction> instructions)
        {
            var variableCounter = 15;

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
                        address = ++variableCounter; // get the next variable address
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