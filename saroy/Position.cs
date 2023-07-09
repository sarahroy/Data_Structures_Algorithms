//COIS 2020H : Data Structure and Algorithms
//Assigment 2
//Name: Sarah Ann Roy
//Student Number: 0650615
//Position.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    public class Position
    {
        //doubles x, y, and z with setters and getters
        public double x { get; set; }
        public double y { get; set; }
        public double z { get; set; }

        private Random random = new Random();

        //Position Constructor which take a string (animal_type) and intializes the starting position (x,y,z) of the Animal
        public Position(string t)
        {
            if(t == "Bird") //for Birds only
            {
                this.x = random.Next(-100, 100);
                this.y = random.Next(-100, 100);
                this.z = random.Next(0, 10);
            }
            else //for Cats & Snakes
            {
                this.x = random.Next(-25, 25);
                this.y = random.Next(-25, 25);
                this.z = 0;
            }
            
        }
        //Method: Move() which takes string t and doubles dx, dy, and dz and changes the position by + dx, + dy, +dz 
        //(it clamps to max values of +/- 100 for the edges).  
        //The three values dx, dy, and dz can be positive or negative
        public void Move(string t, double dx, double dy, double dz)
        {
            if(t == "Bird")//for Birds only
            {
                //clamping the values of x
                if (Math.Abs(this.x + dx) > 100)
                    this.x = 100.0;
                else
                    this.x += dx;

                //clamping the values of y
                if (Math.Abs(this.y + dy) > 100)
                    this.y = 100.0;
                else
                    this.y += dy;

                //clamping the values of z
                if (Math.Abs(this.z + dz) > 10 || Math.Abs(this.z + dz) < 0)
                    this.z = 10.0;
                else
                    this.z += dz;
            }
            else //for Cats & Snakes
            {
                //clamping the values of x
                if (Math.Abs(this.x + dx) > 100)
                    this.x = 100.0;
                else
                    this.x += dx;

                //clamping the values of y
                if (Math.Abs(this.y + dy) > 100)
                    this.y = 100.0;
                else
                    this.y += dy;

                //clamping the values of z
                if (Math.Abs(this.z + dz) > 100)
                    this.z = 100.0;
                else
                    this.z += dz;
            }
        }
    }
}