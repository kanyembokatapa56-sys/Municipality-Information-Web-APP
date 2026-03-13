using System;
using System.Collections.Generic;

namespace ST10265272_PROG7312_PortfolioOfEvidence.Data.Structures
{
    public class ServiceRequestGraph
    {
        private Dictionary<string, List<string>> _adjList = new();

        // Add a new request node
        public void AddRequest(string requestId)
        {
            if (!_adjList.ContainsKey(requestId))
                _adjList[requestId] = new List<string>();
        }

        // Add a dependency: B depends on A
        public void AddDependency(string fromRequestId, string toRequestId)
        {
            AddRequest(fromRequestId);
            AddRequest(toRequestId);

            _adjList[toRequestId].Add(fromRequestId); // Reverse for topological sort
        }

        // Topological Sort (resolve order)
        public List<string> GetResolutionOrder()
        {
            var visited = new HashSet<string>();
            var stack = new Stack<string>();
            var temp = new HashSet<string>();

            foreach (var node in _adjList.Keys)
            {
                if (!visited.Contains(node))
                    if (!TopologicalSort(node, visited, stack, temp))
                        throw new Exception("Cyclic dependency detected");
            }

            return new List<string>(stack);
        }

        private bool TopologicalSort(string node, HashSet<string> visited, Stack<string> stack, HashSet<string> temp)
        {
            if (temp.Contains(node))
                return false; // Cycle found

            if (!visited.Contains(node))
            {
                temp.Add(node);
                foreach (var neighbor in _adjList[node])
                {
                    if (!TopologicalSort(neighbor, visited, stack, temp))
                        return false;
                }

                temp.Remove(node);
                visited.Add(node);
                stack.Push(node);
            }

            return true;
        }

        public Dictionary<string, List<string>> GetAdjacencyList() => _adjList;
    }
}

