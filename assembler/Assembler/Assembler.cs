using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Assembler
{
    public class Assembler
    {
        public string[] Assemble(string[] lines)
        {
            var assembled = lines.Select(l => Regex.Replace(l, @"\s+", "")).Where(l => !string.IsNullOrEmpty(l) && !l.StartsWith("//")).ToArray();

            return assembled;
        }
    }
}