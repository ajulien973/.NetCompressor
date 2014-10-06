using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Huffman;
using System.Collections;

namespace PlugInDotNet
{
    public class PlugInDotNet : MarshalByRefObject, IPlugin 
    {
        public bool Compress(ref Huffman.HuffmanData data)
        {
            bool r = false;

            data.sizeOfUncompressedData = data.uncompressedData.Length;
            data.frequency = new List<KeyValuePair<byte, int>>();
            Dictionary<byte, int> dictionary = new Dictionary<byte, int>();
            List<Node> nodes = new List<Node>();

            // Parcours la chaine non compressee pour compter la fréquence des caractères et les ajoute dans le dictionary
            foreach(byte b in data.uncompressedData)
            {
                if (dictionary.ContainsKey(b))
                {
                    dictionary[b] = dictionary[b] + 1;
                }
                else
                {
                    dictionary.Add(b, 1);
                }
            }

            // Transfert du dictionary dans le tableau de KeyValuePair
            foreach (byte b in dictionary.Keys)
            {
                data.frequency.Add(new KeyValuePair<byte,int>(b, dictionary[b]));
                nodes.Add(new Occurence(new KeyValuePair<byte,int>(b, dictionary[b])));
            }

            GetTree(ref nodes);
            
            foreach (Node n in nodes)
            {
                CheckSaMere(n);
            }
            

            return r;
        }

        public bool Decompress(ref Huffman.HuffmanData data)
        {
            return false;
        }

        public string PluginName {
            get { return "";  }
        }

        public void SortList(ref List<Node> nodes) 
        {
            bool swapped = true;
            int j = 0;
            Node tmp;
            while (swapped) {
                swapped = false;
                j++;        
                for (int i = 0; i < nodes.Count - j; i++)
                {
                    if (nodes[i].GetValue() > nodes[i + 1].GetValue())
                    {
                        tmp = nodes[i];
                        nodes[i] = nodes[i + 1];
                        nodes[i + 1] = tmp;
                        swapped = true;
                    }
                }        
            }
        }

        public void GetTree(ref List<Node> nodes)
        {
            if (nodes.Count > 1)
            {
                // Tri tableau
                SortList(ref nodes);

                // Création d'une nouvelle branche (sum)
                Sum newNode = new Sum();
                newNode.Add(nodes[0]);
                newNode.Add(nodes[1]);
                nodes.Remove(nodes[0]);
                nodes.Remove(nodes[1]);

                nodes.Add(newNode);

                // On récursive jusqu'à en avoir plus que 1 objet dans la liste
                GetTree(ref nodes);
            }
        }
        
        public void CheckSaMere(Node node)
        {
            Console.WriteLine(Object.ReferenceEquals(node.GetType(), typeof(Occurence))); 
            if (Object.ReferenceEquals(node.GetType(), typeof(Occurence)))
            {
                Console.WriteLine(node.GetValue());
            }
            else
            {
                ArrayList al = ((Sum)node).GetNodes();
                CheckSaMere(((Node)al[0]));
                CheckSaMere(((Node)al[1]));
            }
        }
    }
}
