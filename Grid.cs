using System;
using System.Collections;
using System.Collections.Generic;
namespace SudokuLibrary1
{
    public class Grid : IEquatable<Grid>
    {
        private readonly int[,] sudokuGrid;

        public Grid(int n)
        {
            sudokuGrid = new int[n,n];
            InitFill();

        }

        public int Length
        {
            get
            {
                return sudokuGrid.GetLength(0);
            }
        }

        public int this[int rowIndex, int columnIndex]
        {
            get
            {
                Service.ValidateColumnIndex(this, columnIndex);
                Service.ValidateRowIndex(this, rowIndex);
                return sudokuGrid[rowIndex, columnIndex];
            }
            set
            {
                Service.ValidateColumnIndex(this, columnIndex);
                Service.ValidateRowIndex(this, rowIndex);
                sudokuGrid[rowIndex, columnIndex] = value;
            }
        }

        public Grid Copy()
        {
            Grid copy = new Grid(Length);
            for (int r = 0; r < Length; r++) 
            {
                for (int c = 0; c < Length; c++)
                {
                    copy[r,c] = this[r, c];
                }
            }
            return copy;
        }
        public bool Equals(Grid other) 
        {
            if (Length != other.Length)
            {
                return false;
            }
            for (int r = 0; r < Length; r++) 
            {
                for (int c = 0; c < Length; c++) 
                {
                    if (this[r,c] != other[r,c])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public override bool Equals(object obj)
        {
            if (obj is not Grid)
            {
                return false;
            }
            return Equals((Grid)obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public static bool operator== (Grid gridA, Grid gridB)
        {
            return gridA.Equals(gridB);
        }

        public static bool operator!= (Grid gridA, Grid gridB)
        {
            return !gridA.Equals(gridB);
        }

        private void InitFill()
        {
            for (int r = 0; r < sudokuGrid.GetLength(0); r++)
            {
                for (int c = 0; c < sudokuGrid.GetLength(1); c++)
                {
                    sudokuGrid[r, c] = 0;
                }
            }
        }
    }
}