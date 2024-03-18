using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_DtoLayer.AboutDtos;

public class CreateAboutRequestDto
{
    public string ImageUrl { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}
