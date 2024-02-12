using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ActiveX.Controllers;
using ActiveX.Models.Data;
using ActiveX.Models.Contracts;
using Xunit;

namespace ActiveX.Tests;

public class HomeControllerTests
{
    [Fact]
    public void Can_Use_Service()
    {
        Mock<IProductService> mock = new Mock<IProductService>();
        mock.Setup(m => m.Products).Returns((new Product[]
                    {
                       new Product
                       {
                          ProductID = 1,
                          Name = "P1"
                       },
                       new Product
                       {
                          ProductID = 2,
                          Name = "P2"
                       }
                    }).AsQueryable<Product>());

        HomeController controller = new HomeController(mock.Object);

        IEnumerable<Product>? result = 
            (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;

        Product[] prodArray = result?.ToArray() ?? Array.Empty<Product>();
        Assert.True(prodArray.Length == 2);
        Assert.Equal("P1", prodArray[0].Name);
        Assert.Equal("P2", prodArray[1].Name);
    }

    [Fact]
    public void Can_Paginate()
    {
        Mock<IProductService> mock = new Mock<IProductService>();
        mock.Setup(m => m.Products).Returns((new Product[]
                    {
                       new Product
                       {
                          ProductID = 1,
                          Name = "P1"
                       },
                       new Product
                       {
                          ProductID = 2,
                          Name = "P2"
                       },
                       new Product
                       {
                          ProductID = 3,
                          Name = "P3"
                       },
                       new Product
                       {
                          ProductID = 4,
                          Name = "P4"
                       },
                       new Product
                       {
                           ProductID = 5,
                           Name = "P5"
                       }
                    }).AsQueryable<Product>());

        HomeController controller = new HomeController(mock.Object);
        controller.PageSize = 3;

        IEnumerable<Product> result = 
            (controller.Index(2) as ViewResult)?.ViewData.Model
            as IEnumerable<Product> ?? Enumerable.Empty<Product>();

        Product[] prodArray = result.ToArray();
        Assert.True(prodArray.Length == 2);
        Assert.Equal("P4", prodArray[0].Name);
        Assert.Equal("P5", prodArray[1].Name);
    }
}