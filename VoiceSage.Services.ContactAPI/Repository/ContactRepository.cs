using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoiceSage.Services.ContactAPI.DbContexts;
using VoiceSage.Services.ContactAPI.Models;
using VoiceSage.Services.ContactAPI.Models.Dtos;

namespace VoiceSage.Services.ContactAPI.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public ContactRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ContactDto> CreateUpdateContact(ContactDto contactDto)
        {
            Contact contact = _mapper.Map<ContactDto, Contact>(contactDto);

            if (contact.ContactId > 0)
            {
                var c = _db.Contacts.Include("ContactGroups").FirstAsync(x => x.ContactId == contact.ContactId);
                var cgs = contact.ContactGroups;

                c.Result.ContactGroups.Clear();
                foreach (var cg in cgs)
                {
                    c.Result.ContactGroups.Add(cg);
                }
                c.Result.Email = contact.Email;
                c.Result.Number = contact.Number;
                c.Result.Name = contact.Name;
            }
            else
                _db.Contacts.Add(contact);

            await _db.SaveChangesAsync();
            return _mapper.Map<Contact, ContactDto>(contact);
        }

        public async Task<bool> DeleteContact(int contactId)
        {
            try
            {
                Contact contact = await _db.Contacts.FirstOrDefaultAsync(x => x.ContactId == contactId);
                if (contact == null)
                    return false;
                _db.Contacts.Remove(contact);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<ContactDto> GetContactById(int contactId)
        {
            Contact contact = await _db.Contacts.Where(x => x.ContactId == contactId).Include(x => x.ContactGroups).FirstOrDefaultAsync();
            return _mapper.Map<ContactDto>(contact);
        }

        public async Task<IEnumerable<ContactDto>> GetContacts()
        {
            IEnumerable<Contact> contactList = await _db.Contacts.Include(x => x.ContactGroups).ToListAsync();
            return _mapper.Map<List<ContactDto>>(contactList);
        }
    }
}
