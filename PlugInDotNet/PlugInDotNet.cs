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
            // Récupération de la taille de la chaîne
            data.sizeOfUncompressedData = data.uncompressedData.Length;

            // Création d'un dictionnaire permettant de calculer le nombre d'occurences d'une lettre
            Dictionary<byte, int> dictionary = new Dictionary<byte, int>();

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

            // Remplissage du tableau de fréquences ainsi que des feuilles dans le noeud
            data.frequency = new List<KeyValuePair<byte, int>>();
            List<Node> nodes = new List<Node>();

            foreach (byte b in dictionary.Keys)
            {
                data.frequency.Add(new KeyValuePair<byte,int>(b, dictionary[b]));
                nodes.Add(new Occurence(new KeyValuePair<byte,int>(b, dictionary[b])));
            }

            // Création de l'arbre à une racine
            this.GetTree(ref nodes);

            // Création du code Huffman pour chaque lettre
            List<KeyValuePair<byte, List<bool>>> l_kvp = new List<KeyValuePair<byte, List<bool>>>();
            this.GetHuffmanCode(nodes[0], ref l_kvp, new List<bool>());

            // Remplacement de chaque caractère ASCII par son code Huffman
            this.CompressData(ref data, ref l_kvp);

            // Oubli de la valeur initiale de la chaîne
            data.uncompressedData = null;

            return true;
        }

        public bool Decompress(ref Huffman.HuffmanData data)
        {
            // Remplissage du tableau de fréquences ainsi que des feuilles dans le noeud            
            List<Node> nodes = new List<Node>();

            foreach (KeyValuePair<byte, int> kvp in data.frequency)
            {
                nodes.Add(new Occurence(new KeyValuePair<byte, int>(kvp.Key, kvp.Value)));
            }

            // Création de l'arbre à une racine
            this.GetTree(ref nodes);

            // Création du code Huffman pour chaque lettre
            List<KeyValuePair<byte, List<bool>>> l_kvp = new List<KeyValuePair<byte, List<bool>>>();
            this.GetHuffmanCode(nodes[0], ref l_kvp, new List<bool>());

            // Remplacement de chaque code Huffman par son caractère ASCII
            DecompressData(ref data, ref l_kvp);

            return true;
        }

        public string PluginName {
            get { return "Compress / Decompress";  }
        }

        public void GetTree(ref List<Node> nodes)
        {
            // On arrête si la liste n'a qu'un élément
            if (nodes.Count > 1)
            {
                // Récupération de l'index des deux plus petites valeurs
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
            // On vérifie si on est en présence d'un Sum ou d'une Occurence
            if (Object.ReferenceEquals(node.GetType(), typeof(Sum)))
            {
                // Récupération des noeud de la Sum
                ArrayList al = ((Sum)node).GetNodes();

                // On ajoute un 0 (false) et on récursive
                List<bool> l1 = new List<bool>(way);
                l1.Add(false);
                GetHuffmanCode(((Node)al[0]), ref l_kvp, l1);

                // On ajoute un 1 (true) et on récursive
                List<bool> l2 = new List<bool>(way);
                l2.Add(true);
                GetHuffmanCode(((Node)al[1]), ref l_kvp, l2);

            }
            else
            {
                // On ajoute à la liste la pair <ASCII, code Huffman>
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
            //Création de la liste booléenne représentant le code Huffman de la chaîne ASCII
            List<bool> l = new List<bool>();

            foreach (byte b in data.uncompressedData)
            {
                l.AddRange(GetValueOfKeyInList(ref huffman, b));
            }

            int end = 8 - l.Count % 8;

            // On ajoute des booléens jusqu'à avoir un nombre multiple de 8 de booléens
            for (int i = 0; i < end; i++)
            {
                l.Add(false);
            }

            // On transforme la liste de booléens en tableau de bytes
            BitArray compressed = new BitArray(l.ToArray());
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
                    if (l1[i] != l2[i])
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
            // Récupération de code Huffman et transformation en liste de booléens
            BitArray ba = new BitArray(data.compressedData);
            bool[] tabBools = new bool[data.compressedData.Length*8];
            ba.CopyTo(tabBools, 0);
            List<bool> l_b = tabBools.ToList();

            // Création du tableau de la chaîne décompressée
            byte[] decompressed = new byte[data.sizeOfUncompressedData];
            int i = 0;

            // Liste de booléens comparée au tableau code Huffman
            List<bool> l = new List<bool>();

            // Parcours de la liste de booléens
            foreach (bool b in l_b)
            {
                // Vérification si on est pas hors index dans le tableau
                if (i < decompressed.Length)
                {
                    l.Add(b);
                    
                    foreach (KeyValuePair<byte, List<bool>> kvp in huffman)
                    {
                        // Si les deux listes sont égales, on a retrouvé le code Huffman donc le caractère ASCII
                        if (AreEquals(kvp.Value, l))
                        {
                            decompressed[i] = kvp.Key;
                            i++;
                            l.Clear();
                        }
                    }
                }
            }

            // On stocke la donnée dans la structure data de HuffmanData
            data.uncompressedData = decompressed;
        }
    }
}
