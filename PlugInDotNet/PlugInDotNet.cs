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

            /*foreach (Node n in nodes)
            {
                CheckSaMere(n);
            }*/

            List<KeyValuePair<byte, string>> l_kvp = new List<KeyValuePair<byte, string>>();

            GetHuffmanCode("", nodes[0], ref l_kvp);

            foreach (KeyValuePair<byte, string> kvp in l_kvp)
            {
                byte[] tabByte = { kvp.Key };
                Console.Write("(" + kvp.Value + " - " + Encoding.ASCII.GetString(tabByte) + ")");
            }
            Console.WriteLine("");

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
                // On ajoute les deux liens à cette nouvelle branche
                newNode.Add(nodes[0]);
                newNode.Add(nodes[1]);
                // On supprime de la liste les deux liens 
                nodes.Remove(nodes[0]);
                nodes.Remove(nodes[0]);
                // On ajoute la nouvelle branche
                nodes.Add(newNode);

                // On récursive jusqu'à en avoir plus que 1 objet dans la liste
                GetTree(ref nodes);
            }
        }
        
        public void CheckSaMere(Node node)
        {
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

        public /*List<KeyValuePair<byte, byte>>*/void GetHuffmanCode(string way, Node node, ref List<KeyValuePair<byte, string>> l_kvp)
        {

            if (Object.ReferenceEquals(node.GetType(), typeof(Sum)))
            {
                ArrayList al = ((Sum)node).GetNodes();
                GetHuffmanCode(way + "0", ((Node)al[0]), ref l_kvp);
                GetHuffmanCode(way + "1", ((Node)al[1]), ref l_kvp);

            }
            else
            {
                Occurence o = (Occurence) node;
                l_kvp.Add(new KeyValuePair<byte, string>(o.GetKVP().Key, way));
            }
            /*List<KeyValuePair<byte, byte>> l_kvp = new List<KeyValuePair<byte, byte>>();
            byte b = ;

            return l_kvp;*/
        }
    }
}
