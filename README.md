# Municipality of Xheon

## Municipal Service Management System 


A full-stack ASP.NET Core MVC web application designed to simulate a digital municipal service portal where residents can view announcements, report issues, and track service requests through a structured dashboard.

This project focuses on solving a common public service problem: municipal information and service requests are often scattered, manual, and difficult to prioritise. Municipality of Xheon brings these processes into one web-based platform, allowing users to interact with municipal services more clearly while giving the system a structured way to manage, sort, and visualise requests.

* [Watch Demo Part 1 on YouTube](https://www.youtube.com/watch?v=gerExUG54CQ)

* [Watch Demo Part 2 on YouTube](https://www.youtube.com/watch?v=Ut_h6xTyjk8)

---

## Project Overview

Municipality of Xheon allows users to:

* View local events and municipal announcements
* Report service issues such as road damage, outages, or public maintenance problems
* Track and manage service requests
* View request priority and resolution order
* Visualise dependencies between service requests using an interactive graph
* Navigate through a clean, user-friendly interface designed for everyday users

The goal was to create a municipal portal that is not only functional, but also easy to understand for residents and useful for managing service-related workflows.

---

## Problem the Project Solves

Municipal service requests can become difficult to manage when information is handled manually or spread across separate systems.

For example:

* Residents may not know where to report issues
* Municipal teams may struggle to identify urgent requests
* Some service requests may depend on others being completed first
* Manual tracking can make it harder to understand priority and resolution order

This project addresses those issues by creating a central web application where municipal information, issue reporting, request tracking, priority sorting, and dependency visualisation are handled in one place.

---

## Key Features

### Homepage and Navigation

* Built a welcoming homepage with clear call-to-action buttons
* Provided simple navigation to events, announcements, issue reporting, and service request features
* Used Bootstrap to support a clean and responsive layout

### Events and Announcements

* Created an event listing section where users can view municipal events and public announcements
* Designed the section to support future expansion into a dynamic event repository

### Report Issue Page

* Built a report issue feature that allows residents to submit municipal problems such as road damage, outages, or maintenance concerns
* Added input validation to help ensure submitted issue details are usable and structured
* Stored reported issues for tracking and management

### Service Request Dashboard

Built a single dashboard that combines multiple service management views, including:

* A status table of service requests
* A priority-based sorted view
* A dependency graph
* A resolution order based on topological sorting

This dashboard helps make service requests easier to understand, prioritise, and manage.

---

## Data Structures and Logic

This project uses custom data structures to support service request management and prioritisation.

| Data Structure / Logic | Purpose                                      | Outcome                                                                 |
| ---------------------- | -------------------------------------------- | ----------------------------------------------------------------------- |
| `List<T>`              | Stores service requests and events           | Allows requests and events to be added, displayed, filtered, and sorted |
| Graph / Adjacency List | Models dependencies between service requests | Helps show which requests depend on others                              |
| DFS Topological Sort   | Determines resolution order                  | Ensures dependent tasks are resolved in the correct sequence            |
| Priority Sorting       | Sorts service requests by urgency            | Helps high-priority issues appear first                                 |
| Vis.js Graph           | Displays request dependencies visually       | Makes complex relationships easier to understand                        |

---

## Example: Dependency-Based Resolution

If one service request depends on another, the system can model that relationship using a graph.

For example:

If **Request B** depends on **Request A**, the system ensures that **Request A** is resolved first.

This is handled through graph-based logic and visualised using an interactive Vis.js network graph, making it easier to see how service requests are connected.

---

## Technologies Used

* ASP.NET Core MVC
* C# / .NET 6
* HTML
* CSS
* Bootstrap 5
* JavaScript
* Vis.js
* Custom data structures
* Graph traversal
* Sorting algorithms
* Topological sort

---

## Technical Highlights

* Developed a web-based municipal service portal with events, announcements, issue reporting, and service request tracking.
* Built a dashboard that combines request status, priority sorting, dependency visualisation, and resolution ordering in one place.
* Implemented graph-based dependency tracking to show how service requests relate to one another.
* Used DFS topological sorting to determine a logical resolution order for dependent requests.
* Applied priority sorting to help urgent service requests appear first.
* Designed a responsive user interface using Bootstrap, HTML, CSS, and JavaScript.
* Structured the project using controllers, models, views, repositories, and custom data structure classes.

---

## Project Structure

```text
/Controllers
    HomeController.cs
    EventsController.cs
    ReportController.cs
    ServiceRequestController.cs

/Models
    EventViewModel.cs
    ReportIssueViewModel.cs
    ServiceRequestViewModel.cs
    ServiceDashboardViewModel.cs

/Data
    ServiceRequestRepo.cs
    EventRepo.cs
    IssueRepo.cs
    /Structures
        ServiceRequestGraph.cs
        BinarySearchTree.cs

/Views
    /Shared
    /Home
    /Events
    /Report
    /ServiceRequest
        Dashboard.cshtml
        Create.cshtml
        Sorted.cshtml
        Graph.cshtml
```

---

## Outcome

The final application provides a structured digital platform for municipal interaction.

Residents can view announcements, report issues, and access service request information, while the system supports request prioritisation, dependency tracking, and resolution ordering.

From a development perspective, the project demonstrates practical experience with ASP.NET Core MVC, C#, responsive UI design, custom data structures, graph traversal, sorting logic, and dashboard-based web application development.

---

## What I Learned

Through this project, I strengthened my understanding of:

* ASP.NET Core MVC application structure
* Controller, model, view, and repository separation
* Building user-friendly web interfaces
* Applying data structures in a real application scenario
* Using graphs to model real-world dependencies
* Sorting and prioritising service request data
* Creating dashboards that make information easier to understand
* Writing code that connects user interaction with backend logic

---

## Future Improvements

Possible improvements include:

* Adding user authentication and role-based access
* Storing events, issues, and service requests in a relational database
* Adding admin controls for managing submitted issues
* Sending email or SMS notifications when request statuses change
* Adding real-time updates to the service request dashboard
* Improving analytics around request volume, priority, and resolution time

---

## Author

**Kanyembo Katapa**
Computer and Information Sciences in Application Development Graduate

