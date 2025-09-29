using FluentValidation;

namespace SUT24_TooliRent_V2_Application.DTOs.BookingDTOs;

public class CreateBookingRequestDtoValidation : AbstractValidator<CreateBookingRequestDto>
{
    public CreateBookingRequestDtoValidation()
    {
        RuleFor(x => x.MemberId).GreaterThan(0).WithMessage("MemberId must be greater than 0.");
        RuleFor(x=> x.StartDate).GreaterThanOrEqualTo(DateTime.UtcNow.Date).WithMessage("StartDate must be today or later.");
        RuleFor(x => x.StartDate).LessThan(x => x.EndDate).WithMessage("StartDate must be before EndDate.");
        RuleFor(x => x.EndDate).GreaterThan(x => x.StartDate).WithMessage("EndDate must be after StartDate.");
        RuleFor(x => x.ToolIds).NotEmpty().WithMessage("ToolIds cannot be empty.")
            .Must(ids => ids.Distinct().Count() == ids.Count).WithMessage("Dubbel booked tools are not aloud");;
        RuleForEach(x => x.ToolIds).GreaterThan(0).WithMessage("Each ToolId must be greater than 0.");
    }

}