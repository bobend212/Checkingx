using AutoMapper;
using Checkingx.Shared;
using Checkingx.Shared.DTOs;

namespace Checkingx.Server.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CheckingCreateDTO, Checking>();
            CreateMap<CheckingCorrectDTO, Checking>();

            CreateMap<ProjectCreateDTO, Project>();
            CreateMap<ProjectUpdateDTO, Project>();

            CreateMap<CheckItemCreateDTO, CheckItem>();
            CreateMap<CheckItemUpdateDTO, CheckItem>();

        }
    }
}
