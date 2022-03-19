using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    public class Grid
    {
     
        public static Cell[,] cell_array; //Cell constructor two-dimensional array of size x size
        public static int Cell_ID = 0;
        public static int maxSize; // either 10 or 16
        public double max;

        /// <summary>
        /// Grid constructor makes a 2D Cell array according to the gridsize
        /// </summary>
        /// <param name="size"></param>
        public Grid (int size)
        {
           
            maxSize = size;
            cell_array = new Cell[size, size];
            max = Math.Round(Math.Sqrt(cell_array.Length - 1),0);
           
            for (int x=0; x<max; x++)
            {
                for(int y=0; y<max; y++)
                {
                    cell_array[x, y] = new Cell(x,y,size); 
                }
            }
            for (int i = 0; i < 100; i++)
                Console.Write("=");
            Console.WriteLine();
        }
        
        /// <summary>
        /// static method that takes the position and calculates the cell_ID
        /// </summary>
        /// <param name="pos"></param>
        /// <returns>cell_ID</returns>
        public static int GetCellID(Position pos)
        {
            int x1 = (int)(pos.X / Grid.maxSize);
            int y1 = (int)(pos.Y / Grid.maxSize);

            Cell_ID = x1 * 10 + y1;
            return Cell_ID;
        }

        /// <summary>
        /// Static method that takes the cellID and an array which calculates the objects cell ID
        /// </summary>
        /// <param name="CellID"></param>
        /// <param name="xy"></param>
        /// <returns>xy</returns>
        public static int[] ObjCell(int CellID, int[] xy)
        {
            xy[0] = (CellID / Grid.maxSize) * Grid.maxSize;
            xy[1]= (CellID % Grid.maxSize) * Grid.maxSize;
            return xy;
        } 
    }
}
