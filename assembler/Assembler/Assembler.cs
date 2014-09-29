using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Assembler
{
    public class Assembler
    {
        private readonly Sanitiser _sanitiser;

        public Assembler(Sanitiser sanitiser)
        {
            _sanitiser = sanitiser;
        }

        public Assembler() : this(new Sanitiser()) { }
        
        public string[] Assemble(string[] lines)
        {
            var assembled = _sanitiser.Sanitise(lines);

            return assembled;
        }
    }
}