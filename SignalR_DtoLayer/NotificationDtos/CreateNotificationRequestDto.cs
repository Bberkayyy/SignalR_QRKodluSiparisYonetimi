using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_DtoLayer.NotificationDtos;

public class CreateNotificationRequestDto
{
    public string Type { get; set; }
    public string Icon { get; set; }
    public string Description { get; set; }
    public DateTime Date = DateTime.Now;
    public bool Status = false;
}
