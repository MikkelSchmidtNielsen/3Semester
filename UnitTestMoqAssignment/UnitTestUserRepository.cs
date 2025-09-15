using Moq;
using MoqExamples.Interfaces;

namespace UnitTestMoqAssignment
{
    public class UnitTestUserRepository
    {
        [Theory]
        [InlineData(1, "Admin")]
        [InlineData(2, "User")]
        public void GetUserRole_Returns_Correct_Role(int index, string role)
        {
            // Arrange
            var userRepoMock = new Mock<IUserRepository>();
            userRepoMock.Setup(repo => repo.GetUserRole(index)).Returns(role);

            // Act
            var userRole = userRepoMock.Object.GetUserRole(index);

            // Assert
            Assert.Equal(role, userRole);
        }
    }
}
