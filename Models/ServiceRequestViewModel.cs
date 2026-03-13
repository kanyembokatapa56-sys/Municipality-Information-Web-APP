using System;
using System.Collections.Generic;

namespace ST10265272_PROG7312_PortfolioOfEvidence.Models
{
    public class ServiceRequestViewModel : IComparable<ServiceRequestViewModel>
    {
        public string RequestId { get; set; }               // e.g., "SR001"
        public string Title { get; set; }                   // e.g., "Water Leak"
        public string Description { get; set; }
        public string Status { get; set; }                  // e.g., "Pending", "In Progress", "Resolved"
        public string Category { get; set; }                // e.g., "Water", "Electricity"
        public int Priority { get; set; }                   // 1 = High, 2 = Medium, 3 = Low
        public DateTime SubmittedAt { get; set; }

        // For Graph usage
        public List<string> DependsOnRequestIds { get; set; } = new(); // Dependencies for Graph

        // ✅ Add this to make the class usable in BinarySearchTree<T>
        public int CompareTo(ServiceRequestViewModel other)
        {
            if (other == null) return 1;

            // Sort by submission time first
            int result = SubmittedAt.CompareTo(other.SubmittedAt);

            // If same time, compare by priority (1 = high priority)
            if (result == 0)
                result = Priority.CompareTo(other.Priority);

            // If still same, compare by request ID
            if (result == 0)
                result = string.Compare(RequestId, other.RequestId, StringComparison.OrdinalIgnoreCase);

            return result;
        }
    }
}

