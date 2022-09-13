using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VoiceSage.Web.Models
{
    public class ViewModelGroup
    {
        public GroupDto GroupDto { get; set; }
        public ICollection<ContactDto> Contacts { get; set; }
    }
}
