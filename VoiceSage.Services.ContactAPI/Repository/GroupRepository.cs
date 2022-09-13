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
    public class GroupRepository : IGroupRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public GroupRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<GroupDto> CreateUpdateGroup(GroupDto groupDto)
        {
            Group group = _mapper.Map<GroupDto, Group>(groupDto);

            if (group.GroupId > 0)
                _db.Groups.Update(group);
            else
                _db.Groups.Add(group);

            await _db.SaveChangesAsync();
            return _mapper.Map<Group, GroupDto>(group);
        }

        public async Task<bool> DeleteGroup(int groupId)
        {
            try
            {
                Group group = await _db.Groups.FirstOrDefaultAsync(x => x.GroupId == groupId);
                if (group == null)
                    return false;
                _db.Groups.Remove(group);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<GroupDto> GetGroupById(int groupId)
        {
            Group group = await _db.Groups.Where(x => x.GroupId == groupId).Include(x => x.ContactGroups).FirstOrDefaultAsync();
            return _mapper.Map<GroupDto>(group);
        }

        public async Task<IEnumerable<GroupDto>> GetGroups()
        {
            IEnumerable<Group> groupList = await _db.Groups.Include(x => x.ContactGroups).ToListAsync();
            return _mapper.Map<List<GroupDto>>(groupList);
        }
    }
}
