using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_DtoLayer.OrderDetailDtos;

public class CreateOrderDetailRequestDto
{
    public int ProductId { get; set; }
    public int OrderId { get; set; }
    public int ProductCount { get; set; }
    public decimal UnitPrice = 0;
    public decimal TotalPrice = 0;
}
