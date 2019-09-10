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
        [TestCase(new object[] { "abcd", "abab" })]
        [TestCase(new object[] { "abdfg", "hdgbjf" })]
        [TestCase(new object[] { "dsfsn", "dfgthjjgf" })]
        public void can_add_name(object[] names)
        {
            Tree lexicogTree = new Tree();
            for(int i = 0; i < names.Length; i++)
            {
                lexicogTree.AddName(names[i].ToString());
            }
        }

        [TestCase(new object[] { "abcd", "abab" })]
        [TestCase(new object[] { "abdfg", "hdgbjf" })]
        [TestCase(new object[] { "dsfsn", "dfgthjjgf" })]
        public void can_search_name(object[] names)
        {
            Tree lexicogTree = new Tree();
            for (int i = 0; i < names.Length; i++)
            {
                lexicogTree.AddName(names[i].ToString());
            }

            for (int i = 0; i < names.Length; i++)
            {
                lexicogTree.AddName(names[i].ToString());
            }
        }
    }
}
