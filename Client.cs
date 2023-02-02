using System;
using System.Collections.Generic;
namespace SudokuLibrary1
{
    public class Client
    {
        private ICollection<Grid> grids;
        private readonly int length;
        public Client(int n) 
        {
            if (n < 4)
            {
                throw new ArgumentException("The sudoku puzzle must be at least 4x4.");
            }
            if (!Service.IsPefectSquare(n))
            {
                throw new ArgumentException("The sudoku puzzle must be a perfect square.");
            }
            length = n;
        }

        public ICollection<Grid> PotentialSolvedGrids
        {
            get
            {
                grids = new SortedSet<Grid>(new GridComparer());
                FindPotential(new Grid(length), 0, 0);
                return grids;
            }
        }

        private void FindPotential(Grid current, int r, int c)
        {
            if (c >= current.Length)
            {
                FindPotential(current, r + 1, 0);
            }
            else if (r >= current.Length)
            {
                grids.Add(current.Copy());
            }
            else
            {
                for (int value = 1; value <= current.Length; value++)
                {
                    if (Service.IsValidEntry(value, current, r, c))
                    {
                        current[r, c] = value;
                        FindPotential(current, r, c + 1);
                    }
                    current[r, c] = 0;
                }
            }
        }
    }
}