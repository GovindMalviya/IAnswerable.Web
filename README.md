IAnswerable.Web
===============

Use of IAnswerable.Web.WebPage.Page<T> class
============================================

this is base class for webpages you can remove System.Web.UI.Page class and add this for warpping query string strongly typed. check below code
<pre>
<code>
using IAnswerable.Web.Core; 
namespace MyWebFormApplication
{
    public partial class _Default : IAnswerable.Web.WebPage.Page<ProductQueryString>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write(QueryStringModel.CategoryID);
            Response.Write(QueryStringModel.QueryText);
            Response.Write(QueryStringModel.PriceRange);
        }
    }
    public class ProductQueryString
    {
        [Key("cat")]
        public string CategoryID { get; set; }

        [Key("q")]
        public string QueryText { get; set; }

        [Key("range")]
        public string PriceRange { get; set; }
    }
}
</code>
</pre>