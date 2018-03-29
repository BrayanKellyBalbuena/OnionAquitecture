using AutoMapper;
using Data.Models;
using System.Collections.Generic;
using Web.ViewModels;

namespace Web
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PersonViewModel, Person>();
            CreateMap<IEnumerable<PersonViewModel>, IEnumerable<Person>>();

        }
    }
}