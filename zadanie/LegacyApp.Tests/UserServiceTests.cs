namespace LegacyApp.Tests;

public class UserServiceTests
{
    [Fact]
    public void AddUser_ReturnsFalseWhenFirstNameIsEmpty()
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

        // Assert
        Assert.False(result);
    }
    
    [Fact]
    public void AddUser_ReturnsFalseWhenMissingAtSignAndDotInEmail()
    {
        
        // Arrange
        var userService = new UserService();

        // Act
        var result = userService.AddUser(
            "Andrzej",
            null,
            "kowalski@gmail.com",
            DateTime.Parse("2000-02-02"),
            1
        );

        // Assert
        Assert.False(result);
    }
    
    [Fact]
    public void AddUser_ReturnsFalseWhenEmailDoesntContainCorrectSymbols()
    {
        
        // Arrange
        var userService = new UserService();

        // Act
        var result = userService.AddUser(
            "Andrzej",
            "Kowalski",
            "kowalskigmailcom",
            DateTime.Parse("2000-02-02"),
            1
        );

        // Assert
        Assert.False(result);
    }
    
    [Fact]
    public void AddUser_ReturnsFalseWhenYoungerThen21YearsOld()
    {
        
        // Arrange
        var userService = new UserService();

        // Act
        var result = userService.AddUser(
            "Andrzej",
            "Kowalski",
            "kowalski@gmail.com",
            DateTime.Parse("2010-02-02"),
            1
        );

        // Assert
        Assert.False(result);
    }
    
    [Fact]
    public void AddUser_ReturnsTrueWhenVeryImportantClient()
    {
        
        // Arrange
        var userService = new UserService();

        // Act
        var result = userService.AddUser(
            "Andrzej",
            "Kowalski",
            "kowalski@gmail.com",
            DateTime.Parse("2000-02-02"),
            2
        );

        // Assert
        Assert.True(result);
    }
    
    [Fact]
    public void AddUser_ReturnsTrueWhenImportantClient()
    {
        
        // Arrange
        var userService = new UserService();

        // Act
        var result = userService.AddUser(
            "Andrzej",
            "Kowalski",
            "kowalski@gmail.com",
            DateTime.Parse("2000-02-02"),
            3
        );

        // Assert
        Assert.True(result);
    }
    
    [Fact]
    public void AddUser_ReturnsTrueWhenNormalClient()
    {
        
        // Arrange
        var userService = new UserService();

        // Act
        var result = userService.AddUser(
            "Andrzej",
            "Kwiatkowski",
            "kowalski@gmail.com",
            DateTime.Parse("2000-02-02"),
            5
        );

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AddUser_ReturnsFalseWhenNormalClientWithNoCreditLimit()
    {
         
        // Arrange
        var userService = new UserService();

        // Act
        var result = userService.AddUser(
            "Andrzej",
            "Kowalski",
            "kowalski@gmail.com",
            DateTime.Parse("2010-02-02"),
            1
        );

        // Assert
        Assert.False(result);
    }
    
    [Fact]
    public void AddUser_ThrowsExceptionWhenClientDoesNotExist()
    {
        
        // Arrange
        var userService = new UserService();

        // Act
        Action action = () => userService.AddUser(
            "Andrzej", 
            "Kowalski", 
            "kowalski@gmail.com",
            DateTime.Parse("2000-01-01"),
            7
        );

        // Assert
        Assert.Throws<ArgumentException>(action);
    }
    
    [Fact]
    public void AddUser_ThrowsExceptionWhenUserNoCreditLimitExistsForUser()
    {
        
        // Arrange
        var userService = new UserService();

        // Act
        Action action = () => userService.AddUser(
            "Andrzej", 
            "Andrzejewicz", 
            "kowalski@gmail.com",
            DateTime.Parse("2000-01-01"),
            1
        );

        // Assert
        Assert.Throws<ArgumentException>(action);
    }
}