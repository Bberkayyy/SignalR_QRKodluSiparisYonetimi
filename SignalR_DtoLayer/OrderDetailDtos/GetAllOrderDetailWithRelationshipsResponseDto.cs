using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_DtoLayer.OrderDetailDtos;

public class GetAllOrderDetailWithRelationshipsResponseDto
{
    public int Id { get; set; }
    public string ProductName { get; set; }
    public string OrderTableName { get; set; }
    public int ProductCount { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }
}
