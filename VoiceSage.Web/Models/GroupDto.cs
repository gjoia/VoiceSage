using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VoiceSage.Web.Models
{
    public class GroupDto
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public string Description { get; set; }
        public ICollection<ContactGroupDto> ContactGroups { get; set; }
    }
}
