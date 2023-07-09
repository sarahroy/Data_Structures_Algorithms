//COIS 2020H : Data Structure and Algorithms
//Assigment 2
//Name: Sarah Ann Roy
//Student Number: 0650615
//Cat.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    //Enum property for Cat Breed
    enum Breed
    {
        Abyssinian,         //0
        British_Shorthair,  //1
        Bengal,             //2
        Himalayan,          //3
        Ocicat,             //4
        Serval              //5
    }
    class Cat : Animal
    {
        //Cat Property
        Breed breed;

        //Cat Constructor - takes 4 parameters and assigns cat breed to the object. 
        public Cat(string t,int id, string n, double a, int b) : base(t, id, n, a) //animal_type, ID, name, and age is inherited from class Animal.
        {
            //assigning cat breed
            switch (b)
            {
                case 0:
                    this.breed = Breed.Abyssinian;
                    break;
                case 1:
                    this.breed = Breed.British_Shorthair;
                    break;
                case 2:
                    this.breed = Breed.Bengal;
                    break;
                case 3:
                    this.breed = Breed.Himalayan;
                    break;
                case 4:
                    this.breed = Breed.Ocicat;
                    break;
                case 5:
                    this.breed = Breed.Serval;
                    break;
            }
        }

        //ToString() - overrides Animal.ToString() and returns a string
        public override string ToString()
        {
            return $"ID: {this.ID}, AnimalType: {this.animal_type}, Name: {this.name}, Age: {this.age}, Breed: {this.breed}, Position (x,y,z): ({this.pos.x},{this.pos.y},{this.pos.z})";
        }

        //Method: Eat() - takes a Bird object and eats it if is in the range of the cat
        public void Eat(Animal Bird)
        {
            Bird = null;
        }
    }
}