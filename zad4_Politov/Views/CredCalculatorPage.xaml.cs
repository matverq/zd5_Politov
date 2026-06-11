using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace zad4_Politov.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreditCalculatorPage :ContentPage
    {
        public CreditCalculatorPage ()
        {
            InitializeComponent( );

            PaymentTypePicker.SelectedIndex = 0;

            AmountEntry.TextChanged += OnCalculate;
            TermEntry.TextChanged += OnCalculate;
            PaymentTypePicker.SelectedIndexChanged += OnCalculate;
            RateSlider.ValueChanged += (s, e) =>
            {
                RateLabel.Text = $"{e.NewValue:F0}%";
                OnCalculate(s, e);
            };
        }

        private void OnCalculate (object sender, EventArgs e)
        {
            // Проверка суммы
            if (string.IsNullOrWhiteSpace(AmountEntry.Text) ||
                !double.TryParse(AmountEntry.Text, out double amount) || amount <= 0)
            {
                MonthlyPaymentLabel.Text = "Ежемесячный платеж: ...";
                TotalPaymentLabel.Text = "Общая сумма: ...";
                OverpaymentLabel.Text = "Переплата: ...";
                return;
            }

            // Проверка срока
            if (string.IsNullOrWhiteSpace(TermEntry.Text) ||
                !int.TryParse(TermEntry.Text, out int months) || months <= 0)
            {
                MonthlyPaymentLabel.Text = "Ежемесячный платеж: ...";
                TotalPaymentLabel.Text = "Общая сумма: ...";
                OverpaymentLabel.Text = "Переплата: ...";
                return;
            }

            double yearlyRate = RateSlider.Value;
            double monthlyRate = yearlyRate / 100 / 12;

            int selectedType = PaymentTypePicker.SelectedIndex;
            double totalPayment = 0;
            string monthlyText = "";

            if (selectedType == 0) // АННУИТЕТНЫЙ
            {
                double monthlyPayment;
                if (monthlyRate > 0)
                {
                    double pow = Math.Pow(1 + monthlyRate, months);
                    monthlyPayment = amount * monthlyRate * pow / (pow - 1);
                }
                else
                {
                    monthlyPayment = amount / months;
                }
                totalPayment = monthlyPayment * months;

                monthlyText = $"Ежемесячный платеж: {monthlyPayment:F2} ₽";
            }
            else if (selectedType == 1) // ДИФФЕРЕНЦИРОВАННЫЙ
            {
                double principalPerMonth = amount / months;
                double firstPayment = principalPerMonth + (amount * monthlyRate);
                double lastPayment = principalPerMonth + (principalPerMonth * monthlyRate);
                totalPayment = amount * (1 + monthlyRate * (months + 1) / 2);

                monthlyText = $"Ежемесячный платеж: ...";
            }
            else // ФИКСИРОВАННЫЙ
            {
                double fixedCommission = 500;
                double principalPerMonth = amount / months;
                double firstMonthInterest = amount * monthlyRate;
                double monthlyPayment = principalPerMonth + fixedCommission + firstMonthInterest;
                totalPayment = monthlyPayment * months;


                monthlyText = $"Ежемесячный платеж: ...";
            }

            double overpayment = totalPayment - amount;

            MonthlyPaymentLabel.Text = monthlyText;
            TotalPaymentLabel.Text = $"Общая сумма: {totalPayment:F2} ₽";
            OverpaymentLabel.Text = $"Переплата: {overpayment:F2} ₽";
        }
    }
    }
