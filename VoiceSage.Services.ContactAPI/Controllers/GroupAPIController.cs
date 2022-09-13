using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoiceSage.Services.ContactAPI.Models.Dtos;
using VoiceSage.Services.ContactAPI.Repository;

namespace VoiceSage.Services.ContactAPI.Controllers
{
    [Route("api/Groups")]
    public class GroupAPIController : ControllerBase
    {
        protected ResponseDto _response;
        private IGroupRepository _groupRepository;

        public GroupAPIController(IGroupRepository groupRepository)
        {
            _response = new ResponseDto();
            _groupRepository = groupRepository;
        }

        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<GroupDto> groupDtos = await _groupRepository.GetGroups();
                _response.Result = groupDtos;
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
                GroupDto groupDto = await _groupRepository.GetGroupById(id);
                _response.Result = groupDto;
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
        public async Task<object> Post([FromBody] GroupDto groupDto)
        {
            try
            {
                GroupDto model = await _groupRepository.CreateUpdateGroup(groupDto);
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
        public async Task<object> Put([FromBody] GroupDto groupDto)
        {
            try
            {
                GroupDto model = await _groupRepository.CreateUpdateGroup(groupDto);
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
                bool isSucess = await _groupRepository.DeleteGroup(id);
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
