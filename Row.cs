using System.Collections;
using System.Collections.Generic;
namespace SudokuLibrary1
{
    public class Row : IEnumerable<Entry>
    {
        private Grid myGrid;

        private int rowIndex;

        public Row(Grid grid, int rowIndex)
        {
            myGrid = grid;
            this.rowIndex = rowIndex;
        }

        public IEnumerator<Entry> GetEnumerator()
        {
            return new RowEntryEnumerator(myGrid.SudokuGrid, rowIndex);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class RowEntryEnumerator : IEnumerator<Entry>
        {
            private readonly Entry[,] entries;
            private int columnIndex;
            private readonly int rowIndex;

            public RowEntryEnumerator(Entry[,] entries, int rowIndex)
            {
                this.entries = entries;
                columnIndex = 0;
                this.rowIndex = rowIndex;
            }

            public Entry Current
            {
                get
                {
                    return entries[rowIndex, columnIndex];
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
                return columnIndex < entries.GetLength(1) && entries[rowIndex,columnIndex].Value > 0;
            }

            public void Reset()
            {
                columnIndex = 0;
            }
        }
    }
}