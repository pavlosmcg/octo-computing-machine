using System.Text.RegularExpressions;
using Assembler.Instructions;

namespace Assembler.Parsing
{
    public class LabelInstructionParser : IInstructionParser
    {
        public IInstruction ParseInstruction(string line)
        {
            const string pattern = @"^\((\D[\w\.\$:]+)\)$";
            Match match = new Regex(pattern).Match(line);

            if (!match.Success)
                return new UnknownInstruction(line);

            return new LabelInstruction(match.Groups[1].Value);
        }
    }
}