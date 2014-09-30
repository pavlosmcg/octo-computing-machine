using Assembler.Sanitising;

namespace Assembler.Binary
{
    public class HackAssembler : IAssembler
    {
        private readonly ISanitiser _sanitiser;

        public HackAssembler(ISanitiser sanitiser)
        {
            _sanitiser = sanitiser;
        }
        
        public string[] Assemble(string[] lines)
        {
            // get the array of lines cleaned up before parsing
            var assembled = _sanitiser.Sanitise(lines);

            return assembled;
        }
    }
}