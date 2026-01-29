using System.ComponentModel.DataAnnotations;

namespace Lab5.Presentation.Http.Models;

public sealed class CreateAdminSessionRequest
{
    [Required]
    public string SystemPassword { get; set; } = string.Empty;
}