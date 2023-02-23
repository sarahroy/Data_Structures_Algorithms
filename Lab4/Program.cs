using System;
using System.Collections.Generic;
using System.Linq; // probably not necessary
using System.Text;
using System.Threading.Tasks; // also probably not necessary

namespace LinkedList2020H
{
    public class Node
    {
        public Node next;
        //public Node previous; 
        public Object data;
    }
    public class LinkedList
    {
        private Node head;
        private Node tail;

        public void printAllNodes()
        {
            Node current = head;
            //traverse the list
            while (current != null)
            {
                Console.WriteLine(current.data);//print
                current = current.next;
            }
        }
        public void AddFirst(Object data)
        {
            //create new node with data
            Node newNode = new Node();
            newNode.data = data;

            if (head == null && tail ==null) //empty list
            {
                head = tail = newNode; //set both head and tail to new node
            }
            else
            {
                newNode.next = head; 
                head = newNode;
            }
        }
        public void AddLast(Object data)
        {
            //create new node with data
            Node toAdd = new Node();
            toAdd.data = data;

            toAdd.next = null; //next pointer of the last element should be null

            if(head == null && tail == null) //empty list
            {
                head = tail = toAdd; //set both head and tail to the new node   
            }
            else//not an empty list
            {
                tail.next = toAdd;
                tail = toAdd; //update tail pointer  
            }
        }
        public void DeleteLast()
        {
            if (head != null && tail != null) //if not an empty list
            {
                if (head == tail) //list only has 1 item i.e, both head and tail point to the same node
                {
                    head = tail = null; //delete the element and update head and tail 
                }

                else//more than 1 item in the list
                {
                    Node current = head;
                    while (current.next != tail) //traverse to our last element whose next pointer = tail 
                    {
                        current = current.next;
                    }
                    current.next.data = null;
                    current.next = null;
                    tail = current;//update tail pointer
                }
                
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("myList2 Add Last: ");
                LinkedList myList2 = new LinkedList();

                myList2.AddLast("Richard");
                myList2.AddLast("Brian");
                myList2.AddLast("Bonnie");
                myList2.AddLast("Sabine");
                myList2.AddLast("Jamie");
                myList2.AddLast("Wenying");
                myList2.AddLast("Omar");
                myList2.printAllNodes();
                Console.WriteLine();

                Console.WriteLine("myList1 Add First: ");
                LinkedList myList1 = new LinkedList();

                myList1.AddFirst("Richard");
                myList1.AddFirst("Brian");
                myList1.AddFirst("Bonnie");
                myList1.AddFirst("Sabine");
                myList1.AddFirst("Jamie");
                myList1.AddFirst("Wenying");
                myList1.AddFirst("Omar");
                myList1.printAllNodes();
                Console.WriteLine();

                Console.WriteLine("Delete Last on myList1");
                myList1.DeleteLast();
                myList1.printAllNodes();
                Console.WriteLine();

                Console.WriteLine("Delete Last on myList2");
                myList2.DeleteLast();
                myList2.printAllNodes();
                Console.ReadLine();
            }
        }
    }
}
/*//without tail pointer
        public void AddFirst(Object data)
        {
            Node newNode = new Node();
            newNode.data = data;

            if (head == null) //empty list
            {
                head = newNode;
            }
            else
            {
                newNode.next = head;
                head = newNode;
            }
        }
//without tail pointer
        public void AddLast(Object data)
        {
            if (head == null)
            {
                head = new Node();
                head.data = data;
                head.next = null;
            }
            else
            {
                Node toAdd = new Node();
                toAdd.data = data;

                Node current = head;
                while (current.next != null)
                {
                    current = current.next;
                }
                current.next = toAdd;
            }
        }
//without tail pointer
        public void DeleteLast()
        {
            Node current = head;
            if (head != null)//if not an empty list
            {
                if (head.next == null) //list has only 1 item
                {
                    head.data = null;
                    head.next = null;
                }
                else//more than one item in the list
                {
                    while (current.next.next != null)
                    {
                        current = current.next;
                    }
                    current.next.data = null;
                    current.next = null;
                }
            }
        }*/