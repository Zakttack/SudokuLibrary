using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuLibrary1
{
    public class Square
    {
        private readonly ICollection<int> entries;

        public Square(Grid entryGrid, int columnIndex, int rowIndex) 
        {
            Service.ValidateColumnIndex(entryGrid, columnIndex);
            Service.ValidateRowIndex(entryGrid, rowIndex);
            entries = new List<int>();
            BuildSubSquare(entryGrid, columnIndex, rowIndex);
        }

        private void BuildSubSquare(Grid entryGrid, int columnIndex, int rowIndex)
        {
            int squareLength = (int)Math.Sqrt(entryGrid.Length);
            int columnStart = columnIndex - (columnIndex % squareLength);
            int rowStart = rowIndex - (rowIndex % squareLength);

            for (int r = rowStart; r < rowStart + squareLength; r++) 
            {
                for (int c = columnStart; c < columnStart + squareLength; c++)
                {
                    entries.Add(entryGrid[r,c]);
                }
            }
        }

        public ICollection<int> Entries
        {
            get
            {
                return entries;
            }
        }
    }
}
