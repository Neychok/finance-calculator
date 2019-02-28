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
        public decimal GPR = 0.0m, obshto_izplateno = 0.0m, obshto_taksi = 0.0m;

        protected void Page_Load(object sender, EventArgs e)
        {
            error1.Text = "";
            error2.Text = "";
            error3.Text = "";
            error5.Text = "";
        }

        //Input1 = Цена на стоката
        //Input2 = Първоначална вноска
        //Input3 = Период на лизинга
        //Input4 = Месечна вноска
        //Input5 = Първоначална такса за обработка


        protected void CalculateResult(object sender, EventArgs e)
        {
            decimal cena = 0.0m, purvaVnoska = 0.0m, period = 0.0m, mesecVnoska = 0.0m, taksa = 0.0m;
            bool _error = false;

            //INPUT
            cena = decimal.Parse(input1.Text); //Цена на стоката
            if (cena < 100 || cena > 100000000)
            {
                _error = true;
                error1.Text = "Цената на стоката трябва да е по-голяма от 100 и по-малка от 100 000 000";
            }
            purvaVnoska = decimal.Parse(input2.Text); //Първоначална вноска
            if (purvaVnoska >= cena || purvaVnoska < 0)
            {
                _error = true;
                error2.Text = "Първата вноска не може да бъде по-голяма от цената на стоката";
            }
            period = decimal.Parse(input3.Text); //Период на лизинга
            if (period > 120 || period <= 0)
            {
                _error = true;
                error3.Text = "Периода не може да бъде по-дълъг от 120 месеца.";
            }
            mesecVnoska = decimal.Parse(input4.Text); //Месечна вноска

            if (mesecVnoska > 10000 || mesecVnoska <= 0)
            {
                _error = true;
                error4.Text = "Месечната вноска не може да бъде 0 или по-голяма от 10 000";
            }
            else if (mesecVnoska >= cena)
            {
                _error = true;
                error4.Text = "Месечната вноска не може да бъде по-голяма или равна на цената на стоката";
            }

            taksa = decimal.Parse(input5.Text); //Първоначална такса за обработка
            if (taksa < 0 || taksa > 10000)
            {
                _error = true;
                error5.Text = "Таксата не може да бъде по-малка от 0 или по-голяма от 10 000";
            }
            else if (taksa >= cena)
            {
                _error = true;
                error5.Text = "Таксата не може да бъде по-голяма от цената на стоката";
            }
            else if (drop5.SelectedIndex == 0 && taksa >= 50)
            {
                _error = true;
                error5.Text = "Таксата не може да бъде повече от 50%";
            }


            //СМЕТКИ
            if (_error == false)
            {
                //ГПР
                GPR = 2m;

                //Общо такси
                if (drop5.SelectedIndex == 0)
                {
                    //obshto_taksi = cena * (taksa / 100);
                }
                else
                {
                    //obshto_taksi = taksa;
                }

                //Общо изплатено
                obshto_izplateno = obshto_taksi + purvaVnoska + (mesecVnoska * period);

                //Закръгляне
                obshto_izplateno = Decimal.Round(obshto_izplateno, 2);
                obshto_taksi = Decimal.Round(obshto_taksi, 2);
                GPR = Decimal.Round(GPR, 4);



            }
            ScriptManager.RegisterStartupScript(this, GetType(), "showLeasingResult", "showLeasingResult()", true);
            // 1 - ГПР
            // 2 - Общо изплатено
            // 3 - общо такси
        }
    }
}