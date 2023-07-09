using L7_BST;

Node root = null;
BinarySearchTree bst = new BinarySearchTree();
int SIZE = 10; // tested on up to 200k elements and it works fine
int[] testArray = new int[SIZE];
Random rnd = new Random();
Console.WriteLine("Elements to be inserted into the BST");
for (int i = 0; i < SIZE; i++)
{
    testArray[i] = rnd.Next(1, 100);
    Console.Write(testArray[i]+", ");
}
Console.WriteLine("\n");
for (int i = 0; i < SIZE; i++)
{
    root = bst.insert(root, testArray[i]);
}
Console.WriteLine("Elements in the Tree, in some order.  Students get to make this work ");
// - Lab:  Make the following lines of code work. 
// Lab: Pre-order, Post Order, In order traversals
Console.WriteLine($"\nPreOrder: {bst.preOrder(root)}\n\n");
Console.WriteLine($"\nPostOrder: {bst.postOrder(root)}\n\n");
Console.WriteLine($"\nInOrderOrder: {bst.inOrder(root)}");

Console.WriteLine($"\nSmallest Element in the BST: {bst.findSmallest(root)}");
Console.WriteLine();

Console.ReadKey();