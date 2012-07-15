IAnswerable.Web
===============

<h6>Use of IAnswerable.Web.WebPage.Page<T> class</h6>


this is base class for webpages you can remove System.Web.UI.Page class and add this for warpping query string strongly typed. check below code

<ul>
    <li>QueryStringModel : this property for accessing all property of query string</li>
    <li>GetQueryString() : this method for getting query string as string</li>
</ul>
<pre>
<code>
using IAnswerable.Web.Core; 
namespace MyWebFormApplication
{
    public partial class _Default : IAnswerable.Web.WebPage.Page&lt;ProductQueryString>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write(QueryStringModel.CategoryID);
            Response.Write(QueryStringModel.QueryText);
            Response.Write(QueryStringModel.PriceRange);
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            QueryStringModel.CategoryID = ddlCategory.SelectedValue;
            QueryStringModel.QueryText = txtSearch.Text;
            QueryStringModel.PriceRange = ddlPriceRange.SelectedValue;
            
            Response.Redirect("search.aspx?" + GetQueryString());
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