using Assembler.Instructions;

namespace Assembler.Parsing
{
    public class LineParser : ILineParser
    {
        public IInstruction ParseInstruction(string line)
        {
            IInstruction result;

            switch (line[0])
            {
                case '@':
                    result = new AddressInstruction();
                    break;
                case '(':
                    result = new LabelInstruction();
                    break;
                default:
                    result = new ComputeInstruction();
                    break;
            }

            return result;
        }
    }
}