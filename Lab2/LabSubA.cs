//Name: Sarah Ann Roy
//Student Number: 0650615
//COIS 2020H : LAB 2 
//LabSubA.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class LabSubA : LabSuper
    {
        public int demo;
        public override string Print()//Print() overrides LabSuper.Print()
        {
            return $"ID: {this.ID}, Name: {this.Name}, demo = {this.demo}";
        }
    }
}