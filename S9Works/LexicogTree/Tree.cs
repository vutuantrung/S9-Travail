using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace LexicogTree
{
    public class Tree
    {
        public Node Root;

        public Node Iterator { get; set; }

        public Tree()
        {
            Root = null;
        }

        public void AddName(string word)
        {
            AddWord(ref Root, word, 0);
        }

        public void AddWord(ref Node nod, string word, int index)
        {
            if (index >= word.Length) return;
            if (nod == null)
            {
                nod = new Node
                {
                    Letter = word[index],
                    BrotherNode = null,
                    SonNode = null
                };
                AddWord(ref nod.SonNode, word, index + 1);
            }
            else
            {
                if (nod.Letter != word[index])
                {
                    if (nod.BrotherNode != null)
                    {
                        AddWord(ref nod.BrotherNode, word, index);
                    }
                    else
                    {
                        nod.BrotherNode = new Node
                        {
                            Letter = word[index],
                            BrotherNode = null,
                            SonNode = null
                        };
                        AddWord(ref nod.BrotherNode.SonNode, word, ++index);
                    }
                }
                else
                {
                    AddWord(ref nod.SonNode, word, ++index);
                }
            }
        }

        public void DeleteNode()
        {
            throw new NotImplementedException();
        }

        public char Prefix()
        {
            throw new NotImplementedException();
        }

        public string[] SearchByLength(int length)
        {
            throw new NotImplementedException();
        }

        public bool SearchWord()
        {
            /* 
             * si idx > word.length
             *  return true
             *  
             * Récupérer le char c à l'index idx
             * Aller sur currentNode
             * 
             * Si c == N.letter
             *  boucle avec le fils et idx + 1
             *  
             * Sinon 
             *  si frère != null
             *      boucle sur frère avec idx
             *  sinon
             *      return false
             */

            throw new NotImplementedException();
        }

        public void Print()
        {
            Node broIter = Root;
            while (broIter != null)
            {
                Node sonIter = broIter;
                while (sonIter != null)
                {
                    Debug.Write(sonIter.Letter);
                    sonIter = sonIter.SonNode;
                }
                broIter = broIter.BrotherNode;
                Debug.WriteLine("");
            }
        }
    }
}
