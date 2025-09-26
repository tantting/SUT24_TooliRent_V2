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
        CreateMap<Tool, ReadToolDto>();
        CreateMap<Booking, ReadBookingDto>()
            .ForMember(dest => dest.MemberName, opt 
                => opt.MapFrom(src => src.Member.Name))
            .ForMember(dest => dest.ToolName, opt 
                => opt.MapFrom(src => src.Tool.Name))
            .ForMember(dest => dest.ToolCategory, opt 
                => opt.MapFrom(src => src.Tool.Category.ToString()))
            .ForMember(dest => dest.ToolDemandsCertification, opt 
                => opt.MapFrom(src => src.Tool.DemandsCertification))
            .ForMember(dest => dest.BookingStatus, opt 
                => opt.MapFrom(src => src.Status.ToString()));
    }

}