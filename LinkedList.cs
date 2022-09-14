namespace SD340_W22SD_Lab2
{
    public class Node
    {
        public object Data { get; set; }
        public Node Next { get; set; }
        public Node(object data) {
            Data = data;
        }
        public void PrintData()
        {
            Console.Write(Data);
        }
    }

    public class LinkedList
    {
        public int Count { get; private set; } = 0;
        public Node NodeHead { get; set; }
        public List<Node> Nodes { get; set; }
        private Type DataType { get; set; }
        public LinkedList(){
            Nodes = new List<Node>();
        }

        public void Add(object nodeData){
            Type typeOfNewData = nodeData.GetType();
            Node newNode = new Node(nodeData);
            if (NodeHead != null)  {
                if (typeOfNewData == DataType)
                {
                    Node previousNode = NodeHead;
                    newNode.Next = previousNode;
                }
                else{
                    throw new Exception("LinkedList supports only one data type");
                }
            }
            else {
                DataType = typeOfNewData;
            }
            Nodes = Nodes.Prepend(newNode).ToList();
            NodeHead = newNode;
            Count += 1;
        }
        public void PrintNodes() {
            Console.WriteLine("\nPrinting all nodes");
            foreach (Node node in Nodes)  {
                node.PrintData();
                Console.Write(", ");
            }
        }
    }
}
