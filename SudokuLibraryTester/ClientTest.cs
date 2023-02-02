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
            Client client = new Client(4);
            Assert.That(client.PotentialSolvedGrids, Has.Count.EqualTo(288));
        }
    }
}
