using System.ComponentModel;
using Xamarin.Forms;
using zad4_Politov.ViewModels;

namespace zad4_Politov.Views
{
    public partial class ItemDetailPage :ContentPage
    {
        public ItemDetailPage ()
        {
            InitializeComponent( );
            BindingContext = new ItemDetailViewModel( );
        }
    }
}