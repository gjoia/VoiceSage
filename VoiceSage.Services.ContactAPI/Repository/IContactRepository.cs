using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoiceSage.Services.ContactAPI.Models.Dtos;

namespace VoiceSage.Services.ContactAPI.Repository
{
    public interface IContactRepository
    {
        Task<IEnumerable<ContactDto>> GetContacts();
        Task<ContactDto> GetContactById(int contactId);
        Task<ContactDto> CreateUpdateContact(ContactDto contactDto);
        Task<bool> DeleteContact(int contactId);
    }
}
