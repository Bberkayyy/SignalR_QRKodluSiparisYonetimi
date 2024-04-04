namespace SignalR_WebUI.Dtos.OrderDtos;

public class CreateOrderDto
{
    public string TableName { get; set; }
    public string Description { get; set; }
    public DateTime Date = DateTime.Now;
    public decimal TotalPrice = 0;
    public bool Status = true;
}
