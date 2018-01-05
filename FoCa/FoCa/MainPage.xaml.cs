using Xamarin.Forms;

namespace FoCa
{
	public partial class MainPage : MasterDetailPage
	{
		public MainPage()
		{
			InitializeComponent();
            this.Master = new Master();
            this.Detail = new NavigationPage(new Detail());
            App.MasterDetail = this;
		}
	}
}
