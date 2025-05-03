using System.Collections.Generic; //List için

namespace OzyilPara;

public partial class MainPage : ContentPage
{
    private decimal totalIncome = 0;
    private decimal totalExpense = 0;

    //Eklenen her veriyi tutacak liste:

    private readonly List<Transaction> transactions = new List<Transaction>();
    public MainPage()
    {
        InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, true);
        UpdateBalance();
        

    }

    private async void OnAddIncomeClicked(object sender, EventArgs e)
    {
        var gelirSayfasi = new GelirEklePage();
        gelirSayfasi.GelirEklendi += (s, gelir) =>
        {
            // 1) Toplam gelire ekle
            totalIncome += gelir.Tutar;

            // 2) Balance ekranını güncelle
            UpdateBalance();

            // 3) Listeye bir Transaction olarak kaydet
            transactions.Add(new Transaction
            {
                Type = TransactionType.Income,
                Tutar = gelir.Tutar,
                Aciklama = gelir.Aciklama,
                Tarih = gelir.Tarih
            });
        };

        await Navigation.PushAsync(gelirSayfasi);
    }



    private async void OnAddExpenseClicked(object sender, EventArgs e)
    {
        var giderSayfasi = new GiderEklePage();
        giderSayfasi.GiderEklendi += (s, gider) =>
        {
            // 1) Toplam gideri güncelle
            totalExpense += gider.Tutar;

            // 2) Balance ekranını güncelle
            UpdateBalance();

            // 3) Listeye kaydet
            transactions.Add(new Transaction
            {
                Type = TransactionType.Expense,
                Tutar = gider.Tutar,
                Aciklama = gider.Aciklama,
                Tarih = gider.Tarih
            });
        };

        await Navigation.PushAsync(giderSayfasi);
    }

    private async void OnHistoryClicked(object sender, EventArgs e)
    {
        // transactions listesini constructor'a geçiriyoruz
        var historyPage = new TransactionHistoryPage(transactions);
        await Navigation.PushAsync(historyPage);
    }

    private async void OnLinkButtonClicked(object sender, EventArgs e)
    {
        var url = "https://www.youtube.com/@ozyilyapimcilik";
        await Launcher.Default.OpenAsync(url);
    }

    private void UpdateBalance()
    {
        IncomeLabel.Text = $"₺{totalIncome}";
        ExpenseLabel.Text = $"₺{totalExpense}";
        var balance = totalIncome - totalExpense;
        BalanceLabel.Text = $"₺{balance}";
    }
}

