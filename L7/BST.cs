using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTreeLab
{
    class Node
    {
        public int value;// (note this could be a public T value if you wanted to make this generic)
        public Node left;
        public Node right;
    }

    class BinarySearchTree
    {
        public Node insert(Node root, int v)
        {
            if (root == null)
            {
                root = new Node();
                root.value = v;
            }


            // insertion logic, if the value (v )is < root, insert to the root.left
            // otherwise it's >=, so insert to the right
            else if (v < root.value)
            {
                root.left = insert(root.left, v);
            }
            else
            {
                root.right = insert(root.right, v);
            }

            return root;
        }
		
        // Lab:  Take the code from here, and implement 3 different traversals  as strings
        // public string traverse (Node root). Note, this is one of the traversals.  
		//You just need to figure out which one and modify it to return a string  rather than 
		//printing each value to the console.
        public void traverse(Node root)
        {
            if (root == null)
            {
                return;
            }
            Console.WriteLine( root.value.ToString());
            traverse(root.left);
            traverse(root.right);

        }
		
	
        // For students to implement in the lab 
        // note that in order, pre order and post order are all just rearranging the order
        // of the traverse method and sdjusting it to return a string rather than printing 
		//each value to the console.
        public string inOrder(Node root)
        { 
			return ""; 
		
		}//ind inOrder

        public string preOrder(Node root)
        { return ""; }

        public string postOrder(Node root)
        { return ""; }

		/*
		
		breadthFirst algorithm: 
		
		Create a string
		Create a queue
		Add the root to the queue
		Loop while the queue is not empty
		Inside the loop, 
			1)	take the head out of the queue
			2)	add the value of the head node to the string
			3)	add its children (if any) to the queue 
		return the string
		*/
        public string breadthFirst(Node root)
        { 
			//create a queue
			//add the root to the queue
			//immedietly 
		
			return ""; 
		
		}//end breadthFirst
		
		//findSmallest
		//Make this work.
		public int findSmallest()
		{
			return 0; 
		}

    }
}
