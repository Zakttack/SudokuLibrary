using SudokuLibraryImplementation.Models;
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
