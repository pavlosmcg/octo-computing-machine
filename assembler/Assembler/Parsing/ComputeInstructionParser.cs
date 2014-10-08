using System;
using System.Linq;
using Assembler.Instructions;

namespace Assembler.Parsing
{
    public class ComputeInstructionParser : IInstructionParser
    {
        public IInstruction ParseInstruction(string line)
        {
            if (!(line.Contains("=") || line.Contains(";")))
                return new ComputeInstruction(ComputeDestinationType.None, line, ComputeJumpType.None);

            if (line.Count(c => c == '=') > 1)
                return new UnknownInstruction(line);

            if (line.Count(c => c == ';') > 1)
                return new UnknownInstruction(line);

            ComputeJumpType jumpType;
            if (!line.Contains(";"))
                jumpType= ComputeJumpType.None;
            else if (!Enum.TryParse(line.Split(';')[1], out jumpType))
                return new UnknownInstruction(line);

            return new ComputeInstruction(ComputeDestinationType.None, null, jumpType);
        }
    }
}