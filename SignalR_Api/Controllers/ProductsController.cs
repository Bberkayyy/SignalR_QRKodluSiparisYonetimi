using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR_BusinessLayer.Abstract.BusinessEntityInterfaces;
using SignalR_DtoLayer.ProductDtos;
using SignalR_EntityLayer.Entities;

namespace SignalR_Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;
    private readonly IMapper _mapper;

    public ProductsController(IProductService ProductService, IMapper mapper)
    {
        _productService = ProductService;
        _mapper = mapper;
    }
    [HttpGet]
    public IActionResult GetAll()
    {
        IList<GetAllProductResponseDto> values = _mapper.Map<IList<GetAllProductResponseDto>>(_productService.TGetAll());
        return Ok(values);
    }
    [HttpGet("getallwithcategory")]
    public IActionResult GetAllWithCategory()
    {
        IList<GetAllProductWithCategoryResponseDto> values = _mapper.Map<IList<GetAllProductWithCategoryResponseDto>>(_productService.TGetAllProductsWithCategories());
        return Ok(values);
    }
    [HttpGet("getwithcategory/{id}")]
    public IActionResult GetProductWithCategory(int id)
    {
        GetProductWithCategoryResponseDto value = _mapper.Map<GetProductWithCategoryResponseDto>(_productService.TGetProductWithCategory(id));
        return Ok(value);
    }
    [HttpPost]
    public IActionResult Create(CreateProductRequestDto createProductRequestDto)
    {
        Product mappedProduct = _mapper.Map<Product>(createProductRequestDto);
        Product value = _productService.TAdd(mappedProduct);
        CreatedProductResponseDto createdProduct = _mapper.Map<CreatedProductResponseDto>(value);
        return Created("", createdProduct);
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        Product value = _productService.TGetByFilter(x => x.Id == id);
        _productService.TDelete(value);
        return Ok("Başarıyla silindi.");
    }
    [HttpPut]
    public IActionResult Update(UpdateProductRequestDto updateProductRequestDto)
    {
        Product mappedProduct = _mapper.Map<Product>(updateProductRequestDto);
        Product value = _productService.TUpdate(mappedProduct);
        UpdatedProductResponseDto updatedProduct = _mapper.Map<UpdatedProductResponseDto>(value);
        return Ok(updatedProduct);
    }
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        Product value = _productService.TGetByFilter(x => x.Id == id);
        GetProductResponseDto getProduct = _mapper.Map<GetProductResponseDto>(value);
        return Ok(getProduct);
    }
}
