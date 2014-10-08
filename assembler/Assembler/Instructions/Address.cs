using System;

namespace Assembler.Instructions
{
    public struct AddressInstruction: IEquatable<AddressInstruction>
    {
        private readonly int _address;

        public AddressInstruction(int address)
        {
            _address = address;
        }

        public int Address
        {
            get { return _address; }
        }

        public bool Equals(AddressInstruction other)
        {
            return other.Address == Address;
        }
    }
}