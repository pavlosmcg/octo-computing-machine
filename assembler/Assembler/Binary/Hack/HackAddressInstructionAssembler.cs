using System;
using Assembler.Instructions;

namespace Assembler.Binary.Hack
{
    public class HackAddressInstructionAssembler : IInstructionAssembler<AddressInstruction>
    {
        public string[] AssembleInstruction(AddressInstruction instruction)
        {
            string output = Convert.ToString(instruction.Address, 2).PadLeft(16, '0');
            
            //TODO ensure this always starts with zero

            return new[] { output };
        }
    }
}