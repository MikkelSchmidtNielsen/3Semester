using Moq;
using MoqExamples;
using MoqExamples.Interfaces;

namespace UnitTestMoqAssignment
{
    public class UnitTestPaymentProcessor
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void ExternalService_Returns_New_String_On_Each_Call(int id)
        {
            // Arrange
            string[] results = new string[3];

            Mock<IPaymentService> paymentServiceMock = new Mock<IPaymentService>();
            paymentServiceMock.SetupSequence(x => x.GetPaymentStatus(It.IsAny<int>()))
                .Returns("Pending")
                .Returns("Processing")
                .Returns("Completed");

            PaymentProcessor paymentProcessor = new PaymentProcessor(paymentServiceMock.Object);
            
            // Act
            results[0] = paymentProcessor.TrackPayment(id);
            results[1] = paymentProcessor.TrackPayment(id);
            results[2] = paymentProcessor.TrackPayment(id);

            // Assert
            Assert.Equal("Pending", results[0]);
            Assert.Equal("Processing", results[1]);
            Assert.Equal("Completed", results[2]);
            paymentServiceMock.VerifyAll();
        }
    }
}
