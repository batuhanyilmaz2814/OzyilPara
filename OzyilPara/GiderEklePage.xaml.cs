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
            // Tutar textbox'�ndan decimal de�eri almaya �al��
            if (decimal.TryParse(TutarEntry.Text, out decimal tutar))
            {
                var aciklama = AciklamaEntry.Text ?? string.Empty;
                var gider = new GiderBilgisi
                {
                    Tutar = tutar,
                    Aciklama = aciklama,
                    Tarih = DateTime.Now
                };

                // Olay� tetikle ve ana sayfaya geri d�n
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
