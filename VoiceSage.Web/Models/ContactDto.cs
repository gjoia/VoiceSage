﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VoiceSage.Web.Models
{
    public class ContactDto
    {
        public int ContactId { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string Email { get; set; }
        public List<ContactGroupDto> ContactGroups { get; set; }
    }
}
