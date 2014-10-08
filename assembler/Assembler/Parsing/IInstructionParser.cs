using Assembler.Instructions;

namespace Assembler.Parsing
{
    public interface IInstructionParser
    {
        /// <returns>An instruction struct of the type that this parser specialises in. 
        /// Returns an <see cref="UnknownInstruction"/> if the line cannot be understood by this parser</returns>
        IInstruction ParseInstruction(string line);
    }
}