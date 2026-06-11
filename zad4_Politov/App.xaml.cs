using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using zad4_Politov.Services;
using zad4_Politov.Views;

namespace zad4_Politov
{
    public partial class App :Application
    {

        public App ()
        {
            InitializeComponent( );

            var tabbedPage = new TabbedPage( );
            tabbedPage.Children.Add(new Views.CreditCalculatorPage() { Title = "Кредитный калькулятор"});
             tabbedPage.Children.Add(new Views.CurrencyPage() { Title = "Курсы валют"});

            MainPage = new NavigationPage(new Views.WelcomePage( ));
        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}
