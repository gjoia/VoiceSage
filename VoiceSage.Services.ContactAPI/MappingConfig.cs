using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoiceSage.Services.ContactAPI.Models;
using VoiceSage.Services.ContactAPI.Models.Dtos;

namespace VoiceSage.Services.ContactAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ContactDto, Contact>().ReverseMap();
                config.CreateMap<GroupDto, Group>().ReverseMap();
                config.CreateMap<ContactGroupDto, ContactGroup>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
