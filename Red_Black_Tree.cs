using System;

namespace RBT
{
    class Red_Black_Tree_Node
    {
        // Color Representation   --->    False = Red , True = Black
        public int Data ;
        public bool Color ;
        public Red_Black_Tree_Node Parent ;
        public Red_Black_Tree_Node Left_Child ;
        public Red_Black_Tree_Node Right_Child ;
        public Red_Black_Tree_Node( int Data_ , bool Color_  , ref Red_Black_Tree_Node Parent_ )
        {
            Parent = Parent_ ;
            Color = Color_ ;
            Data = Data_ ;
            Left_Child = null ;
            Right_Child = null ;
        }
    }

    class Red_Black_Tree
    {
        private Red_Black_Tree_Node Root_Node;
        public Red_Black_Tree()
        {
            Root_Node = null;
        }

        void Solve_RBT_Violation( ref Red_Black_Tree_Node Node_To_Be_Inserted )
        {
            // If Parent Is A Black Node
            if(Node_To_Be_Inserted.Parent != null && Node_To_Be_Inserted.Parent.Color == true )
            {
                return ;
            }
            // If Parent & Uncle/Sibling Both Are Red Nodes Then Re-Coloring The Entire RBT
            // Node_To_Be_Inserted.Parent.Parent.Left_Child.Color - > Left Sibling/Uncle Color ( Can Be Parent Also In Mirror Images )
            // Node_To_Be_Inserted.Parent.Parent.Right_Child.Color - > Right Sibling/Uncle Color ( Can Be Parent Also In Mirror Images )
            if ( ( Node_To_Be_Inserted.Parent != null ) && (Node_To_Be_Inserted.Parent.Parent != null) && (Node_To_Be_Inserted.Parent.Parent.Left_Child == null || Node_To_Be_Inserted.Parent.Parent.Left_Child.Color == false ) && ( Node_To_Be_Inserted.Parent.Parent.Right_Child == null || Node_To_Be_Inserted.Parent.Parent.Right_Child.Color == false ) )
            {
                if( Node_To_Be_Inserted.Parent.Parent.Left_Child != null )
                {
                    Node_To_Be_Inserted.Parent.Parent.Left_Child.Color = true;
                }
                if(Node_To_Be_Inserted.Parent.Parent.Right_Child != null  )
                {
                    Node_To_Be_Inserted.Parent.Parent.Right_Child.Color = true;
                }
                if( Node_To_Be_Inserted.Parent.Parent != null )
                {
                    Node_To_Be_Inserted.Parent.Parent.Color = false;
                    Solve_RBT_Violation(ref Node_To_Be_Inserted.Parent.Parent);
                }
                return ;
            }
            // If Parent Is Red & Uncle/Sibling Is Black
            if( ( Node_To_Be_Inserted.Parent != null ) && (Node_To_Be_Inserted.Parent.Parent != null) && Node_To_Be_Inserted.Parent.Parent.Left_Child.Color == true && Node_To_Be_Inserted.Parent.Color == false )
            {
                return ;
                // Perform Rotations
            }
        }

        public void Insert(int Value)
        {
            Root_Node = Insert(ref Root_Node , ref Value , ref Root_Node ) ;
        }
        public Red_Black_Tree_Node Insert(ref Red_Black_Tree_Node Current_Node , ref int Value , ref Red_Black_Tree_Node Parent )
        {
            if( Root_Node == null )
            {
                // Root Should Be Black
                Current_Node = new Red_Black_Tree_Node( Value , true , ref Parent ) ; 
                return  Current_Node ;
            }
            if (Current_Node == null)
            {
                // If Equal To Null Means It's The Position Where The New Node Is To Be Inserted 
                Current_Node = new Red_Black_Tree_Node(Value, false, ref Parent) ;
                Solve_RBT_Violation(ref Current_Node);
                return Current_Node ;
            }
            if ( Value > Current_Node.Data )
            {
                Current_Node.Right_Child = Insert( ref Current_Node.Right_Child , ref Value , ref Current_Node ) ;
                return Current_Node ;
            }
            if( Value < Current_Node.Data )
            {
                Current_Node.Left_Child = Insert( ref Current_Node.Left_Child , ref Value , ref Current_Node ) ;
                return Current_Node ;
            }

            return Current_Node ;
        }

        public void Pre_Order_Traversal()
        {
            Console.WriteLine("\n\nPreOrder Traversal");
            Pre_Order_Traversal(ref Root_Node);
        }
        public void Pre_Order_Traversal(ref Red_Black_Tree_Node Current_Node)
        {
            if (Current_Node != null)
            {
                Console.WriteLine("{0} ", Current_Node.Data);
                Pre_Order_Traversal(ref Current_Node.Left_Child);
                Pre_Order_Traversal(ref Current_Node.Right_Child);
            }
            else
            {
                return;
            }
        }

        public void Post_Order_Traversal()
        {
            Console.WriteLine("\n\nPostOrder Traversal");
            Post_Order_Traversal(ref Root_Node);
        }
        public void Post_Order_Traversal(ref Red_Black_Tree_Node Current_Node)
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
        public void In_Order_Traversal(ref Red_Black_Tree_Node Current_Node)
        {
            if (Current_Node != null)
            {
                In_Order_Traversal(ref Current_Node.Left_Child);
                Console.WriteLine("{0} ", Current_Node.Data);
                In_Order_Traversal(ref Current_Node.Right_Child);
            }
            else
            {
                return ;
            }
        }

        public void Delete(int Value)
        {
            Delete(ref Root_Node, Value) ;
        }

        public void Delete(ref Red_Black_Tree_Node Current_Node, int Value)
        {
            

        }


    }



    class Main_
    {
        static void Main(string[] args)
        {
            Red_Black_Tree RBT = new Red_Black_Tree() ;
            RBT.Insert(50) ;
            RBT.Insert(100) ;
            RBT.Insert(70) ;
            RBT.Insert(105) ;
            RBT.Insert(25) ;
            RBT.Insert(30) ;
            RBT.Insert(20) ;
            RBT.Post_Order_Traversal() ;








        }
    }
}
