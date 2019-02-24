using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.VisualBasic;

namespace FinanceCalculator
{
    public partial class CreditCalculator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            error1.Text = "";
            error2.Text = "";
            error3.Text = "";
            error5.Text = "";
            error6.Text = "";
            error7.Text = "";
            error8.Text = "";
            error9.Text = "";
            error10.Text = "";
            error11.Text = "";
            error12.Text = "";
            error13.Text = "";
            error14.Text = "";
        }
        public decimal GPR = 0, vnoski = 0, lihvi = 0, taksi = 0, pogaseni = 0;

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
            double creditAmount = 0.0, interestRate = 0.0,promoInterest = 0.0, promoVnoski = 0.0,Vnoska_glavnica = 0.0,Ostat_glavnica=0.0; 
            int Months = 0,promoMonths = 0,tempMonths = 0;
            double years = 0.0;
            double monthlyPayments = 0.0, temp = 0.0, temp2 = 0.0;
            double fee_kandi = 0.0, fee_obrabot = 0.0, fee_drug = 0.0, yearFee_upr = 0.0, yearFee_drug = 0.0, monthFee_upr = 0.0, monthFee_drug = 0.0; // Такси
            bool _error = false;

            //ВНОСКИ - Input/проверка/сметки
                //Input
            creditAmount = double.Parse(input1.Text);
            Months = int.Parse(input2.Text);
            interestRate = double.Parse(input3.Text);

            interestRate = interestRate / 100; //Превръщане на лихвата в проценти

            //Проверка
            if (creditAmount < 100)
            {
                _error = true;
                error1.Text = "Моля въведете размер на кредита по - голям от 100";
            }
            if (Months <= 0 || Months > 960)
            {
                _error = true;
                error2.Text = "Моля въведете коректно число за срок (до 960 месеца)";
            }
            if (interestRate < 0)
            {
                _error = true;
                error3.Text = "Моля въведете коректно число за лихва";
            }

            //Промоционални месеци
            if (!String.IsNullOrWhiteSpace(input5.Text) && !String.IsNullOrWhiteSpace(input6.Text))
            {
                promoMonths = int.Parse(input5.Text);
                promoInterest = int.Parse(input6.Text);
                promoInterest = promoInterest / 100; //Превръщане на лихвата в проценти
                if (promoMonths >= Months || promoMonths <=0)
                {
                    _error = true;
                    error5.Text = "Моля въведете коректно число за промоционални месеци";
                }
                if (promoInterest < 0)
                {
                    _error = true;
                    error5.Text = "Моля въведете коректно число за промоционалнa лихва";
                }
                if (_error == false) //СМЕТКИ, с промо
                {
                    for (int i = 0; i < Months; i++)
                    {
                        Ostat_glavnica = creditAmount - Vnoska_glavnica;
                        if (i < promoMonths)
                        {
                            temp = MesechnaVnoska(promoInterest, Months - i, Ostat_glavnica);
                            temp2 = MesechnaVnoska(promoInterest, 1, Ostat_glavnica) - Ostat_glavnica;
                        }
                        else
                        {
                            temp = MesechnaVnoska(interestRate, Months - i, Ostat_glavnica);
                            temp2 = MesechnaVnoska(interestRate, 1, Ostat_glavnica) - Ostat_glavnica;
                        }
                        Vnoska_glavnica = Vnoska_glavnica + (temp - temp2);
                        vnoski += (decimal)temp;
                    }
                    temp = 0.0;
                    temp2 = 0.0;
                }
            }
            else if (String.IsNullOrWhiteSpace(input5.Text) && !String.IsNullOrWhiteSpace(input6.Text)) //Ако първото поле е празно
            {
                _error = true;
                error5.Text = "Моля въведете число за промоционални месеци";
            }
            else if(!String.IsNullOrWhiteSpace(input5.Text) && String.IsNullOrWhiteSpace(input6.Text)) //Ако второто поле е празно
            {
                _error = true;
                error6.Text = "Моля въведете число за промоционална лихва";
            }

            if(_error == false) //СМЕТКИ, без промо
            {
                for (int i = 0; i < Months; i++)
                {
                    Ostat_glavnica = creditAmount - Vnoska_glavnica;
                    temp = MesechnaVnoska(interestRate, Months-i, Ostat_glavnica);
                    temp2 = MesechnaVnoska(interestRate, 1, Ostat_glavnica) - Ostat_glavnica;
                    Vnoska_glavnica = Vnoska_glavnica + (temp - temp2);
                    vnoski += (decimal)temp;
                }
                temp = 0.0;
                temp2 = 0.0;

            }

            // //

            if ((Months / 12.0) > 1.0) //Брой години
            {
                years = (Months - 1) / 12;
                years = Math.Floor(years);
            }

            //ТАКСИ - Input / Проверка / Трансформиране в проценти / Сметки
            if (!String.IsNullOrWhiteSpace(input8.Text)) //ТАКСА КАНДИДАТСТВАНЕ
            {
                fee_kandi = double.Parse(input8.Text);
                if (fee_kandi < 0 || fee_kandi >= creditAmount)
                {
                    _error = true;
                    error8.Text = "Моля въведете коректно число за такса кандидатстване";
                }
                if (drop8.SelectedIndex == 1) //Ако е в проценти
                {
                    fee_kandi = fee_kandi / 100;
                    fee_kandi = creditAmount * fee_kandi;
                }
            }

            if (!String.IsNullOrWhiteSpace(input9.Text)) //ТАКСА ОБРАБОТКА
            {
                fee_obrabot = double.Parse(input9.Text);
                if (fee_obrabot < 0 || fee_obrabot >= creditAmount)
                {
                    _error = true;
                    error9.Text = "Моля въведете коректно число за такса обработване";
                }
                if (drop9.SelectedIndex == 1) //Ако е в проценти
                {
                    fee_obrabot = fee_obrabot / 100;
                    fee_obrabot = creditAmount * fee_obrabot;
                }
            }

            if (!String.IsNullOrWhiteSpace(input10.Text)) //ДРУГИ ТАКСИ
            {
                fee_drug = double.Parse(input10.Text);
                if (fee_drug < 0 || fee_drug >= creditAmount)
                {
                    _error = true;
                    error10.Text = "Моля въведете коректно число за други такси";
                }
                if (drop10.SelectedIndex == 1) //Ако е в проценти
                {
                    fee_drug = fee_drug / 100;
                    fee_drug = creditAmount * fee_drug;
                }
            }

            if (!String.IsNullOrWhiteSpace(input11.Text) && years >= 1) //ГОДИШНА ТАКСА УПРАВЛЕНИЕ
            {
                yearFee_upr = double.Parse(input11.Text);
                if (yearFee_upr < 0 || yearFee_upr >= creditAmount)
                {
                    _error = true;
                    error11.Text = "Моля въведете коректно число за годишна такса";
                }
                if (drop11.SelectedIndex == 1) //Ако е в проценти
                {
                    yearFee_upr = yearFee_upr / 100;
                    temp2 = (double)vnoski;
                    for (int i = 0; i < years; i++)
                    {
                        temp = temp + ((temp2 - (monthlyPayments * 12)) * yearFee_upr);
                        temp2 = temp2 - (monthlyPayments * 12);
                    }
                    yearFee_upr = temp;
                    temp = 0.0;
                    temp2 = 0.0;
                }
                else //Ако е във валута
                {
                    yearFee_upr = yearFee_upr * years;
                }
            }

            if (!String.IsNullOrWhiteSpace(input12.Text) && years >= 1) //ГОДИШНА ТАКСА ДРУГА
            {
                yearFee_drug = double.Parse(input12.Text);
                if (yearFee_drug < 0 || yearFee_drug >= creditAmount)
                {
                    _error = true;
                    error12.Text = "Моля въведете коректно число за годишна такса";
                }
                if (drop12.SelectedIndex == 1) //Ако е в проценти
                {
                    yearFee_drug = yearFee_drug / 100;
                    temp2 = (double)vnoski;
                    for (int i = 0; i < years; i++)
                    {
                        temp = temp + ((temp2 - (monthlyPayments * 12)) * yearFee_drug);
                        temp2 = temp2 - (monthlyPayments * 12);
                    }
                    yearFee_drug = temp;
                    temp = 0.0;
                    temp2 = 0.0;
                }
                else //Ако е във валута
                {
                    yearFee_drug = yearFee_drug * years; 
                }
            }

            if (!String.IsNullOrWhiteSpace(input13.Text)) //МЕСЕЧНА ТАКСА УПРАВЛЕНИЕ
            {
                monthFee_upr = double.Parse(input13.Text);
                if (monthFee_upr < 0 || monthFee_upr >= creditAmount)
                {
                    _error = true;
                    error13.Text = "Моля въведете коректно число за месечна такса";
                }
                if (drop13.SelectedIndex == 1) //Ако е в проценти
                {
                    monthFee_upr = monthFee_upr / 100;
                    temp2 = (double)vnoski;
                    temp = temp2 * monthFee_upr;
                    for (int i = 1; i < Months; i++)
                    {
                        temp = temp + (temp2 - monthlyPayments) * monthFee_upr;
                        temp2 = temp2 - monthlyPayments;
                    }
                    monthFee_upr = temp;
                    temp = 0.0;
                    temp2 = 0.0;
                }
                else //Ако е във валута
                {
                    monthFee_upr = monthFee_upr * Months;
                }
            }

            if (!String.IsNullOrWhiteSpace(input14.Text)) //МЕСЕЧНА ТАКСА ДРУГА
            {
                monthFee_drug = double.Parse(input14.Text);
                if (monthFee_drug < 0 || monthFee_drug >= creditAmount)
                {
                    _error = true;
                    error14.Text = "Моля въведете коректно число за месечна такса";
                }
                if (drop14.SelectedIndex == 1) //Ако е в проценти
                {
                    monthFee_drug = monthFee_drug / 100;
                    temp2 = (double)vnoski;
                    temp = temp2 * monthFee_drug;
                    for (int i = 1; i < Months; i++)
                    {
                        temp = temp + (temp2 - monthlyPayments) * monthFee_drug;
                        temp2 = temp2 - monthlyPayments;
                    }
                    monthFee_drug = temp;
                    temp = 0.0;
                    temp2 = 0.0;
                }
                else //Ако е във валута
                {
                    monthFee_drug = monthFee_drug * Months;
                }
            }


            //СМЕТКИ
            if (_error == false)
            {
                //ГПР
                GPR = ((decimal)Math.Pow((interestRate/12) + 1.0, 12) - 1) * 100;

                //ЛИХВИ
                lihvi = vnoski - (decimal)creditAmount;

                //ТАКСИ 
                taksi = (decimal)fee_kandi + (decimal)fee_drug + (decimal)fee_obrabot + (decimal)monthFee_upr + (decimal)monthFee_drug + (decimal)yearFee_upr + (decimal)yearFee_drug;

                //ПОГАСЕНИ
                pogaseni = vnoski + taksi;

                // Закръгляне на числата
                taksi = Decimal.Round(taksi, 2);
                vnoski =Decimal.Round(vnoski, 2);
                pogaseni = Decimal.Round(pogaseni, 2);
                GPR = Decimal.Round(GPR, 4);
                lihvi = Decimal.Round(lihvi, 2);

                //Таблица
                ScriptManager.RegisterStartupScript(this, GetType(), "showCreditResult", "showCreditResult()", true);
                //Първи ред ----- ГОДИШЕН ПРОЦЕНТЕН РАЗХОД
                //Втори ред ----- ПОГАСЕНИ С ЛИХВИ И ТАКСИ
                //Трети ред ----- ТАКСИ И КОМИСИОННИ
                //Четвърти ред -- ЛИХВИ
                //Пети ред ------ ВНОСКИ
            }
        }
        protected double MesechnaVnoska(double interest,int months,double credit)
        { 
            double b = Math.Pow((interest/12)+1.0, -months);
            double monthlyPayments = credit * (interest/12) / (1 - b);
            return monthlyPayments;
        }
    }
}

            