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

        /// <summary>
        /// Runs all the necessary methods for 
        /// the huffman to work properly
        /// </summary>
        public void RunHuffman()
        {
            FindFrequency();
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

        /// <summary>
        /// Build the complete huffman tree
        /// </summary>
        /// <returns>
        ///     A Node containing The completed tree
        /// </returns>
        private Node Build()
        {
            Node Left, Right;
            CreateLeafNode();                        //Create all the binary tree with size 0 and store them in pq.
            if (pq.Size() == 1)                      //Check if there is only one Node in the pq
            {
                return pq.Front();                   //Return that Node 
            }
            else
            {
                while (pq.Size() > 1)
                {
                    Left = pq.Front();               //Get the first item in pq
                    pq.Remove();                     //Remove it afterwards
                    Right = pq.Front();              //Get the first item in pq
                    pq.Remove();                     //Remove it afterwards

                    pq.Add(new Node('#', Left.Frequency + Right.Frequency, Left, Right));
                }

                return pq.Front();                   //Return the full tree at the end
            }

        }




        #region Helper Methods
        /// <summary>
        /// Create binary tree with size 1 and store them in the pq
        /// </summary>
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
