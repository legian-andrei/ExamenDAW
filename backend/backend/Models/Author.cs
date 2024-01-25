using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
	public class Author
	{
		[Key]
		public int AuthorId { get; set; }
		public string Name { get; set; }
		public virtual ICollection<Book> Books { get; set; }
	}
}

