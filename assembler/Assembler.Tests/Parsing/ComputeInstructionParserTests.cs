using System;
using Assembler.Instructions;
using Assembler.Parsing;
using NSubstitute;
using NUnit.Framework;

namespace Assembler.Tests.Parsing
{
    [TestFixture]
    public class ComputeInstructionParserTests
    {
        [Test]
        public void ParseInstruction_Returns_UnkownInstruction_When_Line_Contains_More_Than_One_Equals()
        {
            // arrange
            const string line = "MD=1=1";
            var destinationParser = Substitute.For<IComputeDestinationParser>();
            var jumpParser = Substitute.For<IComputeJumpParser>();
            var parser = new ComputeInstructionParser(destinationParser, jumpParser);

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
            var destinationParser = Substitute.For<IComputeDestinationParser>();
            var jumpParser = Substitute.For<IComputeJumpParser>();
            var parser = new ComputeInstructionParser(destinationParser, jumpParser);

            // act
            IInstruction result = parser.ParseInstruction(line);

            // assert 
            Assert.AreEqual(typeof(UnknownInstruction), result.GetType());
        }

        [TestCase("M+1", typeof(ComputeInstruction))]
        [TestCase("M=1", typeof(ComputeInstruction))]
        [TestCase("D=M+1;JGT", typeof(ComputeInstruction))]
        [TestCase("0;JMP", typeof(ComputeInstruction))]
        [TestCase("", typeof(UnknownInstruction))]
        [TestCase("M=M+1=", typeof(UnknownInstruction))]
        [TestCase("=M", typeof(UnknownInstruction))]
        [TestCase("M=", typeof(UnknownInstruction))]
        [TestCase(";JMP", typeof(UnknownInstruction))]
        [TestCase(":JMP", typeof(UnknownInstruction))]
        [TestCase("MDA=M-1;", typeof(UnknownInstruction))]
        [TestCase("MD==1;JMP", typeof(UnknownInstruction))]
        [TestCase("MD==1", typeof(UnknownInstruction))]
        [TestCase("AMD=HH;;JGT", typeof(UnknownInstruction))]
        [TestCase("AMD=X+1;JNE", typeof(UnknownInstruction))]
        [TestCase("ZK=M+1;JEQ", typeof(UnknownInstruction))]
        public void ParseInstruction_Returns_UnknownInstruction_When_Instruction_Is_Invalid(string line, Type expectedType)
        {
            // arrange
            var destinationParser = Substitute.For<IComputeDestinationParser>();
            var jumpParser = Substitute.For<IComputeJumpParser>();
            var parser = new ComputeInstructionParser(destinationParser, jumpParser);

            // act
            IInstruction result = parser.ParseInstruction(line);

            // assert 
            Assert.AreEqual(expectedType, result.GetType());
        }

        [Test, Combinatorial]
        public void ParseInstruction_Returns_ComputeInstruction_When_Instruction_Is_Valid(
            [Values("", "M", "D", "MD", "A", "AM", "AD", "AMD")]string dest, 
            [Values("", "JGT", "JEQ", "JGE", "JLT", "JNE", "JLE", "JMP")]string jump,
            [Values("0", "1", "-1", "D", "A", "!D", "!A", "-D", "-A", "D+1", "A+1", "D-1", "A-1", "D+A", "D-A",
                "A-D", "D&A", "D|A", "M", "!M", "-M", "M+1", "M-1", "D+M", "D-M", "M-D", "D&M", "D|M")]string comp)
        {
            // arrange
            string equals = "=", semicolon = ";";
            if (string.IsNullOrEmpty(dest))
                equals = string.Empty;
            if (string.IsNullOrEmpty(jump))
                semicolon = string.Empty;
            string line = dest + equals + comp + semicolon + jump;

            var destinationParser = Substitute.For<IComputeDestinationParser>();
            var jumpParser = Substitute.For<IComputeJumpParser>();
            var parser = new ComputeInstructionParser(destinationParser, jumpParser);

            // act
            IInstruction result = parser.ParseInstruction(line);

            // assert 
            destinationParser.Received().ParseComputeDestination(Arg.Is(dest));
            jumpParser.Received().ParseComputeJump(Arg.Is(jump));
            Assert.AreEqual(typeof(ComputeInstruction), result.GetType());
        }
    }
}