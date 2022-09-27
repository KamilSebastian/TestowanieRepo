namespace Szkoleniev2.test
{
    public class StringCalculatorTests
    {
        [TestCase("1,2,3\n4\n5",15)]
        [TestCase("//[***][$$]\n1***2$$5\n1",9)]
        [TestCase("0",0)]
        [TestCase("1",1)]
        [TestCase("1,2",3)]
        [TestCase("1,2,3,1001",6)]
        [TestCase("",0)]
        [Test]
        public void ShouldAddAllNumbersFromString(string numbers,int result)
        {
            StringCalculator stringCalculator = new StringCalculator();
            Assert.That(stringCalculator.Add(numbers), Is.EqualTo(result));
        }
        [TestCase("-1,-2,-3", "[-1,-2,-3]")]
        [TestCase("-9,-10,-15", "[-9,-10,-15]")]
        [Test]
        public void ShouldThrowExceptionForNegativeNumbers(string numbers,string message)
        {
            StringCalculator stringCalculator = new StringCalculator();
            Assert.That(() => stringCalculator.Add(numbers), Throws.TypeOf<Exception>()
                         .With
                         .Message
                         .EqualTo($"Negatives not allowed. {message}"));
        }
    }
}