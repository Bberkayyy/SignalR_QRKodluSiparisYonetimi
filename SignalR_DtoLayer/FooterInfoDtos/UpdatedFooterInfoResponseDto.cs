using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_DtoLayer.FooterInfoDtos;

public class UpdatedFooterInfoResponseDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}
