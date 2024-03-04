using SudokuLibraryImplementation.Models;
using System.Collections;
namespace SudokuLibraryImplementation
{
    public class Client : IEnumerable<Grid>
    {
        public Client(int n)
        {
            ValidateLength(n);
            Length = n;
        }

        public int Length
        {
            get;
        }

        public IEnumerator<Grid> GetEnumerator()
        {
            return new GridEnumerator(Length);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new GridEnumerator(Length);
        }

        public Grid Solve(Grid current)
        {
            if (current is null)
            {
                throw new ArgumentNullException("Grid To Solve", "The Grid doesn't exist");
            }
            ValidateLength(current.Length);
            ICollection<Grid> grids = new List<Grid>();
            Stack<Grid> gridsStack = new();
            gridsStack.Push(current);
            while (gridsStack.TryPop(out Grid temp) && grids.Count < 3)
            {
                GridLocation loc = temp.EmptySlot;
                if (loc is null)
                {
                    grids.Add(temp);
                }
                else
                {
                    for (int x = Length; x >= 1; x--)
                    {
                        if (Service.IsValidEntry(x, temp, loc.RowIndex, loc.ColumnIndex))
                        {
                            Grid other = temp.Copy();
                            other[loc.RowIndex, loc.ColumnIndex] = x;
                            gridsStack.Push(other);
                        }
                    }
                }
            }
            if (grids.Count != 1)
            {
                throw new InvalidOperationException("A grid must only have 1 solution.");
            }
            return grids.First();
        }

        private static void ValidateLength(int n)
        {
            if (n < 4)
            {
                throw new ArgumentOutOfRangeException("Grid dimension","The sudoku puzzle must be at least 4x4.");
            }
            if (!Service.IsPefectSquare(n))
            {
                throw new ArgumentOutOfRangeException("Grid dimension","The sudoku puzzle must be a perfect square.");
            }
        }
    }
}