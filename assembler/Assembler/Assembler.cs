using System.Linq;
using Assembler.Binary;
using Assembler.Parsing;
using Assembler.Sanitising;

namespace Assembler
{
    public class Assembler : IAssembler
    {
        private readonly ISanitiser _sanitiser;
        private readonly IInstructionParser _instructionParser;
        private readonly IBinaryAssembler _binaryAssembler;

        public Assembler(ISanitiser sanitiser, IInstructionParser instructionParser, IBinaryAssembler binaryAssembler)
        {
            _sanitiser = sanitiser;
            _instructionParser = instructionParser;
            _binaryAssembler = binaryAssembler;
        }

        public string[] Assemble(string[] lines)
        {
            // get the array of lines cleaned up before parsing
            var cleanLines = _sanitiser.Sanitise(lines);

            // parse each line into its instruction type
            var instructions = cleanLines.Select(l => _instructionParser.ParseInstruction(l)).ToArray();

            // assemble each instruction into binary line(s)
            var assembledLines = instructions.SelectMany(i => _binaryAssembler.AssembleInstruction(i)).ToArray();

            return assembledLines.ToArray();
        }
    }
}