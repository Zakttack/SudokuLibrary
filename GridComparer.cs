using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuLibrary1
{
    public class GridComparer : IComparer<Grid>
    {
        public int Compare(Grid x, Grid y)
        {
            for (int r = 0; r < x.Length; r++)
            {
                for (int c = 0; c < y.Length; c++)
                {
                    if (x[r, c] < y[r, c])
                    {
                        return -1;
                    }
                    else if (x[r, c] > y[r, c])
                    {
                        return 1;
                    }
                }
            }
            return 0;
        }
    }
}
