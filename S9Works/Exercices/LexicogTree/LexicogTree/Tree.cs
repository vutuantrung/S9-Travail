using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace LexicogTree
{
    public class Tree
    {
        public Node _root;

        int _count;

        public int Count => _count;

        public Tree()
        {
            _root = null;
            _count = 0;
        }

        public void AddName(string name)
        {
            throw new NotImplementedException();
        }

        private void AddName(ref Node nod, string word, int index, bool isAdded)
        {
            throw new NotImplementedException();
        }

        public void DeleteName(string name)
        {
            throw new NotImplementedException();
        }

        private bool DeleteName(ref Node nod, string word, int index)
        {
            throw new NotImplementedException();
        }

        public List<string> GetAllNames()
        {
            throw new NotImplementedException();
        }

        private void GetAllNames(ref Node nod, List<string> words, string currentword)
        {
            throw new NotImplementedException();
        }

        public List<string> Prefix(string pref)
        {
            throw new NotImplementedException();
        }

        private void Prefix(ref Node nod, string pref, List<string> words, string currentword)
        {
            throw new NotImplementedException();
        }

        public List<string> SearchByLength(int length)
        {
            throw new NotImplementedException();
        }

        private void SearchByLength(ref Node nod, int length, List<string> words, string currentword)
        {
            throw new NotImplementedException();
        }

        public bool SearchName(string name)
        {
            throw new NotImplementedException();
        }

        private bool SearchName(ref Node nod, string word, int index)
        {
            throw new NotImplementedException();
        }

        public void Print() => Print(ref _root, 0, false);

        public void Print(ref Node n, int nbPassed, bool isUnderline)
        {
            throw new NotImplementedException();
        }
    }
}
