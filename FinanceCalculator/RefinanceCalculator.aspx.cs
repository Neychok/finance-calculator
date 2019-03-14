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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //input1 - Размер на кредита
        //input2 - Лихва
        //input3 - Срок на кредита
        //input4 - Брой на направените вноски
        //input5 - Такса за предсрочно погасяване
        //input6 - Лихва /нов кредит/
        //input7 - Първоначални такси % /нов кредит/
        //input8 - Първоначални такси Валута /нов кредит/
        public decimal T_lihva = 0, N_lihva = 0;
        protected void CalculateResult(object sender, EventArgs e)
        {





            ScriptManager.RegisterStartupScript(this, GetType(), "showRefinanceResult", "showRefinanceResult()", true);
        }
    }
}