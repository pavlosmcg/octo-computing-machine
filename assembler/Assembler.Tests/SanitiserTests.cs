using NUnit.Framework;

namespace Assembler.Tests
{
    [TestFixture]
    public class SanitiserTests
    {
        [Test]
        public void Sanitise_Removes_Empty_Lines()
        {
            // arrange
            string[] inputLines = {"blorg", "fester", "", "framistan"};
            var sanitiser = new Sanitiser();

            // act
            string[] cleanedLines = sanitiser.Sanitise(inputLines);

            // assert
            Assert.AreEqual(3, cleanedLines.Length);
        }

        [Test]
        public void Sanitise_Removes_Whitespace_Lines()
        {
            // arrange
            string[] inputLines = { "blorg", "fester", "    ", "framistan" };
            var sanitiser = new Sanitiser();

            // act
            string[] cleanedLines = sanitiser.Sanitise(inputLines);

            // assert
            Assert.AreEqual(3, cleanedLines.Length);
        }

        [Test]
        public void Sanitise_Removes_All_Whitespace()
        {
            // arrange
            string[] inputLines = { "blorg = plotz", "fes ter", " framistan" };
            var sanitiser = new Sanitiser();

            // act
            string[] cleanedLines = sanitiser.Sanitise(inputLines);

            // assert
            Assert.AreEqual(3, cleanedLines.Length);
            Assert.AreEqual("blorg=plotz", cleanedLines[0]);
            Assert.AreEqual("fester", cleanedLines[1]);
            Assert.AreEqual("framistan", cleanedLines[2]);
        }

        [Test]
        public void Sanitise_Removes_Comment_Lines()
        {
            // arrange
            string[] inputLines = { "// this is a comment", "a=b", "hello" };
            var sanitiser = new Sanitiser();

            // act
            string[] cleanedLines = sanitiser.Sanitise(inputLines);

            // assert
            Assert.AreEqual(2, cleanedLines.Length);
        }

        [Test]
        public void Sanitise_Removes_End_Of_Line_Comments()
        {
            // arrange
            string[] inputLines = { "blorg = plotz // set blorg equal to plotz", "fester", "//framistan", "//", "x // abc" };
            var sanitiser = new Sanitiser();

            // act
            string[] cleanedLines = sanitiser.Sanitise(inputLines);

            // assert
            Assert.AreEqual(3, cleanedLines.Length);
            Assert.AreEqual("blorg=plotz", cleanedLines[0]);
            Assert.AreEqual("fester", cleanedLines[1]);
            Assert.AreEqual("x", cleanedLines[2]);
        }
    }
}
