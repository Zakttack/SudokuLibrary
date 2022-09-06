using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuLibrary1
{
    public class Column
    {
        private readonly int[] values;

        public Column()
        {
            values = new int[9];
        }

        public int this[int index]
        {
            get
            {
                if (index < 0 || index >= values.Length)
                {
                    throw new ArgumentOutOfRangeException("location", "This location isn't part of the Sudoku Puzzle!!!");
                }
                return values[index];
            }
            set
            {
                if (index < 0 || index >= values.Length)
                {
                    throw new ArgumentOutOfRangeException("location", "This location isn't part of the Sudoku Puzzle!!!");
                }
                else if (Contains(value))
                {
                    throw new ArgumentException("The Number is already in the column!!!");
                }
                values[index] = value;
            }
        }

        private bool Contains(int value)
        {
            foreach (int i in values)
            {
                if (i == value)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
