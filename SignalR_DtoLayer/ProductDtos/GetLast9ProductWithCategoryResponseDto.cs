﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_DtoLayer.ProductDtos;

public class GetLast9ProductWithCategoryResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string ImageUrl { get; set; }
    public string CategoryName { get; set; }
    public bool Status { get; set; }
}
