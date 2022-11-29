using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Records.Models
{
    public class CreateCategoryModel
    {
        [Required]
        [MaxLength(300)]
        public string CategoryName { get; set; }
    }

    public class UpdateCategoryModel : CreateCategoryModel
    {

    }

    public class ViewByCategoryNameModel
    {
        public string CategoryName { get; set; }
    }

    public class CategoryModel : CreateCategoryModel
    {
        public int Id { get; set; }

        public List<BookModel> Books { get; set; }
    }
}
