using Consola;

namespace ConsolaTests
{
    public class CalculatorTest
    {
        [Fact]
        public void Sum()
        {
            var calculator = new Calculator();

            var result = calculator.Sum(2, 3);

            Assert.Equal(5, result);
        }
    }
}