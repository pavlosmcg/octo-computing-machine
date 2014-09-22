using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Assembler
{
    public class Assembler
    {
        public string[] Assemble(string[] lines)
        {
            var assembled = lines.Select(l => l.Trim()).Where(l => !string.IsNullOrEmpty(l)).ToArray();

            return assembled;
        }
    }
}