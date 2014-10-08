using Assembler.Instructions;

namespace Assembler.Parsing
{
    public interface ILineParser
    {
        IInstruction ParseInstruction(string line);
    }
}