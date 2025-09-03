using Moq;
using moq_examples;
using moq_examples.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestMoqAssignment
{
    public class UnitTestAccountManager
    {
        [Theory]
        [InlineData(1, 500, 500)]
        [InlineData(1, 750, 300)]
        public void CanWithdraw_Returns_True(int id, decimal balance, decimal withdrawal)
        {
            // Arrange
            Mock<IBankService> bankServiceMock = new Mock<IBankService>();
            bankServiceMock.Setup(x => x.GetBalance(id)).Returns(balance);

            AccountManager accountManager = new AccountManager(bankServiceMock.Object);

            // Act
            bool canWithdraw = accountManager.CanWithdraw(id, withdrawal);

            // Assert
            Assert.True(canWithdraw);
        }

        [Theory]
        [InlineData(1, 500, 600)]
        [InlineData(1, 400, 1000)]
        public void CanWithdraw_Throws_Exception(int id, decimal balance, decimal withdrawal)
        {
            // Arrange
            Mock<IBankService> bankServiceMock = new Mock<IBankService>();
            bankServiceMock.Setup(x => x.GetBalance(1)).Returns(balance);

            AccountManager accountManager = new AccountManager(bankServiceMock.Object);

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => accountManager.CanWithdraw(id, withdrawal));
        }
    }
}
