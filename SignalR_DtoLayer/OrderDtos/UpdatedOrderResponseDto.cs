﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_DtoLayer.OrderDtos;

public class UpdatedOrderResponseDto
{
    public int Id { get; set; }
    public int RestaurantTableId { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }
    public decimal TotalPrice { get; set; }
    public bool Status { get; set; }
}
