using System.ComponentModel;
using Xamarin.Forms;
using zd5_2_Politov.ViewModels;

namespace zd5_2_Politov.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}