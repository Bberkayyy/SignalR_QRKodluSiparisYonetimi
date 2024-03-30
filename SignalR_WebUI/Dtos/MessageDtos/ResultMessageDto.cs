namespace SignalR_WebUI.Dtos.MessageDtos;

public class ResultMessageDto
{
        public int id { get; set; }
        public string fullName { get; set; }
        public string mail { get; set; }
        public string phone { get; set; }
        public string subject { get; set; }
        public string content { get; set; }
        public DateTime sendDate { get; set; }
        public bool status { get; set; }
}
