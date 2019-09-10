using LexicogTree;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestsLexicogTree
{
    [TestFixture]
    class T1UserTests
    {
        [TestCase(new object[] { "abcd", "abhi" })]
        [TestCase(new object[] { "abcd", "ab" })]
        [TestCase(new object[] { "ab", "ba" })]
        [TestCase(new object[] { "abc", "ab" })]
        [TestCase(new object[] { "abc", "acb" })]
        [TestCase(new object[] { "afgd", "sdfhsdfg", "afh" })]
        [TestCase(new object[] { "as", "fdgdfg" })]
        [TestCase(new object[] { "abcd", "abcsdd", "ashs", "asdfa" })]
        public void can_add_name(object[] names)
        {
            Tree lexicogTree = new Tree();
            for (int i = 0; i < names.Length; i++)
            {
                lexicogTree.AddName(names[i].ToString());
                Assert.That(lexicogTree.Count == i + 1);
            }

            Assert.Throws<Exception>(() => { lexicogTree.AddName(names[0].ToString()); }, "This name is already existed.");
            Assert.Throws<Exception>(() => { lexicogTree.AddName(names[1].ToString()); }, "This name is already existed.");
        }


        [TestCase(new object[] { "abcd", "abab" }, new object[] { "ab", "asde" })]
        [TestCase(new object[] { "abs", "ab" }, new object[] { "ahdf", "abd" })]
        [TestCase(new object[] { "dfg", "df" }, new object[] { "ahdf", "abd" })]
        [TestCase(new object[] { "abdfg", "hdgbjf", "asdgga" }, new object[] { "abd", "adfg" })]
        [TestCase(new object[] { "dsfsn", "dfgthjjgf" }, new object[] { "dfgthjjgfsd", "dfdjg" })]
        public void can_search_name(object[] names, object[] invalidNames)
        {
            Tree lexicogTree = new Tree();
            for (int i = 0; i < names.Length; i++)
            {
                lexicogTree.AddName(names[i].ToString());
            }

            for (int i = 0; i < names.Length; i++)
            {
                var searchRes = lexicogTree.SearchNode(names[i].ToString());
                Assert.That(searchRes == true);
            }

            for (int i = 0; i < invalidNames.Length; i++)
            {
                var searchRes = lexicogTree.SearchNode(invalidNames[i].ToString());
                Assert.That(searchRes == false);
            }
        }


        [TestCase(new object[] { "dfg", "ab", "sfdn", "df", "ds" }, new object[] { }, 6)]
        [TestCase(new object[] { "a", "s", "g", "as", "j" }, new object[] { "a", "s", "g", "j" }, 1)]
        public void can_search_all_name_with_length_specific(object[] namesAdded, object[] namesSearched, int len)
        {
            Tree lexicogTree = new Tree();
            for (int i = 0; i < namesAdded.Length; i++)
            {
                lexicogTree.AddName(namesAdded[i].ToString());
            }

            string[] res = lexicogTree.SearchByLength(len).ToArray();
            string[] nameS = namesSearched.Where(x => x != null)
                       .Select(x => x.ToString())
                       .ToArray();

            var q = from a in nameS
                    join b in res on a equals b
                    select a;

            bool equals = namesSearched.Length == res.Length && q.Count() == namesSearched.Length;
            Assert.That(equals == true);
        }


        [TestCase(new object[] { "asdgd", "asdhd", "ashfdn", "sggrf", "asdfgd" }, new object[] { "asdgd", "asdhd", "ashfdn", "asdfgd" }, "as")]
        [TestCase(new object[] { "jbdf", "sfgnst", "gb", "gha", "fdhd" }, new object[] { }, "e")]
        [TestCase(new object[] { "vdf", "shsrg", "sdhdf", "sdgh", "s" }, new object[] { }, "df")]
        [TestCase(new object[] { "fg", "hf", "s", "fgs", "haa" }, new object[] { "fg", "fgs" }, "fg")]
        public void can_get_all_prefix_name(object[] namesAdded, object[] namesPref, string pref)
        {
            Tree lexicogTree = new Tree();
            for (int i = 0; i < namesAdded.Length; i++)
            {
                lexicogTree.AddName(namesAdded[i].ToString());
            }

            string[] res = lexicogTree.Prefix(pref).ToArray();
            string[] nameS = namesPref.Where(x => x != null)
                       .Select(x => x.ToString())
                       .ToArray();

            var q = from a in nameS
                    join b in res on a equals b
                    select a;

            bool equals = namesPref.Length == res.Length && q.Count() == namesPref.Length;
            Assert.That(equals == true);
        }
    }
}
