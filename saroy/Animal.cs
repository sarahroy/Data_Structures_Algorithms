//COIS 2020H : Data Structure and Algorithms
//Assigment 2
//Name: Sarah Ann Roy
//Student Number: 0650615
//Animal.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    public class Animal : IComparable<Animal>
    {
        //Animal Properties
        public int ID { get; set; }
        public string name { get; set; }
        public double age { get; set; }
        public string animal_type { get; set; } 
        public Position pos;
        private Random random = new Random();

        //Animal Constructor - takes 3 parameters and assigns ID, name, age and position for each object.
        public Animal(string t, int id, string n, double a)
        {
            this.ID = id; //assign ID
            this.animal_type = t; //assign animal_type
            this.name = n; //assign name
            this.age = a; //assign age
            pos = new Position(this.animal_type); //new position for animal
        }
        //Method: Move() creates 3 random values and passes the values to Position.Move() 
        //Move all of the objects with a random dx, dy, dz (but only slightly, these can be +/- 5.0
        public void Move()
        {
            double dx ,dy, dz;
            if(this.animal_type == "Bird") //for Birds only
            {
                dx = random.Next(-10, 10);
                dy = random.Next(-10, 10);
                dz = random.Next(-2, 2);
                
            }
            else //for Cats & Snakes
            {
                dx = random.Next(-5, 5);
                dy = random.Next(-5, 5);
                dz = random.Next(-5, 5);
            }
            this.pos.Move(this.animal_type,dx, dy, dz); //passing the random values to Position.Move()
        }
        
        //Method: ToString() is virtual and is overriden in its subclasses
        public virtual string ToString()
        {
            return "";
        }

        //Method: Eat() is virtual and is overriden in its subclasses
        public virtual void Eat(Animal Bird)
        {
            
        }

        //Method: CompareTo() takes an Animal object and compares the names alphabetically 
        /*The CompareTo() method depending on the comparison:
         * returns 0, if the current instance’s property is equal to the temporary variable’s property (same name)
         * returns 1, if the current instance’s property is greater than the temporary variable’s property
         * returns -1, if the current instance’s property is less than the temporary variable’s property 
         */
        public int CompareTo(Animal animal)
        {
            if(animal == null)
                return 1;
            return this.name.CompareTo(animal.name);
        }
    }
}