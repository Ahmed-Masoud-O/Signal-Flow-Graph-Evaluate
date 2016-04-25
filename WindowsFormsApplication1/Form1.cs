using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class mainFrame : Form
    {
        public enum Operations
        {
            Node,
            Path,
            StartNode,
            EndNode,
            DeleteNode,
            DisConnect
        }
        private String Delta = "";
        private Point tempPoint;
        private Line tempLine;
        private Operations currentOperation;
        private bool Dragging = false;
        private Node tempNode = null;
        private List<Node> nodes;
        private List<Line> Paths;
        private bool lag = false;
        List<List<Node>> LopeVerticessNodes = new List<List<Node>>();
        List<List<Node>> forwardPathsNodes = new List<List<Node>>();
        List<String> ForwardPathsGain = new List<String>();
        List<String> Loops = new List<string>();
        List<List<Line>> LoopPaths = new List<List<Line>>();
        List<String> LoopsGain = new List<String>();
        List<List<List<List<Node>>>> AllNonTouchingLoops = new List<List<List<List<Node>>>>();
        private List<List<List<List<Node>>>> nonTouchingLoops = new List<List<List<List<Node>>>>();





        private Node Root = null;
        private Node Sink = null;
        private Connections connections;
        public mainFrame()
        {
            InitializeComponent();
            nodes = new List<Node>();
            Paths = new List<Line>();
            tempLine = new Line(null, null);
            connections = new Connections();


        }

        private void mainFrame_Load(object sender, EventArgs e)
        {

        }

        private void mouseDown(object sender, MouseEventArgs e)
        {
            if (!lag)
            {


                if (currentOperation == null) ;
                else if (currentOperation == Operations.Node)
                {
                    tempNode = new Node(new Point(e.X, e.Y));
                    nodes.Add(tempNode);
                    lag = true;
                    Input.Enabled = true;
                    Input.Focus();

                }
                else if (currentOperation == Operations.DeleteNode)
                {
                    foreach (Node selected in nodes)
                    {
                        if (selected.Contain(new Point(e.X, e.Y)))
                        {
                            updateDeletedNode(selected);
                            removePaths(selected);
                            nodes.Remove(selected);

                            break;
                        }

                    }
                }
                else if (currentOperation == Operations.Path)
                {
                    foreach (Node selected in nodes)
                    {
                        if (selected.Contain(new Point(e.X, e.Y)))
                        {
                            if (tempLine.Start == null)
                            {
                                tempLine.Start = selected;
                            }
                            else if (tempLine.End == null)
                            {
                                tempLine.End = selected;
                                tempLine.Start.OutNodes.Add(selected);
                                tempLine.End.InNodes.Add(tempLine.Start);
                                Paths.Add(new Line(tempLine));
                                tempLine.Start = tempLine.End = null;
                                lag = true;
                                Input.Enabled = true;
                                Input.Focus();



                                break;
                            }
                        }


                    }



                }
                else if (currentOperation == Operations.StartNode)
                {

                    foreach (Node node in nodes)
                    {
                        if (node.Contain(new Point(e.X, e.Y)))
                        {
                            if (Root != null && Root != node)
                            {
                                Root.IsRoot = false;
                                Root = node;
                                node.IsRoot = true;
                            }
                            else
                            {
                                Root = node;
                                node.IsRoot = true;
                            }

                        }
                    }
                }
                else if (currentOperation == Operations.EndNode)
                {

                    foreach (Node node in nodes)
                    {
                        if (node.Contain(new Point(e.X, e.Y)))
                        {
                            if (Sink != null && Sink != node)
                            {
                                Sink.IsSink = false;
                                Sink = node;
                                node.IsSink = true;
                            }
                            else
                            {
                                Sink = node;
                                node.IsSink = true;
                            }

                        }
                    }
                }
                this.Invalidate();
            }
        }
        private void updateDeletedNode(Node deleted)
        {
            foreach (Node node in nodes)
            {
                node.Update(deleted);
            }
        }
        public void mouseUp(object sender, MouseEventArgs e)
        {
            Console.WriteLine("mouse released");
        }

        private void mouseMoved(object sender, MouseEventArgs e)
        {

        }

        private void DisconnectButton_Click(object sender, EventArgs e)
        {

        }

        private void ButtonsPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ConncetButton_Click(object sender, EventArgs e)
        {

        }

        private void NodeButton_Click(object sender, EventArgs e)
        {
            currentOperation = Operations.Node;
        }

        private void mainFrame_Paint(object sender, PaintEventArgs e)
        {

            Graphics g = e.Graphics;
            foreach (Node node in nodes)
            {
                node.Draw(g);

            }
            foreach (Line Path in Paths)
            {

                Path.Draw(g);
            }
        }



        private void DeleteButton_Click_1(object sender, EventArgs e)
        {
            currentOperation = Operations.DeleteNode;

        }

        private void PathButton_Click(object sender, EventArgs e)
        {
            currentOperation = Operations.Path;
        }
        private void removePaths(Node deleted)
        {
            List<Line> pathsToDelete = new List<Line>();
            foreach (Line path in Paths)
            {
                if (path.Start == deleted || path.End == deleted)
                {
                    pathsToDelete.Add(path);
                }
            }
            foreach (Line path in pathsToDelete)
            {
                Paths.Remove(path);
            }
        }

        private void Input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (currentOperation == Operations.Node)
                {
                    nodes[nodes.Count - 1].NodeName = Input.Text;
                }
                else if (currentOperation == Operations.Path)
                {
                    Paths[Paths.Count - 1].Gain = Input.Text;
                }
                Input.Text = "";
                Input.Enabled = false;
                this.Refresh();
                lag = false;

            }
        }

        private void StartNodeButton_Click(object sender, EventArgs e)
        {
            currentOperation = Operations.StartNode;

        }

        private void EndNodeButton_Click(object sender, EventArgs e)
        {
            currentOperation = Operations.EndNode;
        }

        private void EvaluateButton_Click(object sender, EventArgs e)
        {
            TF.Visible = true;
            List<Node> Temp1 = new List<Node>();

            connections.BFS(Root, Sink, Root);
            List<Node[]> bibo = Connections.forwardPaths;
            foreach (Node[] bibo2 in bibo)
            {
                foreach (Node bibo3 in bibo2)
                {
                    Console.Write(bibo3.NodeName);
                    Temp1.Add(bibo3);
                }
                Console.WriteLine();
                forwardPathsNodes.Add(Temp1);
                Temp1 = new List<Node>();
            }
            Connections.forwardPaths.Clear();
            String Temp = "";
            foreach (Node n in nodes)
            {
                connections.BFS(n, n, n);
                bibo = Connections.forwardPaths;
                foreach (Node[] bibo2 in bibo)
                {
                    foreach (Node bibo3 in bibo2)
                    {
                        Console.Write(bibo3.NodeName);
                        Temp = Temp + bibo3.NodeName;
                    }
                    Console.WriteLine();

                    Loops.Add(Temp);
                    Temp = "";
                }
                Temp = "";
                Connections.forwardPaths.Clear();
                n.isVisited = true;

            }

            List<List<String>> LoopVerticees = new List<List<string>>();
            LoopVerticees = getLoopVerticees(Loops);
            List<List<Line>> ForwardVerticees = new List<List<Line>>();
            ForwardVerticees = getForwardPaths(forwardPathsNodes);
            ForwardPathsGain = calcaulateLoopGain(ForwardVerticees);
            LoopPaths = getLoopPaths(LoopVerticees);
            LoopsGain = calcaulateLoopGain(LoopPaths);
           

            
            LopeVerticessNodes = getLoopVerticeesNodes(LoopPaths);
            List<List<int>> non = getNonTouching(LopeVerticessNodes);
            String nonGain = getNonTouchingLoops(non);
            String LoopGainsMod = "[";
           
           /* foreach (List<Node> loop in LopeVerticessNodes)
            {
                List<List<Node>> temp = new List<List<Node>>();
                temp.Add(loop);
                expand(temp);
            }*/
            foreach (String s in LoopsGain)
            {
                LoopGainsMod += s + "+";
            }
            LoopGainsMod = LoopGainsMod.Remove(LoopGainsMod.Length - 1) + "] + ";
            if (nonGain.Length == 1)
            {
                nonGain = "";
                LoopGainsMod = LoopGainsMod.Remove(LoopGainsMod.Length - 2);
            }
            // Delta = "1 - " + LoopGainsMod + nonGain;
            Delta = "1 - " + LoopGainsMod;

            AllNonTouchingLoops = getNonTouchingLoops();
            removeNonTouchingDuplicateCycles();
            String Test = "";
            foreach (List<List<List<Node>>> list in AllNonTouchingLoops)
            {
                foreach(List<List<Node>> list2 in list)
                {
                    foreach (List<Node> loop in list2)
                    {
                        if (loop.Count == 1)
                        {
                            loop.Add(loop[0]);
                        }
                        else if (loop[loop.Count-1]!=loop[0])
                        {
                            loop.Add(loop[0]);
                        }
                        
                        
                        //Test += CalculateGain(CalculateLines(loop))+" + ";
                    }
                }
            }
            String test1 = "[";
            int count = 0;
            foreach (List<List<List<Node>>> list in AllNonTouchingLoops)
            {
                foreach (List<List<Node>> list2 in list)
                {
                    foreach (List<Node> loop in list2)
                    {
                       


                        Test += CalculateGain(CalculateLines(loop))+" . ";
                    }
                    Test = Test.Remove(Test.Length - 2);
                    Test += " + ";

                }
                if (count % 2 == 0)
                {
                    Test = Test.Remove(Test.Length - 2);
                    Test += "] - [";
                    count++;
                }
                else
                {
                    Test = Test.Remove(Test.Length - 2);
                    Test += "] + [";
                    count++;
                }
                test1 += Test;
                Test = "";
            }
            
            Delta += test1;
            Delta = Delta.Remove(Delta.Length - 2);
            //do nonGain once more after appending the 2 non touching loops and re-call function yo get 3 non touching
            if (Delta.Length == 6)
            {
                Delta = "1";
            }
           
            Console.WriteLine(Delta);
            int i = 0;
            String numerator = "";
            for (i = 0; i < forwardPathsNodes.Count; i++)
            {
                numerator += "(" + ForwardPathsGain[i] + ")";
                numerator += nonTouchingLoopsAndPaths(LopeVerticessNodes, forwardPathsNodes[i]);
                numerator += ") + ";
                //Console.WriteLine(ForwardPathsGain[i] + biboo);

            }
            numerator = numerator.Remove(numerator.Length - 2);
            numerator += " ";

            Console.WriteLine("---------------------------------------");
            TF.Text = ("\t\t" + numerator + "\n________________________________________________________________________________\n\n\t\t" + Delta);

            foreach (List<Node> list in forwardPathsNodes)
            {
                String sheyaka = "";
                foreach (Node node in list)
                {
                    sheyaka += node.NodeName + " => ";
                }
                sheyaka = sheyaka.Remove(sheyaka.Length - 4);

                path.Items.Add(sheyaka);
            }

            foreach (List<Line> list in LoopPaths)
            {
                String sheyaka = "";
                String lastvertex = "";
                foreach (Line path in list)
                {
                    sheyaka += path.Start.NodeName + " => ";
                    lastvertex = path.End.NodeName;
                }
                sheyaka += lastvertex;
                loop.Items.Add(sheyaka);
            }




        }
         
        private String nonTouchingLoopsAndPaths(List<List<Node>> LopeVerticessNodes, List<Node> forwardpathnode)
        {
            String returnvalue = "(1 - ";
            List<List<Node>> Loop;
            bool isTouching = false;
            foreach (List<Node> loopVertexList in LopeVerticessNodes)

            {
                foreach (Node vertex in forwardpathnode)
                {
                    foreach (Node loopVertex in loopVertexList)
                    {
                        if (loopVertex == vertex)
                        {
                            isTouching = true;
                            break;
                        }
                    }
                    if (isTouching)
                    {

                        break;
                    }
                }
                if (isTouching)
                {
                    isTouching = false;

                }
                else
                {
                    Loop = new List<List<Node>>();

                    List<Node> tempp = loopVertexList;
                    if (loopVertexList.Count == 1)
                    {

                        tempp.Add(loopVertexList[0]);

                    }
                    Loop.Add(tempp);
                    List<List<Line>> temp = getForwardPaths(Loop);
                    returnvalue += calcaulateLoopGain(temp)[0] + ".";
                    returnvalue = returnvalue.Remove(returnvalue.Length-1)+"+";

                }
            }
            returnvalue = returnvalue.Remove(returnvalue.Length - 1);
            return returnvalue == "(1 -" ? "(1 - 0" : returnvalue;

        }

        /* private void expand(List<List<Node>> nonTouching)
         {
             foreach (List<Node> loop in LopeVerticessNodes)
             {
                 bool flag = false;
                 foreach (List<Node> mainloop in nonTouching)
                 {
                     if (isTouching(mainloop,loop))
                     {
                         flag = true;
                         break;
                     }
                 }
                 if (!flag)
                 {
                     List<List<Node>> temp = new List<List<Node>>();
                     foreach (List<Node> listt in nonTouching)
                     {
                         temp.Add(listt);
                     }
                        // ((List<Node>[])nonTouching.ToArray().Clone()).CopyTo(temp);
                     temp.Add(loop);

                     if (AllNonTouchingLoops.Count < temp.Count-1)
                     {
                         AllNonTouchingLoops.Add(new List<List<List<Node>>>());
                     }
                     bool duplicate = false;
                     if(!(AllNonTouchingLoops[temp.Count-2].Contains(temp)))
                         AllNonTouchingLoops[temp.Count-2].Add(temp);
                     expand(temp);
                     // temp is a list of loops, nontouching+1
                 }
             }
         }*/
        /*************************************************/
        private void expand(List<List<Node>> cycles)
        {
            bool flag = false;
            foreach (List<Node> cycle1 in LopeVerticessNodes)
            {
                flag = false;
                foreach(List<Node> cycle2 in cycles)
                {
                    if (isTouching(cycle1, cycle2))
                    {
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    List<List<Node>> temp = new List<List<Node>>();
                    foreach (List<Node> l in cycles)
                    {
                        temp.Add(l);
                    }
                    temp.Add(cycle1);

                    if (nonTouchingLoops.Count < temp.Count - 1)
                    {
                        nonTouchingLoops.Add(new List<List<List<Node>>>());
                    }

                    nonTouchingLoops[temp.Count - 2].Add(temp);
                    expand(temp);
                }
            }
        }

        private List<List<List<List<Node>>>> getNonTouchingLoops()
        {
            foreach(List<Node> cycle1 in LopeVerticessNodes)
            {
                foreach (List<Node> cycle2 in LopeVerticessNodes)
                {

                    if (!isTouching(cycle1, cycle2))
                    {
                        List<List<Node>> temp = new List<List<Node>>();
                        temp.Add(cycle1);
                        temp.Add(cycle2);

                        if (nonTouchingLoops.Count == 0)
                        {
                            nonTouchingLoops.Add(new List<List<List<Node>>>());
                        }

                        nonTouchingLoops[0].Add(temp);
                        expand(temp);
                    }
                }
            }
            removeNonTouchingDuplicateCycles();

            return nonTouchingLoops;
        }
        private void removeNonTouchingDuplicateCycles()
        { 
            bool flag;
            foreach (List<List<List<Node>>> listDegreeofNontouchingLoops in nonTouchingLoops)
            {
                for (int i = 0; i <= listDegreeofNontouchingLoops.Count - 1 ; i++)
                {
                    for (int j = 0; j <= listDegreeofNontouchingLoops.Count - 1 ; j++)
                    {
                        flag = false;
                        List<List<Node>> paths1 = listDegreeofNontouchingLoops[i];
                        List<List<Node>> paths2 = listDegreeofNontouchingLoops[j];             
                        if (paths1.Count == paths2.Count)
                        {
                            foreach (List<Node> cycle in paths1)
                            {
                                if (!paths2.Contains(cycle))
                                {
                                    flag = true;
                                    break;
                                }
                            }
                        }

                        if (!flag && i!=j)
                        {
                            listDegreeofNontouchingLoops.RemoveAt(j);
                            flag = false;
                        }

                    }
                }
            }
            //System.out.println("bibo");
        }















        /*************************************************/

        private bool listsEquall(List<Node> l1 , List<Node>l2)
        {
            if (l1.Count != l2.Count)
                return false;
            foreach (Node n in l1)
            {
                if (!(l2.Contains(n)))
                    return false;
            }
            return true;
        }

        private bool listExistsIn(List<Node> loop,List<List<Node>> list)
        {
            foreach (List<Node> x in list)
            {
                if (listsEquall(x, loop))
                    return true;
            }
            return false;
        }

        private bool isTouching(List<Node> loop1,List<Node> loop2)
        {
            foreach (Node n in loop1)
            {
                if (loop2.Contains(n))
                {
                    return true;
                }
            }
            return false;
        }
        private String getNonTouchingLoops(List<List<int>> non)
        {
            String temp = "[";
            foreach (List<int> nonTouchingIndex in non)
            {
                foreach (int index in nonTouchingIndex)
                {
                    temp += "(" + LoopsGain[index] + ")";
                }
                temp += "+";
            }
            temp = temp.Remove(temp.Length - 1);
            temp += "]";
            return temp;
        }


        private List<List<int>> getNonTouching(List<List<Node>> LopeVerticessNodes)
        {
            List<List<int>> nonTouchingLoopsIndex = new List<List<int>>();
            int i = 0; bool istouching = false;
            for (i = 0; i < LopeVerticessNodes.Count; i++)
            {
                for (int j = i + 1; j < LopeVerticessNodes.Count; j++)
                {
                    foreach (Node cmp in LopeVerticessNodes[i])
                    {
                        foreach (Node n in LopeVerticessNodes[j])
                        {
                            if (cmp == n)
                            {
                                istouching = true;
                                break;
                            }
                        }
                        if (istouching)
                        {
                            break;
                        }
                    }
                    if (istouching)
                    {
                        istouching = false;
                    }
                    else
                    {
                        List<int> temp = new List<int>();
                        temp.Add(i);
                        temp.Add(j);
                        nonTouchingLoopsIndex.Add(temp);

                    }

                }
            }
            return nonTouchingLoopsIndex;
        }
        private List<List<Node>> getLoopVerticeesNodes(List<List<Line>> LoopPaths)
        {
            List<Node> temp = new List<Node>();
            List<List<Node>> LopeVerticessNodes = new List<List<Node>>();
            Node start;
            foreach (List<Line> loop in LoopPaths)
            {
                if (loop.Count != 0) { 
                start = loop[0].Start;
                temp.Add(start);
                foreach (Line path in loop)
                {
                    if (path.End != start)
                    {
                        temp.Add(path.End);
                    }
                }
                LopeVerticessNodes.Add(temp);
                temp = new List<Node>();
            } }
            return LopeVerticessNodes;
        }

        private List<String> calcaulateLoopGain(List<List<Line>> LoopPaths)
        {
            String Temp = "";
            List<String> LoopGains = new List<String>();
            foreach (List<Line> paths in LoopPaths)
            {
                foreach (Line path in paths)
                {
                    Temp = Temp + path.Gain + ".";
                }
                if (Temp != "")
                    Temp = Temp.Remove(Temp.Length - 1);
                LoopGains.Add(Temp);
                Temp = "";
            }
            return LoopGains;

        }

        private List<List<Line>> getLoopPaths(List<List<String>> LoopPaths)
        {
            int i = 0;
            List<List<Line>> loopPathsGain = new List<List<Line>>();
            List<Line> temp = new List<Line>();
            foreach (List<String> loopPath in LoopPaths)
            {
                i = 0;
                int j;

                for (j=0;j<Paths.Count;j++)
                {

                    if (i < loopPath.Count)
                        if (Paths[j].Start.NodeName == loopPath[i][0].ToString() && Paths[j].End.NodeName == loopPath[i][1].ToString())
                        {
                            temp.Add(Paths[j]);
                            j = 0;
                            i++;
                        }


                }
                loopPathsGain.Add(temp);
                temp = new List<Line>();
            }
            return loopPathsGain;
        }

        private List<List<Line>> getForwardPaths(List<List<Node>> ForwardPaths)
        {
            int i = 0;
            List<List<Line>> ForwardPathsPaths = new List<List<Line>>();
            List<Line> temp = new List<Line>();
            foreach (List<Node> list in ForwardPaths)
            {

                for (i = 0; i < list.Count; i++)
                {
                    foreach (Line path in Paths)
                    {

                        if (i + 1 < list.Count)
                            if (path.Start == list[i] && path.End == list[i + 1])
                            {
                                temp.Add(path);


                                break;
                            }

                    }
                }


                ForwardPathsPaths.Add(temp);
                temp = new List<Line>();
                i = 0;

            }
            return ForwardPathsPaths;
        }

        private List<List<String>> getLoopVerticees(List<String> Loops)
        {
            List<List<String>> LoopPaths = new List<List<String>>();
            List<String> singleLoopPath = new List<string>();
            int i = 0, j = 0;
            String temp = "";
            foreach (String loop in Loops)
            {
                i = 0;
                singleLoopPath = new List<string>();
                while (i + 1 < loop.Length)
                {
                    temp = loop[i].ToString() + loop[i + 1].ToString();
                    i++;
                    singleLoopPath.Add(temp);
                }

                LoopPaths.Add(singleLoopPath);
            }
            return LoopPaths;

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private  List<Line> CalculateLines(List<Node> x)
        {
            List<Line> returnValue = new List<Line>();
            for (int i = 0; i < x.Count - 1; i++)
            {
                foreach (Line y in Paths)
                    if (y.Start == x[i] && y.End == x[i+1])
                    {
                        returnValue.Add(y);
                        break;
                    }
            }
            return returnValue;
        }
        private  String CalculateGain(List<Line> x)
        {
            String temp = "";
            if (x != null && x.Count!=0)
            {
                temp += "(";
                foreach (Line y in x)
                {
                    temp += y.Gain + ".";
                }
                temp = temp.Substring(0, temp.Length - 1);
                temp += ")";
            }
            return temp;
        }
    }


}