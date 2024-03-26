namespace SignalR_WebUI.Dtos.NotificationDtos;

public class ResultNotificationDto
{
    public int id { get; set; }
    public string type { get; set; }
    public string icon { get; set; }
    public string description { get; set; }
    public DateTime date { get; set; }
    public bool status { get; set; }
}
