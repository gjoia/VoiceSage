using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VoiceSage.Services.ContactAPI.Models.Dtos
{
    public class GroupDto
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public string Description { get; set; }
        public ICollection<ContactGroup> ContactGroups { get; set; }
    }
}
