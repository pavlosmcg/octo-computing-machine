namespace Assembler.Instructions
{
    public interface IInstructionVisitor<T>
    {
        T VisitInstruction(IInstruction instruction);
    }
}