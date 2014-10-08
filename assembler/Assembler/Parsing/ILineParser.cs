using Assembler.Instructions;

namespace Assembler.Parsing
{
    public interface ILineParser
    {
        IInstruction ParseLine(string line);
    }
}