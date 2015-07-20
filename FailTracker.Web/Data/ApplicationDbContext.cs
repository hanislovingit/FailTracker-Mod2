﻿using System.Data.Entity;
using FailTracker.Web.Domain;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FailTracker.Web.Data
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext()
			: base("DefaultConnection")
		{
		}

	    protected override void Dispose(bool disposing)
	    {
	        base.Dispose(disposing);
	    }

        public DbSet<Issue> Issues { get; set; }
        public DbSet<LogAction> Logs { get; set; }
	}
}