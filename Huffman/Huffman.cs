using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huffman
{
    class Huffman
    {

        #region Class field Declaration
        private const int FREQ_SIZE = 256;                                     //Ascii table size
        private string Message;                                                //Store the message
        private PriorityQueue<Node> pq = new PriorityQueue<Node>(35);          //Priority queue
        private Dictionary<char, string> D = new Dictionary<char, string>();   //Hash Table
        private int[] freq = new int[FREQ_SIZE];                               //Frequency Array
        #endregion

        public Huffman(string Message)
        {
            this.Message = Message;
        }

        public void RunHuffman()
        {

        }

        /// <summary>
        /// Finds the frequency of each unique letter
        /// in the string
        /// </summary>
        private void FindFrequency()
        {
            foreach (char letter in Message)         //Get each letter
            {
                ++freq[letter];                      //Increment the corresponding ascii number with the letter
            }
        }

        #region Helper Methods
        public void CreateLeafNode()
        {
            for (int i = 0; i < freq.Length; i++)
            {
                if (freq[i] > 0)
                {
                    pq.Add(new Node((char)i, freq[i]));
                }
            }
        }
        #endregion
    }
}
