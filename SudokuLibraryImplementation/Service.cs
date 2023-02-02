using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuLibrary1
{
    public static class Service
    {
        public static bool IsPefectSquare(int value)
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

        public static bool IsValidEntry(int value, Grid entryGrid, int rowIndex, int columnIndex)
        {
            Column column = new Column(entryGrid, columnIndex);
            Row row = new Row(entryGrid, rowIndex);
            Square square = new Square(entryGrid, columnIndex, rowIndex);
            return value == 0 || !(column.Entries.Contains(value) ||
                row.Entries.Contains(value) || square.Entries.Contains(value));
        }

        public static void ValidateColumnIndex(Grid entryGrid, int columnIndex)
        {
            if (columnIndex < 0 || columnIndex >= entryGrid.Length)
            {
                throw new ArgumentOutOfRangeException("Column Index", "This position isn't in the grid.");
            }
        }

        public static void ValidateRowIndex(Grid entryGrid, int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= entryGrid.Length)
            {
                throw new ArgumentOutOfRangeException("Row Index", "This position isn't in the Grid.");
            }
        }
    }
}
