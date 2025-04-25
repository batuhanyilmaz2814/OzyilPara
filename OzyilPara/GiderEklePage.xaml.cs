using System;
using Microsoft.Maui.Controls;

namespace OzyilPara
{
    public partial class GiderEklePage : ContentPage
    {
        // Gelir sayfamdaki gibi, burada gider eklendi olayý
        public event EventHandler<GiderBilgisi> GiderEklendi;

        public GiderEklePage()
        {
            InitializeComponent();
        }

        
        private void OnEkleClicked(object sender, EventArgs e)
        {
            // Varsayýlan carpan deðeri
            decimal carpan = 1;

            // Kullanýcý geçerli bir deðer girdiyse, onu kullan
            if (!string.IsNullOrWhiteSpace(CarpanEntry.Text) && decimal.TryParse(CarpanEntry.Text, out decimal girilenCarpan))
            {
                carpan = girilenCarpan;
            }

            // Tutarý kontrol et
            if (decimal.TryParse(TutarEntry.Text, out decimal maliyet))
            {
                var aciklama = AciklamaEntry.Text ?? string.Empty;
                var gider = new GiderBilgisi
                {
                    Tutar = carpan * maliyet,
                    Aciklama = aciklama,
                    Tarih = DateTime.Now
                };

                GiderEklendi?.Invoke(this, gider);
                Navigation.PopAsync();
            }
            else
            {
                DisplayAlert("Hata", "Lütfen geçerli bir tutar giriniz.", "Tamam");
            }
        }

    }
}
