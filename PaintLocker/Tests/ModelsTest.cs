using Xunit;
using Models;
using CustomExceptions;

namespace Tests;

public class ModelsTest
{
    [Fact]
    public void StoreShouldCreate()
    {
        //Arrange
        //making sure it had the namespace
        //Act
        StoreFront testStore = new StoreFront();
        //Assert
        Assert.NotNull(testStore);
    }

    [Fact]
    public void StoreShouldSetValidInput()
    {
        //Arrange
        StoreFront testStore = new StoreFront();
        string name = "Test name";
        string address = "Test address";
        //Act
        testStore.Name = name;
        testStore.Address = address;
        //Assert
        Assert.Equal(name, testStore.Name);
        Assert.Equal(address, testStore.Address);
    }

    [Theory]
    [InlineData("     ")]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("#$%^&*@&#")]
    public void StoreShouldNotSetInvalidName(string input)
    {
        //Arrange
        StoreFront testStore = new StoreFront();      
        //Act
        //Assert 
        Assert.Throws<InputInvalidException>(() => testStore.Name = input);
    }

    [Theory]
    [InlineData("     ")]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("#$%^&*@&#")]
    public void StoreShouldNotSetInvalidAddress(string input)
    {
        //Arrange
        StoreFront testStore = new StoreFront();      
        //Act
        //Assert 
        Assert.Throws<InputInvalidException>(() => testStore.Address = input);
    }

    [Fact]
    public void ProductShouldCreate()
    {
        //Arrange
        //making sure it had the namespace
        //Act
        Product testProduct = new Product();
        //Assert
        Assert.NotNull(testProduct);
    }
    [Fact]
    public void ProductShouldSetValidInput()
    {
        //Arrange
        Product testProduct = new Product();
        string name = "Test name";
        string description = "Test description";
        decimal price = 1;
        //Act
        testProduct.Name = name;
        testProduct.Description = description;
        testProduct.Price = price;
        //Assert
        Assert.Equal(name, testProduct.Name);
        Assert.Equal(description, testProduct.Description);
        Assert.Equal(price, testProduct.Price);
    }
    [Theory]
    [InlineData("     ")]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("#$%^&*@&#")]
    public void ProductShouldNotSetInvalidName(string input)
    {
        //Arrange
        Product testProduct = new Product();      
        //Act
        //Assert 
        Assert.Throws<InputInvalidException>(() => testProduct.Name = input);
    }
    [Theory]
    [InlineData("     ")]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("#$%^&*@&#")]
    public void ProductShouldNotSetInvalidDescription(string input)
    {
        //Arrange
        Product testProduct = new Product();      
        //Act
        //Assert 
        Assert.Throws<InputInvalidException>(() => testProduct.Description = input);
    }
    [Theory]
    [InlineData(-1)]
    public void ProductShouldNotSetInvalidPrice(decimal input)
    {
        Product testProduct = new Product();
        Assert.Throws<InputInvalidException>(() => testProduct.Price = input);
    }
    [Fact]
    public void CustomerShouldCreate()
    {
        //Arrange
        //making sure it had the namespace
        //Act
        Customer testCustomer = new Customer();
        //Assert
        Assert.NotNull(testCustomer);
    }
    [Fact]
    public void CustomerShouldSetValidInput()
    {
        //Arrange
        Customer testCustomer = new Customer();
        string username = "Test name";
        string password = "Test Pass";
        //Act
        testCustomer.Username = username;
        testCustomer.Password = password;
        //Assert
        Assert.Equal(username, testCustomer.Username);
        Assert.Equal(password, testCustomer.Password);
    }
    [Theory]
    [InlineData("     ")]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("#$%^&*@&#")]
    [InlineData("four")]
    [InlineData("overthecapofwordsallowed")]
    public void CustomerShouldNotSetInvalidUsername(string input)
    {
        //Arrange
        Customer testCustomer = new Customer();      
        //Act
        //Assert 
        Assert.Throws<InputInvalidException>(() => testCustomer.Username = input);
    }
    [Theory]
    [InlineData("     ")]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("#$%^&*@&#")]
    [InlineData("four")]
    [InlineData("overthecapofwordsallowed")]
    public void CustomerShouldNotSetInvalidPassword(string input)
    {
        //Arrange
        Customer testCustomer = new Customer();      
        //Act
        //Assert 
        Assert.Throws<InputInvalidException>(() => testCustomer.Password = input);
    }
}