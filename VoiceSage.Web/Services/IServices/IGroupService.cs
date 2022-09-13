using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoiceSage.Web.Models;

namespace VoiceSage.Web.Services.IServices
{
    public interface IGroupService : IBaseService
    {
        Task<T> GetAllGroupsAsync<T>();
        Task<T> GetGroupByIdAsync<T>(int id);
        Task<T> CreateGroupAsync<T>(GroupDto contactDto);
        Task<T> UpdateGroupAsync<T>(GroupDto contactDto);
        Task<T> DeleteGroupAsync<T>(int id);
    }
}
