using Moq;
using moq_examples.Interfaces;

namespace UnitTestMoqAssignment
{
    public class UnitTestCalculator
    {
        [Theory]
        [InlineData(5, 5, 25)]
        [InlineData(-5, 5, -25)]
        public void Calculator_Multiplies_Correctly(int x, int y, int expected)
        {
            // Arrange
            var calculatorMock = new Mock<ICalculatorService>();
            calculatorMock.Setup(calc => calc.Multiply(x, y)).Returns(expected);

            // Act
            int result = calculatorMock.Object.Multiply(x, y);

            // Assert
            Assert.Equal(expected, result);
        }


    }
}