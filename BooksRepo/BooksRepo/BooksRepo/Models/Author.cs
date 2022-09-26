using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksRepo.Models
{
    [Table("Authors", Schema = "dbo")]
    public class Author
    {
        public Author()
        {
            Books = new List<Book>();
        }

        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual List<Book> Books { get; set; }
    }
}
