using System;
using System.Globalization;
using System.Web.UI;
using System.Web.Script.Serialization;
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
        public string _GPR, _vnoski, _lihvi, _taksi, _pogaseni;
        public int Months = 0;
        public decimal[,] array;

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
            decimal GPR = 0, vnoski = 0, lihvi = 0, taksi = 0, pogaseni = 0;

            double creditAmount = 0.0, interestRate = 0.0, promoInterest = 0.0;
            int promoMonths = 0,gratis = 0;
            decimal years = 0.0m;
            decimal mesecLihva = 0.0m, mesecVnoska = 0.0m, potok = 0.0m, Vnoska_glavnica = 0.0m, Ostat_glavnica = 0.0m, mesecTaksi = 0.0m;
            decimal fee_kandi = 0.0m, fee_obrabot = 0.0m, fee_drug = 0.0m, yearFee_upr = 0.0m, yearFee_drug = 0.0m, monthFee_upr = 0.0m, monthFee_drug = 0.0m; // Такси
            bool _error = false, promo = false, _gratis = false;

            //ВНОСКИ - Input/проверка/сметки
            //Input
            creditAmount = double.Parse(input1.Text);
            Months = int.Parse(input2.Text);
            interestRate = double.Parse(input3.Text, CultureInfo.InvariantCulture);

            //Проверка
            if (creditAmount < 100 || creditAmount > 100000000) //ГРЕШКА - Ако кредита е по-малък от 100лв
            {
                _error = true;
                error1.Text = "Моля въведете размер на кредита по - голям от 100";
            }
            if (Months <= 0 || Months > 960)//ГРЕШКА - Ако месеците са по-малко от 0 и по-големи от 960
            {
                _error = true;
                error2.Text = "Моля въведете коректно число за срок (до 960 месеца)";
            }
            if (interestRate < 0 || interestRate > 1000000)//ГРЕШКА - Ако лихвата е под 0
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
                promoInterest = int.Parse(input6.Text, CultureInfo.InvariantCulture);
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
                fee_kandi = decimal.Parse(input8.Text, CultureInfo.InvariantCulture);
                if (fee_kandi < 0 || fee_kandi >= (decimal)creditAmount) //ГРЕШКА - Ако такса кандидатстване е по-малка от 0 или е по-голяма или равна на кредита
                {
                    _error = true;
                    error8.Text = "Моля въведете коректно число за такса кандидатстване";
                }
                if (drop8.SelectedIndex == 1) //Ако е в проценти
                {
                    fee_kandi = fee_kandi / 100;
                    taksi = taksi + ((decimal)creditAmount * fee_kandi);
                }
                else
                {
                    taksi += fee_kandi;
                }
            }

            if (!String.IsNullOrWhiteSpace(input9.Text)) //ТАКСА ОБРАБОТКА - Процент от целия кредит / Единична фиксирана сума
            {
                fee_obrabot = decimal.Parse(input9.Text, CultureInfo.InvariantCulture);
                if (fee_obrabot < 0 || fee_obrabot >= (decimal)creditAmount) //ГРЕШКА - Ако такса обработка е по-малка от 0 или е по-голяма или равна на кредита
                {
                    _error = true;
                    error9.Text = "Моля въведете коректно число за такса обработване";
                }
                if (drop9.SelectedIndex == 0) //Ако е в проценти
                {
                    fee_obrabot = fee_obrabot / 100;
                    taksi = taksi + ((decimal)creditAmount * fee_obrabot);
                }
                else
                {
                    taksi += fee_obrabot;
                }
            }

            if (!String.IsNullOrWhiteSpace(input10.Text)) //ДРУГИ ТАКСИ - Процент от целия кредит / Единична фиксирана сума
            {
                fee_drug = decimal.Parse(input10.Text, CultureInfo.InvariantCulture);
                if (fee_drug < 0 || fee_drug >= (decimal)creditAmount) //ГРЕШКА - Ако друга такса е по-малка от 0 или е по-голяма или равна на кредита
                {
                    _error = true;
                    error10.Text = "Моля въведете коректно число за други такси";
                }
                if (drop10.SelectedIndex == 1) //Ако е в проценти
                {
                    fee_drug = fee_drug / 100;
                    taksi = taksi + ((decimal)creditAmount * fee_drug);
                }
                else
                {
                    taksi += fee_drug;
                }
            }

            if (!String.IsNullOrWhiteSpace(input11.Text) && years >= 1) //ГОДИШНА ТАКСА УПРАВЛЕНИЕ - Процент от вносната главница на първия месец на следващата година / фиксирана сума 
            {
                yearFee_upr = decimal.Parse(input11.Text, CultureInfo.InvariantCulture);
                if (yearFee_upr < 0 || yearFee_upr >= (decimal)creditAmount) //ГРЕШКА - Ако годишна такса управление е по-малка от 0 или е по-голяма или равна на кредита
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
                yearFee_drug = decimal.Parse(input12.Text, CultureInfo.InvariantCulture);
                if (yearFee_drug < 0 || yearFee_drug >= (decimal)creditAmount) //ГРЕШКА - Ако друга годишна такса е по-малка от 0 или е по-голяма или равна на кредита
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
                monthFee_upr = decimal.Parse(input13.Text, CultureInfo.InvariantCulture);
                if (monthFee_upr < 0 || monthFee_upr >= (decimal)creditAmount) //ГРЕШКА - Ако месечна такса обработка е по-малка от 0 или е по-голяма или равна на кредита
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
                monthFee_drug = decimal.Parse(input14.Text, CultureInfo.InvariantCulture);
                if (monthFee_drug < 0 || monthFee_drug >= (decimal)creditAmount) //ГРЕШКА - Ако друга месечна такса е по-малка от 0 или е по-голяма или равна на кредита
                {
                    _error = true;
                    error14.Text = "Моля въведете коректно число за месечна такса";
                }
                if (drop14.SelectedIndex == 1) //Ако е в проценти
                {
                    monthFee_drug = monthFee_drug / 100;
                }
            }

            //МАСИВ С ДАННИТЕ ЗА ВСЕКИ МЕСЕЦ
            array = new decimal[Months + 1, 7];

            // Колона 0 = Номер
            // Колона 1 = Месечна вноска
            // Колона 2 = Вноска главница
            // Колона 3 = Вноска лихва
            // Колона 4 = Остатък главница
            // Колона 5 = Такси и комисионни
            // Колона 6 = Паричен поток

            if (_error == false) //СМЕТКИ
            {
                interestRate = interestRate / 100; //Превръщане на лихвата в проценти
                if (promo == true)
                {
                    promoInterest = promoInterest / 100; //Превръщане на лихвата в проценти
                }

                Ostat_glavnica = (decimal)creditAmount;
                FillArr(0, 0, 0, 0, Ostat_glavnica, taksi, (decimal)creditAmount - taksi); //Месец 0 - Плащат се само първоначалните такси

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
                        Vnoska_glavnica = (decimal)creditAmount / (Months - gratis);
                    }

                    if (i < promoMonths && promo == true)
                    {
                        mesecLihva = Ostat_glavnica * (decimal)promoInterest / 12; //Месечна лихва (Промо)
                        if (_gratis == false)
                        {
                            if (drop_vid.SelectedIndex == 0) //За анюитетни вноски - Месечна вноска (Промо)
                            {
                                mesecVnoska = (decimal)Microsoft.VisualBasic.Financial.Pmt(promoInterest / 12, Months - i, (double)-Ostat_glavnica);
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
                        mesecLihva = Ostat_glavnica * (decimal)interestRate / 12; //Месечна лихва
                        if (_gratis == false)
                        {
                            if (drop_vid.SelectedIndex == 0) //За анюитетни вноски - Месечна вноска
                            {
                                mesecVnoska = (decimal)Microsoft.VisualBasic.Financial.Pmt(interestRate / 12, Months - i, (double)-Ostat_glavnica);
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
                    vnoski += mesecVnoska;

                    //Лихви
                    lihvi += mesecLihva;

                    //Пресмятане на месечните такси
                    mesecTaksi = 0.0m;
                    if (!String.IsNullOrWhiteSpace(input13.Text))
                    {
                        if (drop13.SelectedIndex == 0) // Управление
                        {
                            mesecTaksi += (Ostat_glavnica * monthFee_upr);
                        }
                        else
                        {

                            mesecTaksi += monthFee_upr;
                        }
                    }
                    if (!String.IsNullOrWhiteSpace(input14.Text))
                    {
                        if (drop14.SelectedIndex == 1) // Други
                        {
                            mesecTaksi += (Ostat_glavnica * monthFee_drug);
                        }
                        else
                        {
                            mesecTaksi += monthFee_drug;
                        }
                    }
                    //Пресмятане на годишните такси
                    if (i % 12 == 0 && i != 0)
                    {
                        if (!String.IsNullOrWhiteSpace(input11.Text)) // Управление
                        {
                            if (drop11.SelectedIndex == 0)
                            {
                                mesecTaksi += Ostat_glavnica * yearFee_upr;
                            }
                            else
                            {
                                mesecTaksi += yearFee_upr;
                            }
                        }
                        if (!String.IsNullOrWhiteSpace(input12.Text)) // Други
                        {
                            if (drop12.SelectedIndex == 1)
                            {
                                mesecTaksi += Ostat_glavnica * yearFee_drug;
                            }
                            else
                            {
                                mesecTaksi += yearFee_drug;
                            }
                        }
                    }
                    taksi += mesecTaksi;

                    //Паричен поток
                    potok = -(mesecTaksi + mesecVnoska);

                    //МАСИВ С ДАННИТЕ ЗА ВСЕКИ МЕСЕЦ
                    FillArr(i+1, mesecVnoska,Vnoska_glavnica,mesecLihva,Ostat_glavnica,mesecTaksi,potok);

                }

                //Погасени
                pogaseni = vnoski + taksi;

                //ГПР
                GPR = ((decimal)Math.Pow((interestRate / 12) + 1.0, 12) - 1);

                // Закръгляне на числата
                taksi = Decimal.Round(taksi, 2, MidpointRounding.AwayFromZero);
                vnoski = Decimal.Round(vnoski, 2, MidpointRounding.AwayFromZero);
                pogaseni = Decimal.Round(pogaseni, 2, MidpointRounding.AwayFromZero);
                GPR = Decimal.Round(GPR, 4, MidpointRounding.AwayFromZero);
                lihvi = Decimal.Round(lihvi, 2, MidpointRounding.AwayFromZero);

                //Превръщане в String с форматиране

                _taksi = taksi.ToString("C");
                _vnoski = vnoski.ToString("C");
                _pogaseni = pogaseni.ToString("C");
                _GPR = GPR.ToString("P");
                _lihvi = lihvi.ToString("C");


                //Таблица
                ScriptManager.RegisterStartupScript(this, GetType(), "showCreditResult", "showCreditResult()", true);
            }
        }
        /* Заменено с Microsoft.VisualBasic.Financial.Pmt
         *
        protected decimal MesechnaVnoska(double interest, int months, decimal credit)
        {
            decimal b = (decimal)Math.Pow((interest / 12) + 1.0, -months);
            decimal monthlyPayments = credit * ((decimal)interest / 12) / (1 - b);
            return monthlyPayments;
        }
        */
        protected void FillArr(int num,decimal mesecVnoska, decimal vnoskaGlavnica, decimal vnoskaLihva, decimal ostatukGlavnica, decimal taksi, decimal potok)
        {
            array[num, 0] = num;
            array[num, 1] = Decimal.Round(mesecVnoska,2, MidpointRounding.AwayFromZero);
            array[num, 2] = Decimal.Round(vnoskaGlavnica,2, MidpointRounding.AwayFromZero);
            array[num, 3] = Decimal.Round(vnoskaLihva,2, MidpointRounding.AwayFromZero);
            array[num, 4] = Decimal.Round(ostatukGlavnica,2, MidpointRounding.AwayFromZero);
            array[num, 5] = Decimal.Round(taksi,2, MidpointRounding.AwayFromZero);
            array[num, 6] = Decimal.Round(potok,2, MidpointRounding.AwayFromZero);
        }
    }
}

