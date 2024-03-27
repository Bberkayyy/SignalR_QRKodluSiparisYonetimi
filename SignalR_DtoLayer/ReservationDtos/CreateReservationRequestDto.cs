using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_DtoLayer.ReservationDtos;

public class CreateReservationRequestDto
{
    public string Name { get; set; }
    public string Description = "Beklemede";
    public string Phone { get; set; }
    public string Mail { get; set; }
    public int PersonCount { get; set; }
    public DateTime Date { get; set; }
}
