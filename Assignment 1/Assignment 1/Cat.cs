using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    public class Cat :MobileObject
    {
        
        private double torsoLength, headLength, tailLength, legLength;

        public double TorsoLength
        {
            get
            {
                return torsoLength;
            }
            set
            {
                if (value > 0)
                    torsoLength = value;
                else
                    torsoLength = 0;
            }
        }
        public double HeadLength
        {
            get
            {
                return headLength;
            }
            set
            {
                if (value > 0)
                    headLength = value;
                else
                    headLength = 0;
            }
        }
        public double TailLength
        {
            get
            {
                return tailLength;
            }
            set
            {
                if (value > 0)
                    tailLength = value;
                else
                    tailLength = 0;
            }
        }
        public double LegLength
        {
            get
            {
                return legLength;
            }
            set
            {
                if (value > 0)
                    legLength = value;
                else
                    legLength = 0;
            }
        }
        /// <summary>
        ///caluculating Total Length = torsoLength + headLength+ legLength
        /// </summary>
        /// <returns>totoal length</returns> 
        private double TotalLengthCalc()
        {
            return torsoLength + headLength + legLength;
        }
        /// <summary>
        /// Cat constructor sets the tailLength, torsoLength, headLength and legLength whenever called. Name and Mass is given from the MobileObject constructor
        /// </summary>
        /// <param name="tailL"></param>
        /// <param name="torsoL"></param>
        /// <param name="headL"></param>
        /// <param name="legL"></param>
        /// <param name="name"></param>
        /// <param name="mass"></param>
        public Cat(double tailL, double torsoL, double headL, double legL, string name, double mass): base (name,mass)
        {
            this.tailLength = tailL;
            this.torsoLength = torsoL;
            this.headLength = headL;
            this.legLength = legL;
        }
        
        /// <summary>
        /// Prints all the attributes of a Cat
        /// </summary>
        public override void PrintAll()
        {
            Console.WriteLine("\nName: " + this.Name+ "\tObject ID: " + this.objectId + "\tMass: " + this.mass + "\tTorso Length: " + torsoLength + "\t Head Length: " + headLength + "\t LegLength: " + torsoLength + 
             "\tTail Length: " + tailLength+ "\tTotal Length: " + TotalLengthCalc()+ "\nObject Position (x,y,z): ("+Math.Round(this.position.X,2)+", "+ Math.Round(this.position.Y,2) + ", " + Math.Round(this.position.Z,2) + ")" + "\tCell Position (x,y): ( " + this.cellxy[0] + ", " + this.cellxy[1] + " )"+"\tCell ID: "+ this.cellId+ "\n");
            Console.WriteLine();
        }
    }
}
 