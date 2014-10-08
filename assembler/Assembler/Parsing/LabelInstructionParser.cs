using Assembler.Instructions;

namespace Assembler.Parsing
{
    public class LabelInstructionParser : IInstructionParser
    {
        public IInstruction ParseInstruction(string line)
        {
            if (!line.StartsWith("("))
                return new UnknownInstruction(line);

            return new LabelInstruction();
        }
    }
}