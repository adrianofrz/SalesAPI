using System;

namespace SalesAPI.DbModel
{
    public partial class SalesRecord
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public int? SellersId { get; set; }
        public int Status { get; set; }

        public Seller Sellers { get; set; }
    }
}
