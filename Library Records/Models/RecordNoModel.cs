using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Records.Models
{
    public class CreateRecordNoModel
    {
        [Required]
        [MaxLength(30)]
        public string Date { get; set; }

        public int Number { get; set; }
    }

    public class UpdateRecordNoModel : CreateRecordNoModel
    {

    }

    public class ViewRecordNoByDateModel
    {
        [Required]
        [MaxLength(30)]
        public string Date { get; set; }
    }

    public class RecordNoModel : CreateRecordNoModel
    {
        public int Id { get; set; }
    }
}
