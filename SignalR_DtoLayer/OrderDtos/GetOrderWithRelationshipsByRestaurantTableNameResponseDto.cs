﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_DtoLayer.OrderDtos;

public class GetOrderWithRelationshipsByRestaurantTableNameResponseDto
{
    public int Id { get; set; }
    public string RestaurantTableName { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }
    public decimal TotalPrice { get; set; }
    public bool Status { get; set; }
}
