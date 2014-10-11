using System;
using Assembler.Instructions;

namespace Assembler.Parsing
{
    public class ComputeDestinationParser : IComputeDestinationParser
    {
        public ComputeDestinationType ParseComputeDestination(string destination)
        {
            if (string.IsNullOrEmpty(destination))
                return ComputeDestinationType.None;

            throw new ArgumentException("Cannot parse compute instruction destination", destination);
        }
    }
}