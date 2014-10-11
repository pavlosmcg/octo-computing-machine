﻿using System.Text.RegularExpressions;
using Assembler.Instructions;

namespace Assembler.Parsing
{
    public class VariableInstructionParser : IInstructionParser
    {
        private readonly ILabelParser _labelParser;

        public VariableInstructionParser(ILabelParser labelParser)
        {
            _labelParser = labelParser;
        }

        public IInstruction ParseInstruction(string line)
        {
            const string pattern = @"^@(.+)$";
            Match match = new Regex(pattern, RegexOptions.IgnoreCase).Match(line);

            if (!match.Success)
                return new UnknownInstruction(line);

            var parsedLabel = _labelParser.ParseLabel(match.Groups[1].Value);
            if (parsedLabel == null)
                return new UnknownInstruction(line);

            return new VariableInstruction(parsedLabel);
        }
    }
}