using Assembler.Instructions;

namespace Assembler.Parsing
{
    public class ComputeInstructionParser : IInstructionParser
    {
        public IInstruction ParseInstruction(string line)
        {
            if (!(line.Contains("=") || line.Contains(";")))
                return new UnknownInstruction(line);

            return new ComputeInstruction();
        }
    }
}