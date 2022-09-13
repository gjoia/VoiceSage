using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using VoiceSage.Web.Models;
using VoiceSage.Web.Services.IServices;

namespace VoiceSage.Web.Services
{
    public class ContactService : BaseService, IContactService
    {
        private readonly IHttpClientFactory _clientFactory;

        public ContactService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<T> CreateContactAsync<T>(ContactDto contactDto)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = contactDto,
                Url = SD.ContactAPIBase + "/api/contacts",
                AccessToken = ""
            });
        }

        public async Task<T> DeleteContactAsync<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.ContactAPIBase + "/api/contacts/" + id,
                AccessToken = ""
            });
        }

        public async Task<T> GetAllContactsAsync<T>()
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ContactAPIBase + "/api/contacts",
                AccessToken = ""
            });
        }

        public async Task<T> GetContactByIdAsync<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ContactAPIBase + "/api/contacts/" + id,
                AccessToken = ""
            });
        }

        public async Task<T> UpdateContactAsync<T>(ContactDto contactDto)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = contactDto,
                Url = SD.ContactAPIBase + "/api/contacts",
                AccessToken = ""
            });
        }
    }
}
