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
            private ISet<int> values;
            private int columnIndex;
            private readonly int rowIndex;

            public RowEntryEnumerator(Entry[,] entries, int rowIndex)
            {
                this.entries = entries;
                values = new HashSet<int>();
                columnIndex = 0;
                this.rowIndex = rowIndex;
            }

            public Entry Current
            {
                get
                {
                    if (!values.Add(entries[rowIndex,columnIndex].Value))
                    {
                        throw new InvalidOperationException("Each row can't have duplicate numbers");
                    }
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
                return columnIndex < entries.GetLength(1);
            }

            public void Reset()
            {
                columnIndex = 0;
            }
        }
    }
}