//Name: Sarah Ann Roy
//Student Number: 0650615
//COIS 2020H - Assignment 3 
//CircularArray.cs
using System;
using System.Drawing;

namespace Assignment3_4
{
    public class CircularArray<T>
	{
		Node[] array;
        private int front, rear; //front points to the first element and rear points to the last element

		//No-argument constructor. To initialize an empty queue of size 20.
        public CircularArray()
		{
			array = new Node[20];
			front = rear = -1;//since the array has no elements both rear and front is set to -1
        }

		//Constructor that takes the size as a parameter to initialize a queue of a specific size.
		public CircularArray(int size)
		{
			array = new Node[size];
            front = rear = -1; //since the array has no elements both rear and front is set to -1
        }

        //Method: Enqueue() to add a node in the correct place
        //Level 1 > Level 2 > Level 3 > Level 4 > Level 5
        public void Enqueue(Node input, int inputPriority)
		{
            bool flag = false;
            if (IsFull())
            {
                Console.WriteLine("ERROR! CircularArray is full! New patient node cannot be added");
                return;//leave the function without adding the element
            }
                
            else if (IsEmpty())
            {
                front = 0;
                flag = true;
            }
               
            rear = (rear + 1) % array.Length;
            array[rear] = input;
            //rear++;// Also inadequate

            if (!flag)//if there is more than 1 element, sort based on priority
                Sort(); 
        }

        //Method: Sort() sorts the circular array based on priority using Bubble Sort algorithm
        //Level 1 > Level 2 > Level 3 > Level 4 > Level 5
        //Source: https://www.w3resource.com/csharp-exercises/searching-and-sorting-algorithm/searching-and-sorting-algorithm-exercise-3.php
        public void Sort()
        {
            Node temp;
            for (int p = front; p <= rear-1; p++)
            {
                for (int i = front; i <= rear-1; i++)
                {
                    if (this.array[i].emergencyLevel > this.array[i + 1].emergencyLevel)
                    {
                        //Swap Nodes
                        temp = this.array[i + 1];
                        this.array[i + 1] = this.array[i];
                        this.array[i] = temp;
                    }
                }
            }
        }
        //Method: Dequeue() to return and remove a node
        public Node Dequeue()
		{
            if (IsEmpty())//check if the queue is empty
            {
                Console.WriteLine("EMPTY CIRCULAR ARRAY : Cannot remove first element");
                return null;
            }
            else//array is not empty
            {
                Node delete = array[front]; //store the front value temporarily
                if (front == rear) //check if there is only 1 element
                    front = rear = -1;
                else
                {
                    array[front] = null;
                    front = (front + 1) % array.Length;
                }
                return delete;
            }
        }

        //Method: PrintAll() should print the data in each node along with its index in the array. You need to override the ToString() method.
        public void PrintAll()
		{
            if (IsEmpty())
                Console.WriteLine("EMPTY CIRCULAR ARRAY: Cannot print elements");
            else
            {
                for (int i = front; i <= rear; i++)
                    Console.Write($"{array[i].ToString()}\n");
               
                Console.WriteLine();
            }
        }

		//Method: DeleteAll() should delete the nodes, not the array itself
        public void DeleteAll()
        {
            if (IsEmpty())
                Console.WriteLine("EMPTY CIRCULAR ARRAY: Cannot delete elements");
            else
            {
                for (int i = front; i <= rear; i++)
                    array[i] = null;

                front = rear = -1; //since all elements are deleted, front and rear should be -1
            }
        }

        //Method: IsFull() returns boolean (true/false) if the circular array is full
        private bool IsFull()
        {
            return (rear + 1) % array.Length == front;
        }

        //Method: IsEmpty() returns boolean (true/false) if the circular array is empty
        public bool IsEmpty()
        {
            return front == -1;
        }
    }
}
