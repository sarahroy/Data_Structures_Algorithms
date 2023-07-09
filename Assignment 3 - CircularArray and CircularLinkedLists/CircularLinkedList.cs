//Name: Sarah Ann Roy
//Student Number: 0650615
//COIS 2020H - Assignment 3
//CircularLinkedList.cs
using System;
using System.Xml.Linq;

namespace Assignment3_4
{
    public class CircularLinkedList<T>
	{
		public Node head, tail;

        //No-argument constructor. To initialize the front and end to null. 
        public CircularLinkedList()
		{
			head = tail = null;
		}

        //Method: Enqueue() to add a node at the end of the queue (FIFO)
        //Level 1 > Level 2 > Level 3 > Level 4 > Level 5
        //https://www.javatpoint.com/circular-doubly-linked-list
        public void Enqueue(Node input, int inputPriority)
        {
            if (head == null || tail == null)//check if its empty
            {
                head = tail = input; //both head & tail points to the only element in the list
                input.next = head;
                input.previous = head;
            }
                

            else //not empty so add at the end of the list (new tail)
            {
                
                tail.next = input; //connect the existing tail node to the new node with the next pointer
                input.previous = tail; //the prev pointer of the new node should be at tail
                head.previous = input;
                input.next = head; //next pointer of the last element should be head (circular)
                tail = input;//change the tail pointer to point at the new node
                Sort(); //sort list in ascending order based on priority
            }
        }

        //Method: Sort() sorts the list based on priority
        //Level 1 > Level 2 > Level 3 > Level 4 > Level 5
        //Source: https://www.javatpoint.com/program-to-sort-the-elements-of-the-doubly-linked-list
        public void Sort()
        {
            Node current = null, index = null; //2 node objects for traversal
            Node temp;
            //check if the list is empty
            if (head == null)
                return;
            else
            {
                //current starts traversing from the head node 
                for(current = head;current.next != head;current = current.next)
                {
                    //index starts traversing from current.next
                    for(index = current.next;index != head;index = index.next)
                    {
                        //if the priority of current is greater than priority of next, swap  
                        if(current.emergencyLevel > index.emergencyLevel)
                        {
                            //Swap(current, index); //swap current and index
                            temp = current;
                            current = index;
                            index = temp;
                        }      
                    }
                }
            }
        }
        
        //Method: Dequeue() to return and remove a node with the highest priority
        //Level 1 > Level 2 > Level 3 > Level 4 > Level 5
        //Here the CircularLinkedList is ordered so that the highest priority is at the head, so simply removing the Node at head should suffice
        public Node Dequeue()
        {
            Node deleted = head; //temporarily store the head node (before deleting it) to return it

            //Case 1: Empty queue (no elements, so display error)
            if (head == null || tail == null)//check if the queue is empty
            {
                Console.WriteLine("EMPTY CIRCULAR ARRAY : Cannot remove first element");
                return null;
            }

            //Case 2: There is only 1 element in the queue
            else if (head == tail)
                head = tail = null;

            //Case 3: General Case where there is more than 1 element in the queue 
            else
            {
                Node current = head.next; //temporarily store the second node in the list which is the new head
                if (current != null) 
                    current.previous = null; //delete the existing head node  
                head = current;//change the head pointer to point at the new node
            }
            return deleted;
        }

        //Method: PrintAll() should print the data in each node along with its index in the array. You need to override the ToString() method.
        public void PrintAll()
        {
            if (head == null || tail == null)
                Console.WriteLine("EMPTY CIRCULAR LINKED LIST: Cannot print elements");
            else
            {
                Node current = head;
                do
                {
                    Console.Write($"{current.ToString()}\n");
                    current = current.next;
                }
                while (current != head);
            }
        }

        //Method: DeleteAll() should delete the nodes, not the array itself
        public void DeleteAll()
        {
            if (head == null || tail == null)
                Console.WriteLine("EMPTY CIRCULAR LINKED LIST: Cannot delete elements");
            else
            {
                Node current = head;
                while(current.next != head)
                {
                    current = null;
                    current = current.next;
                }
                
                head = tail = null;
            }
        }
    }
}
