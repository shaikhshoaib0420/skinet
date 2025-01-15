using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ProductsController: ControllerBase
{
    private readonly SkinetContext _skinetContext;

    public ProductsController(SkinetContext skinetContext)
    {
        _skinetContext = skinetContext;
    }

    [HttpGet]
    public string Get() {
        return "Products";
    }

}