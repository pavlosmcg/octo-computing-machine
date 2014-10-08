namespace Assembler.Instructions
{
    public interface IInstruction
    {
        void Accept<T>(IInstructionVisitor<T> instructionVisitor);
    }
}