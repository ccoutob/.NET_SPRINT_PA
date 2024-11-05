using System.Threading.Tasks;

public class ClientsControllerTests
{
    [Fact]
    public async Task Register_ShouldReturnOk_WhenClientIsValid()
    {
        // Arrange
        var client = new Client { Name = "Cauã", Sobrenome = "Couto", Email = "couto@gmail.com", Idade = 19 };
        var mockService = new Mock<IClientService>();
        mockService.Setup(s => s.RegisterUser(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), iterator.IsAny<int>())
       .Returns(Task.CompletedTask);
        var controller = new ClientsController(mockService.Object);

        // Act
        var result = await controller.Register(client);

        // Assert
        Assert.IsType<OkResult>(result);
    }
}