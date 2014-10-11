using System;
using Assembler.Instructions;
using Assembler.Parsing;
using NUnit.Framework;

namespace Assembler.Tests.Parsing
{
    [TestFixture]
    public class ComputeDestinationParserTests
    {
        [Test]
        public void ParseInstruction_Returns_None_When_Destination_Is_Empty()
        {
            // arrange
            string dest = string.Empty;
            var parser = new ComputeDestinationParser();

            // act
            ComputeDestinationType result = parser.ParseComputeDestination(dest);

            // assert 
            Assert.AreEqual(ComputeDestinationType.None, result);
        }


        [Test]
        public void ParseInstruction_Throws_ArgumentException_When_Destination_Cannot_Be_Parsed()
        {
            const string dest = "ACDC";
            var parser = new ComputeDestinationParser();

            // act
            TestDelegate testAction = () => parser.ParseComputeDestination(dest);

            // assert 
            Assert.Throws<ArgumentException>(testAction);
        }
    }
}