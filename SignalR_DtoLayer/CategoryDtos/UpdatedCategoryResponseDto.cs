using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_DtoLayer.CategoryDtos;

public class UpdatedCategoryResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool Status { get; set; }
}
