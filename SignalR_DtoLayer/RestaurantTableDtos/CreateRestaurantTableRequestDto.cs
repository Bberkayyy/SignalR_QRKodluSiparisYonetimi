﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_DtoLayer.RestaurantTableDtos;

public class CreateRestaurantTableRequestDto
{
    public string Name { get; set; }
    public bool Status { get; set; }
}
