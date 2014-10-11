using System;
using System.Text.RegularExpressions;
using Assembler.Instructions;

namespace Assembler.Parsing
{
    public class ComputeInstructionParser : IInstructionParser
    {
        private readonly IComputeDestinationParser _destinationParser;
        private readonly IComputeJumpParser _jumpParser;

        public ComputeInstructionParser(IComputeDestinationParser destinationParser, IComputeJumpParser jumpParser)
        {
            _destinationParser = destinationParser;
            _jumpParser = jumpParser;
        }

        public IInstruction ParseInstruction(string line)
        {
            // Regex below matches an instruction of the type [AMD=]M+D[;JMP], where [] are optional
            const string pattern = @"(^|(^([AMD]+)=))([AMD10\+\-\!\&\|]+)((;([JMPGLTNEQ]+$))|$)";
            var r = new Regex(pattern, RegexOptions.IgnoreCase);
            Match match = r.Match(line);

            if (!match.Success)
                return new UnknownInstruction(line);

            string dest = match.Groups[3].Value;
            string comp = match.Groups[4].Value;
            string jump = match.Groups[7].Value;

            ComputeDestinationType destinationType;
            ComputeJumpType jumpType;

            try
            {
                destinationType = _destinationParser.ParseComputeDestination(dest);
                jumpType = _jumpParser.ParseComputeJump(jump);
            }
            catch (ArgumentException)
            {
                return new UnknownInstruction(line);
            }
            
            return new ComputeInstruction(destinationType, comp, jumpType);
        }
    }
}