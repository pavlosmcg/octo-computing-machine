namespace Assembler.Parsing
{
    public class InstructionTypeParser : IInstructionTypeParser
    {
        public InstructionType GetInstructionType(string instruction)
        {
            InstructionType result;

            switch (instruction[0])
            {
                case '@':
                    result = InstructionType.A;
                    break;
                case '(':
                    result = InstructionType.Label;
                    break;
                default:
                    result = InstructionType.C;
                    break;
            }

            return result;
        }
    }
}