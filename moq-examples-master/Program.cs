// See https://aka.ms/new-console-template for more information
using System;
using Moq;
using moq_examples;


// Define a
        Console.WriteLine("### Moq Examples ###\n");

        Example1_BasicMocking();
        Example2_MockReturnValues();
        Example3_MockWithParameters();
  

    // Example 1: Mocking a Simple Method
    void Example1_BasicMocking()
    {
        Console.WriteLine("Example 1: Basic Mocking");

        var mock = new Mock<ICalculatorService>();
        mock.Setup(service => service.Add(2, 3)).Returns(5);

        int result = mock.Object.Add(2, 3);
        Console.WriteLine($"2 + 3 = {result} (Mocked)");

        Console.WriteLine();
    }

    // Example 2: Mocking a Repository with Return Values
    void Example2_MockReturnValues()
    {
        Console.WriteLine("Example 2: Mocking Return Values");

        var mock = new Mock<IUserRepository>();
        mock.Setup(repo => repo.GetUserRole(1)).Returns("Admin");
        mock.Setup(repo => repo.GetUserRole(2)).Returns("User");

        Console.WriteLine($"User 1 Role: {mock.Object.GetUserRole(1)}");
        Console.WriteLine($"User 2 Role: {mock.Object.GetUserRole(2)}");

        Console.WriteLine();
    }

    // Example 3: Mocking a Method with Parameters and Verifying Calls
    void Example3_MockWithParameters()
    {
        Console.WriteLine("Example 3: Mocking with Parameters and Verification");

        var mock = new Mock<ILogger>();
        mock.Setup(logger => logger.LogMessage(It.IsAny<string>()));

        mock.Object.LogMessage("Test Message");
        mock.Object.LogMessage("Another Message");

        // Verify that LogMessage was called exactly twice
        mock.Verify(logger => logger.LogMessage(It.IsAny<string>()), Times.Exactly(2));

        Console.WriteLine("LogMessage was called exactly twice (Verified)");

        Console.WriteLine();
    }

