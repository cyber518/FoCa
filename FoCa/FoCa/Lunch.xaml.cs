using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoCa
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Lunch : ContentPage
	{
		public Lunch ()
		{
			InitializeComponent ();

            GetRequest(label);
        }

        async static void GetRequest(Label label)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync("http://services.web.ua.pt/sas/ementas"))
                {
                    using (HttpContent content = response.Content)
                    {
                        string mycontent = await content.ReadAsStringAsync();
                        System.Diagnostics.Debug.WriteLine(mycontent);
                        string soup = getBetween(mycontent, "<item name=\"Sopa\">", "</item>");
                        string beef = getBetween(mycontent, "<item name=\"Prato normal carne\">", "</item>");
                        string fish = getBetween(mycontent, "<item name=\"Prato normal peixe\">", "</item>");
                        string diet = getBetween(mycontent, "<item name=\"Prato dieta\">", "</item>");
                        string vegetarian = getBetween(mycontent, "<item name=\"Prato vegetariano\">", "</item>");
                        string option = getBetween(mycontent, "<item name=\"Prato opção\">", "</item>");
                        string salad = getBetween(mycontent, "<item name=\"Salada\">", "</item>");
                        string extra = getBetween(mycontent, "<item name=\"Diversos\">", "</item>");
                        string desert = getBetween(mycontent, "<item name=\"Sobremesa\">", "</item>");
                        string final = soup + "\n\n" + beef + "\n\n" + fish + "\n\n" + diet + "\n\n" + vegetarian + "\n\n" + option + "\n\n" + salad + "\n\n" + extra + "\n\n" + desert;
                        System.Diagnostics.Debug.WriteLine(final);
                        label.Text = final;
                    }
                }

            }
        }

        public static string getBetween(string strSource, string strStart, string strEnd)
        {
            int Start, End;
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }
            else
            {
                return "";
            }
        }
    }
}