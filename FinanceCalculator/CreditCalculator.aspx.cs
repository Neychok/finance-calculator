using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinanceCalculator
{
    public partial class CreditCalculator : System.Web.UI.Page
    {
        public double gpr,vnoski,lihvi,taksi,pogaseni = 0.0;

        //Input1 = Credit Amount / Размер на кредит -- Валута -------
        //Input2 = Months / Срок --------------------- Месеци -------
        //Input3 = Interest Rate / Лихва ------------- % ------------
        //Input4 = Credit Type / Вид вноски ---------- Вид ----------
        //Input5 = Промоционален перид --------------- Месеци -------
        //Input6 = Промоционална лихва --------------- % ------------
        //Input7 = Гратисен период ------------------- Месеци -------
        //Input8 = Такса кандидатстване -------------- % или валута -
        //Input9 = Такса обработка ------------------- % или валута -
        //Input10 = Други такси ---------------------- % или валута -
        //Input11 = Годишна такса управление --------- % или валута -
        //Input12 = Други годишни такси -------------- % или валута -
        //Input13 = Месечна такса управление --------- % или валута -
        //Input14 = Други месечни такси -------------- % или валута -

        protected void CalculateResult(object sender, EventArgs e)
        {
            double creditAmount,interestRate,Months = 0.0; // Inputs
            double monthlyPayments, R = 0.0;
            //Input
            creditAmount = double.Parse(input1.Text);
            Months = double.Parse(input2.Text);
            interestRate = double.Parse(input3.Text);
            //

            //Calculation
            interestRate = interestRate / 100.0;
            R = interestRate / 12.0;
            double a = 1.0 + R;
            double b = Math.Pow(a, Months);
            monthlyPayments = creditAmount * R * b / (b - 1.0);
            vnoski = monthlyPayments * Months; //-----------------------------------------ВНОСКИ
            lihvi = vnoski - creditAmount; //---------------------------------------------ЛИХВИ
            pogaseni = vnoski + taksi; //-------------------------------------------------ПОГАСЕНИ

            //

            ScriptManager.RegisterStartupScript(this, GetType(), "showCreditResult", "showCreditResult()", true);
            //Първи ред ----- ГОДИШЕН ПРОЦЕНТЕН РАЗХОД
            //Втори ред ----- ПОГАСЕНИ С ЛИХВИ И ТАКСИ
            //Трети ред ----- ТАКСИ И КОМИСИОННИ
            //Четвърти ред -- ЛИХВИ
            //Пети ред ------ ВНОСКИ
        }
    }
}
