using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;


public class ProductsController: BaseApiController
{
    private readonly IGenericRepository<Product> _productRepository;
    private readonly IGenericRepository<ProductType> _productTypeRepo;
    private readonly IMapper _mapper;
    private readonly IGenericRepository<ProductBrand> _productBrandRepo;

    public ProductsController(IGenericRepository<Product> productRepository,
     IGenericRepository<ProductType> productTypeRepo, 
     IMapper mapper,
     IGenericRepository<ProductBrand> productBrandRepo)
    {
        _productRepository = productRepository;
        _productTypeRepo = productTypeRepo;
        _mapper = mapper;
        _productBrandRepo = productBrandRepo;
    }

    // [HttpGet]
    // public async Task<ActionResult<List<Product>>> GetProducts() {
    //     ProductWithTypesAndBrandSpecification specification = new ProductWithTypesAndBrandSpecification();
    //     return Ok(await _productRepository.GetAllBySpecification(specification));
    //     // return  Ok(await _productRepository.GetAllAsync());
    // }

    [HttpGet]
    public async Task<List<ProductResponseDto>> GetProductsBySpecification([FromQuery]ProductParams productParams) {
        ProductsWithBrandAndTypeSpecification<Product> specification = new ProductsWithBrandAndTypeSpecification<Product>(productParams);
        var products = await _productRepository.GetAllBySpecification(specification);
        List<ProductResponseDto> productResponseDtos = _mapper.Map<List<ProductResponseDto>>(products);
        var productToSend = await PagedList<ProductResponseDto>
            .ToPagedList(productResponseDtos.AsQueryable(), 
            productParams.PageNumber, productParams.PageSize);

        HttpContext.HttpResoponse(productToSend.PaginationMetaData);
        return productToSend;
        // return Ok(_mapper.Map<List<ProductResponseDto>>(products));

    }

    // [HttpGet("{id}")]
    // public async Task<ActionResult<Product>> GetById(int id) {
    // return Ok(await _productRepository.GetByIdAsync(id));    
    // }


    [HttpGet("{id}")]
    public async Task<ActionResult> GetProductBySpecification(int id) {
        ProductsWithBrandAndTypeSpecification<Product> spec = new ProductsWithBrandAndTypeSpecification<Product>(id);
        var product = await _productRepository.GetProductBySpecification(spec);
        if (product == null) return NotFound(new ModelError("The given product doesn't found"));
        return Ok(_mapper.Map<ProductResponseDto>(product));
    }

    [HttpGet("productType")]
    public async Task<ActionResult<List<ProductType>>> GetProductType() {
        return Ok(await _productTypeRepo.GetAllAsync());
    } 

    [HttpGet("productBrand")]
    public async Task<ActionResult> GetProductBrands() {
        return Ok(await _productBrandRepo.GetAllAsync());   
    }
}