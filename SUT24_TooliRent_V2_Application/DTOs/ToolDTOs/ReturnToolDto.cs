using System.ComponentModel.DataAnnotations;
using SUT24_TooliRent_V2_Domain.Enums;

namespace SUT24_TooliRent_V2_Application.DTOs.ToolDTOs;

public record ReturnToolDto
{
        [Required]
        public ReturnStatus ReturnStatus { get; init; }
}