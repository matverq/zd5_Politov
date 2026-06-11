using System;
using System.Collections.Generic;
using Xamarin.Forms;
using zad4_Politov.ViewModels;
using zad4_Politov.Views;

namespace zad4_Politov
{
    public partial class AppShell :Xamarin.Forms.Shell
    {
        public AppShell ()
        {
            InitializeComponent( );
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
