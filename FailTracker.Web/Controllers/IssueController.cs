using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FailTracker.Web.Data;
using FailTracker.Web.Domain;
using FailTracker.Web.Filters;
using FailTracker.Web.Models.Issue;
using Microsoft.AspNet.Identity;

namespace FailTracker.Web.Controllers
{
    public class IssueController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IssueController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        // GET: Issue
        public ActionResult IssueWidget()
        {
            return Content("Here's where issues would go!");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Log("Created issue")]
        public ActionResult New(NewIssueForm form)
        {
            var userId = User.Identity.GetUserId();

            var user = _context.Users.Find(userId);

            _context.Issues.Add(new Issue(user, form.Subject, form.Body));

            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}