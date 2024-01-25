﻿using Microsoft.EntityFrameworkCore;

namespace backend.Models
{
	public class AppDbContext : DbContext
	{
		public AppDbContext() : base()
		{

		}

		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=aspnet-53bc9b9d-9d6a-45d4-8429-2a2761773502;Trusted_Connection=True;MultipleActiveResultSets=true");
		}

		public DbSet<Author> Authors { get; set; }
		public DbSet<Book> Books { get; set; }
		public DbSet<Publisher> Publishers { get; set; }
	}
}
