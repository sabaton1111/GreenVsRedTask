using System;
using System.Collections.Generic;
using System.Text;

namespace GreenVsRed
{
    public class Grid
    {
        #region Data members
        private const int MIN_VALUE = 1;
        private const int MAX_VALUE = 1000;
        protected const int RED = 0;
        protected const int GREEN = 1;

        private int width; // width of field
        private int height; // height of field

        protected int[,] field;
        #endregion

        #region Properties
        public int Width
        {
            get
            {
                return width;
            }
            set
            {
                if (value >= MIN_VALUE && value < MAX_VALUE)
                {
                    width = value;
                }
                else
                {
                    throw new ArgumentException(String.Format("X value not specified correctly!"));
                }
            }
        }
        public int Height
        {
            get { return height; }
            set
            {
                if (value >= MIN_VALUE && value < MAX_VALUE && Width <= value)
                {
                    height = value;
                }
                else
                {
                    throw new ArgumentException(String.Format("Y value is out of range!"));
                }
            }
        }
        #endregion

        #region Constructors
        //Constructor with parameters
        public Grid(int width, int height)
        {
            Width = width;
            Height = height;
            field = new int[height, width];
        }

        //Default constructor
        public Grid() : this(1, 1) { } 
        #endregion

        public void ReadRows(Queue<string> rows)
        {
            int countLine = 0;
            while (rows.Count != 0)
            {
                string row = rows.Peek();
                if (!ValidateRow(row))
                {
                    Console.WriteLine("Ïncorrect input! Rows should contain only '0' and '1'!");
                    System.Environment.Exit(0);
                }
                for (int j = 0; j < Width; j++)
                {
                    int digit = int.Parse(row[j].ToString());
                    field[countLine, j] = digit;
                }
                countLine++;
                rows.Dequeue();
            }
        }

        //Validating row string
        public bool ValidateRow(string row)
        {
            if (row.Length != Width)
            {
                return false;
            }
            for (int i = 0; i < Width; i++)
            {
                //Checking for illegal character
                try
                {
                    int digit = int.Parse(row[i].ToString());
                    if (digit != RED && digit != GREEN)
                    {
                        return false;
                    }
                }
                catch
                {
                    return false;
                }
            }
            return true;
        } 
        public void PrintGrid()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Console.Write("{0} ", field[i, j]);
                }
                Console.WriteLine("");
            }
        }
    }
}
