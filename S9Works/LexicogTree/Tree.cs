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
            word = word + "#";

            AddWord(ref Root, word, 0);
        }

        public void AddWord(ref Node nod, string word, int index)
        {
            // Si la taille du mot est atteinte c'est bon
            if (index >= word.Length) return;

            // Si la node est null il faut ajouter la lettre actuelle
            if (nod == null)
            {
                nod = new Node
                {
                    Letter = word[index],
                    BrotherNode = null,
                    SonNode = null
                };
                // et la suite du mot
                AddWord(ref nod.SonNode, word, ++index);
            }
            // Si la node n'est pas null
            else
            {
                // Si la lettre est différente
                if (nod.Letter != word[index])
                {
                    // On regarde si le frère contient la lettre
                    AddWord(ref nod.BrotherNode, word, index);
                }
                else
                {
                    // Si la lettre est identique on continue sur le fils
                    AddWord(ref nod.SonNode, word, ++index);
                }
            }
        }

        public void DeleteNode()
        {
            throw new NotImplementedException();
        }

        // Retourne tout les mots contenant le prefix suivant
        public List<string> Prefix(string pref)
        {

            throw new NotImplementedException();
        }

        public List<string> PrefixRec()
        {
            /*
             * 
             * 
             */
            throw new NotImplementedException();
        }

        // Retourne tout les mots de la taille length
        public List<string> SearchByLength(int length)
        {
            List<string> words = new List<string>();
            SearchByLengthRec(ref Root, length, words, "");
            return words;
        }

        public void SearchByLengthRec(ref Node nod, int length, List<string> words, string currentword)
        {
            // Si la node est vide (notamment après un appel du frère)
            if (nod == null) return;

            // Si la length est atteinte on regarde si on trouve un end of word
            if(currentword.Length >= length)
            {
                // Si on en trouve une on ajoute le mot actuel
                if (SearchWord(ref nod, "", 0))
                {
                    words.Add(currentword);
                }
            }
            else
            {
                // On boucle sur le frère
                SearchByLengthRec(ref nod.BrotherNode, length, words, currentword);

                // On ajoute la lettre et continue sur le fils si c'est pas un end of word
                if (nod.Letter != '#')
                {
                    currentword += nod.Letter;
                    SearchByLengthRec(ref nod.SonNode, length, words, currentword);
                }
            }
        }

        public bool SearchNode(string word)
        {
            word = word + "#";

            return SearchWord(ref Root, word, 0);
        }

        public bool SearchWord(ref Node nod, string word, int index)
        {
            // Si la taille du mot est atteinte c'est bon.
            if (index >= word.Length) return true;

            // si il y a une node
            if (nod == null) return false;
            else
            {
                // on compare la lettre à notre mot
                if (word[index] == nod.Letter)
                {
                    // Si c'est bon on boucle sur le fils
                    return SearchWord(ref nod.SonNode, word, ++index);
                }
                else
                {
                    // Sinon on regarde sur le frère si il n'a pas la bonne lettre
                    return SearchWord(ref nod.BrotherNode, word, index);
                }
            }
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
