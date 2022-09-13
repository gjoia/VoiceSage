using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VoiceSage.Services.ContactAPI.Models.Dtos
{
    public class ContactDto
    {
        public int ContactId { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string Email { get; set; }
        public ICollection<ContactGroupDto> ContactGroups { get; set; }
    }
}
