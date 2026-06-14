using System;
using System.Collections.Generic;
using Xamarin.Forms;
using zd5_2_Politov.ViewModels;
using zd5_2_Politov.Views;

namespace zd5_2_Politov
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
