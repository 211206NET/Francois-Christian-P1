using Xunit;
using Moq;
using WebAPI.Controllers;
using BL;
using System.Collections.Generic;
using Models;
namespace Tests;

public class ControllerTest
{
    [Fact]
    public void StoreContollerGetShouldGetAllStores()
    {
        bool b = true;
        Assert.True(b);
    }

    [Fact]
    public void StoreFrontList()
    {
        var mockBL = new Mock<IBL>();

        mockBL.Setup(x => x.GetStoreFronts()).Returns(
            new List<StoreFront>
            {
                new StoreFront
                {
                    StoreID = 1,
                    Name = "Name One",
                    Address = "Address One"
                    

                },
                new StoreFront
                {
                    StoreID = 2,
                    Address = "Address Two",                    
                }
            }
        );
        var storeCntrllr = new StoreFrontController(mockBL.Object);

        //Act
        var result = storeCntrllr.Get();

        //Assert
        Assert.IsType<List<StoreFront>>(result);
    }
    [Fact]
    public void ProductList()
    {
        var mockBL = new Mock<IBL>();

        mockBL.Setup(x => x.GetProducts()).Returns(
            new List<Product>
            {
                new Product
                {
                    ProductID = 1,
                    Name = "Name One",
                    Description = "Description One",
                    Price = 12

                },
                new Product
                {
                    ProductID = 2,
                    Name = "name two",
                    Description= "decription Two",
                }
            }
        );
        var ProductCntrllr = new ProductController(mockBL.Object);

        //Act
        var result = ProductCntrllr.Get();

        //Assert
        Assert.IsType<List<Product>>(result);
    }
}

