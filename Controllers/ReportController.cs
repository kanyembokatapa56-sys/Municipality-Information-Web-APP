using Microsoft.AspNetCore.Mvc;
using ST10265272_PROG7312_PortfolioOfEvidence.Data;
using ST10265272_PROG7312_PortfolioOfEvidence.Models;

namespace ST10265272_PROG7312_PortfolioOfEvidence.Controllers
{
    public class ReportController : Controller
    {
        [HttpGet]
        public IActionResult ReportIssue()
        {
            Console.WriteLine("[GET] ReportIssue View loaded.");
            return View(new ReportIssueViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> ReportIssue(ReportIssueViewModel model)
        {
            if (!ModelState.IsValid)
            {
                Console.WriteLine("[POST] ModelState is INVALID. Submission rejected.");
                foreach (var error in ModelState)
                {
                    foreach (var subError in error.Value.Errors)
                    {
                        Console.WriteLine($" - Field: {error.Key}, Error: {subError.ErrorMessage}");
                    }
                }

                return View(model); 
            }

            Console.WriteLine("[POST] ModelState is valid. Proceeding to save...");

          
            if (model.MediaAttachment != null && model.MediaAttachment.Length > 0)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");

                if (!Directory.Exists(uploadsFolder))
                    Directory.CreateDirectory(uploadsFolder);

                string fileName = Path.GetFileName(model.MediaAttachment.FileName);
                string filePath = Path.Combine(uploadsFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await model.MediaAttachment.CopyToAsync(stream);
                }

                model.MediaFileName = fileName;
                Console.WriteLine($"Media uploaded: {fileName}");
            }

      
            IssueRepo.Issues.Add(model);
            Console.WriteLine($"Issue added. Total count: {IssueRepo.Issues.Count}");

            if (!IssueRepo.IssuesByCategory.ContainsKey(model.Category))
            {
                IssueRepo.IssuesByCategory[model.Category] = new List<ReportIssueViewModel>();
                Console.WriteLine($"New category created: {model.Category}");
            }

            IssueRepo.IssuesByCategory[model.Category].Add(model);
            Console.WriteLine($"Issue added to category: {model.Category}. Total in this category: {IssueRepo.IssuesByCategory[model.Category].Count}");

            model.StatusMessage = "Issue submitted successfully!";
            ModelState.Clear();

            return View(new ReportIssueViewModel { StatusMessage = model.StatusMessage });
        
        }

        public IActionResult ViewAll()
        {
            Console.WriteLine($"[GET] ViewAll called. Issues count: {IssueRepo.Issues.Count}");
            return View(IssueRepo.Issues);
        }

        public IActionResult ViewGrouped()
        {
            Console.WriteLine($"[GET] ViewGrouped called. Group count: {IssueRepo.IssuesByCategory.Count}");
            return View(IssueRepo.IssuesByCategory);
        }
    }
}
