using AutoMapper;
using ConstellationOfDelicacies.Bll.Models;
using ConstellationOfDelicacies.Bll.Models.InputModels;
using ConstellationOfDelicacies.Dal.Dtos;

namespace ConstellationOfDelicacies.Bll.Mapping;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        // OutputModels
        CreateMap<OrdersDto,OrdersOutputModel>();
        CreateMap<ProfilesDto,ProfilesOutputModel>();
        CreateMap<RolesDto,RolesOutputModel>();
        CreateMap<SpecializationsDto,SpecializationsOutputModel>();
        CreateMap<TasksDto,TasksOutputModel>();
        CreateMap<TaskStatusesDto,TaskStatusesOutputModel>();
        CreateMap<UsersDto,UsersOutputModel>();
        
        // InputModels
        CreateMap<UsersInputModel,UsersDto>();
        CreateMap<RolesInputModel,RolesDto>();
        CreateMap<ProfilesInputModel,ProfilesDto>();
    }
}