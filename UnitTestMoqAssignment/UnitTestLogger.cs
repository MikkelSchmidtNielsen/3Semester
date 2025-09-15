using Moq;
using MoqExamples;
using MoqExamples.Interfaces;

namespace UnitTestMoqAssignment
{
    public class UnitTestLogger
    {
        // First assignment
        [Theory]
        [InlineData("Hooray")]
        public void LoggerMessage_Is_Called_Exactly_One_Time(string testMessage)
        {
            // Arrange
            Mock<ILogger> loggerMock = new Mock<ILogger>();
            loggerMock.Setup(logger => logger.LogMessage(It.IsAny<string>()));

            // Act
            loggerMock.Object.LogMessage(testMessage);

            // Assert
            loggerMock.Verify(logger => logger.LogMessage(It.IsAny<string>()), Times.Exactly(1));
        }

        // Fourth assignment
        [Theory]
        [InlineData("SurferDude", "This works!", "SurferDude performed This works!")]
        [InlineData("SurferBro", "Nice xUnit!", "SurferBro performed Nice xUnit!")]
        public void LoggerMessage_Logs_Message_When_Called(string username, string message, string expected)
        {
            // Arrange
            List<string> logs = new List<string>();

            Mock<ILogger> loggerMock = new Mock<ILogger>();
            loggerMock.Setup(x => x.LogMessage(expected)).Callback(() => logs.Add(expected));

            UserService userService = new UserService(loggerMock.Object);
            
            // Act
            userService.PerformAction(username, message);

            // Assert
            Assert.Equal(expected, logs[0]);
            loggerMock.Verify(x => x.LogMessage(expected), Times.Once);
        }
    }
}
