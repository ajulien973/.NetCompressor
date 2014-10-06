using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PlugInDotNet;

namespace TestPlugInDotNet
{
    public partial class pluginDotNet : Form
    {
        private PlugInDotNet.PlugInDotNet p;
        private Huffman.HuffmanData datas;

        public pluginDotNet()
        {
            InitializeComponent();
            this.p = new PlugInDotNet.PlugInDotNet();
            this.datas = new Huffman.HuffmanData();
        }

        private void b_for_compression_Click(object sender, EventArgs e)
        {
            this.datas.uncompressedData = Encoding.ASCII.GetBytes(rtb_for_compression.Text);
            this.p.Compress(ref datas);
            //rtb_for_compressed.Text = Encoding.ASCII.GetString(datas.compressedData);
            /*
            System.Console.WriteLine(Encoding.ASCII.GetString(datas.uncompressedData));

            foreach (KeyValuePair<byte, int> kvp in datas.frequency)
            {
                byte[] tabByte = { kvp.Key };
                System.Console.WriteLine(Encoding.ASCII.GetString(tabByte) + " - " + Convert.ToString(kvp.Value));
            }*/
            // ffffffaaaaaaaaaabbbbbbbbbbddddddddddddddddccccccccccccccccccccccccceeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee
        }

        private void b_for_decompression_Click(object sender, EventArgs e)
        {
            this.p.Decompress(ref datas);
            rtb_for_decompression.Text = Encoding.ASCII.GetString(this.datas.uncompressedData);            
        }
    }
}
