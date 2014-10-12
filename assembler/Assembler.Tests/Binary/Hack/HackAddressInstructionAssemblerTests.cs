using Assembler.Binary;
using Assembler.Binary.Hack;
using Assembler.Instructions;
using NUnit.Framework;

namespace Assembler.Tests.Binary.Hack
{
    [TestFixture]
    public class HackAddressInstructionAssemblerTests
    {
        [Test]
        public void AssembleInstruction_Returns_Single_Line()
        {
            // arrange
            var instruction = new AddressInstruction(1234);
            var assembler = new HackAddressInstructionAssembler();

            // act
            string[] result = assembler.AssembleInstruction(instruction);

            // assert 
            Assert.AreEqual(1, result.Length);
        }

        [Test]
        public void AssembleInstruction_Returns_16_Bit_Line()
        {
            // arrange
            var instruction = new AddressInstruction(1234);
            var assembler = new HackAddressInstructionAssembler();

            // act
            string[] result = assembler.AssembleInstruction(instruction);
            string line = result[0];

            // assert 
            Assert.AreEqual(16, line.Length);
        }

        [Test]
        public void AssembleInstruction_Returns_Line_Starts_With_Zero()
        {
            // arrange
            var instruction = new AddressInstruction(1234);
            var assembler = new HackAddressInstructionAssembler();

            // act
            string[] result = assembler.AssembleInstruction(instruction);
            string line = result[0];

            // assert 
            Assert.AreEqual('0', line[0]);
        }

        [TestCase(0, "0000 0000 0000 0000")]
        [TestCase(15, "0000 0000 0000 1111")]
        [TestCase(1234, "0000 0100 1101 0010")]
        [TestCase(16384, "0100 0000 0000 0000")]
        [TestCase(24576, "0110 0000 0000 0000")] 
        public void AssembleInstruction_Returns_Binary_Representation_Of_Address_Instruction(int address, string expected)
        {
            // arrange
            var instruction = new AddressInstruction(address);
            var assembler = new HackAddressInstructionAssembler();

            // act
            string[] result = assembler.AssembleInstruction(instruction);
            string line = result[0];

            // assert 
            Assert.AreEqual(1, result.Length);
            Assert.AreEqual(expected.Replace(" ",""), line);
        }
    }
}