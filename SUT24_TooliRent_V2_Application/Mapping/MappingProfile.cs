using AutoMapper;
using SUT24_TooliRent_V2_Application.DTOs;
using SUT24_TooliRent_V2_Application.DTOs.Bookings;
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
        CreateMap<Tool, ReadToolDto>()
            .ForMember(dest => dest.ToolCategoryName, opt 
                => opt.MapFrom(src => src.ToolCategory.Name));
        
        CreateMap<BookingTool, ReadBookingToolDto>()
            .ForMember(dest => dest.ToolName,
                opt => opt.MapFrom(src => src.Tool.Name))
            .ForMember(dest => dest.ToolCategory,
                opt => opt.MapFrom(src => src.Tool.ToolCategory.Name))
            .ForMember(dest => dest.ToolDemandsCertification,
                opt => opt.MapFrom(src => src.Tool.DemandsCertification))
            .ForMember(dest => dest.ReturnStatus,
                opt => opt.MapFrom(src => src.ReturnStatus.ToString()));              
    }

}