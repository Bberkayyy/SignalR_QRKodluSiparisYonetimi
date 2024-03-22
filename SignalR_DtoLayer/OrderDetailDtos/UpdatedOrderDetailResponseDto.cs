using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_DtoLayer.OrderDetailDtos;

public class UpdatedOrderDetailResponseDto
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int ProductCount { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }
    public int OrderId { get; set; }
}
