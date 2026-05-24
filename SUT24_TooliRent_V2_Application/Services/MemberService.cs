using AutoMapper;
using SUT24_TooliRent_V2_Application.Common;
using SUT24_TooliRent_V2_Application.DTOs.MemberDTOs;
using SUT24_TooliRent_V2_Application.Services.Interfaces;
using SUT24_TooliRent_V2_Domain.Interfaces;

namespace SUT24_TooliRent_V2_Application.Services;

public class MemberService : IMemberService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public MemberService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ReadMemberDto>> GetAllMembersAsync(CancellationToken ct = default)
    {
        var members = await _unitOfWork.Members.GetAllAsync(ct);
        return _mapper.Map<IEnumerable<ReadMemberDto>>(members);
    }

    public async Task<Result> SetMemberActiveStatusAsync(int id, bool isActive, CancellationToken ct = default)
    {
        var member = await _unitOfWork.Members.GetByIdAsync(id, ct);
        if (member is null)
            return Result.Fail($"Member with ID {id} not found");

        member.IsActive = isActive;
        await _unitOfWork.SaveChangesAsync(ct);
        return Result.Ok();
    }
}
