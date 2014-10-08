using Assembler.Instructions;

namespace Assembler.Parsing
{
    public class InstructionParser : IInstructionParser
    {
        public IInstruction ParseInstruction(string instruction)
        {
            IInstruction result;

            switch (instruction[0])
            {
                case '@':
                    result = new AddressInstruction();
                    break;
                case '(':
                    result = new LabelInstruction();
                    break;
                default:
                    result = new ComputeInstruction();
                    break;
            }

            return result;
        }
    }
}