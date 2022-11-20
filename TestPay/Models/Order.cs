﻿namespace TestPay.Models
{
    public partial class Order
    {
        public Order()
        {
            this.OrderDetails = new HashSet<OrderDetail>();
        }

        public int OrderId { get; set; }
        public int PaymentTypeId { get; set; }
        public int CustomerId { get; set; }
        public string OrderNumber { get; set; }
        public System.DateTime OrderDate { get; set; }
        public decimal FinalTotal { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
