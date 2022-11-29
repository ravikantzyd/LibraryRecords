using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Records.Models
{
    public class CreateMemberModel
    {
        [Required]
        [MaxLength(60)]
        public string MemberId { get; set; }

        [Required]
        [MaxLength(300)]
        public string MemberName { get; set; }

        [Required]
        [MaxLength(60)]
        public string RNPost { get; set; }

        [Required]
        [MaxLength(500)]
        public string ClassDepartment { get; set; }
    }

    public class UpdateMemberModel : CreateMemberModel
    {

    }

    public class ViewByMemberNameModel
    {
        public string MemberName { get; set; } = "";
    }

    public class ViewByMemberIdModel
    {
        public string MemberId { get; set; } = "";
    }

    public class SearchByMemberDataModel
    {
        public string MemberData { get; set; }
    }

    public class MemberModel : CreateMemberModel
    {
        public int Id { get; set; }

        public virtual List<RecordModel> Records { get; set; }
    }
}
