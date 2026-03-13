using System;
using System.Collections.Generic;
using ST10265272_PROG7312_PortfolioOfEvidence.Models;
using ST10265272_PROG7312_PortfolioOfEvidence.Data.Structures;

namespace ST10265272_PROG7312_PortfolioOfEvidence.Data
{
    public static class ServiceRequestRepo
    {
        public static List<ServiceRequestViewModel> AllRequests = new();
        public static BinarySearchTree<ServiceRequestViewModel> RequestTree = new();
        public static ServiceRequestGraph DependencyGraph = new();

        static ServiceRequestRepo()
        {
            SeedSampleRequests();
        }

        private static void SeedSampleRequests()
        {
            var request1 = new ServiceRequestViewModel
            {
                RequestId = "SR001",
                Title = "Water Leak at Main Road",
                Description = "Severe leak near the intersection",
                Status = "Pending",
                Category = "Water",
                Priority = 1,
                SubmittedAt = DateTime.Now.AddDays(-2),
                DependsOnRequestIds = new List<string>()
            };

            var request2 = new ServiceRequestViewModel
            {
                RequestId = "SR002",
                Title = "Power Outage Report",
                Description = "Complete blackout in Ward 7",
                Status = "In Progress",
                Category = "Electricity",
                Priority = 2,
                SubmittedAt = DateTime.Now.AddDays(-1),
                DependsOnRequestIds = new List<string> { "SR001" }
            };

            var request3 = new ServiceRequestViewModel
            {
                RequestId = "SR003",
                Title = "Manhole Cover Replacement",
                Description = "Dangerous open manhole",
                Status = "Pending",
                Category = "Roads",
                Priority = 3,
                SubmittedAt = DateTime.Now,
                DependsOnRequestIds = new List<string>()
            };

            var request4 = new ServiceRequestViewModel
            {
                RequestId = "SR004",
                Title = "Street Light Repair",
                Description = "Several lights out on Main Street",
                Status = "Completed",
                Category = "Electricity",
                Priority = 2,
                SubmittedAt = DateTime.Now.AddDays(-4),
                DependsOnRequestIds = new List<string>()
            };

            var request5 = new ServiceRequestViewModel
            {
                RequestId = "SR005",
                Title = "Garbage Collection Delay",
                Description = "Missed collection in Zone B",
                Status = "Pending",
                Category = "Sanitation",
                Priority = 1,
                SubmittedAt = DateTime.Now.AddDays(-3),
                DependsOnRequestIds = new List<string>()
            };

            var request6 = new ServiceRequestViewModel
            {
                RequestId = "SR006",
                Title = "Tree Blocking Road",
                Description = "Large tree fell after storm",
                Status = "Resolved",
                Category = "Emergency",
                Priority = 1,
                SubmittedAt = DateTime.Now.AddDays(-2),
                DependsOnRequestIds = new List<string> { "SR005" } // Depends on garbage issue cleared first
            };

            var request7 = new ServiceRequestViewModel
            {
                RequestId = "SR007",
                Title = "Road Pothole Repair",
                Description = "Multiple potholes near bus station",
                Status = "Pending",
                Category = "Roads",
                Priority = 2,
                SubmittedAt = DateTime.Now.AddDays(-1),
                DependsOnRequestIds = new List<string> { "SR003", "SR004" } // Depends on manhole fix & light repair
            };

            var request8 = new ServiceRequestViewModel
            {
                RequestId = "SR008",
                Title = "Drainage Blockage",
                Description = "Flooding during rain near market",
                Status = "In Progress",
                Category = "Water",
                Priority = 1,
                SubmittedAt = DateTime.Now,
                DependsOnRequestIds = new List<string> { "SR001" } // Depends on leak resolved first
            };

            // Add all requests
            AddRequest(request1);
            AddRequest(request2);
            AddRequest(request3);
            AddRequest(request4);
            AddRequest(request5);
            AddRequest(request6);
            AddRequest(request7);
            AddRequest(request8);
        }


        public static void AddRequest(ServiceRequestViewModel request)
        {
            AllRequests.Add(request);
            RequestTree.Insert(request);
            DependencyGraph.AddRequest(request.RequestId);

            foreach (var dep in request.DependsOnRequestIds)
            {
                DependencyGraph.AddDependency(dep, request.RequestId);
            }
        }

        public static List<string> GetRequestResolutionOrder()
        {
            return DependencyGraph.GetResolutionOrder();
        }

        public static IEnumerable<ServiceRequestViewModel> GetAll()
        {
            return AllRequests;
        }

        public static IEnumerable<ServiceRequestViewModel> GetSortedById()
        {
            return RequestTree.InOrderTraversal();
        }


        public static List<(string From, string To)> GetGraphEdges()
        {
            var edges = new List<(string, string)>();
            foreach (var request in AllRequests)
            {
                foreach (var dep in request.DependsOnRequestIds)
                {
                    edges.Add((dep, request.RequestId)); // "dep" must be completed before "request"
                }
            }
            return edges;
        }

        public static List<ServiceRequestViewModel> GetSortedByPriority()
        {
            return AllRequests.OrderBy(r => r.Priority).ThenBy(r => r.SubmittedAt).ToList();
        }


        public static List<ServiceRequestViewModel> GetTopologicalResolutionOrder()
        {
            var result = new List<ServiceRequestViewModel>();
            var visited = new HashSet<string>();
            var tempMark = new HashSet<string>();

            void Visit(ServiceRequestViewModel node)
            {
                if (visited.Contains(node.RequestId))
                    return;

                if (tempMark.Contains(node.RequestId))
                    return; // Cycle detection (skip or throw)

                tempMark.Add(node.RequestId);

                foreach (var depId in node.DependsOnRequestIds)
                {
                    var dep = AllRequests.FirstOrDefault(r => r.RequestId == depId);
                    if (dep != null)
                        Visit(dep);
                }

                tempMark.Remove(node.RequestId);
                visited.Add(node.RequestId);
                result.Add(node);
            }

            foreach (var req in AllRequests)
            {
                Visit(req);
            }

            return result;
        }

        public static List<(string From, string To)> GetGraphData()
        {
            var edges = new List<(string From, string To)>();

            foreach (var request in AllRequests)
            {
                foreach (var dependency in request.DependsOnRequestIds)
                {
                    edges.Add((From: dependency, To: request.RequestId));
                }
            }

            return edges;
        }


    }

}
