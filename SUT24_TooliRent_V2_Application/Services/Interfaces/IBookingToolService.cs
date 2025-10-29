using SUT24_TooliRent_V2_Application.Common;
using SUT24_TooliRent_V2_Application.DTOs.ToolDTOs;
using SUT24_TooliRent_V2_Domain.Enums;

namespace SUT24_TooliRent_V2_Application.Services.Interfaces;

public interface IBookingToolService
{
    Task<Result> MarkAsPickedUpAsync(int bookingId, int toolId, CancellationToken ct = default);
    Task<Result> MarkAsReturnedAsync(int bookingId, int toolId, ReturnStatus returnStatus, CancellationToken ct = default);
}