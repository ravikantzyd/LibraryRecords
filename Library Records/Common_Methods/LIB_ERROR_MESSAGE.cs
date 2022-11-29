using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Records.Common_Methods
{
    public class LIB_ERROR_MESSAGE
    {
        public static void HttpRequestExceptionMessage(HttpRequestException ex)
        {
            MessageBox.Show("Message :=> Please connect to the server."
                    + "\n\nError Message :=> " + ex.Message
                    + "\n\nError Stacktrace :=> " + ex.StackTrace
                    + "\n\nError Source :=> " + ex.Source,
                    "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ExceptionMessage(Exception ex)
        {
            MessageBox.Show("Error Message :=> " + ex.Message
                    + "\n\nError Stacktrace :=> " + ex.StackTrace
                    + "\n\nError Source :=> " + ex.Source,
                    "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
