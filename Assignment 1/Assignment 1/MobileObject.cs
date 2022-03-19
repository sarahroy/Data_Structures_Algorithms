using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    public class MobileObject 
    {
        public  string Name { set; get; }
        public static int count=0; 
        public int objectId, cellId, PositionCell;
        public int[] cellxy=  new int[2];
        public float[] origin = new float[3];
        public double mass = 0;
        public double Z1;
        public double Mass
        {
            get
            {
                return mass;
            }

            set
            {
                if (value > 0)
                    mass = value;
                else
                    mass = 1;
            }
        }

        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();
        public  Position position;

        /// <summary>
        /// MobileObject constructor which assigns the name, mass, object ID, cell ID, cell position and object position of a Cat/Snake
        /// </summary>
        /// <param name="name"></param>
        /// <param name="mass"></param>
        public MobileObject(string name, double mass)
        {
            this.Name = name;
            this.mass = mass;
            this.objectId = count++;
            position = new Position();
            this.cellId = Grid.GetCellID(position);
            this.cellxy = Grid.ObjCell(cellId, cellxy);
            Z1=UpdateZ();
        }
        /// <summary>
        /// Move(). this method moves the mobileObject by user-inputted dx,dy,dz
        /// </summary>
        /// <param name="dx"></param>
        /// <param name="dy"></param>
        /// <param name="dz"></param>
        public void Move(double dx, double dy, double dz)
         {
            
             if(this.position.X +dx >= Math.Pow(Grid.maxSize,2)) //the new position.x should stay within the 10x10 or 16x16 bounds 
             {
                do
                {
                    Console.Write("Enter dx: "); dx = Convert.ToInt32(Console.ReadLine());
                } while (dx >= Math.Pow(Grid.maxSize, 2) - this.position.X);
                
             }
             else this.position.X += dx;

            if (this.position.Y + dy >= Math.Pow(Grid.maxSize, 2)) //the new position.y should stay within the 10x10 or 16x16 bounds 
            {
                do
                {
                    Console.Write("Enter dy: "); dy = Convert.ToInt32(Console.ReadLine());
                } while (dy >= Math.Pow(Grid.maxSize, 2) - this.position.Y);
                
            }
            else this.position.Y += dy;

            if (this.position.Z + dz >= Math.Pow(Grid.maxSize, 2)) //the new position.z should stay within the 10x10 or 16x16 bounds 
            {
                do
                {
                    Console.Write("Enter dz: "); dz = Convert.ToInt32(Console.ReadLine());
                } while (dz >= Math.Pow(Grid.maxSize, 2) - this.position.Z);
                
            }
            else this.position.Z += dz;
            Z1=UpdateZ();
        }

        //
        /// <summary>
        /// move&update method moves the MobileObject by random dx,dy,dz
        /// </summary>
        public void MoveAndUpdate()
        {
            double a, b, c;
            do
            {
                a = random.Next(1,10); //10 units is the smallest distance chosen that every object will move by
                b = random.Next(1,10);
                c = random.Next(1,10);
            } while (this.position.X + a >= Math.Pow(Grid.maxSize, 2) || this.position.Y + b >= Math.Pow(Grid.maxSize, 2) || this.position.Z + c >= Math.Pow(Grid.maxSize, 2));
            this.position.X += a;
            this.position.Y += b;
            this.position.Z += c;
            Z1=UpdateZ();
        }
        /// <summary>
        /// MoveOrigin() moves the MobileObjects by -dx,-dy,-dz
        /// </summary>
        /// <param name="dx"></param>
        /// <param name="dy"></param>
        /// <param name="dz"></param>
       public  void MoveOrigin(float dx, float dy, float dz)
       {
            this.position.X -= dx;
            this.position.Y -= dy;
            this.position.Z -= dz;
            Z1=UpdateZ();
       }
        /// <summary>
        /// FindWithinDistance Method calculates d=squareroot(x^2 + y^2 + z^2) and if its within bounds of the inputted distance, the object is printed 
        /// </summary>
        /// <param name="distance">this is inputted from the user in Program.cs and is passed to this method when called</param>
        public void FindWithinDistance(float distance)
        {
            double d = Math.Round(Math.Sqrt(Math.Pow(this.position.X, 2)) + Math.Sqrt(Math.Pow(this.position.Y, 2)) + Math.Sqrt(Math.Pow(this.position.Z, 2)),1);
            if (d <= distance)
            {
                Console.WriteLine("Distance from origin: "+d+"\tID: "+this.objectId+"\tName: "+this.Name+"\tPosition: (x,y,z) ("+ this.position.X+","+ this.position.Y+","+this.position.Z+" )");
            }
        }
        /// <summary>
        /// UpdateZ() This method allows the program to keep track of the position.Z value and is called whenever a MobileObject is moved
        /// </summary>
        /// <returns>this returns a double, ie the Z value of that object</returns>
        public double UpdateZ()
        {
            Z1 = this.position.Z;
            return Z1;
        }
        /// <summary>
        ///PrintAnimal() prints the properties of either a Cat or Snake  
        /// </summary>
        public virtual void PrintAll()
        {
            
        }  
    }
}
