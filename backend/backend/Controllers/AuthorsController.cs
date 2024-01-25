using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
	//[ApiController]
	//[Route("[controller]")]
	public class AuthorsController : Controller
	{
		private AppDbContext db = new AppDbContext();

		[HttpGet("GetAuthors")]
		public IActionResult Index()
		{
			try
			{
				var authors = db.Authors
					.Include(a => a.Books)
					.ToList();

				return Ok(new { authors });
			}
			catch (Exception ex)
			{
				return StatusCode(500, new { error = "An error occurred while fetching Authors." });
			}
		}
		public IActionResult New()
		{
			return View();
		}
		[HttpPost("NewAuthor")]
		public IActionResult New(Author a)
		{
			try
			{
				db.Authors.Add(a);
				db.SaveChanges();
				return RedirectToAction("New");
			}
			catch (Exception)
			{
				return View();
			}
		}
	}
}
