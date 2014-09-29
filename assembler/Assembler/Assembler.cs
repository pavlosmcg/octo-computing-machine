using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Assembler
{
    public class Assembler : IAssembler
    {
        private readonly ISanitiser _sanitiser;

        public Assembler(ISanitiser sanitiser)
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