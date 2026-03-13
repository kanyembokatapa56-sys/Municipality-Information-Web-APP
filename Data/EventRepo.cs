using System;
using System.Collections.Generic;
using System.Linq;
using ST10265272_PROG7312_PortfolioOfEvidence.Models;

namespace ST10265272_PROG7312_PortfolioOfEvidence.Data
{
    public static class EventRepo
    {
        // Organizes events by date for fast date-based grouping
        public static SortedDictionary<DateTime, List<EventViewModel>> EventsByDate = new();

        // Tracks unique categories
        public static HashSet<string> EventCategories = new();

        // Stores all events
        public static List<EventViewModel> AllEvents = new();

        // Chronological queue of upcoming events
        public static Queue<EventViewModel> UpcomingEventQueue = new();

        // Most recently added events 
        public static Stack<EventViewModel> RecentEventStack = new();

        // Stores keyword/category search frequency
        public static Dictionary<string, int> SearchFrequency = new();

        static EventRepo()
        {
           
            AddEvent(new EventViewModel
            {
                Title = "Ward 6 Public Consultation",
                Category = "Governance",
                Description = "Engage with local councillors to discuss service delivery and upcoming projects in your ward.",
                Location = "Community Hall, Ward 6",
                StartDateTime = new DateTime(2025, 10, 18, 18, 0, 0),
                EndDateTime = new DateTime(2025, 10, 18, 20, 0, 0)
            });

            AddEvent(new EventViewModel
            {
                Title = "Planned Water Supply Interruption",
                Category = "Infrastructure",
                Description = "Water supply will be interrupted for maintenance in Zone 3. Please store water in advance.",
                Location = "Zone 3, Ethekwini Municipality",
                StartDateTime = new DateTime(2025, 10, 20, 8, 0, 0),
                EndDateTime = new DateTime(2025, 10, 20, 17, 0, 0)
            });

            AddEvent(new EventViewModel
            {
                Title = "Youth Skills Development Workshop",
                Category = "Education",
                Description = "Free training for unemployed youth: CV writing, interview prep, and digital literacy.",
                Location = "KwaMashu Training Centre",
                StartDateTime = new DateTime(2025, 10, 22, 9, 0, 0),
                EndDateTime = new DateTime(2025, 10, 22, 14, 0, 0)
            });

            AddEvent(new EventViewModel
            {
                Title = "Community Health Screening Day",
                Category = "Health",
                Description = "Free blood pressure, glucose, and HIV screenings available to all residents.",
                Location = "Ulundi Clinic Outreach Grounds",
                StartDateTime = new DateTime(2025, 10, 25, 8, 0, 0),
                EndDateTime = new DateTime(2025, 10, 25, 13, 0, 0)
            });

            AddEvent(new EventViewModel
            {
                Title = "Riverbank Clean-Up Campaign",
                Category = "Environment",
                Description = "Join municipal teams in cleaning and restoring the riverbank. Gloves and bags provided.",
                Location = "Mgeni Riverbank Park Entrance",
                StartDateTime = new DateTime(2025, 10, 28, 7, 30, 0),
                EndDateTime = new DateTime(2025, 10, 28, 12, 0, 0)
            });

            

            AddEvent(new EventViewModel
            {
                Title = "Municipal eServices Training",
                Category = "Education",
                Description = "Learn how to access municipal services online, including billing, permits, and complaints.",
                Location = "Durban City Library Auditorium",
                StartDateTime = new DateTime(2025, 11, 2, 10, 0, 0),
                EndDateTime = new DateTime(2025, 11, 2, 13, 0, 0)
            });

            AddEvent(new EventViewModel
            {
                Title = "Neighborhood Watch Induction",
                Category = "Governance",
                Description = "Join your local neighborhood watch team and learn about community policing practices.",
                Location = "Pinetown Community Hall",
                StartDateTime = new DateTime(2025, 11, 4, 18, 30, 0),
                EndDateTime = new DateTime(2025, 11, 4, 20, 30, 0)
            });

            AddEvent(new EventViewModel
            {
                Title = "Road Safety Awareness Campaign",
                Category = "Infrastructure",
                Description = "Educational booths and talks to improve road safety in high-risk areas.",
                Location = "Main Intersection, Umhlanga",
                StartDateTime = new DateTime(2025, 11, 6, 7, 0, 0),
                EndDateTime = new DateTime(2025, 11, 6, 12, 0, 0)
            });

            AddEvent(new EventViewModel
            {
                Title = "Mobile Clinic: Free Flu Shots",
                Category = "Health",
                Description = "Get your seasonal flu vaccine free of charge. No appointment necessary.",
                Location = "Phoenix Plaza Parking Lot",
                StartDateTime = new DateTime(2025, 11, 9, 9, 0, 0),
                EndDateTime = new DateTime(2025, 11, 9, 15, 0, 0)
            });

            AddEvent(new EventViewModel
            {
                Title = "Beach Cleanup & Environmental Workshop",
                Category = "Environment",
                Description = "Help clean our beaches and attend an eco-workshop hosted by local conservationists.",
                Location = "uShaka Beachfront",
                StartDateTime = new DateTime(2025, 11, 12, 8, 30, 0),
                EndDateTime = new DateTime(2025, 11, 12, 12, 30, 0)
            });

            // Populate queue after all events are added
            PopulateUpcomingQueue();
        }


