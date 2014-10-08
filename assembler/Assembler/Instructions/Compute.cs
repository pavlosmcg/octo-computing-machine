namespace Assembler.Instructions
{
    public struct Compute
    {
        private readonly ComputeDestinationType _destinationType;
        private readonly string _calculation;
        private readonly ComputeJumpType _jumpType;

        public Compute(ComputeDestinationType destinationType, string calculation, ComputeJumpType jumpType)
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
    }
}