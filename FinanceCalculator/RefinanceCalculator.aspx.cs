using System;
using System.Collections.Generic;
using System.Globalization;
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
            error1.Text = "";
            error2.Text = "";
            error3.Text = "";
            error4.Text = "";
            error5.Text = "";
            error6.Text = "";
            error7.Text = "";
            error8.Text = "";
        }

        //input1 - Размер на кредита
        //input2 - Лихва
        //input3 - Срок на кредита
        //input4 - Брой на направените вноски
        //input5 - Такса за предсрочно погасяване
        //input6 - Лихва /нов кредит/
        //input7 - Първоначални такси % /нов кредит/
        //input8 - Първоначални такси Валута /нов кредит/

        public string _predsrokTaksa, _T_vnoska, _N_vnoska, _T_izplateni, _N_izplateni, _spestVnoska, _spestIzplateni;
        public int T_srok = 0, N_srok = 0;
        public double T_lihva = 0, N_lihva = 0;
        public string izgodno = "";

        protected void CalculateResult(object sender, EventArgs e)
        {
            decimal predsrokTaksa = 0, T_vnoska = 0, N_vnoska = 0, T_izplateni = 0, N_izplateni = 0, spestVnoska = 0, spestIzplateni = 0;
            int napraveniVnoski = 0;
            decimal purvTaksi_val = 0, purvTaksi_proc = 0, Ostat_glavnica = 0, mesecLihva = 0, vnoskaGlavnica = 0, mesecVnoska = 0, creditAmount = 0;
            bool _error = false;


            //РАЗМЕР НА КРЕДИТА
            creditAmount = decimal.Parse(input1.Text);
            if (creditAmount <= 0 || creditAmount > 100000000) //ГРЕШКА - Размера на кредита е по-малък от 0 или по-голям от 100.000.000
            {
                _error = true;
                error1.Text = "Размера на кредита трябва да е по-голям от 0 и по-малък от 100 000 000";
            }

            //ЛИХВА НА ТЕКУЩ КРЕДИТ
            T_lihva = double.Parse(input2.Text, CultureInfo.InvariantCulture);
            if (T_lihva <= 0 || T_lihva >= 100)
            {
                _error = true;
                error2.Text = "Въведете коректно число за Лихва";
            }

            //СРОК НА ТЕКУЩ КРЕДИТ
            T_srok = int.Parse(input3.Text);
            if(T_srok <= 0 || T_srok > 960)
            {
                _error = true;
                error3.Text = "Въведете коретно число за Срок на кредит (месеци)";
            }

            //НАПРАВЕНИ ВНОСКИ
            napraveniVnoski = int.Parse(input4.Text);
            if(napraveniVnoski >= T_srok || napraveniVnoski <= 0)
            {
                _error = true;
                error4.Text = "Въведете коретно число за Направени вноски";
            }

            //ТАКСА ЗА ПРЕДСРОЧНО ПОГАСЯВАНЕ
            predsrokTaksa = decimal.Parse(input5.Text, CultureInfo.InvariantCulture);
            if (predsrokTaksa >= 100 || predsrokTaksa < 0)
            {
                _error = true;
                error5.Text = "Въведете коретно число за Такса предсрочно погасяване (%)";
            }

            //ЛИХВА НА НОВ КРЕДИТ
            N_lihva = double.Parse(input6.Text, CultureInfo.InvariantCulture);
            if (N_lihva <= 0 || N_lihva >= 100)
            {
                _error = true;
                error6.Text = "Въведете коректно число за Лихва";
            }

            //ПЪРВОНАЧАЛНИ ТАКСИ /ПРОЦЕНТ/
            purvTaksi_proc = decimal.Parse(input7.Text, CultureInfo.InvariantCulture);
            if (purvTaksi_proc >= 100 || purvTaksi_proc < 0)
            {
                _error = true;
                error7.Text = "Въведете коретно число за Първоначални такси (%)";
            }

            //ПЪРВОНАЧАЛНИ ТАКСИ /ВАЛУТА/
            purvTaksi_val = decimal.Parse(input8.Text);
            if (purvTaksi_val >= creditAmount || purvTaksi_val < 0)
            {
                _error = true;
                error8.Text = "Въведете коретно число за Първоначални такси (Валута)";
            }

            if (_error == false)
            {
                //СРОК НА НОВ КРЕДИТ
                N_srok = T_srok - napraveniVnoski;

                //ТАКСА ЗА ПРЕДСРОЧНО ПОГАСЯВАНЕ
                Ostat_glavnica = creditAmount;
                for (int i = 0; i <= napraveniVnoski; i++)
                {
                    Ostat_glavnica -= vnoskaGlavnica;
                    mesecLihva = Ostat_glavnica * ((decimal)T_lihva / 12);
                    mesecVnoska = MesechnaVnoska(T_lihva, T_srok - i, Ostat_glavnica);
                    vnoskaGlavnica = mesecVnoska - mesecLihva;
                }
                predsrokTaksa = Ostat_glavnica * (predsrokTaksa / 100);

                //МЕСЕЧНА ВНОСКА /ТЕКУЩ КРЕДИТ/
                T_vnoska = MesechnaVnoska(T_lihva, T_srok, creditAmount);

                //ОБЩО ИЗПЛАТЕНИ /ТЕКУЩ КРЕДИТ/
                T_izplateni = T_vnoska * napraveniVnoski;

                //МЕСЕЧНА ВНОСКА /НОВ КРЕДИТ/
                N_vnoska = MesechnaVnoska(N_lihva, N_srok, creditAmount);

                //ОБЩО ИЗПЛАТЕНИ /НОВ КРЕДИТ/
                N_izplateni = (N_vnoska * N_srok) + predsrokTaksa + (creditAmount * (purvTaksi_proc / 100)) + purvTaksi_val;

                //СПЕСТЯВАНИЯ /ВНОСКА/
                spestVnoska = T_vnoska - N_vnoska;

                //СПЕСТЯВАНИЯ /ИЗПЛАТЕНИ/
                spestIzplateni = T_izplateni - N_izplateni;

                //ПРОВЕРКА ЗА ИЗГОДНОСТ
                if (spestIzplateni < 0)
                {
                    izgodno = "Офертата е НЕИЗГОДНА";
                }
                else
                {
                    izgodno = "Офертата е ИЗГОДНА";
                }

                //ЗАКРЪГЛЯНЕ
                T_vnoska = Decimal.Round(T_vnoska, 2, MidpointRounding.AwayFromZero);
                N_vnoska = Decimal.Round(N_vnoska, 2, MidpointRounding.AwayFromZero);
                predsrokTaksa = Decimal.Round(predsrokTaksa, 2, MidpointRounding.AwayFromZero);
                spestIzplateni = Decimal.Round(spestIzplateni, 2, MidpointRounding.AwayFromZero);
                spestVnoska = Decimal.Round(spestVnoska, 2, MidpointRounding.AwayFromZero);
                N_izplateni = Decimal.Round(N_izplateni, 2, MidpointRounding.AwayFromZero);
                T_izplateni = Decimal.Round(T_izplateni, 2, MidpointRounding.AwayFromZero);

                //Форматиране в String
                _T_vnoska = T_vnoska.ToString("C");
                _N_vnoska = N_vnoska.ToString("C");
                _predsrokTaksa = predsrokTaksa.ToString("C");
                _spestIzplateni = spestIzplateni.ToString("C");
                _spestVnoska = spestVnoska.ToString("C");
                _N_izplateni = N_izplateni.ToString("C");
                _T_izplateni = T_izplateni.ToString("C");

                ScriptManager.RegisterStartupScript(this, GetType(), "showRefinanceResult", "showRefinanceResult()", true);
            }
        }
        protected decimal MesechnaVnoska(double interest, int months, decimal credit)
        {
            decimal b = (decimal)Math.Pow((interest / 12) + 1.0, -months);
            decimal monthlyPayments = credit * ((decimal)interest / 12) / (1 - b);
            return monthlyPayments;
        }
    }
}