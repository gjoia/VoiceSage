using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoiceSage.Web.Models;
using VoiceSage.Web.Services;
using VoiceSage.Web.Services.IServices;

namespace VoiceSage.Web.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public async Task<IActionResult> ContactIndex()
        {
            List<ContactDto> list = new List<ContactDto>();
            var response = await _contactService.GetAllContactsAsync<ResponseDto>();

            if (response != null && response.IsSucess)
                list = JsonConvert.DeserializeObject<List<ContactDto>>(Convert.ToString(response.Result));
            return View(list);
        }

        public async Task<IActionResult> ContactCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ContactCreate(ContactDto model)
        {
            if (ModelState.IsValid)
            {
                var response = await _contactService.CreateContactAsync<ResponseDto>(model);
                if (response != null && response.IsSucess)
                    return RedirectToAction(nameof(ContactIndex));
            }
            return View(model);
        }

        public async Task<IActionResult> AddRemoveGroup([FromServices] IGroupService groupService, int contactId, int groupId)
        {
            var response = await _contactService.GetContactByIdAsync<ResponseDto>(contactId);
            if (response != null && response.IsSucess)
            {
                ContactDto model = JsonConvert.DeserializeObject<ContactDto>(Convert.ToString(response.Result));
                ContactGroupDto cgDto = new ContactGroupDto
                {
                    ContactId = contactId,
                    GroupId = groupId
                };
                if (model.ContactGroups.Where(x => x.ContactId == contactId)
                    .Where(x => x.GroupId == groupId).FirstOrDefault() != null) {
                    var l = model.ContactGroups.ToList();
                    l.RemoveAll(x => x.GroupId == groupId);
                    model.ContactGroups = l;
                }
                else
                    model.ContactGroups.Add(cgDto);
                var updateResponse = await _contactService.UpdateContactAsync<ResponseDto>(model);
                List<GroupDto> list = new List<GroupDto>();
                
                return RedirectToAction(nameof(ContactEdit), new { contactId = model.ContactId});
            }
            return NotFound();
        }

        public async Task<IActionResult> ContactEdit([FromServices] IGroupService groupService, int contactId)
        {
            var response = await _contactService.GetContactByIdAsync<ResponseDto>(contactId);
            if (response != null && response.IsSucess)
            {
                ContactDto model = JsonConvert.DeserializeObject<ContactDto>(Convert.ToString(response.Result));
                List<GroupDto> list = new List<GroupDto>();
                var groupsResponse = await groupService.GetAllGroupsAsync<ResponseDto>();

                if (groupsResponse != null && response.IsSucess)
                    list = JsonConvert.DeserializeObject<List<GroupDto>>(Convert.ToString(groupsResponse.Result));
                ViewBag.AllGroups = model.ContactGroups.ToList();
                ViewModelContact viewModel = new ViewModelContact
                {
                    ContactDto = model,
                    Groups = list.ToList()

                };
                return View(viewModel);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ContactEdit(ViewModelContact model)
        {
            var response = await _contactService.GetContactByIdAsync<ResponseDto>(model.ContactDto.ContactId);
            if (response != null && response.IsSucess)
            {
                ContactDto modelR = JsonConvert.DeserializeObject<ContactDto>(Convert.ToString(response.Result));
                if (ModelState.IsValid)
                {
                    model.ContactDto.ContactGroups = modelR.ContactGroups;
                    var responseR = await _contactService.UpdateContactAsync<ResponseDto>(model.ContactDto);
                    if (responseR != null && responseR.IsSucess)
                        return RedirectToAction(nameof(ContactIndex));
                }
                return View(model.ContactDto);
            }
            return NotFound();
        }

        public async Task<IActionResult> ContactDelete(int contactId)
        {
            var response = await _contactService.GetContactByIdAsync<ResponseDto>(contactId);
            if (response != null && response.IsSucess)
            {
                ContactDto model = JsonConvert.DeserializeObject<ContactDto>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ContactDelete(ContactDto model)
        {
            if (ModelState.IsValid)
            {
                var response = await _contactService.DeleteContactAsync<ResponseDto>(model.ContactId);
                if (response.IsSucess)
                    return RedirectToAction(nameof(ContactIndex));
            }
            return View(model);
        }

       /*
        public async Task<IActionResult> GroupSelect([FromServices] IGroupService groupService, ContactDto model)
        {
            List<GroupDto> list = new List<GroupDto>();
            var response = await groupService.GetAllGroupsAsync<ResponseDto>();

            if (response != null && response.IsSucess)
                list = JsonConvert.DeserializeObject<List<GroupDto>>(Convert.ToString(response.Result));

            ViewModelContact viewModelContact = new ViewModelContact();
            viewModelContact.ContactDto = model;
            viewModelContact.Groups = list;
            return View(viewModelContact);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GroupSelect(ContactDto model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction(nameof(ContactEdit));
            }
            return View(model);
        }*/
    }
}
