using Assembler.Instructions;
using Assembler.Parsing;
using NUnit.Framework;

namespace Assembler.Tests.Parsing
{
    [TestFixture]
    public class LabelInstructionParserTests
    {
        [Test]
        public void ParseInstruction_Returns_UnkownInstruction_When_Line_Does_Not_Start_With_Opening_Bracket()
        {
            // arrange
            const string line = "BLORG)";
            var parser = new LabelInstructionParser();

            // act
            IInstruction result = parser.ParseInstruction(line);

            // assert 
            Assert.AreEqual(typeof (UnknownInstruction), result.GetType());
        }

        [Test]
        public void ParseInstruction_Returns_UnknownInstruction_When_Label_Starts_With_Digit()
        {
            // arrange
            const string line = "(9BLORG)";
            var parser = new LabelInstructionParser();

            // act
            IInstruction result = parser.ParseInstruction(line);

            // assert 
            Assert.AreEqual(typeof(UnknownInstruction), result.GetType());
        }

        [TestCase("(BLORG)", "BLORG")]
        [TestCase("(blorg)", "blorg")]
        [TestCase("(END_PLOTZ)", "END_PLOTZ")]
        [TestCase("(FRAMI:STAN)", "FRAMI:STAN")]
        [TestCase("(CA$H)", "CA$H")]
        public void ParseInstruction_Returns_LabelInstruction_When_All_Is_Well(string line, string expected)
        {
            // arrange
            var parser = new LabelInstructionParser();

            // act
            IInstruction result = parser.ParseInstruction(line);

            // assert 
            Assert.AreEqual(expected, ((LabelInstruction)result).Label);
        }
    }
}