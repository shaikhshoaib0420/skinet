using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.AspNetCore.Mvc.Infrastructure;

[ApiController]
[Route("api/[controller]")]
public class ProductsController: ControllerBase
{
    private readonly IGenericRepository<Product> _productRepository;
    private readonly IGenericRepository<ProductType> _productTypeRepo;
    private readonly IMapper _mapper;

    public ProductsController(IGenericRepository<Product> productRepository,
     IGenericRepository<ProductType> productTypeRepo, IMapper mapper)
    {
        _productRepository = productRepository;
        _productTypeRepo = productTypeRepo;
        _mapper = mapper;
    }

    // [HttpGet]
    // public async Task<ActionResult<List<Product>>> GetProducts() {
    //     ProductWithTypesAndBrandSpecification specification = new ProductWithTypesAndBrandSpecification();
    //     return Ok(await _productRepository.GetAllBySpecification(specification));
    //     // return  Ok(await _productRepository.GetAllAsync());
    // }

    [HttpGet]
    public async Task<IActionResult> GetProductsBySpecification() {
        ProductsWithBrandAndTypeSpecification<Product> specification = new ProductsWithBrandAndTypeSpecification<Product>();
        var products = await _productRepository.GetAllBySpecification(specification);
        return Ok(_mapper.Map<List<ProductResponseDto>>(products));

    }

    // [HttpGet("{id}")]
    // public async Task<ActionResult<Product>> GetById(int id) {
    // return Ok(await _productRepository.GetByIdAsync(id));    
    // }


    [HttpGet("{id}")]
    public async Task<ActionResult> GetProductBySpecification(int id) {
        ProductsWithBrandAndTypeSpecification<Product> spec = new ProductsWithBrandAndTypeSpecification<Product>(id);
        var product = await _productRepository.GetProductBySpecification(spec);
        return Ok(_mapper.Map<ProductResponseDto>(product));
    }

    [HttpGet("productType")]
    public async Task<ActionResult<List<ProductType>>> GetProductType() {
        return Ok(await _productTypeRepo.GetAllAsync());
    } 
}