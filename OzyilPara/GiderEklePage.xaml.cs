using System;
using Microsoft.Maui.Controls;

namespace OzyilPara
{
    public partial class GiderEklePage : ContentPage
    {
        // Gelir sayfamdaki gibi, burada gider eklendi olay�
        public event EventHandler<GiderBilgisi> GiderEklendi;

        public GiderEklePage()
        {
            InitializeComponent();
        }

        
        private void OnEkleClicked(object sender, EventArgs e)
        {
            // Varsay�lan carpan de�eri
            decimal carpan = 1;

            // Kullan�c� ge�erli bir de�er girdiyse, onu kullan
            if (!string.IsNullOrWhiteSpace(CarpanEntry.Text) && decimal.TryParse(CarpanEntry.Text, out decimal girilenCarpan))
            {
                carpan = girilenCarpan;
            }

            // Tutar� kontrol et
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
                DisplayAlert("Hata", "L�tfen ge�erli bir tutar giriniz.", "Tamam");
            }
        }

    }
}
