using Assembler.Sanitising;
using NUnit.Framework;

namespace Assembler.Tests.Sanitising
{
    [TestFixture]
    public class CommentRemoverTests
    {
        [Test]
        public void RemoveComments_Clears_Comment_Lines()
        {
            // arrange
            //string[] inputLines = { "// this is a comment", "a=b", "hello" };
            var input = "// this is a comment";
            var commentRemover = new CommentRemover();

            // act
            string cleanedLine = commentRemover.RemoveComments(input);

            // assert
            Assert.AreEqual(string.Empty, cleanedLine);
        }

        [Test]
        public void RemoveComments_Removes_End_Of_Line_Comments()
        {
            // arrange
            //string[] inputLines = { "blorg = plotz // set blorg equal to plotz", "fester", "//framistan", "//", "x // abc" };
            var input = "blorg = plotz // set blorg equal to plotz";
            var commentRemover = new CommentRemover();

            // act
            string cleanedLine = commentRemover.RemoveComments(input);

            // assert
            Assert.AreEqual("blorg = plotz ", cleanedLine);
        }
    }
}