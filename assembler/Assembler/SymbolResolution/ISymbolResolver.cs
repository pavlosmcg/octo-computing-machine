using Assembler.Instructions;

namespace Assembler.SymbolResolution
{
    public interface ISymbolResolver
    {
        IInstruction[] ResolveSymbolicInstructions(IInstruction[] instructions);
    }
}