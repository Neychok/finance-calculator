using System;
using System.Web.UI;

namespace FinanceCalculator
{
    public partial class LeasingCalculator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            error1.Text = "";
            error2.Text = "";
            error3.Text = "";
            error4.Text = "";
            error5.Text = "";
        }

        public string _GPR, _obshto_izplateno, _obshto_taksi;

        //Input1 = Цена на стоката
        //Input2 = Първоначална вноска
        //Input3 = Период на лизинга
        //Input4 = Месечна вноска
        //Input5 = Първоначална такса за обработка

        protected void CalculateResult(object sender, EventArgs e)
        {
            decimal GPR = 0.0m, obshto_izplateno = 0.0m, obshto_taksi = 0.0m;
            decimal cena = 0.0m, purvaVnoska = 0.0m, mesecVnoska = 0.0m, taksa = 0.0m;
            int period = 0;
            bool _error = false;

            //ЦЕНА НА СТОКАТА
            cena = decimal.Parse(input1.Text);
            if (cena < 100 || cena > 100000000) //ГРЕШКА - Цената на стоката е по-малка от 100 или по-голяма от 100.000.000
            {
                _error = true;
                error1.Text = "Цената на стоката трябва да е по-голяма от 100 и по-малка от 100 000 000";
            }

            //ПЪРВОНАЧАЛНА ВНОСКА
            purvaVnoska = decimal.Parse(input2.Text);
            if (purvaVnoska >= cena || purvaVnoska < 0) //ГРЕШКА - Първоначалната вноска е по-голяма или равна на цената на стоката, или е по-малка от 0
            {
                _error = true;
                error2.Text = "Първата вноска не може да бъде по-голяма от цената на стоката";
            }

            //ПЕРИОД НА ЛИЗИНГА
            period = int.Parse(input3.Text);
            if (period > 120 || period <= 0) //ГРЕШКА - Периода на лизинга е по-голям от 120 месеца или е по-малък или равен на 0
            {
                _error = true;
                error3.Text = "Периода не може да бъде по-дълъг от 120 месеца.";
            }

            //МЕСЕЧНА ВНОСКА
                mesecVnoska = decimal.Parse(input4.Text);
                if (mesecVnoska > 10000 || mesecVnoska <= 0) //ГРЕШКА - Месечната вноска е по-голяма от 10.000 или е по-малка от 0
                {
                    _error = true;
                    error4.Text = "Месечната вноска не може да бъде 0 или по-голяма от 10 000";
                }
                else if (mesecVnoska >= cena) //ГРЕШКА - Месечната вноска е по-голяма от цената на стоката
                {
                    _error = true;
                    error4.Text = "Месечната вноска не може да бъде по-голяма или равна на цената на стоката";
                }

            //ПЪРВОНАЧАЛНА ТАКСА ОБРАБОТКА
            if (!String.IsNullOrWhiteSpace(input5.Text)){
                taksa = decimal.Parse(input5.Text); 

                if (taksa < 0 || taksa > 10000) //ГРЕШКА - Ако таксата е по-малка от нула или по-голяма от 10.000
                {
                    _error = true;
                    error5.Text = "Таксата не може да бъде по-малка от 0 или по-голяма от 10 000";
                }
                else if (taksa >= cena) //ГРЕШКА - Ако таксата е по-голяма от цената на стоката
                {
                    _error = true;
                    error5.Text = "Таксата не може да бъде по-голяма от цената на стоката";
                }
                else if (drop5.SelectedIndex == 0 && taksa >= 50) //ГРЕШКА - Ако са избрани проценти и са повече от 50%
                {
                    _error = true;
                    error5.Text = "Таксата не може да бъде повече от 50%";
                }
            }

            //СМЕТКИ
            if (_error == false)
            {
                //----Общо такси----
                if (drop5.SelectedIndex == 0) //Ако е избрано "Проценти"
                {
                    obshto_taksi = cena * (taksa / 100);
                }
                else //Ако е избрано "Валута"
                {
                    obshto_taksi = taksa;
                }

                //----Общо изплатено----
                obshto_izplateno = obshto_taksi + purvaVnoska + (mesecVnoska * period);

                //----ГПР----
                double interestGPR = Microsoft.VisualBasic.Financial.Rate(period, (double)-mesecVnoska, (double)(cena-purvaVnoska - obshto_taksi)) * 12;
                GPR = (decimal)Math.Pow((interestGPR / 12) + 1.0, 12) - 1;

                //----Закръгляне----
                obshto_izplateno = Decimal.Round(obshto_izplateno, 2);
                obshto_taksi = Decimal.Round(obshto_taksi, 2);
                GPR = Decimal.Round(GPR, 4);

                //Форматиране в String
                _obshto_izplateno = obshto_izplateno.ToString("C");
                _obshto_taksi = obshto_taksi.ToString("C");
                _GPR = GPR.ToString("P");
            }
            ScriptManager.RegisterStartupScript(this, GetType(), "showLeasingResult", "showLeasingResult()", true);
        }
    }
}