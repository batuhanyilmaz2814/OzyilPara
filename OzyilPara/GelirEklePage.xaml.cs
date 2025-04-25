namespace OzyilPara;

public partial class GelirEklePage : ContentPage
{
    public event EventHandler<GelirBilgisi> GelirEklendi;

    public GelirEklePage()
    {
        InitializeComponent();
    }

    int varsayilan_deger = 1;
    private void OnEkleClicked(object sender, EventArgs e)
    {

        if (CarpanEntry.Text == "") { 
        
            CarpanEntry.Text = varsayilan_deger.ToString();
            CarpanEntry.Focus();}  
        
        if(decimal.TryParse(CarpanEntry.Text, out decimal carpan))
        { 
            if (decimal.TryParse(TutarEntry.Text, out decimal tutar))
            {
                var aciklama = AciklamaEntry.Text ?? "";
                var gelir = new GelirBilgisi
                {
                    Tutar = carpan * tutar,
                    Aciklama = aciklama,
                    Tarih = DateTime.Now
                };

                GelirEklendi?.Invoke(this, gelir);
                Navigation.PopAsync(); // geri dön
            }
            else
            {
                DisplayAlert("Hata", "Geçerli bir tutar giriniz.", "Tamam");
            }
        }
        else
        {
            DisplayAlert("Hata", "Geçerli bir çarpan giriniz.", "Tamam");
        }
    }
}
