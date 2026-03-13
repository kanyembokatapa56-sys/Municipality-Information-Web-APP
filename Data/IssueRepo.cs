using ST10265272_PROG7312_PortfolioOfEvidence.Models;

namespace ST10265272_PROG7312_PortfolioOfEvidence.Data
{
    public static class IssueRepo
    {
        public static List<ReportIssueViewModel> Issues { get; set; } = new();

        public static Dictionary<string, List<ReportIssueViewModel>> IssuesByCategory { get; set; } = new();
    }
}

