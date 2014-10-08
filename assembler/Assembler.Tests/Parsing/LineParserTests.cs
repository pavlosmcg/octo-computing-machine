using System;
using Assembler.Instructions;
using Assembler.Parsing;
using NSubstitute;
using NUnit.Framework;

namespace Assembler.Tests.Parsing
{
    [TestFixture]
    public class LineParserTests
    {
        [Test]
        public void ParseLine_Returns_Correct_InstructionType_When_Line_Is_Matched_By_A_Parser()
        {
            // arrange
            const string line = "--zorf";
            var matchingParser = Substitute.For<IInstructionParser>();
            matchingParser.ParseInstruction(line).Returns(new AddressInstruction(1234));
            var nonMatchingParser = Substitute.For<IInstructionParser>();
            nonMatchingParser.ParseInstruction(line).Returns(new UnknownInstruction());

            IInstructionParser[] parsers = {nonMatchingParser, matchingParser};
            var lineParser = new LineParser(parsers);

            // act
            IInstruction instruction = lineParser.ParseLine(line);

            // assert
            Assert.AreEqual(typeof(AddressInstruction), instruction.GetType());
        }

        [Test]
        public void ParseLine_Returns_UnknownInstructionType_When_Line_Is_Not_Matched_By_A_Parser()
        {
            // arrange
            const string line = "--zorf";
            var nonMatchingParser = Substitute.For<IInstructionParser>();
            nonMatchingParser.ParseInstruction(line).Returns(new UnknownInstruction());
            var anotherParser = Substitute.For<IInstructionParser>();
            anotherParser.ParseInstruction(line).Returns(new UnknownInstruction());

            IInstructionParser[] parsers = { nonMatchingParser, anotherParser };
            var lineParser = new LineParser(parsers);

            // act
            IInstruction instruction = lineParser.ParseLine(line);

            // assert
            Assert.AreEqual(typeof(UnknownInstruction), instruction.GetType());
        }
    }
}