using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoiceSage.Services.ContactAPI.Models.Dtos;
using VoiceSage.Services.ContactAPI.Repository;

namespace VoiceSage.Services.ContactAPI.Controllers
{
    [Route("api/contacts")]
    public class ContactAPIController : ControllerBase
    {
        protected ResponseDto _response;
        private IContactRepository _contactRepository;

        public ContactAPIController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
            _response = new ResponseDto();
        }

        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<ContactDto> contactDtos = await _contactRepository.GetContacts();
                _response.Result = contactDtos;
                _response.IsSucess = true;
            }
            catch (Exception ex)
            {
                _response.IsSucess = false;
                _response.ErrorMessages =
                    new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<object> Get(int id)
        {
            try
            {
                ContactDto contactDto = await _contactRepository.GetContactById(id);
                _response.Result = contactDto;
                _response.IsSucess = true;
            }
            catch (Exception ex)
            {
                _response.IsSucess = false;
                _response.ErrorMessages =
                    new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPost]
        public async Task<object> Post([FromBody] ContactDto contactDto)
        {
            try
            {
                ContactDto model = await _contactRepository.CreateUpdateContact(contactDto);
                _response.Result = model;
                _response.IsSucess = true;
            }
            catch (Exception ex)
            {
                _response.IsSucess = false;
                _response.ErrorMessages =
                    new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPut]
        public async Task<object> Put([FromBody] ContactDto contactDto)
        {
            try
            {
                ContactDto model = await _contactRepository.CreateUpdateContact(contactDto);
                _response.Result = model;
                _response.IsSucess = true;
            }
            catch (Exception ex)
            {
                _response.IsSucess = false;
                _response.ErrorMessages =
                    new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<object> Delete(int id)
        {
            try
            {
                bool isSucess = await _contactRepository.DeleteContact(id);
                _response.Result = isSucess;
                _response.IsSucess = true;
            }
            catch (Exception ex)
            {
                _response.IsSucess = false;
                _response.ErrorMessages =
                    new List<string>() { ex.ToString() };
            }
            return _response;
        }
    }
}
