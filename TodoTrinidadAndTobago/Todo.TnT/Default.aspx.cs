using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Todo.TnT
{
    public partial class _Default : Page
    {
        protected string Category;

        protected void Page_Load(object sender, EventArgs e)
        {
            List<string> categories = new List<string>()
            {
                "Visiting Friends & Relatives", 
                "Leisure",
                "Business",
                "Wedding/Honeymoon",
                "Study",
                "Other"
            };

            Category = GetCurrentCategory();
            categoriesDdl.DataSource = categories;
            categoriesDdl.DataBind();
        }

        private string GetCurrentCategory()
        {
            return "Leisure";
        }
    }
}