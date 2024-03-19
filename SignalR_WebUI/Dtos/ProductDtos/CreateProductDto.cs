﻿namespace SignalR_WebUI.Dtos.ProductDtos;

public class CreateProductDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string ImageUrl { get; set; }
    public int CategoryId { get; set; }
    public bool Status = true;
}
