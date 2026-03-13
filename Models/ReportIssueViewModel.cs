using System.ComponentModel.DataAnnotations;

namespace ST10265272_PROG7312_PortfolioOfEvidence.Models
{
    public class ReportIssueViewModel
    {
        [Required]
        public string Location { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public string Description { get; set; }

        public IFormFile? MediaAttachment { get; set; }

        public string? MediaFileName { get; set; }  

        public string? StatusMessage { get; set; } 
    }
}
