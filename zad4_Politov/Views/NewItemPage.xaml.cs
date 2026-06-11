using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using zad4_Politov.Models;
using zad4_Politov.ViewModels;

namespace zad4_Politov.Views
{
    public partial class NewItemPage :ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage ()
        {
            InitializeComponent( );
            BindingContext = new NewItemViewModel( );
        }
    }
}