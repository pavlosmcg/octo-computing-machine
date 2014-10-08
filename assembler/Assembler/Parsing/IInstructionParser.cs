using Assembler.Instructions;

namespace Assembler.Parsing
{
    public interface IInstructionParser
    {
        IInstruction ParseInstruction(string line);
    }
}