using SudokuLibraryImplementation.Models;
using System.Collections;

namespace SudokuLibraryImplementation
{
    public class GridEnumerator : IEnumerator<Grid>
    {
        private Stack<Grid> gridsStack;
        private readonly int length;
        private Grid current;

        public GridEnumerator(int n)
        {
            length = n;
            Reset();
        }

        public Grid Current
        {
            get
            {
                return current;
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return current;
            }
        }

        public void Dispose()
        {
            gridsStack = null;
            current = null;
        }

        public bool MoveNext()
        {
            while (gridsStack.TryPop(out Grid temp))
            {
                GridLocation loc = temp.EmptySlot;
                if (loc is null)
                {
                    current = temp;
                    return true;
                }
                for (int x = length; x >= 1; x--)
                {
                    if (Service.IsValidEntry(x, temp, loc.RowIndex, loc.ColumnIndex))
                    {
                        Grid other = temp.Copy();
                        other[loc.RowIndex, loc.ColumnIndex] = x;
                        gridsStack.Push(other);
                    }
                }
            }
            return false;
        }

        public void Reset()
        {
            gridsStack = new();
            gridsStack.Push(new(length));
        }
    }
}