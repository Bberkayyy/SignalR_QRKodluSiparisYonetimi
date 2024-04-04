namespace SignalR_WebUI.Dtos.OrderDtos;

public class ResultOrderDto
{
    public int id { get; set; }
    public string tableName { get; set; }
    public DateTime date { get; set; }
    public string description { get; set; }
    public decimal totalPrice { get; set; }
    public bool status { get; set; }
}
