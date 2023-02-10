using System;
using System.Collections.Generic;
namespace SudokuLibrary1
{
    public class Client
    {
        private readonly Grid current;
        private readonly ICollection<Grid> grids;
        public Client(int n) 
        {
            ValidateLength(n);
            current = new Grid(n);
            grids = new SortedSet<Grid>(new GridComparer());
            FindPotential(current, 0, 0);
        }

        public Client(int[,] entryGrid)
        {
            if (entryGrid == null) 
            {
                throw new ArgumentNullException("Entry Grid" ,"This grid doesn't exist.");
            }
            else if (entryGrid.GetLength(0) != entryGrid.GetLength(1)) 
            {
                throw new ArgumentException("The entry grid isn't square.");
            }
            int n = entryGrid.GetLength(0);
            ValidateLength(n);
            current = new Grid(entryGrid);
            grids = new SortedSet<Grid>(new GridComparer());
            FindPotential(current, 0, 0);
        }

        public void PrintGrid()
        {
            if (grids.Count != 1)
            {
                throw new NotSupportedException("A partially filled sudoku must result in exactly one solvable grid.");
            }
            IEnumerator<Grid> gridEnum = grids.GetEnumerator();
            gridEnum.MoveNext();
            Grid grid = gridEnum.Current;
            for (int r = 0; r < grid.Length; r++)
            {
                string line = "";
                for (int c = 0; c < grid.Length; c++)
                {
                    line += grid[r, c] + " ";
                }
                Console.WriteLine(line);
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
            else if (current[r,c] == 0)
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
            else
            {
                FindPotential(current, r, c + 1);
            }
        }

        private void ValidateLength(int n)
        {
            if (n < 4)
            {
                throw new ArgumentException("The sudoku puzzle must be at least 4x4.");
            }
            if (!Service.IsPefectSquare(n))
            {
                throw new ArgumentException("The sudoku puzzle must be a perfect square.");
            }
        }
    }
}