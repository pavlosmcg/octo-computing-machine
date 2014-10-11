using Assembler.Instructions;
using Assembler.Parsing;
using NUnit.Framework;

namespace Assembler.Tests.Parsing
{
    [TestFixture]
    public class ComputeInstructionParserTests
    {
        [Test]
        public void ParseInstruction_Returns_ComputeInstruction_With_No_Destination_Or_Jump_When_Line_Does_Not_Contain_Equals_Or_Semicolon()
        {
            // arrange
            const string line = "M+1";
            var parser = new ComputeInstructionParser();

            // act
            IInstruction result = parser.ParseInstruction(line);

            // assert 
            Assert.AreEqual(typeof(ComputeInstruction), result.GetType());
            Assert.AreEqual(ComputeDestinationType.None, ((ComputeInstruction)result).DestinationType);
            Assert.AreEqual(ComputeJumpType.None, ((ComputeInstruction)result).JumpType);
        }

        [Test]
        public void ParseInstruction_Returns_UnkownInstruction_When_Line_Contains_More_Than_One_Equals()
        {
            // arrange
            const string line = "MD=1=1";
            var parser = new ComputeInstructionParser();

            // act
            IInstruction result = parser.ParseInstruction(line);

            // assert 
            Assert.AreEqual(typeof(UnknownInstruction), result.GetType());
        }

        [Test]
        public void ParseInstruction_Returns_UnkownInstruction_When_Line_Contains_More_Than_One_Semicolon()
        {
            // arrange
            const string line = "M+1;JMP;JGT";
            var parser = new ComputeInstructionParser();

            // act
            IInstruction result = parser.ParseInstruction(line);

            // assert 
            Assert.AreEqual(typeof(UnknownInstruction), result.GetType());
        }

        [Test]
        public void ParseInstruction_Returns_ComputeInstruction_With_No_Jump_When_Line_Does_Not_Contain_Semicolon()
        {
            // arrange
            const string line = "MD=1";
            var parser = new ComputeInstructionParser();

            // act
            IInstruction result = parser.ParseInstruction(line);

            // assert 
            Assert.AreEqual(typeof(ComputeInstruction), result.GetType());
        }

        [TestCase("JMP", ComputeJumpType.JMP)]
        [TestCase("JGT", ComputeJumpType.JGT)]
        [TestCase("JEQ", ComputeJumpType.JEQ)]
        [TestCase("JGE", ComputeJumpType.JGE)]
        [TestCase("JLT", ComputeJumpType.JLT)]
        [TestCase("JNE", ComputeJumpType.JNE)]
        [TestCase("JLE", ComputeJumpType.JLE)]
        public void ParseInstruction_Returns_ComputeInstruction_With_Regular_Jump_When_Jump_Is_Specified(string jumpstring, ComputeJumpType expected)
        {
            // arrange
            string line = "MD=1;" + jumpstring;
            var parser = new ComputeInstructionParser();

            // act
            IInstruction result = parser.ParseInstruction(line);

            // assert 
            Assert.AreEqual(expected, ((ComputeInstruction)result).JumpType);
        }

        [Test]
        public void ParseInstruction_Returns_UnkownInstruction_When_Jump_Cannot_Be_Parsed()
        {
            // arrange
            const string line = "0;LOL";
            var parser = new ComputeInstructionParser();

            // act
            IInstruction result = parser.ParseInstruction(line);

            // assert 
            Assert.AreEqual(typeof(UnknownInstruction), result.GetType());
        }

        [Test]
        public void ParseInstruction_Returns_ComputeInstruction_With_No_Destination_When_Line_Does_Not_Contain_Equals()
        {
            // arrange
            const string line = "0;JMP";
            var parser = new ComputeInstructionParser();

            // act
            IInstruction result = parser.ParseInstruction(line);

            // assert 
            Assert.AreEqual(ComputeDestinationType.None, ((ComputeInstruction) result).DestinationType);
        }


        [Test]
        public void ParseInstruction_Returns_UnkownInstruction_When_Destination_Contains_Invalid_Chars()
        {
            // arrange
            const string line = "ABC=1;JMP";
            var parser = new ComputeInstructionParser();

            // act
            IInstruction result = parser.ParseInstruction(line);

            // assert
            Assert.AreEqual(typeof(UnknownInstruction), result.GetType());
        }
    }
}