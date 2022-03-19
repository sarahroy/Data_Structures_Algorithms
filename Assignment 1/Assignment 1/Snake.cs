using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    public class Snake : MobileObject
    {
        
        public double length = 0, radius = 0;
        public int vertebrae = 0;
        private double Volume;

       public double Length
        {
            get
            { return length;}
            set
            {
                if (value > 0)
                    length = value;
                else
                    length = 0;
            }
        }
        public double Radius
        {
            get
            { return radius; }
            set
            {
                if (value > 0)
                    radius = value;
                else
                    radius = 0;
            }
        }
        
        public int Vertebrae
        {
            get
            { return vertebrae; }
            set
            {
                if (value >= 200 && value <= 300)
                    vertebrae = value;
                else
                    vertebrae = 200;
            }
        }
        /// <summary>
        /// Calculating Volume of Snake = pi * r * r * length
        /// </summary>
        /// <returns>volume</returns>
        private double CalcVolume()
        {
            Volume = 3.14 * radius * radius * length;
            return Volume;
        }
        /// <summary>
        /// Snake Constructor sets the attributes of the Snake whenever called. Name and mass is given by the MobileObject constructor
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <param name="v"></param>
        /// <param name="name"></param>
        /// <param name="mass"></param>
        public  Snake(double l, double r,int v, string name, double mass): base (name, mass)
        {
            this.length = l;
            this.radius = r;
            this.Vertebrae = v;
            this.Volume = CalcVolume();
        }
        /// <summary>
        /// Prints the attributes of the Snake
        /// </summary>
        public override void PrintAll()
        {
            Console.WriteLine("\nName: " + this.Name + "\tObject ID: "+this.objectId+"\tMass: " + this.mass + "\tLength: " + this.length + 
                "\tRadius: " + this.radius + "\tVolume: " + Volume + "\tNo: of Vertebrae: " + Vertebrae  + "\nObject Position (x,y,z): (" + Math.Round(this.position.X, 2) + ", " + Math.Round(this.position.Y, 2) + ", " + Math.Round(this.position.Z, 2) + ")" + "\tCell Position (x,y): (" + this.cellxy[0]+ ", " + this.cellxy[1] + ")"+"\tCell ID: " + this.cellId + "\n");
            Console.WriteLine();
        }
    }
}
