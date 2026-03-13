using Microsoft.AspNetCore.Mvc;
using ST10265272_PROG7312_PortfolioOfEvidence.Data;
using ST10265272_PROG7312_PortfolioOfEvidence.Models;
using System.Linq;

namespace ST10265272_PROG7312_PortfolioOfEvidence.Controllers
{
    public class ServiceRequestController : Controller
    {
        // List all service requests
        public IActionResult Index()
        {
            var requests = ServiceRequestRepo.AllRequests;
            return View(requests);
        }

        // GET: Create a new request
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.AllRequestIds = ServiceRequestRepo.AllRequests.Select(r => r.RequestId).ToList();
            return View();
        }

        // POST: Create a new request
        [HttpPost]
        public IActionResult Create(ServiceRequestViewModel model, List<string> selectedDependencies)
        {
            if (ModelState.IsValid)
            {
                model.SubmittedAt = DateTime.Now;
                model.DependsOnRequestIds = selectedDependencies ?? new List<string>();
                ServiceRequestRepo.AddRequest(model);
                return RedirectToAction("Index");
            }

            ViewBag.AllRequestIds = ServiceRequestRepo.AllRequests.Select(r => r.RequestId).ToList();
            return View(model);
        }

        // Display dependency graph
        public IActionResult Graph()
        {
            var graphData = ServiceRequestRepo.GetGraphEdges(); 
            return View(graphData); 
        }

        // View requests sorted by priority
        public IActionResult Sorted()
        {
            var sorted = ServiceRequestRepo.GetSortedByPriority(); 
            return View("Index", sorted); // Reuse Index view
        }

        // View resolution order (topological sort)
        public IActionResult ResolutionOrder()
        {
            var ordered = ServiceRequestRepo.GetTopologicalResolutionOrder(); 
            return View("Index", ordered); // Reuse Index view
        }
        public IActionResult Dashboard()
        {
            var dashboard = new ServiceDashboardViewModel
            {
                AllRequests = ServiceRequestRepo.AllRequests,
                Sorted = ServiceRequestRepo.GetSortedByPriority(),
                ResolutionOrder = ServiceRequestRepo.GetTopologicalResolutionOrder(),
                GraphEdges = ServiceRequestRepo.GetGraphEdges()
            };

            return View(dashboard);
        }

        private string GetColor(string status)
        {
            return status switch
            {
                "Completed" => "#28a745",
                "In Progress" => "#ffc107",
                "Pending" => "#dc3545",
                _ => "#6c757d"
            };
        }




    }
}

