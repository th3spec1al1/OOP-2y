using System.ComponentModel.DataAnnotations;

namespace Lab5.Presentation.Http.Models;

public sealed class DepositRequest
{
    [Required]
    public Guid SessionId { get; set; }

    [Range(0.01, double.MaxValue)]
    public decimal Amount { get; set; }
}