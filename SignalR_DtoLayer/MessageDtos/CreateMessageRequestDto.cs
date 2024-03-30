using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_DtoLayer.MessageDtos;

public class CreateMessageRequestDto
{
    public string FullName { get; set; }
    public string Mail { get; set; }
    public string Phone { get; set; }
    public string Subject { get; set; }
    public string Content { get; set; }
    public DateTime SendDate = DateTime.Now;
    public bool Status = false;
}
