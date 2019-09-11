﻿using System;
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

        public void AddName(string word)
        {
            try
            {
                word = word + "#";
                AddWord(ref _root, word, 0, false);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void AddWord(ref Node nod, string word, int index, bool isAdded)
        {
            // Si la taille du mot est atteinte c'est bon
            if (index >= word.Length)
            {
                if (isAdded)
                {
                    _count++;
                    return;
                }
                else throw new Exception("This name is already existed.");
            }

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
                AddWord(ref nod.SonNode, word, ++index, true);
            }
            // Si la node n'est pas null
            else
            {
                // Si la lettre est différente
                if (nod.Letter != word[index])
                {
                    // On regarde si le frère contient la lettre
                    AddWord(ref nod.BrotherNode, word, index, isAdded);
                }
                else
                {
                    // Si la lettre est identique on continue sur le fils
                    AddWord(ref nod.SonNode, word, ++index, isAdded);
                }
            }
        }

        public void DeleteNode(string word)
        {
            try
            {
                if (!SearchNode(word)) throw new Exception("This word doesn't exist.");
                DeleteNodeRec(ref _root, word + "#", 0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteNodeRec(ref Node nod, string word, int index)
        {
            bool deleteMore = true;

            if (word[index] == nod.Letter)
            {
                if (index >= word.Length - 1)
                {
                    deleteMore = nod.BrotherNode == null;
                    nod = nod.BrotherNode;
                }
                // Si c'est bon on boucle sur le fils
                else if (DeleteNodeRec(ref nod.SonNode, word, index + 1))
                {
                    // On supprime si on le doit
                    deleteMore = nod.BrotherNode == null;
                    nod = nod.BrotherNode;
                }
                else
                    deleteMore = false;
            }
            else
            {
                // Sinon on regarde sur le frère si il n'a pas la bonne lettre
                if (DeleteNodeRec(ref nod.BrotherNode, word, index))
                {
                    // On supprime si on le doit
                    if (nod.SonNode != null && nod.BrotherNode == null)
                    {
                        deleteMore = false;
                    }
                    else
                    {
                        deleteMore = nod.BrotherNode == null;
                        nod = nod.BrotherNode;
                    }
                }
                else
                    deleteMore = false;
            }
            //}

            return deleteMore;
        }

        public List<string> GetAllWords()
        {
            List<string> words = new List<string>();
            GetAllWordsRec(ref _root, words, "");
            return words;
        }

        /// <summary>
        /// Affiche tout les mots contenu dans le dictionnaire
        /// </summary>
        /// <param name="nod"></param>
        /// <param name="words"></param>
        /// <param name="currentword"></param>
        public void GetAllWordsRec(ref Node nod, List<string> words, string currentword)
        {
            // Dès qu'on trouve un end of word on ajoute le mot et on parcours son frère et fils.
            if (nod == null) return;

            if (nod.Letter == '#')
                words.Add(currentword);

            GetAllWordsRec(ref nod.BrotherNode, words, currentword);
            currentword += nod.Letter;
            GetAllWordsRec(ref nod.SonNode, words, currentword);
        }

        /// <summary>
        /// Retourne tout les mots contenant le prefix suivant
        /// </summary>
        /// <param name="pref"></param>
        /// <returns></returns>
        public List<string> Prefix(string pref)
        {
            List<string> words = new List<string>();
            PrefixRec(ref _root, pref, words, "");
            return words;
        }

        public void PrefixRec(ref Node nod, string pref, List<string> words, string currentword)
        {
            if (nod == null) return;

            // Si le prefix a été trouvé
            if (currentword.Length >= pref.Length)
            {
                // On regarde si un end of word est présent
                if (SearchWord(ref nod, "#", 0))
                {
                    words.Add(currentword);
                }
                // On continu sur le frère
                PrefixRec(ref nod.BrotherNode, pref, words, currentword);

                // Et sur le fils après avoir ajouté la lettre actuelle
                currentword += nod.Letter;
                PrefixRec(ref nod.SonNode, pref, words, currentword);
            }
            else
            {
                // on compare la lettre à notre mot
                if (pref[currentword.Length] == nod.Letter)
                {
                    // Si c'est bon on boucle sur le fils
                    currentword += nod.Letter;
                    PrefixRec(ref nod.SonNode, pref, words, currentword);
                }
                else
                {
                    // Sinon on regarde sur le frère si il n'a pas la bonne lettre
                    PrefixRec(ref nod.BrotherNode, pref, words, currentword);
                }
            }
        }

        /// <summary>
        /// Retourne tout les mots de la taille length
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public List<string> SearchByLength(int length)
        {
            List<string> words = new List<string>();
            SearchByLengthRec(ref _root, length, words, "");
            return words;
        }

        public void SearchByLengthRec(ref Node nod, int length, List<string> words, string currentword)
        {
            // Si la node est vide (notamment après un appel du frère)
            if (nod == null) return;

            // Si la length est atteinte on regarde si on trouve un end of word (on appel la fonction pour tester les frères)
            if (currentword.Length >= length)
            {
                // Si on en trouve une on ajoute le mot actuel
                if (SearchWord(ref nod, "#", 0))
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
            return SearchWord(ref _root, word, 0);
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

        public void Print(ref Node n, int nbPassed, bool isUnderline)
        {
            int nbSpaces = nbPassed;
            if (n == null)
            {
                return;
            }
            else
            {
                string spaces = string.Empty;
                if (isUnderline)
                {
                    for (int i = 0; i < nbSpaces; i++)
                    {
                        spaces += "  ";
                    }
                }
                
                Debug.Write(spaces + n.Letter + " ");
                Print(ref n.SonNode, ++nbPassed, false);
                if (n.Letter == '#')
                {
                    Debug.WriteLine("");
                }
                Print(ref n.BrotherNode, nbSpaces, true);
            }
        }
    }
}
