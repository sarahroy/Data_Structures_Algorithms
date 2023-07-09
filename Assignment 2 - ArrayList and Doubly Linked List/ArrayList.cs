//COIS 2020H : Data Structure and Algorithms
//Assigment 2
//Name: Sarah Ann Roy
//Student Number: 0650615
//ArrayList.cs
using System;
using System.Collections.Generic;
namespace Assignment_1
{
	public class ArrayList<T>
	{
		public Animal[] array;

		//Constructor that takes a size and creates an array 
        public ArrayList(int size)
        {
            array = new Animal[size];
        }

        //Method: Grow() private method that doubles the size of the array when called by AddFront or AddLast if the array is out of space.  
        private void Grow()
		{
			int size = this.array.Length;//stores the size of the array
			if (size == 0)
				size = 1;
			ArrayList<T> newarray = new ArrayList<T>(size*2);//create new array double the size of the existing array
			for(int i = 0; i < size; i++) 
			{
				newarray.array[i] = this.array[i]; //copy all elements from existing array to new array
			}
			this.array = newarray.array;//replace existing array with the new array
		}

		//Method: IsFull() private method that returns a boolean value whether the array is full or not
		private bool IsFull()
        {
			bool flag = false;
			for (int i = 0; i < this.array.Length; i++)
			{
				if (this.array[i] != null)
					flag = true;
				else
				{
					flag = false;
					break;
				}
			}
			return flag;
		}


		//Method: AddFront() adds an item at the front (index 0) of the list (and moves the rest of the list out of the way first)
		public void AddFront(Animal toAdd)
		{
			//check if the existing list is full or empty, if so then Grow()
			if (this.IsFull() || this.GetCount() == 0)
				this.Grow();
			//add new element to the first index
			//this.array.Prepend(toAdd);
			//shift all the elements from the last index by 1 position to right
			for (int i = this.array.Length-1; i > 0; i--)
				this.array[i] = this.array[i - 1];

			//then insert element at the front of the array (index = 0)
			this.array[0] = toAdd;
		}


		//Method: AddLast() this should add an item after all current items (Hint: this is NOT Length -1 though).  You’ll probably need GetCount for this, or you may think of other solutions.
		public void AddLast(Animal toAdd)
		{
			//this.array.Append(toAdd);
			//check if list is full or empty, if so then Grow()
			if (this.IsFull() || this.GetCount() == 0)
				this.Grow();

			for (int i = this.array.Length - 1; i >= 0; i--)
				if (this.array[i] == null) //finding the last empty index
					this.array[i] = toAdd; //insert element at the last empty index
		}

        //Method: GetCount() this should return the number of items in the list (not the length of the array)
        public int GetCount()
		{
			//return this.array.Count();
			int count = 0;
			// Loop for counting non-zero values in array.
			for (int i = 0; i < this.array.Length; i++) //traverse the entire array
				if (this.array[i] != null)
					count++;
			return count;
		}

        //Method: InsertBefore() takes two object parameters, and it will insert the first object (first parameter) before the object in the second parameter
        public void InsertBefore(Object a, Object b)
		{
			//get the indices of the two objects
			int index1 = 0 , index2 = 0;
			for(int i=0; i < this.array.Length; i++)
            {
				if(this.array[i] == a)
					index1 = i;
				if (this.array[i] == b)
					index2 = i;
			}
			//Now swap the two objects in the list
			this.Swap(index2,index1);
		}


		//Method: InPlaceSort() sorts the array list in place without making a new Array. use built in array sorting for this for now.  (Make sure your Animals are comparable, and compare on Name)
		public void InPlaceSort()
		{
			Array.Sort(this.array); //sort this array using name without making a new one
		}

        //Method: Swap(index1, index2) should swap the two elements in the array list
        public void Swap(int index1, int index2)
		{
			Animal temp = this.array[index1];//temporarily store data at index1
			this.array[index1] = this.array[index2];
			this.array[index2] = temp;
		}

		//Method: DeleteFirst() this should delete the object at position 0, and shuffle all the elements back one to fill the hole
		public void DeleteFirst()
		{
			this.array[0] = null; //delete element at index = 0

			for (int i = 1; i < this.array.Length; i++)
			{
				this.array[i - 1] = this.array[i]; //shift all elements to the left 
			}
			Console.WriteLine($"Number of elements in the arrayList = {this.GetCount()}"); //update GetCount() and print
		}

