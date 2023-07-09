//Name: Sarah Ann Roy
//Student Number: 0650615
//COIS 2020H - Assignment 3
//Node.cs
using System;
namespace Assignment3_4
{
	public class Node
    {
        //firstName, lastName, Age, and emergencyLevel. It should also include the Next and Previous references.
        public Node next, previous;
		string firstName, lastName;
		int Age;
		public int emergencyLevel;

		public Node()
		{
            firstName = lastName = "";
            Age = emergencyLevel = -1;
            next = previous = null;
        }
		public Node(string f, string l, int a, int e)
		{
			firstName = f;
			lastName = l;
			Age = a;
			emergencyLevel = e;
			next = previous = null;
		}

		public override string ToString()
		{
			return $"First Name: {firstName}, Last Name: {lastName}, Age: {Age}, Emergency Level: {emergencyLevel}";
		}
    }
}
