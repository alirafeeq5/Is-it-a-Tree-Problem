using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IsATree
{
    public class CheckTree
    {
        //===============================================================================
        //Your Code is Here:
        public static bool IsTree(string[] vertices, List<KeyValuePair<string, string>> edges)
        {
           
            Dictionary<string, LinkedList<string>> adjacencyList = new Dictionary<string, LinkedList<string>>();
            string[] vertixColor = new string[vertices.Length];
            bool isTree = true;
            for (int vertix_no = 0; vertix_no < vertices.Length; vertix_no++)
            {
                vertixColor[vertix_no] = "White";
            }


            for (int edge_no = 0; edge_no < edges.Count; edge_no++)
            {
                string temp = edges[edge_no].Key;
                if (!adjacencyList.Keys.Contains(edges[edge_no].Key))
                {
                    adjacencyList[temp] = new LinkedList<string>();
                    adjacencyList[temp].AddFirst(edges[edge_no].Value);
                }
                else
                {
                    adjacencyList[temp].AddLast(edges[edge_no].Value);
                }
            }

            for (int vertix_no = 0; vertix_no < vertices.Length; vertix_no++)
            {
                string temp = vertices[vertix_no];
                if (adjacencyList.Keys.Contains(temp))
                {
                    isTree = dfsVisit(vertix_no, temp, adjacencyList, vertixColor, vertices);
                }

                if (isTree == false)
                    break;
            }

            return isTree;
        }
        public static int getIndexOf(string element, string[] vertices)
        {
            int index = -1;
            for (int vertix_no = 0; vertix_no < vertices.Length; vertix_no++)
            {
                if (vertices[vertix_no] == element)
                {
                    index = vertix_no;
                    break;
                }
            }
            return index;
        }
        public static bool dfsVisit(int vertixIndex, string vertix, Dictionary<string, LinkedList<string>> adjacencyList, string[] vertixColor, string[] vertices)
        {

            vertixColor[vertixIndex] = "Gray";
            bool isTree = true;
            for (int adjacent = 0; adjacent < adjacencyList[vertix].Count; adjacent++)
            {
                string temp = adjacencyList[vertix].First();
                int indexOfAdjacent = getIndexOf(temp, vertices);
                adjacencyList[vertix].RemoveFirst();
                if (adjacencyList.Keys.Contains(temp))
                {
                    if (vertixColor[indexOfAdjacent] == "White")
                    {

                        isTree = dfsVisit(indexOfAdjacent, vertices[indexOfAdjacent], adjacencyList, vertixColor, vertices);
                        if (isTree == false)
                        {
                            break;
                        }

                    }
                    else if (vertixColor[indexOfAdjacent] == "Gray")
                    {
                        isTree = false;
                        break;
                    }
                    else
                    {
                        isTree = true;

                    }

                }
            }
            vertixColor[vertixIndex] = "Black";
            return isTree;
        }

        //===============================================================================
       
        //===============================================================================
    }
}
