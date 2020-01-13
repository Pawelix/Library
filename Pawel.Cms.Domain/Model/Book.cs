using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Pawel.Cms.Common.Enums;

namespace Pawel.Cms.Domain.Model
{
    [Table("Books", Schema = "Book")]
    public class Book
    {
        public Book()
        {

        }

        public Book(string title)
        {
            Title = title;
            BookType = BookType.Encyclopedia;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Author { get; set; }

        [Required]
        private BookType BookType { get; set; }

        

       
        /// <summary>
        /// Constructor 2 - newspapers
        /// </summary>
        /// <param name="title"></param>
        /// <param name="authorName"></param>
        public Book(string title, string authorName)
        {
            Title = title;
            Author = authorName;
            BookType = BookType.NewspaperCodzienna;
        }

        public void SetTitle(string title)
        {
            Title = title;
        }

        public BookType GetBookType()
        {
            return BookType;
        }
    }
}
