namespace LegacyApp.Tests;

public class UserServiceTests
{
    [Fact]
    public void AddUserReturnsFalseWhenFirstNameIsEmpty()
    {
        
        // Arrange
        var userService = new UserService();

        // Act
        var result = userService.AddUser(
            null,
            "Kowalski",
            "kowalski@gmail.com",
            DateTime.Parse("2000-02-02"),
            1
        );
        
        /*Action action = () => userService.AddUser(
            null,
            "Kowalski",
            "kowalski@gmail.com",
            DateTime.Parse("2000-02-02"),
            1
        );*/

        // Assert
        Assert.False(result);
        /*Assert.Throws<ArgumentException>(action);*/
    }
}