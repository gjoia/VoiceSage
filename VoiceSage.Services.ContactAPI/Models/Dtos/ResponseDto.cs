﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VoiceSage.Services.ContactAPI.Models.Dtos
{
    public class ResponseDto
    {
        public bool IsSucess { get; set; }
        public object Result { get; set; }
        public string DisplayMessage { get; set; } = "";
        public List<string> ErrorMessages{ get; set; } 
    }
}
