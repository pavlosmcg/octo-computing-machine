using Assembler.Instructions;

namespace Assembler.Parsing
{
    public class LineParser : ILineParser
    {
        private readonly IInstructionParser[] _instructionParsers;

        public LineParser(IInstructionParser[] instructionParsers)
        {
            _instructionParsers = instructionParsers;
        }

        public IInstruction ParseLine(string line)
        {
            IInstruction result = new UnknownInstruction();

            foreach (IInstructionParser instructionParser in _instructionParsers)
            {
                result = instructionParser.ParseInstruction(line);
                if (result.GetType() != typeof (UnknownInstruction))
                    break;
            }

            return result;
        }
    }
}