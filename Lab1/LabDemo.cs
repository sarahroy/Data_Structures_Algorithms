//COIS 2020H - Lab 1
//Sarah Ann Roy
//0650615
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class LabDemo
    {
        public String Name { set; get; }
        public int Age { set; get; }
        public double value;
        public double Value
        {
            get { return value; }
            set { this.value = value; }
        }

        //Constructor to initialize values
        public LabDemo()
        {
            Name = " ";
            Age = 0;
            value = 0.0;
        }

        //Method to triple the value
        public void TripleValue()
        {
            value *= 3;
        }
    }
}