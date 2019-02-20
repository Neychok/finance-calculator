using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinanceCalculator
{
    public partial class RefinanceCalculator : System.Web.UI.Page
    {
        public double val = 2.5;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CalculateResult(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showRefinanceResult", "showRefinanceResult()", true);
        }
    }
}