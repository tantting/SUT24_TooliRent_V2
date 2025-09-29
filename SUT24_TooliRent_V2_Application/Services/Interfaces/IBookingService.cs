using SUT24_TooliRent_V2_Application.Common;
using SUT24_TooliRent_V2_Application.DTOs;
using SUT24_TooliRent_V2_Application.DTOs.BookingDTOs;
using SUT24_TooliRent_V2_Application.DTOs.ToolDTOs;
using SUT24_TooliRent_V2_Domain.Enums;

namespace SUT24_TooliRent_V2_Application.Services.Interfaces;

public interface IBookingService
{
    Task<IEnumerable<ReadBookingDto>> GetAllBookingsAsync(CancellationToken ct = default);
    Task<ReadBookingDto?> GetBookingByIdAsync(int id, CancellationToken ct = default);
    Task<IEnumerable<ReadBookingDto>> GetBookingsByUserIdAsync(int userId, CancellationToken ct = default);
    // Task<IEnumerable<ReadBookingDto>> GetBookingsByToolIdAsync(int toolId, CancellationToken ct = default);
    Task <Result<int>> CreateBookingAsync(CreateBookingRequestDto dto, CancellationToken ct = default);
    // Task <Result<ReadBookingDto>>  UpdateBookingAsync(UpdateBookingDto dto, CancellationToken ct = default);
    Task <Result<ReadBookingDto>>  DeleteBookingAsync(int id, CancellationToken ct = default);
    // Task<bool> BookingExistsAsync(int id, CancellationToken ct = default);
}