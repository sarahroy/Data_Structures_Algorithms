using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    public class Cell
    {
        public int CellID { get; set; }
        public int x, y;
        public float width = 10, height = 10;
        public int[] pos = new int[3];
        Position CellPosition;
        public List<MobileObject> CellIDs;

        /// <summary>
        /// Cell constructor that calculated the position of the cell and calls GetCellID() to set a calculate cell ID
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="size"></param>
        public Cell(int row, int col, int size)
        {
            x = row*10;
            y = col*10;
            GetCellID(row, col);
            CellPosition = new Position(row, col, size);
            CellIDs = new List<MobileObject>(); 
        }
        /// <summary>
        /// GetCellID() calculates the cell Id according to the row and column
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        public void GetCellID(int row, int col)
        {
            CellID = row * Grid.maxSize + col;
        }

        /// <summary>
        /// Prints the cell position coordinates (x,y)
        /// </summary>
        public void PrintXY()
        {
            Console.Write("(" + this.x + "," + this.y + ") ");   
        }

    }
}
