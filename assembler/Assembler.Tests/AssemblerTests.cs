using NUnit.Framework;

namespace Assembler.Tests
{
    [TestFixture]
    public class AssemblerTests
    {
        [Test]
        public void Assembler_Removes_Empty_Lines()
        {
            // arrange
            string[] inputLines = {"blorg", "fester", "", "framistan"};
            var assember = new Assembler();

            // act
            string[] assembledLines = assember.Assemble(inputLines);

            // assert
            Assert.AreEqual(3, assembledLines.Length);
        }

        [Test]
        public void Assembler_Removes_Whitespace_Lines()
        {
            // arrange
            string[] inputLines = { "blorg", "fester", "    ", "framistan" };
            var assember = new Assembler();

            // act
            string[] assembledLines = assember.Assemble(inputLines);

            // assert
            Assert.AreEqual(3, assembledLines.Length);
        }
    }
}
