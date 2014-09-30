using Assembler.Parsing;
using NUnit.Framework;

namespace Assembler.Tests.Parsing
{
    [TestFixture]
    public class InstructionTypeParserTests
    {
        [TestCase("@1234", InstructionType.A)]
        [TestCase("@blorg", InstructionType.A)]
        [TestCase("@ fester", InstructionType.A)]
        [TestCase("M=D", InstructionType.C)]
        [TestCase("D=A;JMP", InstructionType.C)]
        [TestCase("0;JMP", InstructionType.C)]
        [TestCase("(LOOP)", InstructionType.Label)]
        [TestCase("what=ever", InstructionType.C)]
        public void GetInstructionType(string input, InstructionType expected)
        {
            // arrange
            var instructionTypeParser = new InstructionTypeParser();

            // act
            var instructionType = instructionTypeParser.GetInstructionType(input);

            // assert
            Assert.AreEqual(expected, instructionType);
        }
    }
}