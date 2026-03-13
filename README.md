Municipality of Xheon — Portfolio of Evidence

A Full ASP.NET Core MVC Application
Student: Kanyembo Katapa | Module: PROG7312 | Student ID: ST10265272

- Overview

This web application is designed to simulate a municipal service portal for the fictional "Municipality of Xheon". It allows users to:

View local events and announcements

Report issues directly

Track and manage service requests

Visualize dependencies between service requests

View priority and resolution ordering using sorting and graphs

Interact with an intuitive UI tailored for everyday users

- Technologies Used

ASP.NET Core MVC (Razor Pages)

C# / .NET 6

HTML, CSS, Bootstrap 5

JavaScript (Vis.js for graphs)

Custom Data Structures (Graph, Sort, etc.)

- How to Run the Application
- Prerequisites

Visual Studio 2022 or newer

.NET 6 SDK or later

Web browser (Edge, Chrome, Firefox)

- Steps

Clone or unzip the solution on your local machine.

Open the solution file: ST10265272_PROG7312_PortfolioOfEvidence.sln.

Build the solution (Ctrl + Shift + B).

Press F5 or click Start Debugging.

App opens in browser at https://localhost:####.

- Key Features
1. Homepage & Navigation

Welcoming banner with call-to-action buttons

Easy access to services, events, and issue reporting

Uses Bootstrap for a clean and responsive layout

2. Event Listing

Displays current events and announcements

Uses static data or future event repository integration

3. Report Issue Page

Allows users to report municipal issues (e.g., road damage, power outages)

Validates input and stores issues

4. Service Request Dashboard

A single page that integrates:

Status Table of all service requests

Dependency Graph (interactive)

Sorted View (by priority)

Resolution Order (topological sort)

- Data Structures & Their Purpose
Structure	Purpose	Contribution
List<T>	Holds all service requests and events	Dynamic storage, ideal for iteration and sorting
Graph (Adjacency List)	Models dependency between service requests	Enables graph traversal and visual dependency graphs
Topological Sort (DFS)	Determines resolution order	Ensures dependent tasks are resolved correctly
Priority Sort (OrderBy)	Sorts requests by urgency	Allows the municipality to handle high-priority tasks first
- Example: Graph-Based Resolution

If Request B depends on A, the system ensures A is completed before B. This is visualized using a vis.js network graph and implemented using a DFS topological sort in the backend.

- Graph & Visualization

Uses Vis.js
 to render an intuitive dependency graph

Arrows show which requests rely on others

Graph is labeled for clarity (Request ID, Title)

Styled with color-coded boxes for accessibility

File Structure
/Controllers
    - HomeController.cs
    - EventsController.cs
    - ReportController.cs
    - ServiceRequestController.cs

/Models
    - EventViewModel.cs
    - ReportIssueViewModel.cs
    - ServiceRequestViewModel.cs
    - ServiceDashboardViewModel.cs

/Data
    - ServiceRequestRepo.cs
    - EventRepo.cs
    - IssueRepo.cs
    - Structures/
        - BinarySearchTree.cs (if used)
        - ServiceRequestGraph.cs

/Views
    - Shared/
    - Home/
    - Events/
    - Report/
    - ServiceRequest/
        - Dashboard.cshtml (Main View)
        - Create.cshtml
        - Sorted.cshtml
        - Graph.cshtml (now integrated into Dashboard)

Final Notes

Every page was styled with user-friendliness in mind

Functionality is combined into a single dashboard for simplicity

Designed to meet all rubric requirements: UI, sorting, graphing, and data structures

Author Information
Kanyembo Katapa
