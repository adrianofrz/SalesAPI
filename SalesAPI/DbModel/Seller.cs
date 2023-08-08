using System;
using System.Collections.Generic;

namespace SalesAPI.DbModel
{
    public partial class Seller
    {
        public Seller()
        {
            SalesRecord = new HashSet<SalesRecord>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Date { get; set; }
        public double BaseSalary { get; set; }
        public int DepartmentId { get; set; }

        public Department Department { get; set; }
        public ICollection<SalesRecord> SalesRecord { get; set; }
    }
}
