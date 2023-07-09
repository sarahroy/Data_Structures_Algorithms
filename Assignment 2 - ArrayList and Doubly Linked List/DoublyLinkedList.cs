//COIS 2020H : Data Structure and Algorithms
//Assigment 2
//Name: Sarah Ann Roy
//Student Number: 0650615
//DoublyLinkedList.cs
using System;
using System.Collections.Generic;
namespace Assignment_1
{
    public class Node
    {
        public Node next = null, previous = null; 
        public Animal data;
    }
    public class DoublyLinkedList<T>
	{
		Node head, tail; //head and tail pointers that point to the first and last elements respectively
        public Animal[] dll; //list of Animals
        public int Count; //attribute that  updates number of elements in the doubly linked list
        private Random random = new Random();

        //Constructor that creates an empty list
        public DoublyLinkedList()
		{
            dll = new Animal[0];
            head = tail = null;
            this.Count = 0;//update count for an empty linked list
        }

        //Method: AddFirst() adds a new node (animal) at the head
        public void AddFront(Animal A) //O(1)
        {
            Node newnode = new Node(); //create new node
            newnode.data = A; //copy data onto new node
            newnode.next = head; //next pointer should be at head
            newnode.previous = null; //prev pointer of the first element is null
            if(head == null) //check if its empty
                head = tail = newnode; //both head & tail points to the only element in the list
            if (head != null) //not an empty list
            {
                head.previous = newnode; //connect the existing head node to the new node with the prev pointer
                head = newnode; //change the head pointer to point at the new node
            }
            this.Count++;//update count after adding new element
        }

        //Method: AddLast() adds a new node (animal) at the tail
        public void AddLast(Animal A) //O(1)
        {
            Node newnode = new Node();//create new node
            newnode.data = A;//copy data onto new node
            newnode.next = null;//next pointer of the last element should be null
            if (head == null)//check if its empty
                head = tail = newnode; //both head & tail points to the only element in the list
            else //not empty
            {
                tail.next = newnode; //connect the existing tail node to the new node with the next pointer
                newnode.previous = tail; //the prev pointer of the new node should be at tail
                tail = newnode;//change the tail pointer to point at the new node
            }
            this.Count++;//update count after adding new element
        }

        //Method: GetCount() Should be O(1) meaning you need to keep track the count in other methods
        public int GetCount()
        {
            return this.Count; //return count
        }

        //Method: InsertAtRandomLocation() keep track of the size of the list, generate a random # up to that size, insert at that position in the list
        //Source: https://www.procoding.org/doubly-linked-list/
        public void InsertAtRandomLocation(Animal A)
        {
            if (this.GetCount() == 0) //if list is empty, then add new head
                this.AddFront(A);
            int index = random.Next(0, this.GetCount());

            if (index == 0)//insert at the beginning of the doubly linked list
                this.AddFront(A);
            else if (index == this.dll.Length - 1)//insert at the end of the doubly linked list
                this.AddLast(A);
            else
            {
                Node newnode = new Node();
                newnode.data = A;
                Node current = head;
                for(int i = 0; i < index - 1; i++)
                {
                    current = current.next;
                }
                newnode.next = current.next; //set next pointer of new node
                current.next = newnode;
                newnode.previous = current; //set prev pointer of new node
            }
                        
            this.Count++; //update count after adding new element
        }

        //Method: Merge() this should merge another list (take only 1 parameter) onto the calling one at the end (and update the count correctly). 
        public DoublyLinkedList<T> Merge(DoublyLinkedList<T> dll)
        {
            if (dll.GetCount() == 0) //if the list is empty, return existing list
                return this;

            //merging dll to the end of the current list
            this.tail.next = dll.head;//connect last element of current list to first element of dll
            dll.head.previous = this.tail; //connect first element of dll to last element of current list
            tail = dll.tail;//change the tail pointer to the last element of dll (head does not change)
            this.Count = this.GetCount() + dll.GetCount(); //update count
            Console.WriteLine($"Number of elements in the merged Doubly Linked List = {this.GetCount()}"); //update GetCount() and print
            return this;
        }


        //Method: FindClosest() Searches the list to find the closest bird to the cat or snake position of the animal in the parameter A 
        public Animal FindClosest(Animal A)
        {
            Animal bird = head.data; //the closest bird to animal A (to be returned)
            double[] distance = new double[this.Count];//store the distances from each bird to A
            Node current = head;
            
            for(int i = 0; i < distance.Length; i++) //loop through the array
            {
                while (current != null) //traverse doubly linked list
                {
                    distance[i] = FindDistance(current.data.pos, A); //calculate distance from current bird's pos with animal A                    
                    current = current.next; //move current pointer to the next element
                }
            }
            int index = Array.IndexOf(distance,distance.Min()); //get index of the closest distance

            //find the closest bird using its index
            while(current != null)
            {
                if (current.data.ID == index)
                    bird = current.data;
                current = current.next;
            }
            return bird;//return animal
        }


        //Method: FindDistance() returns the distance from an object with position pos to the Animal obj.
        //This method uses the equation for distance between two points = √((x1-x2)^2)+((y1-y2)^2)+((z1-z2)^2)
        public double FindDistance(Position pos, Animal obj)
        {
            double distance = 0.0;
            double x1 = pos.x, y1 = pos.y, z1 = pos.z;
            double x2 = obj.pos.x, y2 = obj.pos.y, z2 = obj.pos.z;

            distance = Math.Sqrt(Math.Pow((x1 - x2), 2)+ Math.Pow((y1 - y2), 2) + Math.Pow((z1 - z2), 2));
            return distance;
        }

