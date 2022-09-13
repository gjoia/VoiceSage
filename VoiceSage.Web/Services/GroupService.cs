using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using VoiceSage.Web.Models;
using VoiceSage.Web.Services.IServices;

namespace VoiceSage.Web.Services
{
    public class GroupService : BaseService, IGroupService
    {
        private readonly IHttpClientFactory _clientFactory;

        public GroupService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<T> CreateGroupAsync<T>(GroupDto contactDto)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = contactDto,
                Url = SD.ContactAPIBase + "/api/groups",
                AccessToken = ""
            });
        }

        public async Task<T> DeleteGroupAsync<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.ContactAPIBase + "/api/groups/" + id,
                AccessToken = ""
            });
        }

        public async Task<T> GetAllGroupsAsync<T>()
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ContactAPIBase + "/api/groups",
                AccessToken = ""
            });
        }

        public async Task<T> GetGroupByIdAsync<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ContactAPIBase + "/api/groups/" + id,
                AccessToken = ""
            });
        }

        public async Task<T> UpdateGroupAsync<T>(GroupDto contactDto)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = contactDto,
                Url = SD.ContactAPIBase + "/api/groups",
                AccessToken = ""
            });
        }
    }
}
