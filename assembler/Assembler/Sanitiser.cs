using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Assembler
{
    public class Sanitiser
    {
         public string[] Sanitise(string[] lines)
         {
             return lines
                .Select(l => Regex.Replace(l, @"\s+", ""))
                .Select(l => l.Split(new[] { "//" }, StringSplitOptions.None)[0])
                .Where(l => !string.IsNullOrEmpty(l)).ToArray();
         }
    }
}