        //Method: DeleteFirst() deletes the element at the head
        public void DeleteFirst()//O(1)
        {
            //delete head
            if (head == null) //check if the list is empty
                Console.WriteLine("EMPTY LIST");
            else
            {
                Node current = head.next; //temporarily store the second node in the list which is the new head
                if (current != null) //if the element exists
                    current.previous = null; //delete the existing head node
                head = current; //change the head pointer to point at the new node
            }
            this.Count--; //update count after deleting an element
        }

        //Method: DeleteLast() deletes the element at the tail
        public void DeleteLast() //O(1)
        {
            //delete tail
            if (head == null && tail == null) //check if the list is empty
                Console.WriteLine("EMPTY LIST");
            else
            {
                Console.WriteLine(tail.ToString()); //print off the element that is being deleted
                Node current = tail.previous; //temporarily store the second last element which will be the new tail
                if (current != null) //if the element exists
                    current.next = null; //delete the last element (tail)
                tail = current; //change the tail pointer to point at the new tail 
            }
            this.Count--; //update count after deleting an element
        }


        //Method: this deletes “target” from the list.  Make sure to test correctly the head/first and tail/last of the list as well as objects in the middle.  This should print off which bird was eaten to the console (use target.ToString()) 
        public void GetEaten(Animal target)//GetEaten(object T target)
        {
            if (head.data == target)
                this.DeleteFirst();//remove at head
            else if (tail.data == target)
                this.DeleteLast();//remove at tail
            else
            {
                Node current = head;
                while (current != null)//traverse the list
                {
                    if (current.data == target)//if current matches target
                    {
                        current.previous.next = current.next; //change next pointer of previous element to the next element
                        current.next.previous = current.previous;//change prev pointer of the next element to the previous element.
                    }
                    current = current.next;//change current if target not found
                }
            }
            Console.WriteLine($"{target.ToString()} got eaten");
            this.Count--;//update count after deleting an element
        }

        //Method: RotateLeft() Should rotate all elements in the array left.
        //Example: Given a list {A, B, C, D} rotate all elements left one place becomes {B, C, D, A}
        public void RotateLeft()
        {
            if (this.GetCount() == 1 || this.GetCount() == 0)
                return;
            //for example, starting off with {A, B, C, D}, head = A and tail = D
            Node last = tail; //last points to last element (points to D)
            Node first = head; //first points the first node around which the list is rotated (points to A)

            //connecting the tail node (D) to the head node (A) to achieve {...D,A}
            last.next = head;//link the last node to the head   
            head.previous = last;//change prev of head node to last

            //update the head to the second element (B)
            head = first.next; //change head to the second element (now head = B)

            //update the tail pointer to point to (A which is now stored in first)
            tail = first;

            //severing connections and updating pointers
            head.previous = null; //update prev pointer of head in doubly linked list is always null
            first.next = null; //remove connection between first and second element A & B
            tail.next = null;//update tail
        }

        //Method: RotateRight() Should rotate all elements in the array right.
        //Example: {A, B, C, D} -> {D, A, B, C}
        public void RotateRight()
        {
            if (this.GetCount() == 1 || this.GetCount() == 0)
                return;
            //for example, starting off with {A, B, C, D}, head = A and tail = D
            Node last = tail; //last points to last element (points to D)
            Node first = head; //first points the first node around which the list is rotated (points to A)

            //connecting the tail node (D) to the head node (A) to achieve {D,A,..}
            last.next = head;//link the last node to the head   
            head.previous = last;//change prev of head node to last

            //update the tail to the second last element (now tail = C)
            tail = last.previous;

            //update head to last (now head = D)
            head = last;

            //severing connections and updating pointers
            head.previous = null; //update head in doubly linked list to null
            last.previous = null; //remove connection between C & D
            tail.next = null;//update tail in doubly linked list to null
        }

        //Method: PrintAllForward() returns a string containing all elements from the doubly linked list in order
        public string PrintAllForward()
        {
            string forward = "";
            Node current = head;
            if (head == null)
                forward = "EMPTY LIST";
            else
            {
                while (current != null)//check if current element exists, if yes then add to final string
                {
                    forward += current.data.ToString() + "\n"; //concatenate the element to the forward
                    current = current.next;
                }
            }
            return forward;
        }

        //Method: PrintAllReverse() returns a string containing all elements from the doubly linked list in reverse order
        public string PrintAllReverse()
        {
            string reverse = "";
            Node current = tail;
            if (head == null && tail == null)
                reverse = "EMPTY LIST";
            else
            {
                while (current != null) //check if current element exists, if yes then add to final string
                {
                    reverse += current.data.ToString() + "\n";//concatenate the element to the reverse
                    current = current.previous; //move to the previous element
                }
            }
            return reverse;
        }

        //Method: DeleteAll() deletes all elements in the list 
        public void DeleteAll()
        {
            //Delete all elements, not the list.
            Node current = head;
            if (head == null)
                Console.WriteLine("EMPTY LIST");
            else
            {
                while (current.next != null)
                {
                    current = null;
                    current = current.next;
                }
                Console.WriteLine($"Number of elements in doubly linked list after DeleteAll() = {this.GetCount()}");
            }
        }

        //Method: MoveBirds() moves all birds in the dll randomly by calling Animal.Move()
        public void MoveBirds()
        {
            Node current = head;
            if (head == null)
                Console.WriteLine("EMPTY LIST");
            else
            {
                while(current != null)
                {
                    current.data.Move();
                    current = current.next;
                }
            }
        }

        public void EatBirds(Bird B)
        {
            head.data.Eat(B);
        }
    }
}