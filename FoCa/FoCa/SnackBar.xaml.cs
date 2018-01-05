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
	public partial class SnackBar : ContentPage
	{
        public SnackBar()
        {
            InitializeComponent();

            Task<string> content = GetRequest(label);


        }

        async static Task<string> GetRequest(Label label)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync("http://services.web.ua.pt/sas/ementas"))
                {
                    using (HttpContent content = response.Content)
                    {
                        string mycontent = await content.ReadAsStringAsync();
                        System.Diagnostics.Debug.WriteLine(mycontent);
                        string snack = getBetween(mycontent, "<menu canteen=\"Snack - Bar", "</result>");
                        System.Diagnostics.Debug.WriteLine("********** "+snack);
                        string soup = getBetween(snack, "<item name=\"Sopa\">", "</item>");
                        string beef = getBetween(snack, "<item name=\"Prato normal carne\">", "</item>");
                        string fish = getBetween(snack, "<item name=\"Prato normal peixe\">", "</item>");
                        string salad = getBetween(snack, "<item name=\"Salada\">", "</item>");
                        string extra = getBetween(snack, "<item name=\"Diversos\">", "</item>");
                        string desert = getBetween(snack, "<item name=\"Sobremesa\">", "</item>");
                        string final = soup + "\n\n" + beef + "\n\n" + fish + "\n\n" + salad + "\n\n" + extra + "\n\n" + desert;
                        System.Diagnostics.Debug.WriteLine(final);
                        label.Text = final;
                        return mycontent;
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