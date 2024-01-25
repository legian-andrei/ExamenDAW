using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{ 
//	[ApiController]
//	[Route("[controller]")]
	public class PublishersController : Controller
	{
		private AppDbContext db = new AppDbContext();
		[HttpGet("GetPublishers")]
		public IActionResult Index()
		{
			try
			{
				var publishers = db.Publishers
					.Include(p => p.Authors)
					.ToList();

				return Ok(new { publishers });
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
		[HttpPost("NewPublisher")]
		public IActionResult New(Publisher p)
		{
			try
			{
				db.Publishers.Add(p);
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
