using Microsoft.AspNetCore.Mvc;
using minhaapi.Services.Interfaces;
using minhaapi.Common.Models;
using minhaapi.Common.HttpResult;

namespace api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _service;
    private readonly ILogger<ProductController> _logger;

    public ProductController(ILogger<ProductController> logger, IProductService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpGet("category")]
    public JsonResult GetAllCategory()
    {
        try
        {
            var list = _service.GetAllCategory();
            return new JsonResult(list);

        }
        catch (System.Exception ex)
        {

            return ResponseHelper.Error(ex.Message, System.Net.HttpStatusCode.InternalServerError);
        }
    }

    [HttpPost("category")]
    public JsonResult CreateCategory([FromBody] CategoryModel model)
    {
        try
        {
            var list = _service.CreateCategory(model);
            return new JsonResult(list);

        }
        catch (System.Exception ex)
        {

            return ResponseHelper.Error(ex.Message, System.Net.HttpStatusCode.InternalServerError);
        }
    }

    [HttpPut("category")]
    public JsonResult UpdateCategory([FromBody] CategoryModel model)
    {
        try
        {
            var list = _service.UpdateCategory(model);
            return new JsonResult(list);

        }
        catch (System.Exception ex)
        {

            return ResponseHelper.Error(ex.Message, System.Net.HttpStatusCode.InternalServerError);
        }
    }

    [HttpDelete("category/{uuid}")]
    public JsonResult DeleteCategory(string uuid)
    {
        try
        {
            var list = _service.DeleteCategory(uuid);
            return new JsonResult(list);

        }
        catch (System.Exception ex)
        {

            return ResponseHelper.Error(ex.Message, System.Net.HttpStatusCode.InternalServerError);
        }
    }

    // -------------------------------------- PRODUCT -----------------------------------------------//

    [HttpGet]
    public JsonResult GetAllProduct()
    {
        try
        {
            var list = _service.GetAllProduct();
            return new JsonResult(list);

        }
        catch (System.Exception ex)
        {

            return ResponseHelper.Error(ex.Message, System.Net.HttpStatusCode.InternalServerError);
        }
    }

    [HttpGet("bycategory/{uuid}")]
    public JsonResult GetProductByCategory(string uuid)
    {
        try
        {
            var list = _service.GetProductByCategory(uuid);
            return new JsonResult(list);

        }
        catch (System.Exception ex)
        {

            return ResponseHelper.Error(ex.Message, System.Net.HttpStatusCode.InternalServerError);
        }
    }

    [HttpPost]
    public JsonResult CreateProduct([FromBody] ProductModel model)
    {
        try
        {
            var list = _service.CreateProduct(model);
            return new JsonResult(list);

        }
        catch (System.Exception ex)
        {

            return ResponseHelper.Error(ex.Message, System.Net.HttpStatusCode.InternalServerError);
        }
    }

    [HttpPut]
    public JsonResult UpdateProduct([FromBody] ProductModel model)
    {
        try
        {
            var list = _service.UpdateProduct(model);
            return new JsonResult(list);

        }
        catch (System.Exception ex)
        {

            return ResponseHelper.Error(ex.Message, System.Net.HttpStatusCode.InternalServerError);
        }
    }

    [HttpDelete("{uuid}")]
    public JsonResult DeleteProduct(string uuid)
    {
        try
        {
            var list = _service.DeleteProduct(uuid);
            return new JsonResult(list);

        }
        catch (System.Exception ex)
        {

            return ResponseHelper.Error(ex.Message, System.Net.HttpStatusCode.InternalServerError);
        }
    }
}
