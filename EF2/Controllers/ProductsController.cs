using EF2.Services;
using Microsoft.AspNetCore.Mvc;
using EF2.DTOs;
using EF2.DTOs.Product;

namespace EF2.Controllers;


[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public IEnumerable<GetProductRespone> GetAll()
    {
        return _productService.GetAll();
    }

    [HttpGet("{id}")]
    public GetProductRespone GetById(int id)
    {
        return _productService.GetById(id);
    }

    [HttpPost]
    public AddProductRespone Add([FromBody] AddProductRequest requestModel)
    {
        return _productService.Create(requestModel);
    }

    [HttpPut("{id}")]
    public UpdateProductRespone Update(int id, [FromBody] UpdateProductRequest requestModel)
    {
        return _productService.Update(id, requestModel);
    }

    [HttpDelete("{id}")]
    public bool Delete(int id)
    {
        return _productService.Delete(id);
    }
}
