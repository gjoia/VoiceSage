using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoiceSage.Web.Models;
using VoiceSage.Web.Services.IServices;

namespace VoiceSage.Web.Controllers
{
    public class GroupController : Controller
    {
        private readonly IGroupService _groupService;
        public GroupController(IGroupService groupervice)
        {
            _groupService = groupervice;
        }

        public async Task<IActionResult> GroupIndex()
        {
            List<GroupDto> list = new List<GroupDto>();
            var response = await _groupService.GetAllGroupsAsync<ResponseDto>();

            if (response != null && response.IsSucess)
                list = JsonConvert.DeserializeObject<List<GroupDto>>(Convert.ToString(response.Result));
            return View(list);
        }

        public async Task<IActionResult> GroupCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GroupCreate(GroupDto model)
        {
            if (ModelState.IsValid)
            {
                var response = await _groupService.CreateGroupAsync<ResponseDto>(model);
                if (response != null && response.IsSucess)
                    return RedirectToAction(nameof(GroupIndex));
            }
            return View(model);
        }

        public async Task<IActionResult> GroupEdit(int groupId)
        {
            var response = await _groupService.GetGroupByIdAsync<ResponseDto>(groupId);
            if (response != null && response.IsSucess)
            {
                GroupDto model = JsonConvert.DeserializeObject<GroupDto>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GroupEdit(GroupDto model)
        {
            if (ModelState.IsValid)
            {
                var response = await _groupService.UpdateGroupAsync<ResponseDto>(model);
                if (response != null && response.IsSucess)
                    return RedirectToAction(nameof(GroupIndex));
            }
            return View(model);
        }

        public async Task<IActionResult> GroupDelete(int groupId)
        {
            var response = await _groupService.GetGroupByIdAsync<ResponseDto>(groupId);
            if (response != null && response.IsSucess)
            {
                GroupDto model = JsonConvert.DeserializeObject<GroupDto>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GroupDelete(GroupDto model)
        {
            if (ModelState.IsValid)
            {
                var response = await _groupService.DeleteGroupAsync<ResponseDto>(model.GroupId);
                if (response.IsSucess)
                    return RedirectToAction(nameof(GroupIndex));
            }
            return View(model);
        }
    }
}
