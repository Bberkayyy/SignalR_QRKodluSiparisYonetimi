namespace SignalR_WebUI.Dtos.CartDtos;

public class ResultCartDto
{
    public int id { get; set; }
    public string productName { get; set; }
    public decimal productPrice { get; set; }
    public string restaurantTableName { get; set; }
    public int productCount { get; set; }
    public decimal totalAmount { get; set; }
}
