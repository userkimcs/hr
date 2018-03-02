
using System.Web;
namespace HR.Core.Helpers
{
    public class JsHelper
    {
        public static void Alert(string message)
        {
            HttpContext.Current.Response.Write("<script>alert('" + message + "');</script>");
        }
    }
}
