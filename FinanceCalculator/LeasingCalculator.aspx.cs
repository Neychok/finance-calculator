using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinanceCalculator
{
    public partial class LeasingCalculator : System.Web.UI.Page
    {
        public int val = -1997;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void CalculateResult(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showLeasingResult", "showLeasingResult()", true);
        }
    }
}