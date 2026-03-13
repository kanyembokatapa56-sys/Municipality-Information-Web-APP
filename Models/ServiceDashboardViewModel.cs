namespace ST10265272_PROG7312_PortfolioOfEvidence.Models
{
    public class ServiceDashboardViewModel
    {
        public List<ServiceRequestViewModel> AllRequests { get; set; }
        public List<ServiceRequestViewModel> Sorted { get; set; }
        public List<(string From, string To)> GraphEdges { get; set; }
        public List<ServiceRequestViewModel> ResolutionOrder { get; set; }
    }


}
