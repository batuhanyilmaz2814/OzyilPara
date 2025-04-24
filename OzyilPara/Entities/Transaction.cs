using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzyilPara
{

    public enum TransactionType
    {
        Income,
        Expense
    }
    public class Transaction
    {
        public TransactionType Type { get; set; }
        public decimal Tutar { get; set; }
        public string Aciklama { get; set; }
        public DateTime Tarih { get; set; }
    }
}
