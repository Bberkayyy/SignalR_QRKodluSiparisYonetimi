using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using SignalR_WebUI.Dtos.SendMailDtos;

namespace SignalR_WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]")]
public class SendEmailController : Controller
{
    [Route("Index")]
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    [Route("Index")]
    [HttpPost]
    public IActionResult Index(CreateMailDto createMailDto)
    {
        MimeMessage mimeMessage = new MimeMessage();

        MailboxAddress mailBoxAdressFrom = new MailboxAddress("SignalR Restoran", "berkayoguz45@gmail.com");
        mimeMessage.From.Add(mailBoxAdressFrom);

        MailboxAddress mailBoxAdressTo = new MailboxAddress("User", createMailDto.ReceiverMail);
        mimeMessage.To.Add(mailBoxAdressTo);

        BodyBuilder bodyBuilder = new BodyBuilder();
        bodyBuilder.TextBody = createMailDto.Content;

        mimeMessage.Body = bodyBuilder.ToMessageBody();
        mimeMessage.Subject = createMailDto.Subject;

        SmtpClient client = new SmtpClient();
        client.Connect("smtp.gmail.com", 587, false);
        client.Authenticate("berkayoguz45@gmail.com", "sjoi msps bpuh tesv");

        client.Send(mimeMessage);
        client.Disconnect(true);

        return RedirectToAction("Index", "Product", new { area = "Admin" });
    }
    [Route("Index/{mail}")]
    [HttpGet]
    public IActionResult Index(string mail)
    {
        CreateMailDto createMailDto = new();
        createMailDto.ReceiverMail = mail;
        return View(createMailDto);
    }
    [Route("Index/{mail}")]
    [HttpPost]
    public IActionResult Index(CreateMailFromReservationListDto createMailFromReservationListDto)
    {
        MimeMessage mimeMessage = new MimeMessage();

        MailboxAddress mailBoxAdressFrom = new MailboxAddress("SignalR Restoran", "berkayoguz45@gmail.com");
        mimeMessage.From.Add(mailBoxAdressFrom);

        MailboxAddress mailBoxAdressTo = new MailboxAddress("User", createMailFromReservationListDto.ReceiverMail);
        mimeMessage.To.Add(mailBoxAdressTo);

        BodyBuilder bodyBuilder = new BodyBuilder();
        bodyBuilder.TextBody = createMailFromReservationListDto.Content;

        mimeMessage.Body = bodyBuilder.ToMessageBody();
        mimeMessage.Subject = createMailFromReservationListDto.Subject;

        SmtpClient client = new SmtpClient();
        client.Connect("smtp.gmail.com", 587, false);
        client.Authenticate("berkayoguz45@gmail.com", "sjoi msps bpuh tesv");

        client.Send(mimeMessage);
        client.Disconnect(true);

        return RedirectToAction("Index", "Reservation", new { area = "Admin" });
    }
}
