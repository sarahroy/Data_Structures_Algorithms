//Name: Sarah Ann Roy
//Student Number: 0650615
//COIS 2020H - Assignment 3
//Program.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Assignment3_4;
using System.Reflection.Emit;

int choice = -1; //initialize choice (-1 means user has not inputted their choice)
CircularArray<Node> circularArray = new CircularArray<Node>(10);
CircularLinkedList<Node> circularlinkedList = new CircularLinkedList<Node>();
Random random = new Random();

while (choice != 0) //while-loop 
{
    //Display options
    Console.Write("\n\n----------OPTIONS----------\n\n" +
    "0. Exit the program\n" +
    "1. Add a patient\n" +
    "2. Delete one patient\n" +
    "3. Print all patients\n" +
    "4. Delete all patients\n\n" +
    "Enter a valid option number: ");


    choice = Convert.ToInt32(Console.ReadLine());//get option from user

    //if-else statements based on user choice number
    if (choice == 0) //Exit program after printing elements
    {
        Console.WriteLine("Exiting program after printing all elemets in circular array");
        Console.WriteLine("Circular Array: Printing All Elements");
        circularArray.PrintAll();
        Console.WriteLine("Circular Linked List: Printing All Elements");
        circularlinkedList.PrintAll();
        break; //exit the program
    }
    else if (choice == 1) //add a patient (enqueue)
    {
        Node patient = new Node(); //create a new patient
        patient = AddPatient(patient); //add a patient by calling the method
        Console.WriteLine(patient.ToString()); //displaying the patient that has been added
    }
    else if (choice == 2) //delete a patient (dequeue)
    {
        Node delete1 = circularArray.Dequeue();
        if (delete1 != null)
        {
            Console.WriteLine($"Circular Array: Deleted the following patient - \n\t{delete1.ToString()}");
        }
        Node delete2 = circularlinkedList.Dequeue();
        if (delete2 != null)
        {
            Console.WriteLine($"Circular Linked List: Deleted the following patient - \n\t{delete2.ToString()}");
        }
    }
    else if (choice == 3) //printing all patients (printAll)
    {
        Console.WriteLine("\nCircular Array: Printing All Elements:");
        circularArray.PrintAll();
        Console.WriteLine("\n\nCircular Linked List: Printing All Elements:");
        circularlinkedList.PrintAll();
    }
    else if (choice == 4)//deleting all patients (deleteAll)
    {
        Console.WriteLine("\nCircular Array: All Elements have been Deleted");
        circularArray.DeleteAll();
        Console.WriteLine("\n\nCircular Linked List: All Elements have been Deleted");
        circularlinkedList.DeleteAll();
    }
    else //user inputted an invalid option, so display error, options and take user option input
    {
        Console.WriteLine("ERROR - Invalid input of choice");
    }
}


//Method: AddPatient() takes a Node object and gets patient's info and assigns random emergency level to the object
Node AddPatient(Node obj)
{
    int age, level;
    string firstn, lastn;
    Console.Write("Enter First Name: ");
    firstn = Console.ReadLine(); //get first name

    Console.Write("Enter Last Name: ");
    lastn = Console.ReadLine(); //get last name

    Console.Write("Enter Age: ");
    age = Convert.ToInt32(Console.ReadLine()); //get age

    level = random.Next(1, 5); //generate random number between 1 & 5 for the emergency level
    obj = new Node(firstn, lastn, age, level); //create the new Node to be added to the lists

    //adding patient to the circulat array and circular linked list
    circularArray.Enqueue(obj, level); //add to circular array
    circularlinkedList.Enqueue(obj, level); //add to circular linked list
    return obj;
}