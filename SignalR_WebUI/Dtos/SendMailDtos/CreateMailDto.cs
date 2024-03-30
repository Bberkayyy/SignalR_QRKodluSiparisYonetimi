namespace SignalR_WebUI.Dtos.SendMailDtos;

public class CreateMailDto
{
    public string ReceiverMail { get; set; }
    public string Subject { get; set; }
    public string Content { get; set; }
}
