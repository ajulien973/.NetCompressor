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

            List<KeyValuePair<byte, List<bool>>> l_kvp = new List<KeyValuePair<byte, List<bool>>>();

            GetHuffmanCode(nodes[0], ref l_kvp, new List<bool>());

            /*foreach (KeyValuePair<byte, List<bool>> kvp in l_kvp)
            {
                byte[] tabByte = { kvp.Key };
                List<bool> listBool = kvp.Value;
                string s = "";
                foreach (bool b in listBool)
                {
                    if (b)
                    {
                        s = s + "1";
                    }
                    else
                    {
                        s = s + "0";
                    }
                }
                Console.Write("(" + s + " - " + Encoding.ASCII.GetString(tabByte) + ")");
            }
            Console.WriteLine("");*/

            CompressData(ref data, ref l_kvp);

            data.uncompressedData = null;

            return true;
        }

        public bool Decompress(ref Huffman.HuffmanData data)
        {
            List<Node> nodes = new List<Node>();

            // Transfert du dictionary dans le tableau de KeyValuePair
            foreach (KeyValuePair<byte, int> kvp in data.frequency)
            {
                nodes.Add(new Occurence(new KeyValuePair<byte, int>(kvp.Key, kvp.Value)));
            }

            GetTree(ref nodes);

            List<KeyValuePair<byte, List<bool>>> l_kvp = new List<KeyValuePair<byte, List<bool>>>();

            GetHuffmanCode(nodes[0], ref l_kvp, new List<bool>());

            DecompressData(ref data, ref l_kvp);

            return true;
        }

        public string PluginName {
            get { return "";  }
        }

        public void GetTree(ref List<Node> nodes)
        {
            if (nodes.Count > 1)
            {
                int i = 2;
                int i1;
                int i2;

                if(nodes[0].GetValue() < nodes[1].GetValue())
                {
                    i1 = 0;
                    i2 = 1;
                }
                else
                {
                    i1 = 1;
                    i2 = 0;
                }

                while (i < nodes.Count)
                {
                    if (nodes[i].GetValue() < nodes[i1].GetValue())
                    {
                        i2 = i1;
                        i1 = i;
                    }
                    else if (nodes[i].GetValue() < nodes[i2].GetValue())
                    {
                        i2 = i;
                    }

                    i++;
                }

                // Création d'une nouvelle branche (sum)
                Sum newNode = new Sum();

                // On ajoute les deux liens à cette nouvelle branche
                newNode.Add(nodes[i1]);
                newNode.Add(nodes[i2]);
                // On supprime de la liste les deux liens 
                if (i1 < i2)
                {
                    nodes.Remove(nodes[i2]);
                    nodes.Remove(nodes[i1]);
                }
                else
                {
                    nodes.Remove(nodes[i1]);
                    nodes.Remove(nodes[i2]);
                }
                // On ajoute la nouvelle branche
                nodes.Add(newNode);

                // On récursive jusqu'à en avoir plus que 1 objet dans la liste
                GetTree(ref nodes);
            }
        }

        public void GetHuffmanCode(Node node, ref List<KeyValuePair<byte, List<bool>>> l_kvp, List<bool> way)
        {

            if (Object.ReferenceEquals(node.GetType(), typeof(Sum)))
            {
                ArrayList al = ((Sum)node).GetNodes();

                List<bool> l1 = new List<bool>(way);
                l1.Add(false);
                GetHuffmanCode(((Node)al[0]), ref l_kvp, l1);

                List<bool> l2 = new List<bool>(way);
                l2.Add(true);
                GetHuffmanCode(((Node)al[1]), ref l_kvp, l2);

            }
            else
            {
                Occurence o = (Occurence) node;
                l_kvp.Add(new KeyValuePair<byte, List<bool>>(o.GetKVP().Key, way));
            }
        }

        public List<bool> GetValueOfKeyInList(ref List<KeyValuePair<byte, List<bool>>> huffman, byte key)
        {
            foreach (KeyValuePair<byte, List<bool>> kvp in huffman)
            {
                if (kvp.Key == key)
                {
                    return kvp.Value;
                }
            }

            return new List<bool>();
        }

        public void CompressData(ref Huffman.HuffmanData data, ref List<KeyValuePair<byte, List<bool>>> huffman)
        {
            BitArray compressed;
            List<bool> l = new List<bool>();

            foreach (byte b in data.uncompressedData)
            {
                l.AddRange(GetValueOfKeyInList(ref huffman, b));
            }

            int end = 8 - l.Count % 8;

            for (int i = 0; i < end; i++)
            {
                l.Add(false);
            }

            compressed = new BitArray(l.ToArray());
            int nb = l.Count / 8;
            data.compressedData = new byte[nb];
            compressed.CopyTo(data.compressedData, 0);
        }

        public bool AreEquals(List<bool> l1, List<bool> l2)
        {
            if (l1.Count == l2.Count)
            {
                for (int i = 0; i < l1.Count; i++)
                {
                    if (l1[i] && !l2[i])
                    {
                        return false;
                    }

                    if (!l1[i] && l2[i])
                    {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }

        public void DecompressData(ref Huffman.HuffmanData data, ref List<KeyValuePair<byte, List<bool>>> huffman)
        {
            BitArray ba = new BitArray(data.compressedData);
            bool[] tabBools = new bool[data.compressedData.Length*8];
            ba.CopyTo(tabBools, 0);
            List<bool> l_b = tabBools.ToList();
            List<bool> l = new List<bool>();
            
            byte[] decompressed = new byte[data.sizeOfUncompressedData];
            int i = 0;

            foreach (bool b in l_b)
            {
                if (i < decompressed.Length)
                {
                    l.Add(b);
                    
                    foreach (KeyValuePair<byte, List<bool>> kvp in huffman)
                    {
                        if (AreEquals(kvp.Value, l))
                        {
                            decompressed[i] = kvp.Key;
                            i++;
                            l.Clear();
                        }
                    }
                }
            }

            
            data.uncompressedData = decompressed;
        }
    }
}
