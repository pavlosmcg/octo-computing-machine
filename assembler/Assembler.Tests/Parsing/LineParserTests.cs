using System;
using Assembler.Instructions;
using Assembler.Parsing;
using NUnit.Framework;

namespace Assembler.Tests.Parsing
{
    [TestFixture]
    public class LineParserTests
    {
        [TestCase("@1234", typeof (AddressInstruction))]
        [TestCase("@blorg", typeof(AddressInstruction))]
        [TestCase("@ fester", typeof(AddressInstruction))]
        [TestCase("M=D", typeof(ComputeInstruction))]
        [TestCase("D=A;JMP", typeof(ComputeInstruction))]
        [TestCase("0;JMP", typeof(ComputeInstruction))]
        [TestCase("(LOOP)", typeof(LabelInstruction))]
        [TestCase("what=ever", typeof(ComputeInstruction))]
        public void ParseInstruction_Returns_Correct_Instruction_Type(string input, Type expected)
        {
            // arrange
            var lineParser = new LineParser();

            // act
            IInstruction instruction = lineParser.ParseInstruction(input);

            // assert
            Assert.AreEqual(expected, instruction.GetType());
        }
    }
}