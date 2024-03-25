using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_EntityLayer.Entities;

public class Cart
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int RestaurantTableId { get; set; }
    public Product Product { get; set; }
    public RestaurantTable RestaurantTable { get; set; }
    public int ProductCount { get; set; }
    public decimal TotalAmount { get; set; }
}
