using AutoMapper;
using ConstellationOfDelicacies.Bll.Models;
using ConstellationOfDelicacies.Bll.Models.InputModels;
using ConstellationOfDelicacies.Bll.Models.OutputModels;
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
        CreateMap<UsersDto,LoginOutputModel>();

        // InputModels
        CreateMap<UsersInputModel,UsersDto>();
        CreateMap<RolesInputModel,RolesDto>();
        CreateMap<ProfilesInputModel,ProfilesDto>();
        CreateMap<TasksInputModel,TasksDto>();
        CreateMap<OrderInputModel,OrdersDto>();
        CreateMap<TaskStatusesInputModel,TaskStatusesDto>();
    }
}