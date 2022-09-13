using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoiceSage.Services.ContactAPI.Models;
using VoiceSage.Services.ContactAPI.Models.Dtos;

namespace VoiceSage.Services.ContactAPI.Repository
{
    public interface IGroupRepository
    {
        Task<IEnumerable<GroupDto>> GetGroups();
        Task<GroupDto> GetGroupById(int groupId);
        Task<GroupDto> CreateUpdateGroup(GroupDto groupDto);
        Task<bool> DeleteGroup(int groupId);
    }
}
