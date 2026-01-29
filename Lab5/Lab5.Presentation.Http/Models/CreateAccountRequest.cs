using System.ComponentModel.DataAnnotations;

namespace Lab5.Presentation.Http.Models;

public sealed class CreateAccountRequest
{
    [Required]
    public int AccountNumber { get; set; } = 0;

    [Range(0, 9999)]
    public int PinCode { get; set; }
}