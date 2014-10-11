using Assembler.Instructions;
using Assembler.Parsing;
using NSubstitute;
using NUnit.Framework;

namespace Assembler.Tests.Parsing
{
    [TestFixture]
    public class VariableInstructionParserTests
    {
        [Test]
        public void ParseInstruction_Returns_UnkownInstruction_When_Line_Does_Not_Start_With_At_Symbol()
        {
            // arrange
            const string line = "somevar";
            var labelParser = Substitute.For<ILabelParser>();
            var parser = new VariableInstructionParser(labelParser);

            // act
            IInstruction result = parser.ParseInstruction(line);

            // assert 
            Assert.AreEqual(typeof (UnknownInstruction), result.GetType());
        }

        [Test]
        public void ParseInstruction_Returns_VariableInstruction_When_Label_Is_Valid()
        {
            // arrange
            const string line = "@somevar";
            var labelParser = Substitute.For<ILabelParser>();
            var parser = new VariableInstructionParser(labelParser);

            // act
            IInstruction result = parser.ParseInstruction(line);

            // assert 
            labelParser.Received().ParseLabel(Arg.Is("somevar"));
            Assert.AreEqual(typeof(VariableInstruction), result.GetType());
        }
    }
}