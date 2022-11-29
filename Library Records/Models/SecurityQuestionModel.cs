using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Records.Models
{
    public class CreateSecurityQuestionModel
    {       
        public string Question { get; set; }
        
        public string Answer { get; set; }
        
        public int UserId { get; set; }
    }

    public class UpdateSecurityQuestionModel : CreateSecurityQuestionModel
    {

    }

    public class ViewBySecurityQuestionModel : CreateSecurityQuestionModel
    {

    }

    public class SecurityQuestionModel : CreateSecurityQuestionModel
    {
        public int Id { get; set; }

        public virtual UserModel Users { get; set; }
    }
}
