using SudokuLibraryImplementation;
namespace SudokuLibraryTester
{
    public class ServiceTest
    {

        [Test]
        public void TestPefectSquare()
        {
            int value = 4;
            bool result = Service.IsPefectSquare(value);
            Assert.That(result, Is.True);
        }

        [Test]
        public void TestPefectSquare2() 
        {
            int value = 5;
            bool result = Service.IsPefectSquare(value);
            Assert.That(result, Is.False);
        }
    }
}