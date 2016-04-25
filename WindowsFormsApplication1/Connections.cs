using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Connections
    {
        public static List<Node[]> forwardPaths = new List<Node[]>();
        private Stack<Node> testStack;
        private int counter = 0;

        public Connections()
        {
            this.testStack = new Stack<Node>();
            
        }
        public void BFS(Node nowNode, Node end, Node root)
        {
            if (nowNode == end && testStack.Count != 0)
            {
                AddPath(root);

                testStack.Pop().isVisited = false;
                return;
            }
            else if (nowNode.OutNodes.Count == 0)
            {
                if(testStack.Count!=0)
                testStack.Pop().isVisited = false;
                return;
            }
            else {
                foreach (Node x in nowNode.OutNodes)
                {
                    if (!x.isVisited)
                    {
                        x.isVisited = true;
                        testStack.Push(x);
                        BFS(x, end,root);
                    }
                }
                if(testStack.Count!=0)
                testStack.Pop().isVisited = false;
            }

        }

        private void AddPath(Node root)
        {
            Node[] temp = new Node[testStack.Count + 1];
            int j = 1;
            for (int i = testStack.Count - 1; i >= 0; i--)
            {
                temp[j++] = testStack.ElementAt(i);

            }
            temp[0] = root;
           
                forwardPaths.Add(temp);
            
        }

       
    }
}

