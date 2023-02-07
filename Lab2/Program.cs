//Name: Sarah Ann Roy
//Student Number: 0650615
//COIS 2020H : LAB 2&3 
//Program.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2;

LinkedList <LabSuper> labList = new LinkedList <LabSuper>();

//create object #1, add it to linked list and print
LabSubA obj1 = new LabSubA();
obj1.ID = 0;
obj1.Name = "zero";
obj1.demo = 10;
labList.AddFirst(obj1);
//Console.WriteLine(obj1.Print());

//create object #2, add it to linked list and print
LabSubB obj2 = new LabSubB();
obj2.ID = 1;
obj2.Name = "One";
obj2.demo = 22.22;
labList.AddFirst(obj2);
//Console.WriteLine(obj2.Print());

//create object #3, add it to linked list and print
LabSubA obj3 = new LabSubA();
obj3.ID = 2;
obj3.Name = "two";
obj3.demo = 18;
labList.AddFirst(obj3);
//Console.WriteLine(obj3.Print());

//create object #4, add it to linked list and print
LabSubB obj4 = new LabSubB();
obj4.ID = 3;
obj4.Name = "Three";
obj4.demo = 26.73;
labList.AddFirst(obj4);
//Console.WriteLine(obj4.Print());

Console.WriteLine("AddFirst()");
//Print all objects in the linked list
foreach (LabSuper x in labList)
    Console.WriteLine(x.Print());

Console.WriteLine("\nAddLast()");
//create object #5, add it to linked list and print
LabSubA obj5 = new LabSubA();
obj5.ID = 4;
obj5.Name = "four";
obj5.demo = 23;
labList.AddLast(obj5);

//create object #6, add it to linked list and print
LabSubB obj6 = new LabSubB();
obj6.ID = 5;
obj6.Name = "Five";
obj6.demo = 63.59;
labList.AddLast(obj6);

//Print all objects in the linked list
foreach (LabSuper x in labList)
    Console.WriteLine(x.Print());

//RemoveFirst()
Console.WriteLine("\nTrying RemoveFirst()");
labList.RemoveFirst();
//Print all objects in the linked list
foreach (LabSuper x in labList)
    Console.WriteLine(x.Print());


//RemoveLast()
Console.WriteLine("\nTrying RemoveLast()");
labList.RemoveLast();
//Print all objects in the linked list
foreach (LabSuper x in labList)
    Console.WriteLine(x.Print());

//labList.Count
Console.WriteLine($"\nlablist.Count = {labList.Count}");