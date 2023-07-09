//COIS 2020H : Data Structure and Algorithms
//Assigment 2
//Name: Sarah Ann Roy
//Student Number: 0650615
//Snake.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    class Snake : Animal
    {
        //Snake Properties
        double length;
        bool venomous;

        //Snake Constructor - take 5 parameters and assigns length and venomous to the object.
        public Snake(string t, int id, string n, double a, double l, bool v) : base(t, id, n, a)//animal_type, ID, name, and age is inherited from class Animal.
        {
            this.length = l; //assign length
            this.venomous = v; //assign venomous
        }

        //ToString() - overrides Animal.ToString() and returns a string 
        public override string ToString()
        {
            return $"ID: {this.ID}, AnimalType: {this.animal_type}, Name: {this.name}, Age: {this.age}, Length: {this.length}, IsVenomous: {this.venomous}, Position (x,y,z): ({this.pos.x},{this.pos.y},{this.pos.z})";
        }

        //Method: Eat() - takes a Bird object and eats it if is in the range of the snake
        public void Eat(Animal Bird)
        {
            Bird = null;
        }
    }
}