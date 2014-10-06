using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlugInDotNet
{
    // Define a "lowest common denominator"
    public interface Node
    {
        int GetValue();
    }

    // File implements the "lowest common denominator"
    public class Occurence : Node
    {
        private KeyValuePair<byte, int> kvp;

        public Occurence(KeyValuePair<byte, int> kvp)
        {
            this.kvp = kvp;
        }

        public int GetValue()
        {
            return this.kvp.Value;
        }
    }

    // Directory implements the "lowest common denominator"
    public class Sum : Node
    {
        private ArrayList nodes = new ArrayList();

        public void Add(Node node)
        {
            nodes.Add(node);
        }

        public void Remove(Node node)
        {
            nodes.Remove(node);
        }

        public int GetValue()
        {
            int sum = 0;
            foreach (Node node in nodes)
            {
                sum += node.GetValue();
            }
            return sum;
        }

        public ArrayList GetNodes()
        {
            return this.nodes;
        }
    }
}
