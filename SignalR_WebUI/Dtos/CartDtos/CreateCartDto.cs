namespace SignalR_WebUI.Dtos.CartDtos;

public class CreateCartDto
{
    public int ProductId { get; set; }
    public int RestaurantTableId { get; set; }
    public int ProductCount = 1;
    public decimal TotalAmount = 0;
}
