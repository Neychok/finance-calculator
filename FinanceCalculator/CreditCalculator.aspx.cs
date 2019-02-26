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
        //Input4 = Credit Type / Вид вноски ---------- Вид ---------- drop_vid
        //Input5 = Промоционален перид --------------- Месеци -------
        //Input6 = Промоционална лихва --------------- % ------------
        //Input7 = Гратисен период ------------------- Месеци -------
        //Input8 = Такса кандидатстване -------------- % или валута - drop8
        //Input9 = Такса обработка ------------------- % или валута - drop9
        //Input10 = Други такси ---------------------- % или валута - drop10
        //Input11 = Годишна такса управление --------- % или валута - drop11
        //Input12 = Други годишни такси -------------- % или валута - drop12
        //Input13 = Месечна такса управление --------- % или валута - drop13
        //Input14 = Други месечни такси -------------- % или валута - drop14

        protected void CalculateResult(object sender, EventArgs e)
        {
            double creditAmount = 0.0, interestRate = 0.0, promoInterest = 0.0, Vnoska_glavnica = 0.0, Ostat_glavnica = 0.0;
            int Months = 0, promoMonths = 0,gratis = 0;
            double years = 0.0;
            double mesecLihva = 0.0, mesecVnoska = 0.0;
            double fee_kandi = 0.0, fee_obrabot = 0.0, fee_drug = 0.0, yearFee_upr = 0.0, yearFee_drug = 0.0, monthFee_upr = 0.0, monthFee_drug = 0.0; // Такси
            bool _error = false, promo = false, _gratis = false;

            //ВНОСКИ - Input/проверка/сметки
            //Input
            creditAmount = double.Parse(input1.Text);
            Months = int.Parse(input2.Text);
            interestRate = double.Parse(input3.Text);

            interestRate = interestRate / 100; //Превръщане на лихвата в проценти

            //Проверка
            if (creditAmount < 100) //ГРЕШКА - Ако кредита е по-малък от 100лв
            {
                _error = true;
                error1.Text = "Моля въведете размер на кредита по - голям от 100";
            }
            if (Months <= 0 || Months > 960)//ГРЕШКА - Ако месеците са по-малко от 0 и по-големи от 960
            {
                _error = true;
                error2.Text = "Моля въведете коректно число за срок (до 960 месеца)";
            }
            if (interestRate < 0)//ГРЕШКА - Ако лихвата е под 0
            {
                _error = true;
                error3.Text = "Моля въведете коректно число за лихва";
            }

            if ((Months / 12.0) > 1.0) //Брой години
            {
                years = (Months - 1) / 12;
                years = Math.Floor(years);
            }

            //ПРОМОЦИОНАЛНИ МЕСЕЦИ
            if (!String.IsNullOrWhiteSpace(input5.Text) && !String.IsNullOrWhiteSpace(input6.Text))
            {
                promoMonths = int.Parse(input5.Text);
                promoInterest = int.Parse(input6.Text);
                promoInterest = promoInterest / 100; //Превръщане на лихвата в проценти
                if (promoMonths >= Months || promoMonths <= 0) //ГРЕШКА - Ако промоционалните месеци са по-малко или равни на 0; са повече от срока на кредита
                {
                    _error = true;
                    error5.Text = "Моля въведете коректно число за промоционални месеци";
                }
                if (promoInterest < 0) //ГРЕШКА - Ако промоционалната лихва е по-малка от 0
                {
                    _error = true;
                    error5.Text = "Моля въведете коректно число за промоционалнa лихва";
                }
                if (_error == false) // ПРОМО = True
                {
                    promo = true;
                }
            }
            else if (String.IsNullOrWhiteSpace(input5.Text) && !String.IsNullOrWhiteSpace(input6.Text)) //ГРЕШКА - Ако първото поле е празно
            {
                _error = true;
                error5.Text = "Моля въведете число за промоционални месеци";
            }
            else if (!String.IsNullOrWhiteSpace(input5.Text) && String.IsNullOrWhiteSpace(input6.Text)) //ГРЕШКА - Ако второто поле е празно
            {
                _error = true;
                error6.Text = "Моля въведете число за промоционална лихва";
            }

            //ГРАТИСЕН ПЕРИОД
            if (!String.IsNullOrWhiteSpace(input7.Text))
            {
                gratis = int.Parse(input7.Text);
                if (gratis >= Months || gratis <= 0) //ГРЕШКА - Ако гратисния период е по-дълъг от срока на кредита; е по-малък или равен на 0
                {
                    _error = true;
                    error7.Text = "Моля въведете коректно число за гратисен период (гратисният период трябва да е по-малък от срока на кредита)";
                }
                _gratis = true;
            }

            //ТАКСИ
            if (!String.IsNullOrWhiteSpace(input8.Text)) //ТАКСА КАНДИДАТСТВАНЕ - Процент от целия кредит / Единична фиксирана сума
            {
                fee_kandi = double.Parse(input8.Text);
                if (fee_kandi < 0 || fee_kandi >= creditAmount) //ГРЕШКА - Ако такса кандидатстване е по-малка от 0 или е по-голяма или равна на кредита
                {
                    _error = true;
                    error8.Text = "Моля въведете коректно число за такса кандидатстване";
                }
                if (drop8.SelectedIndex == 1) //Ако е в проценти
                {
                    fee_kandi = fee_kandi / 100;
                    taksi = taksi + (decimal)(creditAmount * fee_kandi);
                }
                else
                {
                    taksi += (decimal)fee_kandi;
                }
            }

            if (!String.IsNullOrWhiteSpace(input9.Text)) //ТАКСА ОБРАБОТКА - Процент от целия кредит / Единична фиксирана сума
            {
                fee_obrabot = double.Parse(input9.Text);
                if (fee_obrabot < 0 || fee_obrabot >= creditAmount) //ГРЕШКА - Ако такса обработка е по-малка от 0 или е по-голяма или равна на кредита
                {
                    _error = true;
                    error9.Text = "Моля въведете коректно число за такса обработване";
                }
                if (drop9.SelectedIndex == 0) //Ако е в проценти
                {
                    fee_obrabot = fee_obrabot / 100;
                    taksi = taksi + (decimal)(creditAmount * fee_obrabot);
                }
                else
                {
                    taksi += (decimal)fee_obrabot;
                }
            }

            if (!String.IsNullOrWhiteSpace(input10.Text)) //ДРУГИ ТАКСИ - Процент от целия кредит / Единична фиксирана сума
            {
                fee_drug = double.Parse(input10.Text);
                if (fee_drug < 0 || fee_drug >= creditAmount) //ГРЕШКА - Ако друга такса е по-малка от 0 или е по-голяма или равна на кредита
                {
                    _error = true;
                    error10.Text = "Моля въведете коректно число за други такси";
                }
                if (drop10.SelectedIndex == 1) //Ако е в проценти
                {
                    fee_drug = fee_drug / 100;
                    taksi = taksi + (decimal)(creditAmount * fee_drug);
                }
                else
                {
                    taksi += (decimal)fee_drug;
                }
            }

            if (!String.IsNullOrWhiteSpace(input11.Text) && years >= 1) //ГОДИШНА ТАКСА УПРАВЛЕНИЕ - Процент от вносната главница на първия месец на следващата година / фиксирана сума 
            {
                yearFee_upr = double.Parse(input11.Text);
                if (yearFee_upr < 0 || yearFee_upr >= creditAmount) //ГРЕШКА - Ако годишна такса управление е по-малка от 0 или е по-голяма или равна на кредита
                {
                    _error = true;
                    error11.Text = "Моля въведете коректно число за годишна такса";
                }
                if (drop11.SelectedIndex == 0) //Ако е в проценти
                {
                    yearFee_upr = yearFee_upr / 100;
                }
            }

            if (!String.IsNullOrWhiteSpace(input12.Text) && years >= 1) //ГОДИШНА ТАКСА ДРУГА - Процент от вносната главница на първия месец на следващата година / фиксирана сума
            {
                yearFee_drug = double.Parse(input12.Text);
                if (yearFee_drug < 0 || yearFee_drug >= creditAmount) //ГРЕШКА - Ако друга годишна такса е по-малка от 0 или е по-голяма или равна на кредита
                {
                    _error = true;
                    error12.Text = "Моля въведете коректно число за годишна такса";
                }
                if (drop12.SelectedIndex == 1) //Ако е в проценти
                {
                    yearFee_drug = yearFee_drug / 100;
                }
            }

            if (!String.IsNullOrWhiteSpace(input13.Text)) //МЕСЕЧНА ТАКСА УПРАВЛЕНИЕ - Процент от вносната главница / фиксирана сума
            {
                monthFee_upr = double.Parse(input13.Text);
                if (monthFee_upr < 0 || monthFee_upr >= creditAmount) //ГРЕШКА - Ако месечна такса обработка е по-малка от 0 или е по-голяма или равна на кредита
                {
                    _error = true;
                    error13.Text = "Моля въведете коректно число за месечна такса";
                }
                if (drop13.SelectedIndex == 0) //Ако е в проценти
                {
                    monthFee_upr = monthFee_upr / 100;
                }
            }

            if (!String.IsNullOrWhiteSpace(input14.Text)) //МЕСЕЧНА ТАКСА ДРУГА  Процент от вносната главница / фиксирана сума
            {
                monthFee_drug = double.Parse(input14.Text);
                if (monthFee_drug < 0 || monthFee_drug >= creditAmount) //ГРЕШКА - Ако друга месечна такса е по-малка от 0 или е по-голяма или равна на кредита
                {
                    _error = true;
                    error14.Text = "Моля въведете коректно число за месечна такса";
                }
                if (drop14.SelectedIndex == 1) //Ако е в проценти
                {
                    monthFee_drug = monthFee_drug / 100;
                }
            }


            if (_error == false) //СМЕТКИ
            {
                Ostat_glavnica = creditAmount;

                for (int i = 0; i < Months; i++) //Цикъл, който смята за всеки месец от периода на кредита
                {
                    if (i == gratis) //Проверка дали е изтекал гратисния период
                    {
                        _gratis = false;
                    }

                    if (_gratis == false)
                    {
                        Ostat_glavnica -= Vnoska_glavnica; //Остатък главница
                    }

                    if (drop_vid.SelectedIndex == 1 && _gratis == false) //За намаляващи вноски - Вноска главница
                    {
                        Vnoska_glavnica = creditAmount / (Months - gratis);
                    }

                    if (i < promoMonths && promo == true)
                    {
                        mesecLihva = Ostat_glavnica * promoInterest / 12; //Месечна лихва (Промо)
                        if (_gratis == false)
                        {
                            if (drop_vid.SelectedIndex == 0) //За анюитетни вноски - Месечна вноска (Промо)
                            {
                                mesecVnoska = MesechnaVnoska(promoInterest, Months - i, Ostat_glavnica);
                            }

                            if (drop_vid.SelectedIndex == 1) //За намаляващи вноски - Месечна вноска (Промо)
                            {
                                mesecVnoska = Vnoska_glavnica + mesecLihva;
                            }
                        }else if(_gratis == true)
                        {
                            mesecVnoska = mesecLihva;
                        }
                    }
                    else
                    {
                        mesecLihva = Ostat_glavnica * interestRate / 12; //Месечна лихва
                        if (_gratis == false)
                        {
                            if (drop_vid.SelectedIndex == 0) //За анюитетни вноски - Месечна вноска
                            {
                                mesecVnoska = MesechnaVnoska(interestRate, Months - i, Ostat_glavnica);
                            }

                            if (drop_vid.SelectedIndex == 1) //За намаляващи вноски - Месечна вноска
                            {
                                mesecVnoska = Vnoska_glavnica + mesecLihva;
                            }
                        }else if(_gratis == true) //Ако е в гратисен период се плаща само лихвата
                        {
                            mesecVnoska = mesecLihva;
                        }
                    }
                    if (drop_vid.SelectedIndex == 0) //За анюитетни вноски - Вноска главница
                    {
                        Vnoska_glavnica = mesecVnoska - mesecLihva;
                    }

                    //Вноски
                    vnoski += (decimal)mesecVnoska;

                    //Лихви
                    lihvi += (decimal)mesecLihva;

                    //Пресмятане на месечните такси
                    if (!String.IsNullOrWhiteSpace(input13.Text))
                    {
                        if (drop13.SelectedIndex == 0) // Управление
                        {
                            taksi = taksi + (decimal)(Ostat_glavnica * monthFee_upr);
                        }
                        else
                        {
                            taksi = taksi + (decimal)monthFee_upr;
                        }
                    }
                    if (!String.IsNullOrWhiteSpace(input14.Text))
                    {
                        if (drop14.SelectedIndex == 1) // Други
                        {
                            taksi = taksi + (decimal)(Ostat_glavnica * monthFee_drug);
                        }
                        else
                        {
                            taksi = taksi + (decimal)monthFee_drug;
                        }
                    }
                    //Пресмятане на годишните такси
                    if (i % 12 == 0 && i != 0)
                    {
                        if (!String.IsNullOrWhiteSpace(input11.Text)) // Управление
                        {
                            if (drop11.SelectedIndex == 0)
                            {
                                taksi = taksi + (decimal)Ostat_glavnica * (decimal)yearFee_upr;
                            }
                            else
                            {
                                taksi = taksi + (decimal)yearFee_upr;
                            }
                        }
                        if (!String.IsNullOrWhiteSpace(input12.Text)) // Други
                        {
                            if (drop12.SelectedIndex == 1)
                            {
                                taksi = taksi + (decimal)Ostat_glavnica * (decimal)yearFee_drug;
                            }
                            else
                            {
                                taksi = taksi + (decimal)yearFee_drug;
                            }
                        }
                    }

                    //Погасени
                    pogaseni = vnoski + taksi;
                }

                //ГПР
                GPR = ((decimal)Math.Pow((interestRate / 12) + 1.0, 12) - 1) * 100;

                // Закръгляне на числата
                taksi = Decimal.Round(taksi, 2);
                vnoski = Decimal.Round(vnoski, 2);
                pogaseni = Decimal.Round(pogaseni, 2);
                GPR = Decimal.Round(GPR, 4);
                lihvi = Decimal.Round(lihvi, 2);

                //Таблица
                ScriptManager.RegisterStartupScript(this, GetType(), "showCreditResult", "showCreditResult()", true);
            }
        }
        protected double MesechnaVnoska(double interest, int months, double credit)
        {
            double b = Math.Pow((interest / 12) + 1.0, -months);
            double monthlyPayments = credit * (interest / 12) / (1 - b);
            return monthlyPayments;
        }
    }
}

