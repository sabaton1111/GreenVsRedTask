using System;
using System.Collections.Generic;
using System.Text;

namespace GreenVsRed
{
    public class Game : Grid
    {
        #region Data members
        private int xCoordinate;
        private int yCoordinate;
        private int numGenerations;
        #endregion

        #region Properties
        public int NumGenerations
        {
            get
            {
                return numGenerations;
            }
            set
            {
                //Number of generations cannot be negative number
                if (value >= 0)
                {
                    numGenerations = value;
                }
                else
                {
                    numGenerations = 0;
                }
            }
        }
        public int XCoordinate
        {
            get
            {
                return xCoordinate;
            }
            set
            {
                //Validation
                if (value < Width && value >= 0)
                {
                    xCoordinate = value;
                }
                else
                {
                    throw new ArgumentException("Coordinate not specified correctly");
                }
            }
        }
        public int YCoordinate
        {
            get
            {
                return yCoordinate;
            }
            set
            {
                //Validation
                if (value < Height && value >= 0)
                {
                    yCoordinate = value;
                }
                else
                {
                    throw new ArgumentException("Coordinate not specified correctly");
                }
            }
        }
        #endregion

        #region Constructors

        //Constructor with parameters
        public Game(int width, int height, int xCoordinate, int yCoordinate, int numGenerations) : base(width, height)
        {
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
            NumGenerations = numGenerations;
        }

        //Default constructor
        public Game() : this(1,1,0,0,0){ }
        #endregion

        public void Generation()
        {
            int greenNum = 0; //Number of green neighbours

            //Copy of field matrix with added borders
            int[,] tmp = new int[Height + 2, Width + 2];

            for (int i = 0; i < Height + 2; i++)
            {
                for (int j = 0; j < Width + 2; j++)
                {
                    if (i == 0 || j == 0 || i == Width + 1 || j == Height + 1) //Border
                    {
                        tmp[i, j] = 2; 
                    }
                    else
                    {
                        tmp[i, j] = field[i - 1, j - 1];
                    }
                }
            }

            for (int i = 1; i < Width + 1; i++)
            {
                for (int j = 1; j < Height + 1; j++)
                {
                    #region Neighbours

                    //Checking if neighbours are green
                    if (tmp[i - 1, j - 1] == GREEN)
                    {
                        greenNum++;
                    }
                    if (tmp[i - 1, j] == GREEN)
                    {
                        greenNum++;
                    }
                    if (tmp[i - 1, j + 1] == GREEN)
                    {
                        greenNum++;
                    }
                    if (tmp[i, j - 1] == GREEN)
                    {
                        greenNum++;
                    }
                    if (tmp[i, j + 1] == GREEN)
                    {
                        greenNum++;
                    }
                    if (tmp[i + 1, j - 1] == GREEN)
                    {
                        greenNum++;
                    }
                    if (tmp[i + 1, j] == GREEN)
                    {
                        greenNum++;
                    }
                    if (tmp[i + 1, j + 1] == GREEN)
                    {
                        greenNum++;
                    } 
                    #endregion

                    if (tmp[i, j] == GREEN)
                    {
                        if (greenNum == 0 || greenNum == 1 || greenNum == 4 || greenNum == 5 || greenNum == 7 
                            || greenNum == 8)
                        {
                            field[i - 1, j - 1] = RED;
                        }
                    }
                    else
                    {
                        if (greenNum == 3 || greenNum == 6)
                        {
                            field[i - 1, j - 1] = GREEN;
                        }
                    }

                    greenNum = 0;
                }
            }
        }
        public int NGenerations()
        {
            int counter = 0;
            for (int i = 0; i < NumGenerations; i++)
            {
                Generation();

                if (field[XCoordinate, YCoordinate] == GREEN)
                {
                    counter++;
                }
            }
            return counter;
        }

    }
}
