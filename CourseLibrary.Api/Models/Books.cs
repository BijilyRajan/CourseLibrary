using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseLibrary.Api.Models
{
    public class Books
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.Text.Json.Serialization.JsonIgnore]
        public int BookID { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public long ISBN { get; set; }
        public DateTime PublishedDate { get; set; }
        public short Price { get; set; }
        public int AuthorID { get; set; }

    }

    public class BooksDB : DbContext
    {
        public BooksDB(DbContextOptions<BooksDB> options) : base(options)
        {

        }
        public DbSet<Books> Books { get; set; }
       

    }
}
