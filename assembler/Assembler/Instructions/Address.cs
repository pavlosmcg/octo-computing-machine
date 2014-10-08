namespace Assembler.Instructions
{
    public struct AInstruction
    {
        private readonly int _address;

        public AInstruction(int address)
        {
            _address = address;
        }

        public int Address
        {
            get { return _address; }
        }
    }
}