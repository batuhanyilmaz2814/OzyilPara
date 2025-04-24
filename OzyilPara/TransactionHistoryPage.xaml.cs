using System.Collections.Generic;
using Microsoft.Maui.Controls;

namespace OzyilPara
{
    public partial class TransactionHistoryPage : ContentPage
    {
        public TransactionHistoryPage(List<Transaction> transactions)
        {
            InitializeComponent();
            TransactionsView.ItemsSource = transactions;
        }
    }
}
