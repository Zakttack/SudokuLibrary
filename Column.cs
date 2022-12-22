using System;
using System.Collections;
using System.Collections.Generic;

namespace SudokuLibrary1
{
    public class Column : IEnumerable<Entry>
    {
        private readonly Grid myGrid;
        private readonly int columnIndex;

        public Column(Grid grid, int columnId)
        {
            myGrid = grid;
            columnIndex = columnId;
        }

        public IEnumerator<Entry> GetEnumerator()
        {
            return new ColumnEntryEnumerator(myGrid.SudokuGrid, columnIndex);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class ColumnEntryEnumerator : IEnumerator<Entry>
        {
            private Entry[,] sudokuGrid;

            private int columnIndex;
            private int rowIndex;
            public ColumnEntryEnumerator(Entry[,] sudokuGrid, int columnIndex)
            {
                this.sudokuGrid = sudokuGrid;
                this.columnIndex = columnIndex;
                rowIndex = 0;
            }

            public Entry Current
            {
                get
                {
                    return sudokuGrid[rowIndex,columnIndex];
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
                return rowIndex < sudokuGrid.GetLength(0) && sudokuGrid[rowIndex,columnIndex].Value > 0;
            }

            public void Reset()
            {
                rowIndex = 0;
            }
        }
    }
}
