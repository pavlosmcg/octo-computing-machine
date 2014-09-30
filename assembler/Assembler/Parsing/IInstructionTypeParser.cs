namespace Assembler.Parsing
{
    public interface IInstructionTypeParser
    {
        InstructionType GetInstructionType(string instruction);
    }
}