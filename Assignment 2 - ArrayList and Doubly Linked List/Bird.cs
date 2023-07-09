//COIS 2020H : Data Structure and Algorithms
//Assigment 2
//Name: Sarah Ann Roy
//Student Number: 0650615
//Bird.cs
using System;
namespace Assignment_1
{
	public class Bird : Animal
	{
        //Bird Constructor 
        public Bird(string t, int id, string n, double a) : base(t, id, n, a) 
        {
            //animal_type, ID, name, and age is inherited from class Animal.
        }

        //ToString() - overrides Animal.ToString() and returns a string
        public override string ToString()
        {
            return $"ID: {this.ID}, AnimalType: {this.animal_type}, Name: {this.name}, Age: {this.age}, Position (x,y,z): ({this.pos.x},{this.pos.y},{this.pos.z})";
        }
    }
}
