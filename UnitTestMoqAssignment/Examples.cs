using Moq;
using moq_examples.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestMoqAssignment
{
    public class Examples
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            var mockCalculator = new Mock<ICalculatorService>();
            mockCalculator.Setup(service => service.Add(2, 4)).Returns(6);

            // Act
            int result = mockCalculator.Object.Add(2, 4);

            // Assert
            Assert.Equal(6, result);
        }

        [Fact]
        public void Test2()
        {
            // Arrange
            var mockCalculator = new Mock<ICalculatorService>();
            mockCalculator.Setup(x => x.Add(2, 4)).Verifiable();

            // Act & Assert
            mockCalculator.Verify(x => x.Add(2, 4), Times.Exactly(0));
        }
    }
}
