using System.Linq;
using Assembler.Parsing;
using Assembler.Sanitising;

namespace Assembler
{
    public class Assembler : IAssembler
    {
        private readonly ISanitiser _sanitiser;
        private readonly IInstructionParser _instructionParser;

        public Assembler(ISanitiser sanitiser, IInstructionParser instructionParser)
        {
            _sanitiser = sanitiser;
            _instructionParser = instructionParser;
        }

        public string[] Assemble(string[] lines)
        {
            // get the array of lines cleaned up before parsing
            var cleanLines = _sanitiser.Sanitise(lines);

            // parse each line into its instruction type
            var instructions = cleanLines.Select(line => _instructionParser.ParseInstruction(line)).ToList();

            return cleanLines;
        }
    }
}