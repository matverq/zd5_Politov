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
    public partial class WelcomePage :ContentPage
    {
        public WelcomePage ()
        {
            InitializeComponent( );
        }

        private async void OnSignInClicked (object sender, EventArgs e)
        {
            // Проверка полей
            if (string.IsNullOrWhiteSpace(UsernameEntry.Text))
            {
                await DisplayAlert("Ошибка", "Введите имя пользователя", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(PasswordEntry.Text))
            {
                await DisplayAlert("Ошибка", "Введите пароль", "OK");
                return;
            }
            // Переход на кредитный калькулятор+курсы валют
            var tabbedPage = new TabbedPage( );
            tabbedPage.Children.Add(new CreditCalculatorPage( ) { Title = "Кредитный калькулятор" });
            tabbedPage.Children.Add(new CurrencyPage( ) { Title = "Курсы валют" });

            Application.Current.MainPage = new NavigationPage(tabbedPage);
        }

        private async void OnForgotTapped (object sender, EventArgs e)
        {
            await DisplayAlert("Напоминание", "Обратитесь к администратору", "OK");
        }
    }
}