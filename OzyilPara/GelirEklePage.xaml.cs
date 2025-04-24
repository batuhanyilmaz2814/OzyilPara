namespace OzyilPara;

public partial class GelirEklePage : ContentPage
{
    public event EventHandler<GelirBilgisi> GelirEklendi;

    public GelirEklePage()
    {
        InitializeComponent();
    }

    private void OnEkleClicked(object sender, EventArgs e)
    {
        if (decimal.TryParse(TutarEntry.Text, out decimal tutar))
        {
            var aciklama = AciklamaEntry.Text ?? "";
            var gelir = new GelirBilgisi
            {
                Tutar = tutar,
                Aciklama = aciklama,
                Tarih = DateTime.Now
            };

            GelirEklendi?.Invoke(this, gelir);
            Navigation.PopAsync(); // geri d�n
        }
        else
        {
            DisplayAlert("Hata", "Ge�erli bir tutar giriniz.", "Tamam");
        }
    }
}
