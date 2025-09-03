using CalculatorAssignment;

namespace UnitTestCalculator
{
    public class UnitTestCalc
    {
        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(0, 4, 4)]
        [InlineData(-1, -1, -2)]
        [InlineData(3, -4, -1)]
        [InlineData(0, double.MaxValue, double.MaxValue)]
        [InlineData(double.MaxValue, double.MaxValue, double.PositiveInfinity)]
        [InlineData(double.NaN, double.NaN, double.NaN)]
        public void Calculator_AddsCorrectly(double a, double b, double expected)
        {
            //Arrange
            var calculator = new Calculator();

            //Act
            double result = calculator.Add(a, b);

            //Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(4, 3, 1)]
        [InlineData(-4, 3, -7)]
        [InlineData(0, 3, -3)]
        [InlineData(3, 0, 3)]
        [InlineData(0, double.MaxValue, double.MinValue)]
        [InlineData(double.MinValue, double.MaxValue, double.NegativeInfinity)]
        public void Calculator_SubtractsCorrectly(double a, double b, double expected)
        {
            //Arrange
            var calculator = new Calculator();

            //Act
            double result = calculator.Subtract(a, b);

            //Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(2, 4, 0.5)]
        [InlineData(30, 5, 6)]
        [InlineData(25, -5, -5)]
        public void Calculator_DividesCorrectly(double a, double b, double expected)
        {
            //Arrange
            var calculator = new Calculator();

            //Act
            double result = calculator.Divide(a, b);

            //Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(4, 0)]
        public void Calculator_Throws_Error_If_Divided_By_Zero(double a, double b)
        {
            //Arrange
            var calculator = new Calculator();

            //Act & Assert
            var result = Assert.Throws<ArgumentException>(
                () => calculator.Divide(a, b));
        }


    }
}