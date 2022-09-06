namespace SudokuLibrary1
{
    public class Row
    {
        private readonly int[] values;

        public Row()
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
                    throw new ArgumentException("The Number is already in the row!!!");
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