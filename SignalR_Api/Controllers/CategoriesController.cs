using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR_BusinessLayer.Abstract.BusinessEntityInterfaces;
using SignalR_DtoLayer.CategoryDtos;
using SignalR_EntityLayer.Entities;

namespace SignalR_Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;
    private readonly IMapper _mapper;

    public CategoriesController(ICategoryService CategoryService, IMapper mapper)
    {
        _categoryService = CategoryService;
        _mapper = mapper;
    }
    [HttpGet]
    public IActionResult GetAll()
    {
        IList<GetAllCategoryResponseDto> values = _mapper.Map<IList<GetAllCategoryResponseDto>>(_categoryService.TGetAll());
        return Ok(values);
    }
    [HttpPost]
    public IActionResult Create(CreateCategoryRequestDto createCategoryRequestDto)
    {
        Category mappedCategory = _mapper.Map<Category>(createCategoryRequestDto);
        Category value = _categoryService.TAdd(mappedCategory);
        CreatedCategoryResponseDto createdCategory = _mapper.Map<CreatedCategoryResponseDto>(value);
        return Created("", createdCategory);
    }
    [HttpDelete]
    public IActionResult Delete(int id)
    {
        Category value = _categoryService.TGetByFilter(x => x.Id == id);
        _categoryService.TDelete(value);
        return Ok("Başarıyla silindi.");
    }
    [HttpPut]
    public IActionResult Update(UpdateCategoryRequestDto updateCategoryRequestDto)
    {
        Category mappedCategory = _mapper.Map<Category>(updateCategoryRequestDto);
        Category value = _categoryService.TUpdate(mappedCategory);
        UpdatedCategoryResponseDto updatedCategory = _mapper.Map<UpdatedCategoryResponseDto>(value);
        return Ok(updatedCategory);
    }
    [HttpGet("getbyid")]
    public IActionResult Get(int id)
    {
        Category value = _categoryService.TGetByFilter(x => x.Id == id);
        GetCategoryResponseDto getCategory = _mapper.Map<GetCategoryResponseDto>(value);
        return Ok(getCategory);
    }
}
