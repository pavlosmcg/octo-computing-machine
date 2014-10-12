using System;
using Assembler.Instructions;

namespace Assembler.Binary.Hack
{
    public class HackComputeInstructionAssembler : IInstructionAssembler<ComputeInstruction>
    {
        private readonly IHackComputeBitsAssembler _computeBitsAssembler;

        public HackComputeInstructionAssembler(IHackComputeBitsAssembler computeBitsAssembler)
        {
            _computeBitsAssembler = computeBitsAssembler;
        }

        public string[] AssembleInstruction(ComputeInstruction instruction)
        {
            // TODO string builder!

            // set compute instruction marker bits
            string output = "111";

            // set computation bits for ALU
            try
            {
                output += _computeBitsAssembler.AssembleComputeBits(instruction.Computation);
            }
            catch (Exception)
            {
                return new[] { string.Format("Error: Invalid Hack computation '{0}'", instruction.Computation) };
            }
            
            // set dest bits
            string destBits = Convert.ToString((byte)instruction.DestinationType, 2).PadLeft(3, '0');
            output += destBits;

            // set jump bits
            string jumpBits = Convert.ToString((byte) instruction.JumpType, 2).PadLeft(3, '0');
            output += jumpBits;

            return new[] { output };
        }
    }
}