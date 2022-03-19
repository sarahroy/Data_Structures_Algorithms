using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    public class Position
    {
        private double x, y, z;
        public static double Z1;

        public double X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }
        public double Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }
        public double Z
        {
            get
            {
                return z;
            }
            set
            {
                z = value;
            }
        }


        private static  readonly Random random = new Random();
        private static  readonly object syncLock = new object();
       
       /// <summary>
       /// Position constructor which takes no parameters, sets the x,y,z coordinates using random numbers 
       /// </summary>
        public Position()
        {
                this.x = Math.Round(random.NextDouble() * (Grid.maxSize * Grid.maxSize),1);
                this.y = Math.Round(random.NextDouble() * (Grid.maxSize * Grid.maxSize),1);
                this.z = Math.Round(random.NextDouble() * (Grid.maxSize * Grid.maxSize),1);
            Z1 = z;
        }

        /// <summary>
        /// Position constructor which takes x,y,z parameters, sets the x,y,z to the formal parameters 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public Position(double x, double y, double z)
        { 
                this.X = x;
                this.Y = y;
                this.Z = z;
            Z1 = z;
        }
        
    }
}
