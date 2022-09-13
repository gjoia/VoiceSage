using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VoiceSage.Services.ContactAPI.Models
{
    public class Group
    {
        [Key]
        public int GroupId { get; set; }
        [Required]
        public string GroupName { get; set; }
        public string Description { get; set; }
        public ICollection<ContactGroup> ContactGroups { get; set; }
    }
}
