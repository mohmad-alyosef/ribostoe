using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksRepo.Models
{
    [Table("Books", Schema = "dbo")]
    public class Book
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }

        [ForeignKey("Authors")]
        public Guid AuthorId { get; set; }
        public virtual Author Author { get; set; }

        public double Price { get; set; }
        public double VersionNum { get; set; }
    }
}
