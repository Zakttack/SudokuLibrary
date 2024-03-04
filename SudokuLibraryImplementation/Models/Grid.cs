namespace SudokuLibraryImplementation.Models
{
    public class Grid : IComparable<Grid>, IEquatable<Grid>
    {
        private readonly int[,] sudokuGrid;

        public Grid(int n)
        {
            sudokuGrid = new int[n,n];
            InitFill();
        }

        public Grid(int[,] sudokuGrid)
        {
            this.sudokuGrid = sudokuGrid;
        }

        public GridLocation EmptySlot
        {
            get
            {
                int r = 0;
                int c = 0;
                while (r < Length && this[r,c] != 0)
                {
                    int currentC = c;
                    if (currentC == Length - 1)
                    {
                        r++;
                    }
                    c = (currentC + 1) % Length;
                }
                return r == Length ? null : new(r,c);
            }
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

        public int CompareTo(Grid other)
        {
            if (other is null)
            {
                return 1;
            }
            else if (Length < other.Length)
            {
                return -1;
            }
            else if (Length > other.Length)
            {
                return 1;
            }
            for (int r = 0; r < Length; r++)
            {
                for (int c = 0; c < Length; c++)
                {
                    if (this[r, c] < other[r, c])
                    {
                        return -1;
                    }
                    else if (this[r, c] > other[r, c])
                    {
                        return 1;
                    }
                }
            }
            return 0;
        }

        public Grid Copy()
        {
            Grid copy = new(Length);
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
            return CompareTo(other) == 0;
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
            return HashCode.Combine(sudokuGrid);
        }

        public override string ToString()
        {
            return sudokuGrid.ToString();
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