using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_DtoLayer.CartDtos;

public class GetCartWithRelationshipsResponseDto
{
    public int Id { get; set; }
    public string ProductName { get; set; }
    public decimal ProductPrice { get; set; }
    public string RestaurantTableName { get; set; }
    public int ProductCount { get; set; }
    public decimal TotalAmount { get; set; }
}
