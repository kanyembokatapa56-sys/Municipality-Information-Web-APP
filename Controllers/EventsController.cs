using Microsoft.AspNetCore.Mvc;
using ST10265272_PROG7312_PortfolioOfEvidence.Data;
using ST10265272_PROG7312_PortfolioOfEvidence.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ST10265272_PROG7312_PortfolioOfEvidence.Controllers
{
    public class EventsController : Controller
    {
      
        public IActionResult Index(string keyword, string category, DateTime? date)
        {
            
            EventRepo.TrackSearch(keyword, category);

           
            var filtered = EventRepo.SearchEvents(keyword, category, date)
                .GroupBy(e => e.StartDateTime.Date)
                .OrderBy(g => g.Key)
                .ToDictionary(g => g.Key, g => g.ToList());

            
            var sorted = new SortedDictionary<DateTime, List<EventViewModel>>(filtered);


            var recommendations = EventRepo.GetRecommendations();



            var nextUpcoming = EventRepo.GetNextUpcomingEvent();

          
            ViewBag.Recommendations = recommendations;
            ViewBag.NextUpcoming = nextUpcoming;
            ViewBag.AllCategories = EventRepo.GetAllCategories();

            return View(sorted);
        }

        public IActionResult Details(Guid id)
        {
            var evt = EventRepo.AllEvents.FirstOrDefault(e => e.Id == id);
            if (evt == null)
                return NotFound();

            return View(evt);
        }
    }
}

