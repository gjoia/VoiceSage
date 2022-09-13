using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoiceSage.Web.Models;

namespace VoiceSage.Web.Services.IServices
{
    public interface IContactService : IBaseService
    {
        Task<T> GetAllContactsAsync<T>();
        Task<T> GetContactByIdAsync<T>(int id);
        Task<T> CreateContactAsync<T>(ContactDto contactDto);
        Task<T> UpdateContactAsync<T>(ContactDto contactDto);
        Task<T> DeleteContactAsync<T>(int id);
    }
}
