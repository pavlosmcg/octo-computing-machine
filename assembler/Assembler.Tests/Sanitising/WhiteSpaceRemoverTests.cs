using NUnit.Framework;
using Assembler.Sanitising;

namespace Assembler.Tests.Sanitising
{
    [TestFixture]
    public class WhiteSpaceRemoverTests
    {
        [Test]
        public void RemoveWhiteSpace_Removes_All_Whitespace_From_Line()
        {
            // arrange
            //string[] inputLine = { "blorg = plotz", "fes ter", " framistan" };
            var input = "blorg = plotz";
            var whitespaceRemover = new WhitespaceRemover();

            // act
            string cleanedLine = whitespaceRemover.RemoveWhiteSpace(input);

            // assert
            Assert.AreEqual("blorg=plotz", cleanedLine);
        }
    }
}