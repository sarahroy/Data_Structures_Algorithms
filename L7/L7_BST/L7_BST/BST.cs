using System;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace L7_BST
{
	public class Node
	{
        public int value;// (note this could be a public T value if you wanted to make this generic)
        public Node left;
        public Node right;
    }
	public class BinarySearchTree
	{
		public BinarySearchTree()
		{
            //root = null;
		}

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
            Console.WriteLine(root.value.ToString());
            traverse(root.left);
            traverse(root.right);

        }


        // For students to implement in the lab 
        // note that in order, pre order and post order are all just rearranging the order
        // of the traverse method and sdjusting it to return a string rather than printing 
        //each value to the console.
        public string inOrder(Node root)
        {
            if (root == null)
                return "";

            string s = "";
            /* first recur on left child */
            inOrder(root.left);

            /* then print the data of node */
            s += Convert.ToString(root.value) + " ";
            Console.Write(s);
            /* now recur on right child */
            inOrder(root.right);

            return s;
            //return "";

        }//ind inOrder

        public string preOrder(Node root)
        {
            if (root == null)
                return "";

            string s = "";
            

            /* then print the data of node */
            s += Convert.ToString(root.value) + " ";
            Console.Write(s);
            /* first recur on left child */
            preOrder(root.left);

            /* now recur on right child */
            preOrder(root.right);

            return s;
            //return "";
        }

        public string postOrder(Node root)
        {
            if (root == null)
                return "";

            string s = "";

            /* first recur on left child */
            postOrder(root.left);

            /* now recur on right child */
            postOrder(root.right);

            /* then print the data of node */
            s += Convert.ToString(root.value) + " ";
            Console.Write(s);
            return s;
            //return "";
        }

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
            string n = ""; //Create a string
            Queue<Node> Q = new Queue<Node>(); //create a queue
            Q.Enqueue(root); //append the root to the queue
            Node node;
            while (Q.Count != 0)//while loop
            {
               node = Q.Dequeue(); //remove the head of the queue
               n += Convert.ToString(node.value);//add value of the head node to the string
               //add its children(if any) to the queue
                if (root.left != null)
                    Q.Enqueue(root.left); //add left child if it exists
                if (root.right != null)
                    Q.Enqueue(root.right); //add right child if it exists
            }
            return n;

        }//end breadthFirst

        //findSmallest
        //Make this work.
        public int findSmallest(Node root)
        {
            Node current = root;
            //getting the left most node in the bst (which is the smallest value)
            while(current.left != null)
            {
                current = current.left;
            }
            return current.value;
        }
    }
}
