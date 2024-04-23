using System;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace пз_17._1
{
    public partial class Form1 : Form
    {
        private Timer timer;
        private HttpClient httpClient;
        private Random random;

        public Form1()
        {
            InitializeComponent();
            httpClient = new HttpClient();
            random = new Random();
            timer = new Timer();
            timer.Enabled = true;
            timer.Interval = 5000; // інтервал у мілісекундах (60 секунд)
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private async void Timer_Tick(object sender, EventArgs e)
        {
            string quote = await GetRandomAnimeQuote();
            if (quote != null)
            {
                textBox1.Text = (quote + Environment.NewLine);
            }
            else
            {
                textBox1.Text = ("Failed to fetch data from API" + Environment.NewLine);
            }
        }

        private async Task<string> GetRandomAnimeQuote()
        {
            string apiUrl = "https://animechan.xyz/api/random";
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    dynamic quoteData = JObject.Parse(responseBody);
                    return $"{quoteData.quote} - {quoteData.character} ({quoteData.anime})";
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                return null;
            }
        }
    }
}
