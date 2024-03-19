namespace SignalR_WebUI.Dtos.ProductDtos;

public class ResultProductsWithCategoriesDto
{
    public int id { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public decimal price { get; set; }
    public string imageUrl { get; set; }
    public string categoryName { get; set; }
    public bool status { get; set; }
}
