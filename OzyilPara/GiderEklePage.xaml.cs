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
            // Tutar textbox'ýndan decimal deðeri almaya çalýþ
            if (decimal.TryParse(TutarEntry.Text, out decimal tutar))
            {
                var aciklama = AciklamaEntry.Text ?? string.Empty;
                var gider = new GiderBilgisi
                {
                    Tutar = tutar,
                    Aciklama = aciklama,
                    Tarih = DateTime.Now
                };

                // Olayý tetikle ve ana sayfaya geri dön
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
