using System;
using System.Collections.Generic;
using System.Text;

namespace LexicogTree
{
    public class Node
    {
        public char Letter { get; set; }

        public Node BrotherNode { get; set; }

        public Node SonNode { get; set; }
    }
}
