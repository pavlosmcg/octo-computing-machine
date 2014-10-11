using System;
using System.Linq;
using System.Text.RegularExpressions;
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
                jumpType = ComputeJumpType.None;
            else if (!Enum.TryParse(line.Split(';')[1], out jumpType))
                return new UnknownInstruction(line);

            var destinationType = ComputeDestinationType.None;
            if (!line.Contains("="))
                destinationType = ComputeDestinationType.None;
            else if (line.Split('=')[0].Count(c => !(c == 'A' || c == 'M' || c == 'D')) > 0)
                return new UnknownInstruction(line);

            return new ComputeInstruction(destinationType, null, jumpType);
        }
    }
}