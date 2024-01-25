using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
//	[ApiController]
	//[Route("[controller]")]
	public class BooksController : Controller
	{
		private AppDbContext db = new AppDbContext();

		[HttpGet("Index")]
		public IActionResult Index()
		{
			try
			{
				var books = db.Books
					.Include(b => b.Authors)
					.Include(b => b.Publisher)
					.ToList();

				return Ok( new { books } );
			}
			catch (Exception ex)
			{
				return StatusCode(500, new { error = "An error occurred while fetching books." });
			}
		}
		public IActionResult New()
		{
			return View();
		}
		[HttpPost("NewBook")]
		public IActionResult New(Book b)
		{
			try
			{
				db.Books.Add(b);
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
