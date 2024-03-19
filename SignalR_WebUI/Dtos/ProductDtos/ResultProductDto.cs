namespace SignalR_WebUI.Dtos.ProductDtos;

public class ResultProductDto
{
    public int id { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public int price { get; set; }
    public string imageUrl { get; set; }
    public int categoryId { get; set; }
    public bool status { get; set; }
}
