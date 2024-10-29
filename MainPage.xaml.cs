using System.Net;
using System.Text.Json;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;

namespace kantorwymianywalutzlodzieje
{

    public class Currency
    {
        public string? table { get; set; }
        public string? currency { get; set; }
        public string? code { get; set; }
        public IList<Rate> rates { get; set; }
    }
    public class Rate
    {
        public string? no { get; set; }
        public string? effectiveDate { get; set; }
        public double? bid { get; set; }
        public double? ask { get; set; }
    }



    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();
            DateTime dzis = DateTime.Now;
            dpData.MaximumDate = dzis;
        }
        private void OnCounterClicked1(object sender, EventArgs e)
        {
            string data = dpData.Date.ToString("yyyy-MM-dd");

            string url1 = "https://api.nbp.pl/api/exchangerates/rates/c/" + "usd" + "/" + $"{data}" + "/?format=json";

            string json1;

            using (var webClient = new WebClient())
            {

                json1 = webClient.DownloadString(url1);



            }

            Currency c = JsonSerializer.Deserialize<Currency>(json1);


            string s1 = $"nazwa waluty: {c.currency}\n";
            s1 += $"Kod waluty: {c.code}\n";
            s1 += $"Data: {c.rates[0].effectiveDate}\n";

            s1 += $"Cena skupu: {c.rates[0].bid}\n";
            s1 += $"Cena sprzedaży: {c.rates[0].ask}\n";



            lblJSON.Text = s1;




        }
        private void OnCounterClicked(object sender, EventArgs e)
        {
            string data = dpData.Date.ToString("yyyy-MM-dd");

            string url = "https://api.nbp.pl/api/exchangerates/rates/c/" + "eur" + "/" + $"{data}" + "/?format=json";

            string json;
       
            using (var webClient = new WebClient())
            {

                json = webClient.DownloadString(url);
             


            }

            Currency c = JsonSerializer.Deserialize<Currency>(json);


            string s = $"nazwa waluty: {c.currency}\n";
            s += $"Kod waluty: {c.code}\n";
            s += $"Data: {c.rates[0].effectiveDate}\n";

            s += $"Cena skupu: {c.rates[0].bid}\n";
            s += $"Cena sprzedaży: {c.rates[0].ask}\n";



            lblJSON.Text = s;




        }
    }

}