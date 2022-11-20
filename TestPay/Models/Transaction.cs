namespace TestPay.Models
{
    public partial class Transaction
    {
        public int TransactionId { get; set; }
        public int ItemId { get; set; }
        public decimal Quantity { get; set; }
        public System.DateTime TranactionDate { get; set; }
        public int TypeId { get; set; }
    }
}
