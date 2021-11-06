using System;
using System.Web.UI;
using DAL;
using System.Linq;

namespace WebApplicationDemo
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            WestwindEntities context = ObjectContextPerHttpRequest.Context;
            GridView1.DataSource = from c in context.Customers select c;
            GridView1.DataBind();
        }
    }
}
