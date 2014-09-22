﻿using NUnit.Framework;

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

        [Test]
        public void Assembler_Removes_All_Whitespace()
        {
            // arrange
            string[] inputLines = { "blorg = plotz", "fes ter", " framistan" };
            var assember = new Assembler();

            // act
            string[] assembledLines = assember.Assemble(inputLines);

            // assert
            Assert.AreEqual("blorg=plotz", assembledLines[0]);
            Assert.AreEqual("fester", assembledLines[1]);
            Assert.AreEqual("framistan", assembledLines[2]);
        }
    }
}