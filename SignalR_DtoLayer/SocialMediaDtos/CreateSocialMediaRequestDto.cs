﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_DtoLayer.SocialMediaDtos;

public class CreateSocialMediaRequestDto
{
    public string Name { get; set; }
    public string Url { get; set; }
    public string Icon { get; set; }
}
