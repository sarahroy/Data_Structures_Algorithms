//Name: Sarah Ann Roy
//Student Number: 0650615
//COIS 2020H : LAB 2 
//LabSuper.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class LabSuper : LabInterface
    {
        public string Name { get; set; }
        public int ID { get; set ; }
        public virtual string Print()//virtual method in parent class overridden by Print in the child classes.
        {
            return ""; 
        }
    }
}
