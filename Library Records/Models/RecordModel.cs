using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Records.Models
{
    public class CreateRecordModel
    {
        [Required]
        public string RecordId { get; set; }

        [Required]
        public int MemberId { get; set; }

        [Required]
        public int BookId { get; set; }

        [Required]
        public DateTime BorrowDate { get; set; }

        [Required]
        public string BorrowSignature { get; set; }
        
        public DateTime ReturnDate { get; set; }
        
        public string ReturnSignature { get; set; }
        
        public int DateExtended { get; set; }
        
        public string DExtendedSignature { get; set; }

        [Required]
        public int UserId { get; set; }
    }

    public class UpdateRecordModel
    {
        public DateTime ReturnDate { get; set; }

        public string ReturnSignature { get; set; }

        public int DateExtended { get; set; }

        public string DExtendedSignature { get; set; }
    }

    public class SearchByRecordDataModel
    {
        public string RecordData { get; set; }
    }

    public class ViewByRIDandBookNameModel
    {
        public string RecordId { get; set; }
        public string BookName { get; set; }
    }


    public class RecordModel : CreateRecordModel
    {
        public int Id { get; set; }

        public virtual MemberModel Members { get; set; }

        public virtual BookModel Books { get; set; }

        public virtual UserModel Users { get; set; }
    }
}
