using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_DtoLayer.OrderDtos;

public class CreateOrderRequestDto
{
    public string TableName { get; set; }
    public DateTime Date = DateTime.Now;
    public string Description { get; set; }
    public decimal TotalPrice = 0;
    public bool Status = true;
}
