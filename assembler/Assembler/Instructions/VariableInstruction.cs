using System;

namespace Assembler.Instructions
{
    public struct VariableInstruction : IInstruction, IEquatable<VariableInstruction>
    {
        private readonly string _label;

        public VariableInstruction(string label)
        {
            _label = label;
        }

        public string Label
        {
            get { return _label; }
        }

        public void Accept<T>(IInstructionVisitor<T> instructionVisitor)
        {
            instructionVisitor.VisitInstruction(this);
        }

        public bool Equals(VariableInstruction other)
        {
            return string.Equals(other.Label, Label);
        }
    }
}