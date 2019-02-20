﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinanceCalculator
{
    public partial class CreditCalculator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public double GPR,vnoski,lihvi,taksi,pogaseni = 0.0;

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
            double creditAmount = 0.0, interestRate = 0.0, Months = 0.0; // Inputs
            double monthlyPayments = 0.0, R = 0.0;
            double fee_kandi = 0.0, fee_obrabot = 0.0, fee_drug = 0.0, yearFee_upr = 0.0, yearFee_drug = 0.0, monthFee_upr = 0.0, monthFee_drug = 0.0; // Такси
            double temp=0.0,monthTemp=0.0, temp2 = 0.0;
            //Input
            creditAmount = double.Parse(input1.Text);
            Months = double.Parse(input2.Text);
            interestRate = double.Parse(input3.Text);

            //ВНОСКИ
            interestRate = interestRate / 100.0;
            R = interestRate / 12.0;
            double a = 1.0 + R;
            double b = Math.Pow(a, Months);
            monthlyPayments = creditAmount * R * b / (b - 1.0);
            vnoski = monthlyPayments * Months;

            //ГПР


            //ЛИХВИ
            lihvi = vnoski - creditAmount;

            //ТАКСИ
            if (!String.IsNullOrWhiteSpace(input8.Text)){
                fee_kandi = double.Parse(input8.Text);
            }

            if (!String.IsNullOrWhiteSpace(input9.Text)){
                fee_obrabot = double.Parse(input9.Text);
            }

            if (!String.IsNullOrWhiteSpace(input10.Text)){
                fee_drug = double.Parse(input10.Text);
            }

            if (!String.IsNullOrWhiteSpace(input11.Text)){
                yearFee_upr = double.Parse(input11.Text);
            }

            if (!String.IsNullOrWhiteSpace(input12.Text)){
                yearFee_drug = double.Parse(input12.Text);
            }

            if (!String.IsNullOrWhiteSpace(input13.Text)){
                monthFee_upr = double.Parse(input13.Text);
            }

            if (!String.IsNullOrWhiteSpace(input14.Text)){
                monthFee_drug = double.Parse(input14.Text);
            }
                //Ако са избрани проценти
            if (drop8.SelectedIndex == 0){
                fee_kandi = fee_kandi / 100;
                fee_kandi = creditAmount * fee_kandi;
            }
            if (drop9.SelectedIndex== 0){
                fee_obrabot = fee_obrabot / 100;
                fee_obrabot = creditAmount * fee_obrabot;
            }
            if (drop10.SelectedIndex == 0){
                fee_drug = fee_drug / 100;
                fee_drug = creditAmount * fee_drug;
            }
            if (drop11.SelectedIndex == 0){
                yearFee_upr = yearFee_upr / 100;

            }
            if (drop12.SelectedIndex == 0){
                yearFee_drug = yearFee_drug / 100;
            }
            if (drop13.SelectedIndex == 0)
            {
                monthFee_upr = monthFee_upr / 100;
                temp = creditAmount;
                for(int i = 0; i < Months; i++)
                {
                    temp2 += temp * monthFee_upr;
                    temp = temp - monthlyPayments;
                }
                monthFee_upr = temp2;
                temp = 0.0;
                temp2 = 0.0;
            }
            if (drop14.SelectedIndex == 0){
                monthFee_drug = monthFee_drug / 100;
                temp = creditAmount;
                monthTemp = temp / Months;
                for (int i = 0; i < Months; i++)
                {
                    temp2 += temp * monthFee_drug;
                    temp = temp - monthTemp;
                }
                monthFee_drug = temp2;
                temp = 0.0;
                monthTemp = 0.0;
                temp2 = 0.0;
            }

            taksi = fee_kandi + fee_drug + fee_obrabot + monthFee_upr + monthFee_drug + yearFee_upr + yearFee_drug;

            //ПОГАСЕНИ
            pogaseni = vnoski + taksi;

            ScriptManager.RegisterStartupScript(this, GetType(), "showCreditResult", "showCreditResult()", true);
            //Първи ред ----- ГОДИШЕН ПРОЦЕНТЕН РАЗХОД
            //Втори ред ----- ПОГАСЕНИ С ЛИХВИ И ТАКСИ
            //Трети ред ----- ТАКСИ И КОМИСИОННИ
            //Четвърти ред -- ЛИХВИ
            //Пети ред ------ ВНОСКИ
        }
    }
}