		//Method: DeleteLast() Should delete the last non null element (and update the count correctly).  
		public void DeleteLast()
		{
			for (int i = this.array.Length-1; i >=0; i--)
				if (this.array[i] != null) //finding the last non-null element
                {
					Console.WriteLine(this.array[i].ToString()); //print off the element that is being deleted from the array
					this.array[i] = null;
				}		
			Console.WriteLine($"Number of elements in the arrayList = {this.GetCount()}"); //update GetCount() and print
		}

		//Method: RotateLeft() Should rotate all elements in the array left.
		//Example: Given a list {A, B, C, D} rotate all elements left one place becomes {B, C, D, A}
		public void RotateLeft()
		{
            if (this.GetCount() == 1 || this.GetCount() == 0)
                return;
            Animal temp = this.array[0];//temporarily store data at index = 0
			for(int i = 1; i < this.array.Length; i++)
            {
				this.array[i - 1] = this.array[i]; //shift all elements to the left (except the last index)
            }
			this.array[this.array.Length - 1] = temp; //last index gets the value at the first index
		}


		//Method: RotateRight() Should rotate all elements in the array right.
		//Example: {A, B, C, D} -> {D, A, B, C}
		public void RotateRight()
		{
            if (this.GetCount() == 1 || this.GetCount() == 0)
                return;
            Animal temp = this.array[this.array.Length-1];//temporarily store data at the last index 
			for (int i = this.array.Length; i > 0; i--)
			{
				this.array[i] = this.array[i-1]; //shift all elements to the right (except the first index)
			}
			this.array[0] = temp; //first index gets the value at the last index
		}


		//Method: Merge() takes two ArrayLists, and return a third which is the first two merged in an unsorted order. 
		public static ArrayList<T> Merge(ArrayList<T> a1, ArrayList<T> a2)
		{
			int s1,s2,i,j, newsize;
			s1 = a1.array.Length; //size of the first array
			s2 = a2.array.Length; //size of the second array
			if (s1 == 0)
				return a2;
			else if (s2 == 0)
				return a1;
			newsize = a1.array.Length + a2.array.Length + 1; //size of the new merged array
            ArrayList<T> merged = new ArrayList<T>(newsize); //create merged array using newsize

			//a1.array.CopyTo(newarray.array, 0);
			//a2.array.CopyTo(newarray.array, a1.array.Length);
			// copying array 1 elements in to new merged array
			for (i = 0; i < s1; i++)
			{
				merged.array[i] = a1.array[i];
			}

			// copying array 2 elements in to new merged array
			for (i = 0, j = s1; j < newsize && i < s2; i++, j++)
			{
				merged.array[j] = a2.array[i];
			}
            Console.WriteLine($"Number of elements in the merged arrayList = {merged.GetCount()}"); //update GetCount() and print
            return merged;
		}

        //Method: StringPrintAllForward() This returns a string which is the whole structure printed from beginning to end (calling the object.ToString or similar)
        public string PrintAllForward()
		{
            string forward = "";
            if (this.GetCount() == 0)
            {
                forward = "Empty ArrayList";
            }
            else
            {
                for (int i = 0; i < this.array.Length; i++)
                {
					if (this.array[i] != null)
					{
                        forward += this.array[i].ToString() + "\n";
                    }
                }
            }
            return forward;
        }

        //Method: StringPrintAllReverse() This returns a string which is the whole structure printed from the end to the beginning (calling the object.ToString or similar)
        public string PrintAllReverse()
        {
            string reverse = "";
			if (this.GetCount() == 0)
			{
				reverse = "Empty ArrayList";
			}
			else
			{
                for (int i = this.array.Length - 1; i >= 0; i--)
                {
                    if (this.array[i] != null)
                    {
                        reverse += this.array[i].ToString() + "\n";
                    }
                }
            }
            return reverse;
        }

        //Method: DeleteAll() deletes all the elements not the list
        public void DeleteAll()
		{
			for(int i = 0; i < this.array.Length; i++)
			{
				this.array[i] = null;
			}
            Console.WriteLine($"Number of elements in the arrayList after DeleteAll() = {this.GetCount()}"); //update GetCount() and print
        }
    }
}