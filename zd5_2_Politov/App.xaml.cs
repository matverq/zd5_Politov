using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using zd5_2_Politov.Services;
using zd5_2_Politov.Views;

namespace zd5_2_Politov
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            DependencyService.Register<MockDataStore>();
            MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
