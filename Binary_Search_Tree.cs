using System ;

namespace Binary_Search_Tree
{
    class Node
    {
        public int Data ;
        public Node Left_Child ;
        public Node Right_Child ;
        public Node( int Data_ = 0 )
        {
            Data = Data_ ;
            Left_Child = null ;
            Right_Child = null ;
        }
    }

    class Tree
    {
        private Node Root_Node ;
        public Tree()
        {
            Root_Node = null ;
        }

        public void Insert( int Value )
        {
            Root_Node = Insert(ref Root_Node , ref Value) ;
        }
        public Node Insert( ref Node Current_Node , ref int Value )
        {
            if( Current_Node == null )
            {
                Current_Node = new Node( Value ) ;
                return Current_Node ;
            }
            if( Value < Current_Node.Data )
            {
                Current_Node.Left_Child = Insert(ref Current_Node.Left_Child , ref Value) ;
            }
            if( Value > Current_Node.Data )
            {
                Current_Node.Right_Child = Insert(ref Current_Node.Right_Child , ref Value) ;
            }

            return Current_Node ;
        }

        public void Pre_Order_Traversal()
        {
            Console.WriteLine("\n\nPreOrder Traversal") ;
            Pre_Order_Traversal(ref Root_Node) ;
        }
        public void Pre_Order_Traversal( ref Node Current_Node )
        {
            if( Current_Node != null )
            {
                Console.WriteLine("{0} ", Current_Node.Data);
                Pre_Order_Traversal(ref Current_Node.Left_Child);
                Pre_Order_Traversal(ref Current_Node.Right_Child) ;
            }
            else
            {
                return ;
            }
        }

        public void Post_Order_Traversal()
        {
            Console.WriteLine("\n\nPostOrder Traversal");
            Post_Order_Traversal(ref Root_Node);
        }
        public void Post_Order_Traversal(ref Node Current_Node)
        {
            if (Current_Node != null)
            {
                Post_Order_Traversal(ref Current_Node.Left_Child);
                Post_Order_Traversal(ref Current_Node.Right_Child);
                Console.WriteLine("{0} ", Current_Node.Data);
            }
            else
            {
                return;
            }
        }

        public void In_Order_Traversal()
        {
            Console.WriteLine("\n\nInOrder Traversal");
            In_Order_Traversal(ref Root_Node);
        }
        public void In_Order_Traversal(ref Node Current_Node)
        {
            if (Current_Node != null)
            {
                In_Order_Traversal(ref Current_Node.Left_Child);
                Console.WriteLine("{0} ", Current_Node.Data);
                In_Order_Traversal(ref Current_Node.Right_Child);
            }
            else
            {
                return;
            }
        }

        public void Delete( int Value )
        {
            Delete(ref Root_Node , Value ) ;
        }

        public void Delete( ref Node Current_Node , int Value )
        {
            if( Current_Node == null )
            {
                Console.WriteLine("Value Not Found");
                return;
            }
            if( Value < Current_Node.Data )
            {
                Delete(ref Current_Node.Left_Child, Value);
                return;
            }
            if (Value > Current_Node.Data)
            {
                Delete(ref Current_Node.Right_Child, Value);
                return;
            }
            if (Value == Current_Node.Data)
            {
                if( Current_Node.Left_Child == null && Current_Node.Right_Child != null )
                {
                    Current_Node = Current_Node.Right_Child ;
                    return;
                }
                if (Current_Node.Right_Child == null && Current_Node.Left_Child != null)
                {
                    Current_Node = Current_Node.Left_Child ;
                    return;
                }
                if( Current_Node.Right_Child == null && Current_Node.Left_Child == null )
                {
                    Current_Node = null ;
                    return;
                }

                Node In_Order_Successor = Find_In_Order_Successor( ref Current_Node.Right_Child ) ;
                Delete(In_Order_Successor.Data) ;
                Current_Node.Data = In_Order_Successor.Data ;
                return;
            }

        }

        ref Node Find_In_Order_Successor( ref Node Current_Node)
        {
            if( Current_Node.Left_Child == null )
            {
                return ref Current_Node ;
            }
            else
            {
                 return ref Find_In_Order_Successor(ref Current_Node.Left_Child) ;
            }
        }
    }



    class Main_
    {
        static void Main(string[] args)
        {
            Tree BST = new Tree() ;
            BST.Insert(50) ;
            BST.Insert(25) ;
            BST.Insert(15) ;
            BST.Insert(20) ;
            BST.Insert(75) ;
            BST.Insert(60) ;
            BST.Insert(100) ;
            BST.Insert(90) ;
            BST.Delete(50) ;
            BST.Pre_Order_Traversal() ;
            BST.In_Order_Traversal() ;
            BST.Post_Order_Traversal() ;







        }
    }
}
