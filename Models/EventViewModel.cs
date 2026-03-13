using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace ST10265272_PROG7312_PortfolioOfEvidence.Models
{
    public class EventViewModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string Title { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public DateTime StartDateTime { get; set; }

        [Required]
        public DateTime EndDateTime { get; set; }

        public string Status => DateTime.Now >= StartDateTime && DateTime.Now <= EndDateTime ? "Showing" : "Upcoming";


    }
}

