using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huffman
{
    class Program
    {
        static void Main(string[] args)
        {
            string msg;
            Console.Write("Enter the string you want run through Huffman: ");
            msg = Console.ReadLine();
            Huffman Huff = new Huffman(msg);
            Huff.RunHuffman();
        }
    }
}
