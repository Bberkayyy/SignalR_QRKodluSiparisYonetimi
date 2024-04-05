namespace SignalR_WebUI.Dtos.OrderDetailDtos;

public class ResultOrderDetailDto
{
    public int id { get; set; }
    public string productName { get; set; }
    public string orderTableName { get; set; }
    public int productCount { get; set; }
    public decimal unitPrice { get; set; }
    public decimal totalPrice { get; set; }
}
