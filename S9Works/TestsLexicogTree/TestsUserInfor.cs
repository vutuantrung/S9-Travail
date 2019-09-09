using LexicogTree;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestsLexicogTree
{
    [TestFixture]
    class T1UserTests
    {
        [TestCase("abcd")]
        public void can_add_name(string name)
        {
            Tree lexicogTree = new Tree();
            lexicogTree.AddName("abcd");
            lexicogTree.AddName("abab");
            lexicogTree.Print();
        }

        [Test]
        public void unit_test_example2()
        {

        }
    }
}
