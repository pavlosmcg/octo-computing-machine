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
            const string pattern =
                @"(^|(^(?<dest>[AMD]+)=))(?<comp>[AMD10\+\-\!\&\|]+)((;(?<jump>[JMPGLTNEQ]+)$)|$)";
            Match match = new Regex(pattern, RegexOptions.IgnoreCase).Match(line);

            if (!match.Success)
                return new UnknownInstruction(line);

            string dest = match.Groups["dest"].Value;
            string comp = match.Groups["comp"].Value;
            string jump = match.Groups["jump"].Value;

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