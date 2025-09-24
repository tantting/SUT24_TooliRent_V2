using AutoMapper;
using SUT24_TooliRent_V2_Application.DTOs;
using SUT24_TooliRent_V2_Domain.Entities;

namespace SUT24_TooliRent_V2_Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // DTO to Entity mappings
        CreateMap<CreateToolDto, Tool>();
        CreateMap<UpdateToolDto, Tool>();

        // Entity to DTO mappings
        CreateMap<Tool, ReadToolDto>();
    }

}