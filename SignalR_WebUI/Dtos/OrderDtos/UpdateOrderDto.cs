namespace SignalR_WebUI.Dtos.OrderDtos;

public class UpdateOrderDto
{
    public int Id { get; set; }
    public int RestaurantTableId { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }
    public decimal TotalPrice { get; set; }
    public bool Status { get; set; }
}
