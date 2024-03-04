namespace SudokuLibraryImplementation.Models
{
    public class GridLocation
    {
        public GridLocation(int r, int c)
            {
                RowIndex = r;
                ColumnIndex = c;
            }
            public int RowIndex
            {
                get;
            }

            public int ColumnIndex
            {
                get;
            }
    }
}