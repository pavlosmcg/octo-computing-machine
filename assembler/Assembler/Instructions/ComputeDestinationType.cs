using System;

namespace Assembler.Instructions
{
    [Flags]
    public enum ComputeDestinationType
    {
        None = 0x0,
        AddressRegister = 0x1,
        DataRegister = 0x2,
        Memory = 0x4
    }
}