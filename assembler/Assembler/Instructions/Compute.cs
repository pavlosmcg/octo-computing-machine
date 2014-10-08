using System;

namespace Assembler.Instructions
{
    public struct ComputeInstruction : IEquatable<ComputeInstruction>
    {
        private readonly ComputeDestinationType _destinationType;
        private readonly string _calculation;
        private readonly ComputeJumpType _jumpType;

        public ComputeInstruction(ComputeDestinationType destinationType, string calculation, ComputeJumpType jumpType)
        {
            _destinationType = destinationType;
            _calculation = calculation;
            _jumpType = jumpType;
        }

        public ComputeDestinationType DestinationType
        {
            get { return _destinationType; }
        }

        public string Calculation
        {
            get { return _calculation; }
        }

        public ComputeJumpType JumpType
        {
            get { return _jumpType; }
        }

        public bool Equals(ComputeInstruction other)
        {
            if (other.DestinationType != DestinationType)
                return false;

            if (other.Calculation != Calculation)
                return false;

            if (other.JumpType != JumpType)
                return false;

            return true;
        }
    }
}