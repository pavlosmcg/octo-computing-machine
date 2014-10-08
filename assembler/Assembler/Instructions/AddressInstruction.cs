﻿using System;

namespace Assembler.Instructions
{
    public struct AddressInstruction : IInstruction, IEquatable<AddressInstruction>
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

        public void Accept<T>(IInstructionVisitor<T> instructionVisitor)
        {
            instructionVisitor.VisitInstruction(this);
        }

        public bool Equals(AddressInstruction other)
        {
            return other.Address == Address;
        }
    }
}