        // Adds a new event to all storage structures
        public static void AddEvent(EventViewModel newEvent)
        {
            AllEvents.Add(newEvent);

            if (!EventsByDate.ContainsKey(newEvent.StartDateTime.Date))
                EventsByDate[newEvent.StartDateTime.Date] = new List<EventViewModel>();

            EventsByDate[newEvent.StartDateTime.Date].Add(newEvent);

            EventCategories.Add(newEvent.Category);
            RecentEventStack.Push(newEvent); // Most recently added
        }

        // Populates the queue of future events
        private static void PopulateUpcomingQueue()
        {
            var upcoming = AllEvents
                .Where(e => e.StartDateTime > DateTime.Now)
                .OrderBy(e => e.StartDateTime);

            foreach (var evt in upcoming)
                UpcomingEventQueue.Enqueue(evt);
        }

        
        public static EventViewModel GetNextUpcomingEvent()
        {
            return UpcomingEventQueue.Count > 0 ? UpcomingEventQueue.Peek() : null;
        }

        // Searches events by keyword/category/date
        public static IEnumerable<EventViewModel> SearchEvents(string keyword = "", string category = "", DateTime? date = null)
        {
            return AllEvents.Where(e =>
                (string.IsNullOrEmpty(keyword) || e.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase) || e.Description.Contains(keyword, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrEmpty(category) || e.Category.Equals(category, StringComparison.OrdinalIgnoreCase)) &&
                (!date.HasValue || e.StartDateTime.Date == date.Value.Date));
        }

      
        public static IEnumerable<string> GetAllCategories()
        {
            return EventCategories;
        }

        // Adds keyword or category to search history for recommendations
        public static void TrackSearch(string keyword, string category)
        {
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                var key = keyword.Trim().ToLower();
                if (SearchFrequency.ContainsKey(key))
                    SearchFrequency[key]++;
                else
                    SearchFrequency[key] = 1;
            }

            if (!string.IsNullOrWhiteSpace(category))
            {
                var cat = category.Trim().ToLower();
                if (SearchFrequency.ContainsKey(cat))
                    SearchFrequency[cat]++;
                else
                    SearchFrequency[cat] = 1;
            }
        }


        public static List<EventViewModel> GetRecommendations(string keyword = "", string category = "", DateTime? date = null)
        {
            var baseQuery = EventRepo.AllEvents.AsQueryable();

            if (!string.IsNullOrEmpty(category))
            {
                baseQuery = baseQuery.Where(e => e.Category.Equals(category, StringComparison.OrdinalIgnoreCase));
            }
            else if (!string.IsNullOrEmpty(keyword))
            {
                baseQuery = baseQuery.Where(e => e.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase)
                                               || e.Description.Contains(keyword, StringComparison.OrdinalIgnoreCase));
            }

            return baseQuery
                .OrderBy(e => e.StartDateTime) // Suggest earlier events
                .Take(4) // Limit to 4 for UI balance
                .ToList();
        }

    }
}

