using System;
using System.Collections;
using System.Collections.Generic;
namespace SudokuLibrary1
{
    public class Grid
    {
        private readonly Entry[,] sudokuGrid;

        public Grid(int n)
        {
            if (!IsPefectSquare(n))
            {
                throw new ArgumentException("The sudoku puzzle must be a perfect square.");
            }
            sudokuGrid = new Entry[n,n];
            InitFill();
        }

        public int SquareLength
        {
            get
            {
                return (int)Math.Sqrt(sudokuGrid.GetLength(0));
            }
        }

        public Entry[,] SudokuGrid
        {
            get
            {
                return sudokuGrid;
            }
        }

        public IEnumerator<Column> Columns
        {
            get
            {
                return new ColumnEnumerator(this);
            }
        }

        public IEnumerator<Row> Rows
        {
            get
            {
                return new RowEnumerator(this);
            }
        }

        public IEnumerator<Square> Squares
        {
            get
            {
                return new SquareEnumerator(this);
            }
        }

        private void InitFill()
        {
            for (int r = 0; r < sudokuGrid.GetLength(0); r++)
            {
                for (int c = 0; c < sudokuGrid.GetLength(1); c++)
                {
                    sudokuGrid[r,c] = new Entry();
                }
            }
        }

        private bool IsPefectSquare(int value)
        {
            string num = Math.Sqrt(value).ToString();
            int index = num.IndexOf('.');
            if (index < 0)
            {
                return true;
            }
            for (int i = index + 1; i < num.Length; i++)
            {
                if (num[i] != '0')
                {
                    return false;
                }
            }
            return true;
        }

        private class ColumnEnumerator : IEnumerator<Column>
        {
            private readonly Grid grid;
            private int columnIndex;

            public ColumnEnumerator(Grid grid)
            {
                this.grid = grid;
                columnIndex = 0;
            }

            public Column Current
            {
                get
                {
                    return new Column(grid, columnIndex);
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }

            public void Dispose()
            {
                columnIndex++;
            }

            public bool MoveNext()
            {
                return columnIndex < grid.SudokuGrid.GetLength(1);
            }

            public void Reset()
            {
                columnIndex = 0;
            }
        }

        private class RowEnumerator : IEnumerator<Row>
        {
            private readonly Grid grid;
            private int rowIndex;

            public RowEnumerator(Grid grid)
            {
                this.grid = grid;
                rowIndex = 0;
            }

            public Row Current
            {
                get
                {
                    return new Row(grid, rowIndex);
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }

            public void Dispose()
            {
                rowIndex++;
            }

            public bool MoveNext()
            {
                return rowIndex < grid.SudokuGrid.GetLength(0);
            }

            public void Reset()
            {
                rowIndex = 0;
            }
        }

        private class SquareEnumerator : IEnumerator<Square>
        {
            private Grid myGrid;

            private int columnIndex;

            private int rowIndex;

            public SquareEnumerator(Grid grid)
            {
                myGrid = grid;
                columnIndex = 0;
                rowIndex = 0;
            }

            public Square Current
            {
                get
                {
                    return new Square(myGrid, columnIndex, rowIndex);
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }

            public void Dispose()
            {
                if (columnIndex < myGrid.SudokuGrid.GetLength(1))
                {
                    columnIndex += myGrid.SquareLength;
                }
                else
                {
                    columnIndex = 0;
                    rowIndex += myGrid.SquareLength;
                }
            }

            public bool MoveNext()
            {
                return columnIndex < myGrid.SudokuGrid.GetLength(1) &&
                    rowIndex < myGrid.SudokuGrid.GetLength(0);
            }

            public void Reset()
            {
                columnIndex = 0;
                rowIndex = 0;
            }
        }
    }
}