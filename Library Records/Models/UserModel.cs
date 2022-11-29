using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Records.Models
{
    public class CreateUserModel
    {        
        public string UserName { get; set; }
        
        public string Password { get; set; }
    }

    public class UpdateUserModel : CreateUserModel
    {

    }

    public class ViewByUserNameModel
    {
        public string UserName { get; set; } = "";
    }

    public class UserModel : CreateUserModel
    {
        public int Id { get; set; }

        public virtual List<SecurityQuestionModel> SecurityQuestions { get; set; }
    }
}
