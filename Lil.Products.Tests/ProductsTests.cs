using Lil.Products.Controllers;
using Lil.Products.DAL;
using Microsoft.AspNetCore.Mvc;

namespace Lil.Products.Tests;

[TestClass]
public class ProductsTests
{
    [TestMethod]
    public void GetAsyncReturnsOk()
    {
        var productsController = new ProductsController(new ProductsProvider());

        var result = productsController.GetAsync("1").Result;

        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result, typeof(OkObjectResult));
    }

    [TestMethod]
    public void GetAsyncReturnsNotFound()
    {
        var productsController = new ProductsController(new ProductsProvider());

        var result = productsController.GetAsync("101").Result;

        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result, typeof(NotFoundResult));
    }
}