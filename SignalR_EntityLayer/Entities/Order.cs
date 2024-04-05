using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_EntityLayer.Entities;

public class Order
{
    public int Id { get; set; }
    public int RestaurantTableId { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }
    public decimal TotalPrice { get; set; }
    public bool Status { get; set; }
    public IList<OrderDetail> OrderDetails { get; set; }
    public RestaurantTable RestaurantTable { get; set; }
}
