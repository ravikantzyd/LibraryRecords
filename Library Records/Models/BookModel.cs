using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Records.Models
{
    public class CreateBookModel
    {
        [Required]
        public string BookId { get; set; }

        [Required]
        [MaxLength(500)]
        public string BookName { get; set; }

        [Required]
        [MaxLength(500)]
        public string Author { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public int TotalCount { get; set; }        
    }

    public class UpdateBookModel : CreateBookModel
    {

    }

    public class SearchByBookDataModel
    {
        public string BookData { get; set; }
    }

    public class ViewByBookNameModel
    {
        public string BookName { get; set; } = "";
    }

    public class ViewByBookIdModel
    {
        public string BookId { get; set; } = "";
    }

    public class ViewByCategoryIdModel
    {
        public int CategoryId { get; set; }
    }

    public class BookModel : CreateBookModel
    {
        public int Id { get; set; }

        public CategoryModel Categories { get; set; }
        public virtual List<RecordModel> Records { get; set; }
    }
}
