using System;

namespace CodeQuotes
{
    public partial class MainPage : ContentPage
    {
        List<string> quotes = new List<string>();
        Random random = new Random();

        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await LoadMauiAsset();
            lblQuote.Text = quotes[random.Next(0, quotes.Count)];
        }

        async Task LoadMauiAsset()
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync("quotes.txt");
            using var reader = new StreamReader(stream);

            while (reader.Peek() >= 0)
            {
                if (reader.ReadLine() is string line)
                {
                    quotes.Add(line);
                }
            }
        }

        private void btnGenerateQuote_Clicked(object sender, EventArgs e)
        {
            var startColor = Color.FromRgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));
            var endColor = Color.FromRgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));
            var gradientStops = new GradientStopCollection
            {
                new GradientStop { Color = startColor, Offset = 0 },
                new GradientStop { Color = endColor, Offset = 1 }
            };
            GradientBackground.GradientStops = gradientStops;
            lblQuote.Text = quotes[random.Next(0, quotes.Count)];
        }
    }
}