using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoCa
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Master : ContentPage
	{
		public Master ()
		{
			InitializeComponent ();

            buttonA.Clicked += async (sender, e) =>
            {
                await App.NavigateMasterDetail(new Lunch());
            };

            buttonB.Clicked += async (sender, e) =>
            {
                await App.NavigateMasterDetail(new B());
            };

            buttonC.Clicked += async (sender, e) =>
            {
                await App.NavigateMasterDetail(new SnackBar());
            };
        }
	}
}