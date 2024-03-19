namespace SignalR_WebUI.Dtos.ReservationDtos;

public class ResultReservationDto
{
    public int id { get; set; }
    public string name { get; set; }
    public string phone { get; set; }
    public string mail { get; set; }
    public int personCount { get; set; }
    public DateTime date { get; set; }
}
