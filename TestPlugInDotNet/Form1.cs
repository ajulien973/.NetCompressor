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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Huffman.HuffmanData datas = new Huffman.HuffmanData();
            datas.uncompressedData = Encoding.ASCII.GetBytes("ffffffaaaaaaaaaabbbbbbbbbbddddddddddddddddccccccccccccccccccccccccceeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee");
            PlugInDotNet.PlugInDotNet p = new PlugInDotNet.PlugInDotNet();
            p.Compress(ref datas);

            System.Console.WriteLine(Encoding.ASCII.GetString(datas.uncompressedData));

            foreach (KeyValuePair<byte, int> kvp in datas.frequency)
            {
                byte[] tabByte = { kvp.Key };
                System.Console.WriteLine(Encoding.ASCII.GetString(tabByte) + " - " + Convert.ToString(kvp.Value));
            }
        }
    }
}
