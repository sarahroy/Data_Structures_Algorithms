//COIS 2020H - Lab 1
//Sarah Ann Roy
//0650615
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab1;

int[] array = {1, 13, 37, 51, 77, 90, 120, 211, 258, 300, 301};
Console.WriteLine(String.Join(",", array));
int i; //iterator
for(i=0; i<array.Length; i++)
{
    if(array[i] % 11 == 0)
        Console.WriteLine($"{array[i]} is evenly divisible by 11 where {array[i]} is of course the value");
}


LabDemo demo1 = new LabDemo();
demo1.Name = "Tim";
demo1.Age = 10;
demo1.value = 2300.57;

LabDemo[] demos = new LabDemo[5]; //creating an array of 5 objects of LabDemo
for(i=0; i < demos.Length; i++)
{
    demos[i] = new LabDemo();
}

demos[0].Name = "Jawa";
demos[0].Age = 7;
demos[0].value = 2134.56;

demos[1].Name = "Indi";
demos[1].Age = 7;
demos[1].value = 1921.10;

demos[2].Name = "Sasha";
demos[2].Age = 3;
demos[2].value = 540.23;

demos[3].Name = "Tiger";
demos[3].Age = 19;
demos[3].value = 167.89;

demos[4].Name = "Willow";
demos[4].Age = 16;
demos[4].value = 654.32;


int j = demos.Length;
i=0;
while (i < j)
{
    if(demos[i].value < 2000)
    {
        demos[i].TripleValue();
    }
    i++;
}

foreach(var d in demos)
{
    Console.WriteLine($"Name: {d.Name}, Age: {d.Age}, Value: {d.value}");
}
