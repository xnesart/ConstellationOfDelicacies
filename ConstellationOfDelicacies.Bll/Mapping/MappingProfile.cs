using AutoMapper;
using ConstellationOfDelicacies.Bll.Models;
using ConstellationOfDelicacies.Dal.Dtos;

namespace ConstellationOfDelicacies.Bll.Mapping;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<OrdersDto,OrdersOutputModel>();
        CreateMap<ProfilesDto,ProfilesOutputModel>();
        CreateMap<RolesDto,RolesOutputModel>();
        CreateMap<SpecializationsDto,SpecializationsOutputModel>();
        CreateMap<TasksDto,TasksOutputModel>();
        CreateMap<TaskStatusesDto,TaskStatusesOutputModel>();
        CreateMap<UsersDto,UsersOutputModel>();
    }
}