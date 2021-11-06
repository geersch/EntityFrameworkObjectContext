using System.Web;
using DAL;

namespace WebApplicationDemo
{
    public static class ObjectContextPerHttpRequest
    {
        public static WestwindEntities Context
        {
            get
            {
                string objectContextKey = HttpContext.Current.GetHashCode().ToString("x");
                if (!HttpContext.Current.Items.Contains(objectContextKey))
                {
                    HttpContext.Current.Items.Add(objectContextKey, new WestwindEntities());
                }
                return HttpContext.Current.Items[objectContextKey] as WestwindEntities;
            }
        }
    }
}
