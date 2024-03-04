using SudokuLibraryImplementation;
using SudokuLibraryImplementation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuLibraryTester
{
    public class ClientTest
    {
        [Test]
        public void TestPotentialSolvedGrids()
        {
            Client client = new(4);
            IReadOnlyCollection<Grid> grids = client.ToList();
            Assert.That(grids, Has.Count.EqualTo(288));
        }
    }
}
