using backend.Models;
using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
	public class Book
	{
		[Key]
		public int BookId { get; set; }
		public string Title { get; set; }
		public virtual Publisher Publisher { get; set; }
		public virtual ICollection<Author> Authors { get; set; }
	}
}