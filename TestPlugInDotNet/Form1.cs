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
            l_size_compression.Text = this.datas.uncompressedData.Length.ToString() + " octets";
            this.p.Compress(ref datas);
            rtb_for_compressed.Text = Encoding.ASCII.GetString(this.datas.compressedData);
            l_size_compressed.Text = this.datas.compressedData.Length.ToString() + " octets";

            lb_frequency.Items.Clear();
            foreach (KeyValuePair<byte, int> kvp in datas.frequency)
            {
                byte[] b = { kvp.Key };
                lb_frequency.Items.Add("Caractère : " + Encoding.ASCII.GetString(b));

                string binary = Convert.ToString(kvp.Key, 2);
                lb_frequency.Items.Add("Caractère ASCII : " + binary);

                lb_frequency.Items.Add("Nombre d'occurences : " + kvp.Value.ToString());
                lb_frequency.Items.Add("");
            }
        }

        private void b_for_decompression_Click(object sender, EventArgs e)
        {
            this.p.Decompress(ref datas);
            rtb_for_decompression.Text = Encoding.ASCII.GetString(this.datas.uncompressedData);
            l_size_decompression.Text = this.datas.uncompressedData.Length.ToString() + " octets";           
        }
    }
}
