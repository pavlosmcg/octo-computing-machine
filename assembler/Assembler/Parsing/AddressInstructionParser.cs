using Assembler.Instructions;

namespace Assembler.Parsing
{
    public class AddressInstructionParser : IInstructionParser
    {
        public IInstruction ParseInstruction(string line)
        {
            if (!line.StartsWith("@"))
                return new UnknownInstruction(line);

            int address;
            if (!int.TryParse(line.Substring(1), out address))
                return new UnknownInstruction(line);

            return new AddressInstruction(address);
        }
    }
}