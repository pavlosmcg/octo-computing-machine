using Assembler.Instructions;
using Assembler.Parsing;
using NUnit.Framework;

namespace Assembler.Tests.Parsing
{
    [TestFixture]
    public class AddressInstructionParserTests
    {
        [Test]
        public void ParseInstruction_Returns_UnkownInstruction_When_Line_Does_Not_Start_With_At_Symbol()
        {
            // arrange
            const string line = "12345";
            var parser = new AddressInstructionParser();

            // act
            IInstruction result = parser.ParseInstruction(line);

            // assert 
            Assert.AreEqual(typeof (UnknownInstruction), result.GetType());
        }

        [Test]
        public void ParseInstruction_Returns_UnkownInstruction_When_Address_Is_Not_Integer()
        {
            // arrange
            const string line = "@blorg";
            var parser = new AddressInstructionParser();

            // act
            IInstruction result = parser.ParseInstruction(line);

            // assert 
            Assert.AreEqual(typeof (UnknownInstruction), result.GetType());
        }

        [Test]
        public void ParseInstruction_Returns_AddressInstruction_When_Address_Is_Valid()
        {
            // arrange
            const string line = "@1234";
            var parser = new AddressInstructionParser();

            // act
            IInstruction result = parser.ParseInstruction(line);

            // assert 
            Assert.AreEqual(1234, ((AddressInstruction)result).Address);
        }
    }
}