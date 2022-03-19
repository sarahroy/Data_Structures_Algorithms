using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int option,grid_size, input_ID, vertebrae;
            float dist;
            double tail, torso, head, leg, length, radius, mass; 
            string name = "";

            //Creating a Linked List of type MobileObjects. This is the list of all Cats and Snakes
            LinkedList<MobileObject> LL = new LinkedList<MobileObject>();

            //Welcome Message
            Console.WriteLine("\t\t\t\t\tWelcome to My Program of Cats and Snakes\n");
            
            //Taking the size from the user to create a gride of size x size
            Console.Write("10x10 or 16x16? Enter valid size:");
            grid_size = Convert.ToInt32(Console.ReadLine());
            if (grid_size != 10 && grid_size != 16)
                grid_size = 10;
            Grid new_grid = new Grid(grid_size);
            Console.WriteLine(grid_size + "x" + grid_size + " Grid created successfully!");

            //Adding 5 (five) cats and snakes each to the empty Linked List
            MobileObject Malcho = new Snake (17, 4,9,"Malcho", 15); LL.AddLast(Malcho);
            MobileObject Nagini = new Snake(5, 10, 2, "Nagini", 14); LL.AddLast(Nagini);
            MobileObject Kaa = new Snake(6, 12, 5, "Kaa", 12); LL.AddLast(Kaa);
            MobileObject Viper = new Snake(6, 12, 5, "Viper", 12); LL.AddLast(Viper);
            MobileObject Slytherin = new Snake(6, 12, 5, "Slytherin", 12); LL.AddLast(Slytherin);

            MobileObject Garfield = new Cat(3, 14, 8, 3, "Garfield", 13); LL.AddLast(Garfield);
            MobileObject Tom = new Cat(4, 15, 4, 3, "Tom", 10); LL.AddLast(Tom);
            MobileObject Simba = new Cat(7, 20, 8, 9, "Simba", 11); LL.AddLast(Simba);
            MobileObject Nala = new Cat(7, 20, 8, 9, "Nala", 11); LL.AddLast(Nala);
            MobileObject Sylvester = new Cat(7, 20, 8, 9, "Sylvester", 11); LL.AddLast(Sylvester);
            Console.WriteLine("10 Mobile Objects created and stored in the Grid successfully!");

            //Adding all the MobileObjects from the LL to Cellid to sort by cellid
            foreach (var item in LL)
            {
                Grid.cell_array[(int)(item.position.X / Grid.maxSize), (int)(item.position.Y / Grid.maxSize)].CellIDs.Add(item);
            }

            //loading the text files for Cat Names and Snake Names
            string[] CatNumbers = System.IO.File.ReadAllLines(@"C:\Users\Sarah Roy\Documents\CatNames.txt");//C:\Users\Sarah Roy\Documents\CatNames.txt
            string[] CatNames = new string[CatNumbers.Length];
            for(int i=0; i< CatNumbers.Length;i++)
            {
                string[] lineParts = CatNumbers[i].Split(' ');
                CatNames[i] = lineParts[2];
            }
            string[] SnakeNames = System.IO.File.ReadAllLines(@"C:\Users\Sarah Roy\Documents\SnakeNames.txt");//C:\Users\Sarah Roy\Documents\SnakeNames.txt

            //do-while loop
            do
            {
                //prompting the user
                Console.WriteLine("\nOPTIONS: \n" +
                    "\n0.QUIT " +
                    "\n1.Add Cat " +
                    "\n2.Add Snake " +
                    "\n3.Move Cat/Snake " +
                    "\n4.Move&Update " +
                    "\n5.Move Origin " +
                    "\n6.Find Within Distance " +
                    "\n7.Randomize Array " +
                    "\n8.Print Existing Objects " +
                    "\n9.Number of MobileObjects in each CellID " +
                    "\n10.Print "+ grid_size + "x"+ grid_size +" Grid and all Mobileobjects sorted by z-coordinate\n");
                Console.Write("Enter valid option: ");
                option = Convert.ToInt32(Console.ReadLine());    
                if (option != 0)
                {
                    switch (option)
                    {      
                        //Adding a New Cat
                        case 1:
                            {
                                //this next piece of code asks the user whether they would like to enter the name of MobileObject themselves or if they would want a random name from the textfiles Sri gave us
                                char choice;
                                Console.Write("A.User Input Name\tB. Automated Input Name\t Enter valid option (A/B): "); choice = Convert.ToChar(Console.ReadLine()); choice = Char.ToUpper(choice);
                                if (choice == 'A')
                                {
                                    Console.Write("Enter Name: "); name = Convert.ToString(Console.ReadLine());
                                }
                                else if (choice == 'B')
                                {
                                    Random random = new Random(LL.Count);
                                    int a = random.Next(LL.Count);
                                    name = CatNames[a];
                                }
                                else
                                {
                                    Console.WriteLine("INVALID OPTION!!"); break;
                                }

                                //prompting the user for the other attributes of the MobileObjects
                                Console.Write("Enter tail length: "); tail = Convert.ToDouble(Console.ReadLine());
                                Console.Write("Enter torso length: "); torso = Convert.ToDouble(Console.ReadLine());
                                Console.Write("Enter head length: "); head = Convert.ToDouble(Console.ReadLine());
                                Console.Write("Enter leg length: "); leg = Convert.ToDouble(Console.ReadLine());
                               Console.Write("Enter mass: "); mass = Convert.ToDouble(Console.ReadLine());
                                if(tail<0 || torso <0 || head<0 || leg<0|| mass<0)
                                {
                                    Console.WriteLine("\n\nERROR! Object Creation Failed!! Please enter positive integers only!");
                                    for (int i = 0; i < 100; i++)
                                        Console.Write("=");
                                    Console.WriteLine();
                                    break;
                                }
                                
                                else
                                {
                                    //adding a new cat with constructor
                                    MobileObject new_cat = new Cat(tail, torso, head, leg, name, mass);
                                    LL.AddLast(new_cat);
                                    new_cat.PrintAll();
                                    Console.WriteLine("\nMobileObject "+name+" was created successfully!");
                                    for (int i = 0; i < 100; i++)
                                        Console.Write("=");
                                    Console.WriteLine();
                                }
                                break;
                            }

                        //Adding A new Snake
                        case 2:
                            {
                                //this next chunk of code asks the user whether they would like to enter the name of MobileObject themselves or if they would want a random name from the textfiles Sri gave us
                                char choice;
                                Console.Write("A.User Input Name\tB. Automated Input Name\t Enter valid option: "); choice = Convert.ToChar(Console.ReadLine()); choice = Char.ToUpper(choice);
                                if (choice == 'A')
                                {
                                    Console.Write("Enter Name: "); name = Convert.ToString(Console.ReadLine());
                                }
                                else if (choice == 'B')
                                {
                                    Random random = new Random(LL.Count);
                                    int a = random.Next(LL.Count);
                                    name = SnakeNames[a];
                                }
                                else
                                {
                                    Console.WriteLine("INVALID OPTION!!");break;
                                }
                                //prompting the user for the other attributes of the MobileObjects
                                Console.Write("Enter number of vertebrae (200/300) : "); vertebrae = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Enter length: "); length = Convert.ToDouble(Console.ReadLine());
                                Console.Write("Enter radius: "); radius = Convert.ToDouble(Console.ReadLine());
                                Console.Write("Enter mass: "); mass = Convert.ToDouble(Console.ReadLine());
                                if (vertebrae < 0 || length < 0 || radius < 0 || mass < 0)
                                {
                                    Console.WriteLine("\n\nERROR! Object Creation Failed!! Please enter positive integers only!");
                                    for (int i = 0; i < 100; i++)
                                        Console.Write("=");
                                    Console.WriteLine();
                                    break;
                                }
                                else
                                {
                                    //adding a new snake with constructor
                                    MobileObject new_snake = new Snake(length, radius, vertebrae, name, mass);
                                    LL.AddLast(new_snake);
                                    new_snake.PrintAll();
                                    Console.WriteLine("\nMobileObject " + name + " was created successfully!");
                                    for (int i = 0; i < 100; i++)
                                        Console.Write("=");
                                }
                                break;
                            }

                        //Moving an Animal
                        case 3:
                            {
                                int dx, dy, dz, count;
                                count = LL.Count - 1;
                                Console.Write("Enter the ID of the Cat/Snake you want to move (0-" +count+") :");
                                input_ID = Convert.ToInt32(Console.ReadLine());
                                if (input_ID > count || input_ID < 0)
                                {
                                    Console.WriteLine("ERROR!! Mobile Object Not Found"); break;
                                }
                                else
                                {
                                    //Finding the object the cat/snake to be moved from the existing linked list
                                    MobileObject moveObject = null;
                                    foreach (var item in LL)
                                    {
                                        if (item.objectId == input_ID)
                                        {
                                            moveObject = item;
                                            break;
                                        }
                                    }
                                    //not found
                                    if (moveObject == null)
                                        break;
                                    Console.Write("Enter dx:"); dx = Convert.ToInt32(Console.ReadLine());
                                    Console.Write("Enter dy:"); dy = Convert.ToInt32(Console.ReadLine());
                                    Console.Write("Enter dz:"); dz = Convert.ToInt32(Console.ReadLine());

                                    moveObject.Move(dx, dy, dz);
                                    moveObject.PrintAll();
                                    for (int i = 0; i < 100; i++)
                                        Console.Write("=");
                                }
                                break;
                            }
                        //Move&Update all esxisting animals from the list
                        case 4:
                            {
                                Console.WriteLine("The existing Cats & Snakes will be randomly moved");
                                foreach(var item in LL)
                                {
                                    if (item != null)
                                       item.MoveAndUpdate();
                                    item.PrintAll();
                                }
                                for (int i = 0; i < 100; i++)
                                    Console.Write("=");
                                break;
                            }

                        //Move Origin
                        case 5:
                            {
                                float dx, dy, dz;
                                Console.Write("Enter dx:"); dx = Convert.ToSingle(Console.ReadLine());
                                Console.Write("Enter dy:"); dy = Convert.ToSingle(Console.ReadLine());
                                Console.Write("Enter dz:"); dz = Convert.ToSingle(Console.ReadLine());
                                foreach (var item in LL)
                                {
                                    if (item != null)
                                        item.MoveOrigin(dx, dy, dz);
                                    item.PrintAll();
                                }
                                for (int i = 0; i < 100; i++)
                                    Console.Write("=");
                                break;
                            }

                        //Find Within Distance
                        case 6:
                            {
                                Console.Write("Enter the distance within origin: "); dist = Convert.ToSingle(Console.ReadLine());
                                if (dist > 0)
                                {
                                    foreach (var item in LL)
                                    {
                                        item.FindWithinDistance(dist);
                                    }
                                    for (int i = 0; i < 100; i++)
                                        Console.Write("=");
                                }
                                else if(dist<0)
                                {
                                    Console.WriteLine("ERROR!! Negative value for distance!");
                                }
                                break;
                            }

                        //Randomize the List 
                        case 7:
                            {  Random random = new Random(LL.Count);
                               List <MobileObject> Random_array = new List<MobileObject> (LL.Count);

                                //Adding elements into the new List Random_array from LL in a random order
                                Random_array = LL.OrderBy(x => random.Next(LL.Count)).ToList();
                                foreach(var item in Random_array)
                                {
                                    item.PrintAll();
                                }
                                for (int i = 0; i < 100; i++)
                                    Console.Write("=");
                                break;
                            }

                        //Printing all Existing Cats&Snakes in LL
                        case 8:
                            {
                                Console.WriteLine("\nList of Existing MobileObjects: ");
                                foreach (var item in LL)
                                {
                                    item.PrintAll();
                                }
                                for (int i = 0; i < 100; i++)
                                    Console.Write("=");
                                break;
                            }

                        //Printing number of  MobileObjects in each Cell ID and printing if there is 1 or more 
                        case 9:
                            {
                                double size = Math.Sqrt(Grid.cell_array.Length - 1);
                                int n;
                              for (int x=0;x<size;x++)
                              {
                                    for(int y=0;y< size;y++)
                                    {
                                        double a = (x*10)+y;
                                        n = Grid.cell_array[x, y].CellIDs.Count;
                                        Console.Write("\nMobileObjects in CellID " + a + ": " + n + "\t");
                                    }
                                }Console.WriteLine();
                                for (int i = 0; i < 100; i++)
                                    Console.Write("=");
                                break;
                            }

                        //Printing the size x size grid and a List of all MobileObjects sorted by their z-value in each CellID 
                        case 10:
                            {
                                List<MobileObject> SortbyZ = new List<MobileObject>();
                                double limit = Math.Sqrt(Grid.cell_array.Length - 1);
                                Console.WriteLine("\n"+grid_size+"x"+grid_size+" Grid:");
                                for(int i=0;i<limit; i++)
                                {
                                    for(int j=0;j<limit;j++)
                                    {
                                        Grid.cell_array[i, j].PrintXY();
                                    }
                                }Console.WriteLine("\n\n");
                                //copying all MobileObjects from LL to SortbyZ
                                foreach (var item in LL)
                                {
                                   SortbyZ.Add(item);
                                }
                                //adding elements into the List SortbyZ from LL sorted by their object's z-value
                                SortbyZ = LL.OrderBy(mo => mo.UpdateZ()).ToList();
                                Console.WriteLine("List of all MobileObjects sorted by their z-value");
                                foreach (var item in SortbyZ)
                                {
                                    item.PrintAll();
                                }
                                   
                                for (int i = 0; i < 100; i++)
                                    Console.Write("=");
                                break;
                            }
                        //invalid option for any other number other than the mentioned options
                        default:
                            {
                                Console.WriteLine("ERROR!! Invalid Option!");
                                break;
                            }
                    }
                }
            } while (option != 0);
        }
    }
}
