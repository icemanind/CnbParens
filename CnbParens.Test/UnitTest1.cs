using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CnbParens.Test
{
    [TestClass]
    public class CnbTests
    {
        [TestMethod]
        public void ValidTestsShouldPass()
        {
            var bt = new BracketTester("()[]{}");

            Assert.IsTrue(bt.IsValid("()"));
            Assert.IsTrue(bt.IsValid("()[]{}"));
            Assert.IsTrue(bt.IsValid("{[]}"));
        }

        [TestMethod]
        public void InvalidTestsShouldPass()
        {
            var bt = new BracketTester("()[]{}");

            Assert.IsFalse(bt.IsValid("(]"));
            Assert.IsFalse(bt.IsValid("([)]"));
        }

        [TestMethod]
        public void EmptyStringShouldPass()
        {
            var bt = new BracketTester("()[]{}");

            Assert.IsTrue(bt.IsValid(""));
        }

        [TestMethod]
        public void NonStandardBracketsShouldPass()
        {
            var bt = new BracketTester("AaZz()");

            Assert.IsTrue(bt.IsValid("AZ(Aa)za"));
        }

        [TestMethod]
        public void StandardBracketsShouldFailIfNotPassedInConstructor()
        {
            var bt = new BracketTester("[]");

            Assert.IsTrue(bt.IsValid("[]"));
            Assert.IsFalse(bt.IsValid("()"));
            Assert.IsFalse(bt.IsValid("{}"));
        }
    }
}
