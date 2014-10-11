using System.Collections.Generic;
using System.Linq;
using Assembler.Instructions;
using Assembler.Parsing;
using Assembler.Sanitising;

namespace Assembler
{
    public class Assembler : IAssembler
    {
        private readonly ISanitiser _sanitiser;
        private readonly ILineParser _lineParser;

        public Assembler(ISanitiser sanitiser, ILineParser lineParser)
        {
            _sanitiser = sanitiser;
            _lineParser = lineParser;
        }

        public string[] Assemble(string[] lines)
        {
            // get the array of lines cleaned up before parsing
            var cleanLines = _sanitiser.Sanitise(lines);

            // parse each line into its instruction type
            var instructions = cleanLines.Select(line => _lineParser.ParseLine(line)).ToList();

            return cleanLines;
        }
    }
}