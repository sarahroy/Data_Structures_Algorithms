//COIS 2020H : Data Structure and Algorithms
//Assigment 2
//Name: Sarah Ann Roy
//Student Number: 0650615
//Program.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Assignment_1;

//creating an ArrayList of 3 cats
ArrayList<Animal> cats = new ArrayList<Animal>(3);

//creating an ArrayList of 3 snakes
ArrayList<Animal> snakes = new ArrayList<Animal>(3);

//creating 3 objects of class Cat and adding to the arraylist 
Animal bella = new Cat("Cat",1,"Bella",6.2, 0); cats.AddFront(bella);
Animal charlie = new Cat("Cat", 2, "Charlie", 1.5, 1); cats.AddFront(charlie);
Animal lucy = new Cat("Cat", 3, "Lucy", 4.3, 2); cats.AddFront(lucy);

Console.WriteLine($"Number of cats = {cats.GetCount()}");

//creating 3 objects of class Snake and adding to the arraylist 
Animal coral = new Snake("Snake", 4, "Coral", 5.3, 24.45, true); snakes.AddFront(coral);
Animal ebony = new Snake("Snake", 5, "Ebony", 0.4, 3.30, false); snakes.AddFront(ebony);
Animal jade = new Snake("Snake", 6, "Jade", 9.6, 152.66, true); snakes.AddFront(jade);

Console.WriteLine($"Number of snakes = {snakes.GetCount()}");

//Merging the list of cats and snakes
ArrayList<Animal> animals = ArrayList<Animal>.Merge(cats, snakes);

//Testing PrintAllForward() on the merged array list
Console.WriteLine("\nTesting PrintAllForward() for merged arrayList");
Console.WriteLine(animals.PrintAllForward());

//Testing PrintAllReverse() on the merged array list
Console.WriteLine("\nTesting PrintAllReverse() for merged arrayList");
Console.WriteLine(animals.PrintAllReverse());

//Creating the first doubly linked list of birds
DoublyLinkedList<Bird> birds1 = new DoublyLinkedList<Bird>();

//creating 5 objects of class Bird and adding them to the first doubly linked list
Animal tweety = new Bird("Bird", 1, "Tweety", 4.6);birds1.AddLast(tweety);
Animal zazu = new Bird("Bird", 2, "Zazu", 5.2);birds1.AddLast(zazu);
Animal iago = new Bird("Bird", 3, "Iago", 0.8);birds1.AddLast(iago);
Animal hula = new Bird("Bird", 4, "Hula", 3.9);birds1.AddLast(hula);
Animal manu = new Bird("Bird", 5, "Manu", 12.0);birds1.AddLast(manu);

//Creating a second doubly linked list of birds
DoublyLinkedList<Bird> birds2 = new DoublyLinkedList<Bird>();

//creating 5 objects of class Bird and adding them to the second doubly linked list
Animal couscous = new Bird("Bird", 6, "Couscous", 1.6);birds2.AddLast(couscous);
Animal roo = new Bird("Bird", 7, "Roo", 4.6);birds2.AddLast(roo);
Animal tookie = new Bird("Bird", 8, "Tookie", 5.2);birds2.AddLast(tookie);
Animal plucky = new Bird("Bird", 9, "Plucky", 0.8);birds2.AddLast(plucky);
Animal jay = new Bird("Bird", 10, "Jay", 1.6);birds2.AddLast(jay);

//Merge the second list onto the first
birds1.Merge(birds2);

//Testing PrintAllForward() on the merged doubly linked list
Console.WriteLine("\nTesting PrintAllForward() on merged Doubly Linked List");
Console.WriteLine(birds1.PrintAllForward());

//Testing PrintAllReverse() on the merged doubly linked list
Console.WriteLine("\nTesting PrintAllReverse() on merged Doubly Linked List");
Console.WriteLine(birds1.PrintAllReverse());

int r = 0;//number of rounds it takes to eat all birds
int range_c = 8, range_s = 3, speed_c = 16, speed_s = 14; //range and speeds of cats and snakes
Animal toeat;
//while-loop for the cats and snakes to eat all the birds
while (birds1.GetCount()>0)
{
    for(int i = 0; i < animals.array.Length; i++)
    {
        toeat = birds1.FindClosest(animals.array[i]);//find closest bird to the animal
        Console.WriteLine($"{animals.array[i].name} is Eating -> {toeat.name}");
        animals.array[i].Eat(toeat);
    }
    
    if (r % 5 == 0)//After every fifth iteration, PrintallForward 
    {
        Console.WriteLine($"After {r} rounds, the surviving birds are: \n");
        birds1.PrintAllForward();
    }
    birds1.MoveBirds();//Then birds “that survive” will randomly move as per their rules above.  
    r++;//update round count
}
Console.WriteLine($"Number of rounds it took to eat all birds = {r}");//Report how many rounds it took
