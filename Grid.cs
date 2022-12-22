using System;
using System.Collections;
using System.Collections.Generic;
namespace SudokuLibrary1
{
    public class Grid
    {
        private readonly Entry[,] sudokuGrid;

        public Grid(int length)
        {
            if (!IsPefectSquare(length))
            {
                throw new ArgumentException("The sudoku puzzle must be a perfect square.");
            }
            sudokuGrid = new Entry[length,length];
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

        private bool IsPefectSquare(int value)
        {
            string num = Math.Sqrt(value).ToString();
            return !num.Contains('.');
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
    }
}