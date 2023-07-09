using System;
using System.Collections.Generic;
using System.Text;

namespace MinHeap
{
    class DemoClass : IComparable
    {
        public string name;
        public int priority;
     
        public DemoClass()
        { name = "";
            priority = 0;
        }

        public int CompareTo(Object obj)
        {   //CompareTo  
            //this.CompareTo(value) returns < 0 if this < value
            //this.CompareTo(value) returns >0 if this > value
            DemoClass sample = (DemoClass)obj;

            if (priority < sample.priority) return -1;
            else if (priority > sample.priority) return 1;
            else return 0; // value == sample.value

        
        }
        public override string ToString()
        {
            return name + " " + priority + " ";
        }

    }
}
