using SUT24_TooliRent_V2_Application.Common;
using SUT24_TooliRent_V2_Application.DTOs;
using SUT24_TooliRent_V2_Application.DTOs.BookingDTOs;
using SUT24_TooliRent_V2_Domain.Enums;

namespace SUT24_TooliRent_V2_Application.Services.Interfaces;

public interface IBookingService
{
    Task<IEnumerable<ReadBookingDto>> GetAllBookingsAsync(CancellationToken ct = default);
    // Task<ReadToolDto?> GetBookingByIdAsync(int id, CancellationToken ct = default);
    // Task<IEnumerable<ReadToolDto>> GetBookingsByUserIdAsync(int userId, CancellationToken ct = default);
    // Task<IEnumerable<ReadToolDto>> GetBookingsByToolIdAsync(int toolId, CancellationToken ct = default);
    // Task <Result<ReadBookingDto>> CreateBookingAsync(CreateToolDto dto, CancellationToken ct = default);
    // Task <Result<ReadBookingDto>>  UpdateBookingAsync(UpdateToolDto dto, CancellationToken ct = default);
    // Task <Result<ReadBookingDto>>  DeleteBookingAsync(int id, CancellationToken ct = default);
    // Task<bool> BookingExistsAsync(int id, CancellationToken ct = default);
}