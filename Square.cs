using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuLibrary1
{
    public class Square : IEnumerable<Entry>
    {
        private readonly Grid myGrid;
        private int columnIndex;
        private int rowIndex;

        public Square(Grid grid, int columnStartIndex, int rowStartIndex)
        {
            myGrid = grid;
            columnIndex = columnStartIndex;
            rowIndex = columnStartIndex;
        }

        public IEnumerator<Entry> GetEnumerator()
        {
            return new SquareEntryEnumerator(myGrid.SudokuGrid, myGrid.SquareLength, columnIndex, rowIndex);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class SquareEntryEnumerator : IEnumerator<Entry>
        {
            private readonly Entry[,] entries;
            private readonly int squareLength;
            private int columnIndex;
            private int rowIndex;
            private readonly int columnStartIndex;

            private readonly int rowStartIndex;

            public SquareEntryEnumerator(Entry[,] entries, int squareLength, int columnIndex, int rowIndex)
            {
                this.entries = entries;
                this.squareLength = squareLength;
                columnStartIndex = columnIndex;
                rowStartIndex = rowIndex;
                Reset();
            }

            public Entry Current
            {
                get
                {
                    return entries[rowIndex,columnIndex];
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
                if (columnIndex < columnStartIndex + squareLength)
                {
                    columnIndex++;
                }
                else
                {
                    columnIndex = columnStartIndex;
                    rowIndex++;
                }
            }

            public bool MoveNext()
            {
                return columnIndex < columnStartIndex + squareLength && 
                    rowIndex < rowStartIndex + squareLength && entries[rowIndex,columnIndex].Value > 0;
            }

            public void Reset()
            {
                columnIndex = columnStartIndex;
                rowIndex = rowStartIndex;
            }
        }
    }
}
