using System.ComponentModel.DataAnnotations;

namespace backend.Models
{

	public class Publisher
	{
		[Key]
		public int PublisherId { get; set; }
		public string Name { get; set; }
		public virtual ICollection<Author> Authors{ get; set; }
	}
}
