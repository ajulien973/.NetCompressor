using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Huffman;

namespace PlugInDotNet
{
    public class PlugInDotNet : MarshalByRefObject, IPlugin 
    {
        public bool Compress(ref Huffman.HuffmanData data)
        {
            bool r = false;

            data.sizeOfUncompressedData = data.uncompressedData.Length;
            data.frequency = new List<KeyValuePair<byte, int>>();

            Dictionary<byte, int> d = new Dictionary<byte, int>();

            foreach(byte b in data.uncompressedData)
            {
                if (d.ContainsKey(b))
                {
                    d[b] = d[b] + 1;
                }
                else
                {
                    d.Add(b, 1);
                }
            }

            foreach (byte b in d.Keys)
            {
                data.frequency.Add(new KeyValuePair<byte,int>(b, d[b]));
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
    }
}
