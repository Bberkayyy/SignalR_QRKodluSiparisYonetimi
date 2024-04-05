namespace SignalR_WebUI.Dtos.OrderDetailDtos;

public class UpdateOrderDetailDto
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int OrderId { get; set; }
    public int ProductCount { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }
}
