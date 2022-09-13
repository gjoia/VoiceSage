using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VoiceSage.Web.Models
{
    public class ViewModelContact
    {
        public ContactDto ContactDto { get; set; }
        public List<GroupDto> Groups { get; set; }
    }
}
