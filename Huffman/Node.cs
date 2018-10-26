using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huffman
{
    class Node : IComparable
    {
        #region Properties Declaration && Constructor 
        public char Letter { get; set; }
        public int Frequency { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; } 

        public Node(char Letter, int Frequency, Node Left = null, Node Right = null)
        {
            this.Letter = Letter;
            this.Frequency = Frequency;
            this.Left = Left;
            this.Right = Right;
        }
        #endregion

        public int CompareTo(object obj)
        {
            Node that = (Node)obj;
            return Frequency.CompareTo(that.Frequency);
        }
    }
}
