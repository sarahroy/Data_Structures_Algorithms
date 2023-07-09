using System;
using System.Diagnostics;

// Flagrantly stolen from https://gist.github.com/aaronjwood/7e0fc962c5cd898b3181
// including the class file
// Significant modifications by Sri

namespace BinarySearchTreeLab
{
    


    class BinarySearch
    {
        static void Main(string[] args)
        {
            Node root = null;
            BinarySearchTree bst = new BinarySearchTree();
            int SIZE = 10; // tested on up to 200k elements and it works fine
            int[] testArray = new int[SIZE];
            Random rnd = new Random();
            Console.WriteLine("Elements to be inserted into the BST");
            for (int i=0; i<SIZE; i++)
            {
                testArray[i] = rnd.Next(1, 100);
                Console.WriteLine(testArray[i]);
            }
            
            for (int i = 0; i < SIZE; i++)
            {
                root = bst.insert(root, testArray[i] );
            }
            Console.WriteLine("Elements in the Tree, in some order.  Students get to make this work ");
            // - Lab:  Make the following lines of code work. 
            // Lab: Pre-order, Post Order, In order traversals
            Console.WriteLine(bst.preOrder(root));
            Console.WriteLine(bst.postOrder(root));
            Console.WriteLine(bst.inOrder(root));

            Console.WriteLine();

            Console.ReadKey();
        }
    }
}