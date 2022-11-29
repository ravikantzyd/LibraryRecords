using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Records.Common_Methods
{
    public class LIB_FORM_CLEAR
    {
        public event EventHandler On_Clear_To_New_Form_Event;

        public void Form_Clear()
        {
            On_Clear_To_New_Form_Event?.Invoke(this, EventArgs.Empty);
        }
    }
}
