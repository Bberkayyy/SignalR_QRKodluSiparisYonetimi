using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_WebUI.Dtos.RecipeDtos;

public class ResultRecipeDto
{
    public int Count { get; set; }
    public List<RecipesDto>? Results { get; set; }

    public class RecipesDto
    {
        public string Name { get; set; }
        public string Original_Video_Url { get; set; }
        public int Total_Time_Minutes { get; set; }
        public string Thumbnail_Url { get; set; }
    }
}