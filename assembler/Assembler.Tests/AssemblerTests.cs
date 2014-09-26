using NUnit.Framework;

namespace Assembler.Tests
{
    [TestFixture]
    public class AssemblerTests
    {
        [Test]
        public void Assemble_Removes_Empty_Lines()
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
        public void Assemble_Removes_Whitespace_Lines()
        {
            // arrange
            string[] inputLines = { "blorg", "fester", "    ", "framistan" };
            var assember = new Assembler();

            // act
            string[] assembledLines = assember.Assemble(inputLines);

            // assert
            Assert.AreEqual(3, assembledLines.Length);
        }

        [Test]
        public void Assemble_Removes_All_Whitespace()
        {
            // arrange
            string[] inputLines = { "blorg = plotz", "fes ter", " framistan" };
            var assember = new Assembler();

            // act
            string[] assembledLines = assember.Assemble(inputLines);

            // assert
            Assert.AreEqual(3, assembledLines.Length);
            Assert.AreEqual("blorg=plotz", assembledLines[0]);
            Assert.AreEqual("fester", assembledLines[1]);
            Assert.AreEqual("framistan", assembledLines[2]);
        }

        [Test]
        public void Assemble_Removes_Comment_Lines()
        {
            // arrange
            string[] inputLines = { "// this is a comment", "a=b", "hello" };
            var assember = new Assembler();

            // act
            string[] assembledLines = assember.Assemble(inputLines);

            // assert
            Assert.AreEqual(2, assembledLines.Length);
        }

        [Test]
        public void Assemble_Removes_End_Of_Line_Comments()
        {
            // arrange
            string[] inputLines = { "blorg = plotz // set blorg equal to plotz", "fester", "//framistan", "//", "x // abc" };
            var assember = new Assembler();

            // act
            string[] assembledLines = assember.Assemble(inputLines);

            // assert
            Assert.AreEqual(3, assembledLines.Length);
            Assert.AreEqual("blorg=plotz", assembledLines[0]);
            Assert.AreEqual("fester", assembledLines[1]);
            Assert.AreEqual("x", assembledLines[2]);
        }
    }
}
