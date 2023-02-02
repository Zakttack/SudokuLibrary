using System;
using System.Collections;
using System.Collections.Generic;

namespace SudokuLibrary1
{
    public class Column
    {
        private readonly ICollection<int> entries;

        public Column(Grid entryGrid, int columnIndex)
        {
            Service.ValidateColumnIndex(entryGrid, columnIndex);
            entries = new List<int>();
            for (int r = 0; r < entryGrid.Length; r++) 
            {
                entries.Add(entryGrid[r,columnIndex]);
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
