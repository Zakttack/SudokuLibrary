namespace SudokuLibraryImplementation.Models
{
    public class Row
    {
        private readonly ICollection<int> entries;

        public Row(Grid entryGrid, int rowIndex) 
        {
            Service.ValidateRowIndex(entryGrid, rowIndex);
            entries = new List<int>();
            for (int c = 0; c < entryGrid.Length; c++) 
            {
                entries.Add(entryGrid[rowIndex, c]);
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