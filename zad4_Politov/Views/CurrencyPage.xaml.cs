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
    public partial class CurrencyPage :ContentPage
    {
        public CurrencyPage ()
        {
            InitializeComponent( );
            DatePicker.Date = DateTime.Today;
            LoadRates( );
        }

        private void OnDateSelected (object sender, DateChangedEventArgs e)
        {
            if (e.NewDate > DateTime.Today)
            {
                DisplayAlert("Ошибка", "Нельзя выбрать будущую дату", "OK");
                DatePicker.Date = DateTime.Today;
                return;
            }
            LoadRates( );
        }

        private void LoadRates ()
        {
            var random = new Random(DatePicker.Date.DayOfYear);
            UsdRateLabel.Text = $"{72 + random.NextDouble( ) * 10:F2} ₽";
            EurRateLabel.Text = $"{83 + random.NextDouble( ) * 12:F2} ₽";
        }
    }
}